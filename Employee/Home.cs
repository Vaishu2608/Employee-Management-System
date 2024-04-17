using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
           Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
              Employee employee = new Employee();
              employee.Show();
              this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee();
            employee.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ViewEmployee employee = new ViewEmployee();
            employee.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Salary employee = new Salary();
            employee.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Salary employee = new Salary();
            employee.Show();
            this.Hide();
        }
    }
}
