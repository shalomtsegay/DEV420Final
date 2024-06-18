﻿using System;
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
    public partial class PatientManagementForm : Form
    {
        private HospitalContext _context;

        public PatientManagementForm()
        {
            InitializeComponent();
            _context = new HospitalContext();
        }

        private void PatientManagementForm_Load(object sender, EventArgs e)
        {
            // load patients to the datagridview on form load
            LoadPatients();
            MessageBox.Show("Patients loaded successfully.");
        }

        // load patients method. simple query to generate all needed data and set
        // it as the datagridview's datasource.
        private void LoadPatients()
        {
            var loadPatients = from patient in _context.Patients
                               select new
                               {
                                   patient.PatientId,
                                   patient.FirstName,
                                   patient.LastName,
                                   patient.DateOfBirth,
                                   patient.MedicalHistory
                               };

            dataGridViewPatients.DataSource = loadPatients.ToList();
        }

        // add button. take new inputs from textboxes etc. and create a new patient from them.
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Patient newPatient = new Patient
            {
                // add from textboxes, DOB, and History
                FirstName = textBox_FirstName.Text,
                LastName = textBox_LastName.Text,
                DateOfBirth = dateTimePickerDOB.Value,
                MedicalHistory = textBox_MedicalHistory.Text
            };

            _context.Patients.Add(newPatient);
            int changes = _context.SaveChanges();
            LoadPatients();

            // troubleshooting to make sure a change occured. 
            if (changes > 0)
            {
                MessageBox.Show("Patient added successfully.");
            }
            else
            {
                MessageBox.Show("Failed to add patient.");
            }
        }

        // update button. 1. select row of patient you want to update.  
        // 2. input new information 3. click update button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                int patientId = (int)dataGridViewPatients.SelectedRows[0].Cells[0].Value;
                var patient = _context.Patients.Find(patientId);

                if (patient != null)
                {
                    // grab new data from textboxes, DOB dateTime, and history
                    patient.FirstName = textBox_FirstName.Text;
                    patient.LastName = textBox_LastName.Text;
                    patient.DateOfBirth = dateTimePickerDOB.Value;
                    patient.MedicalHistory = textBox_MedicalHistory.Text;

                    int changes = _context.SaveChanges();
                    LoadPatients();

                    // troubleshooting to make sure a change occured.
                    if (changes > 0)
                    {
                        MessageBox.Show("Patient updated successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to update patient.");
                    }
                }
            }
        }

        //delete button. 1. select row of patient you want to delete. 2. click delete.
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (dataGridViewPatients.SelectedRows.Count > 0)
            {
                int patientId = (int)dataGridViewPatients.SelectedRows[0].Cells[0].Value;
                var patient = _context.Patients.Find(patientId);

                if (patient != null)
                {
                    _context.Patients.Remove(patient);
                    int changes = _context.SaveChanges();
                    LoadPatients();

                    // troubleshooting to make sure a change occured.
                    if (changes > 0)
                    {
                        MessageBox.Show("Patient deleted successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete patient.");
                    }
                }
            }
        }

        private void btn_Load_Click(object sender, EventArgs e)
        {
            //calls loadPatients method
            LoadPatients();
        }
        
        //back to main 
        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 staffForm = new Form1();
            staffForm.Show();
            this.Hide();
        }
    }
}