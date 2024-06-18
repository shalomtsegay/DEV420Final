using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient
{
    public partial class AppointmentsForm : Form
    {

        private HospitalDataClassesDataContext dbContext = new HospitalDataClassesDataContext();


        public AppointmentsForm()
        {
            InitializeComponent();
        }
        
        
        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            // Adding an appointment
            try
            {
                if (int.TryParse(txtPatientID.Text, out int patientID))
                {
                    DateTime appointmentDateTime = dtpAppointmentDateTime.Value;
                    AppointmentTable newAppointment = new AppointmentTable
                    {
                        patientid = patientID,
                        appday = appointmentDateTime.Date,
                        apptime = appointmentDateTime.TimeOfDay
                    };

                    dbContext.AppointmentTables.InsertOnSubmit(newAppointment);
                    dbContext.SubmitChanges();

                    MessageBox.Show("Appointment successfully added!");
                    LoadAppointments();
                }
                else
                {
                    MessageBox.Show("Please enter a valid Patient ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}");
            }
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            // Updating an appointment
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                    int appointmentID = Convert.ToInt32(selectedRow.Cells["appid"].Value);
                    var appointmentToUpdate = dbContext.AppointmentTables.SingleOrDefault(a => a.appid == appointmentID);

                    if (appointmentToUpdate != null)
                    {
                        if (int.TryParse(txtPatientID.Text, out int patientID))
                        {
                            appointmentToUpdate.patientid = patientID;
                            appointmentToUpdate.appday = dtpAppointmentDateTime.Value.Date;
                            appointmentToUpdate.apptime = dtpAppointmentDateTime.Value.TimeOfDay;

                            dbContext.SubmitChanges();
                            MessageBox.Show("Appointment successfully updated!");
                            LoadAppointments();
                        }
                        else
                        {
                            MessageBox.Show("Please enter a valid Patient ID.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Appointment not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating appointment: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to update.");
            }
        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {
            // Deleting an appointment
            if (dgvAppointments.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dgvAppointments.SelectedRows[0];
                    int appointmentID = Convert.ToInt32(selectedRow.Cells["appid"].Value);
                    var appointmentToDelete = dbContext.AppointmentTables.SingleOrDefault(a => a.appid == appointmentID);
                    if (appointmentToDelete != null)
                    {
                        dbContext.AppointmentTables.DeleteOnSubmit(appointmentToDelete);
                        dbContext.SubmitChanges();
                        MessageBox.Show("Appointment successfully cancelled.");
                        LoadAppointments();
                    }
                    else
                    {
                        MessageBox.Show("Appointment not found.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cancelling appointment: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to cancel.");
            }
        }
        
        
        private void LoadAppointments()
        {
            try
            {
                var appointments = from app in dbContext.AppointmentTables
                                   select new
                                   {
                                       app.appid,
                                       app.patientid,
                                       app.appday,
                                       app.apptime
                                   };

                dgvAppointments.DataSource = appointments.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 staffForm = new Form1();
            staffForm.Show();
            this.Hide();
        }
    }
}
