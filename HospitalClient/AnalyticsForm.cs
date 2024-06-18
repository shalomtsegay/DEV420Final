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
    public partial class AnalyticsForm : Form
    {
        private HospitalDataClassesDataContext dbContext = new HospitalDataClassesDataContext();

        public AnalyticsForm()
        {
            InitializeComponent();
        }

        // on form load, calculate statistics
        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            CalculateAverageAge();
            CalculateTotalPatients();
        }

        // average age, calculated from current year - birth year from patients on the chart
        private void CalculateAverageAge()
        {
            var averageAge = dbContext.Patients
                .Where(p => p.DateOfBirth != null)
                .Average(p => DateTime.Now.Year - p.DateOfBirth.Year);

            label_avgAge.Text = averageAge.ToString($"Average Age: {averageAge}");
        }

        // total patients derived from the patients db count
        private void CalculateTotalPatients()
        {
            var totalPatients = dbContext.Patients.Count();
            label_totalPatients.Text = totalPatients.ToString($"Total Patients: {totalPatients}");


        }

        // back to main
        private void btn_back_Click(object sender, EventArgs e)
        {
            Form1 staffForm = new Form1();
            staffForm.Show();
            this.Hide();
        }

        
    }
}
