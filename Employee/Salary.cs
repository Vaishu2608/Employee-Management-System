using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Schema;

namespace Employee
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        private readonly string connectionstring = File.ReadAllText("Conn.txt");
        private void fetchEmpData()
        {  if (EmpId.Text == "")
            {
                MessageBox.Show("Enter Employee Id");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionstring);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mode", "Search");
                    cmd.Parameters.AddWithValue("EmpId", EmpId.Text);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                    DataTable Dt = new DataTable();
                    dataAdapter.Fill(Dt);

                    foreach (DataRow dr in Dt.Rows)
                    {
                        EmpId.Text = dr["EmpId"].ToString();
                        EmpName.Text = dr["EmpName"].ToString();

                        ComBoposition.Text = dr["EmpPos"].ToString();



                    }
                    cmd.ExecuteNonQuery();

                    connection.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fetchEmpData();
        }
        int DailyBase,Total;

        private void button3_Click(object sender, EventArgs e)
        {

            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("********* SALARY SUMMARY********", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180));
            e.Graphics.DrawString("Employee Id:  " + EmpId.Text + "\t Employee Name: " + EmpName.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 100));
           
            e.Graphics.DrawString("Employee Position:  " + ComBoposition.Text + "\t Employee Working Days: " + EmpWork.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 160));

            e.Graphics.DrawString("Employee Daily Pay:  " + DailyBase + "\t Employee Total Salary: " + Total, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 200));
            e.Graphics.DrawString("********* EMPLOYEE DETAILS********", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(20,260));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(ComBoposition==null)
            {
                MessageBox.Show("Select An Employee");

            }
            else if(EmpWork.Text==""||Convert.ToInt32(EmpWork.Text)>28) 
            
            {
                MessageBox.Show("Enter A valid Number of Days");
            }
            else
            {
                if (ComBoposition.Text == "Manager")
                {
                    DailyBase = 1000;
                }
                else if (ComBoposition.Text == "Human Resource")
                {
                    DailyBase = 950;
                }
                else if (ComBoposition.Text == "Senior Developer")
                {
                    DailyBase = 850;
                }
                else if (ComBoposition.Text == "Junior Developer")
                {
                    DailyBase = 650;
                }
                else if (ComBoposition.Text == "Accountant")
                {
                    DailyBase = 550;
                }
                else if (ComBoposition.Text == "Receptionist")
                {
                    DailyBase = 350;
                }
                else if (ComBoposition.Text == "Clerk")
                {
                    DailyBase = 250;
                }
                else 
                {
                    DailyBase = 250;
                }
            } 
            Total = DailyBase * Convert.ToInt32(EmpWork.Text);
            SalarySlip.Text = "Employee ID: "+EmpId.Text + "\n" +"Employee Name: "+
                EmpName.Text + "\n" +"Employee Position : "+ ComBoposition.Text + "\n" +"Working Days : "+EmpWork.Text + "\n"+"Daily Salary Rs. : "+DailyBase+"\n" +"Total Salary : " + Total;

        }
    }
}
