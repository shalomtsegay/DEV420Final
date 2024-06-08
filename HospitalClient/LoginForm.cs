using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalClient
{
    public partial class LoginForm : Form
    {
        IMongoCollection<User> userCollection;
        public LoginForm()
        {
            InitializeComponent();

            //connect to the database using the connection string in app.config. then call the "users" collection

            var connectionString = ConfigurationManager.ConnectionStrings["DatabaseConnection"].ConnectionString;
            var databaseName = MongoUrl.Create(connectionString).DatabaseName;
            var mongoClient = new MongoClient(connectionString);
            var database = mongoClient.GetDatabase(databaseName);
            userCollection = database.GetCollection<User>("users");
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            // get username and password from textboxes
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            // find if the user exists
            var filter = Builders<User>.Filter.Eq("Username", username) &
                Builders<User>.Filter.Eq("Password", password);

            var user = userCollection.Find(filter).FirstOrDefault();

            if (user != null)
            {

                // send them to main form
                Form1 mainForm = new Form1();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                //error, Login failed
                MessageBox.Show("Invalid username or password");
            }
        }
    }
}
