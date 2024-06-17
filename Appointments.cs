using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient
{
    public partial class Appointments : Form
    {
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPatientID;
        private TextBox txtAppID;
        private DateTimePicker dtpAppointmentDateTime;
        private Button btnAddAppointment;
        private Button btnUpdateAppointment;
        private DataGridView dataGridViewAppointments;
        private Button btnDeleteAppointment;
        private DataClasses1DataContext db = new DataClasses1DataContext();

        public Appointments()
        {
            InitializeComponent();
            this.btnAddAppointment.Click += new System.EventHandler(this.button1_Click); 
            // Add the appointments
            this.btnDeleteAppointment.Click += new System.EventHandler(this.button2_Click); 
            // Cancel the appointments
            this.Load += new System.EventHandler(this.Appointments_Load); 
            // Load patients appointments when the form loads
        }

        private void Appointments_Load(object sender, EventArgs e)
        {
            LoadAppointments();
        }

        private void LoadAppointments()
        {
            try
            {
                var appointments = from app in db.AppointmentTables
                                   select new
                                   {
                                       app.appid,
                                       app.patientid,
                                       app.appday,
                                       app.apptime
                                   };

                dataGridViewAppointments.DataSource = appointments.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading appointments: {ex.Message}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Adding Appointments
            try
            {
                int patientID;
                if (int.TryParse(txtPatientID.Text, out patientID))
                {
                    DateTime appointmentDateTime = dtpAppointmentDateTime.Value;
                    AppointmentTable newAppointment = new AppointmentTable
                    {
                        patientid = patientID,
                        appday = appointmentDateTime.Date,
                        apptime = appointmentDateTime.TimeOfDay
                    };

                    db.AppointmentTables.InsertOnSubmit(newAppointment);
                    db.SubmitChanges();

                    // User has added appointment successfully. 
                    MessageBox.Show("Appointment Added Successfully!");
                    LoadAppointments();
                }
                else
                {
                    // user must enter valid patient id to continue
                    MessageBox.Show("To continue, enter a valid Patient ID.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Canceling Appointments
            if (dataGridViewAppointments.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow selectedRow = dataGridViewAppointments.SelectedRows[0];
                    int appID = Convert.ToInt32(selectedRow.Cells["AppID"].Value);
                    var appointmentToDelete = db.AppointmentTables.SingleOrDefault(a => a.appid == appID);
                    if (appointmentToDelete != null)
                    {
                        db.AppointmentTables.DeleteOnSubmit(appointmentToDelete);
                        db.SubmitChanges();
                        //Message when they cancel appointments. 
                        MessageBox.Show("Successfully, Cancelled Appointments!");
                        LoadAppointments();
                    }
                    else
                        //Message when they cancel appointments. 
                    {
                        MessageBox.Show("Did not find any appointments.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                        // User selects appointments to cancel 
            {
                MessageBox.Show("Select any appointment to cancel.");
            }
        }

        private void dataGridViewAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridViewAppointments.Rows[e.RowIndex];
                txtAppID.Text = selectedRow.Cells["AppID"].Value.ToString();
                txtPatientID.Text = selectedRow.Cells["PatientID"].Value.ToString();
                dtpAppointmentDateTime.Value = Convert.ToDateTime(selectedRow.Cells["AppDay"].Value).Add((TimeSpan)selectedRow.Cells["AppTime"].Value);
            }
        }

        private void btnUpdateAppointment_Click(object sender, EventArgs e)
        {
            // Update Code for Appointments
        }

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPatientID = new System.Windows.Forms.TextBox();
            this.txtAppID = new System.Windows.Forms.TextBox();
            this.dtpAppointmentDateTime = new System.Windows.Forms.DateTimePicker();
            this.btnAddAppointment = new System.Windows.Forms.Button();
            this.btnUpdateAppointment = new System.Windows.Forms.Button();
            this.dataGridViewAppointments = new System.Windows.Forms.DataGridView();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Patient ID ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "App ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Select Date ";
            // 
            // txtPatientID
            // 
            this.txtPatientID.Location = new System.Drawing.Point(149, 23);
            this.txtPatientID.Name = "txtPatientID";
            this.txtPatientID.Size = new System.Drawing.Size(411, 20);
            this.txtPatientID.TabIndex = 3;
            // 
            // txtAppID
            // 
            this.txtAppID.Location = new System.Drawing.Point(149, 55);
            this.txtAppID.Name = "txtAppID";
            this.txtAppID.Size = new System.Drawing.Size(411, 20);
            this.txtAppID.TabIndex = 4;
            // 
            // dtpAppointmentDateTime
            // 
            this.dtpAppointmentDateTime.Location = new System.Drawing.Point(149, 91);
            this.dtpAppointmentDateTime.Name = "dtpAppointmentDateTime";
            this.dtpAppointmentDateTime.Size = new System.Drawing.Size(411, 20);
            this.dtpAppointmentDateTime.TabIndex = 5;
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.Location = new System.Drawing.Point(51, 126);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(260, 23);
            this.btnAddAppointment.TabIndex = 6;
            this.btnAddAppointment.Text = "Request App";
            this.btnAddAppointment.UseVisualStyleBackColor = true;
            // 
            // btnUpdateAppointment
            // 
            this.btnUpdateAppointment.Location = new System.Drawing.Point(311, 126);
            this.btnUpdateAppointment.Name = "btnUpdateAppointment";
            this.btnUpdateAppointment.Size = new System.Drawing.Size(249, 23);
            this.btnUpdateAppointment.TabIndex = 7;
            this.btnUpdateAppointment.Text = "Update App";
            this.btnUpdateAppointment.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAppointments
            // 
            this.dataGridViewAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAppointments.Location = new System.Drawing.Point(45, 189);
            this.dataGridViewAppointments.Name = "dataGridViewAppointments";
            this.dataGridViewAppointments.Size = new System.Drawing.Size(515, 159);
            this.dataGridViewAppointments.TabIndex = 8;
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.Location = new System.Drawing.Point(45, 354);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(515, 23);
            this.btnDeleteAppointment.TabIndex = 9;
            this.btnDeleteAppointment.Text = "Cancel App";
            this.btnDeleteAppointment.UseVisualStyleBackColor = true;
            // 
            // Appointments
            // 
            this.ClientSize = new System.Drawing.Size(595, 400);
            this.Controls.Add(this.btnDeleteAppointment);
            this.Controls.Add(this.dataGridViewAppointments);
            this.Controls.Add(this.btnUpdateAppointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.dtpAppointmentDateTime);
            this.Controls.Add(this.txtAppID);
            this.Controls.Add(this.txtPatientID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Appointments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAppointments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}

