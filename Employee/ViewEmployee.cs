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

namespace Employee
{
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        private readonly string connectionstring = File.ReadAllText("Conn.txt");
        private void fetchEmpData()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionstring);
                connection.Open();
                SqlCommand cmd = new SqlCommand("AddEmployee", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Mode", "Search");
                cmd.Parameters.AddWithValue("EmpId", Emptxt.Text);
                
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataTable Dt = new DataTable();
                dataAdapter.Fill(Dt);

                foreach (DataRow dr in Dt.Rows)
                {
                    EmpId.Text = dr["EmpId"].ToString();
                    EmpName.Text = dr["EmpName"].ToString();
                    EmpAdd.Text = dr["EmpAdd"].ToString();
                    Emppos.Text = dr["EmpPos"].ToString();
                    EmpDob.Text = dr["EmpDOB"].ToString();
                    Empphone.Text = dr["EmpPhone"].ToString();
                    EmpGen.Text = dr["EmpGen"].ToString();
                    EmpEdu.Text = dr["EmpEducation"].ToString();
                    pictureBox1.ImageLocation = dr["User_Image"].ToString();
                    EmpId.Visible=true; 
                    EmpName.Visible=true; 
                    EmpAdd.Visible=true;
                    Emppos.Visible=true;
                    EmpDob.Visible = true;
                    Empphone.Visible=true;
                    EmpGen.Visible=true;

                    EmpEdu.Visible=true;
                    pictureBox1.Visible=true;
                    label10.Visible=true;
                    


                }
                cmd.ExecuteNonQuery();
               
                connection.Close();
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
                fetchEmpData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog()==DialogResult.OK)
            {
                printDocument1.Print(); 
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Emptxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmpDob_Click(object sender, EventArgs e)
        {

        }

        private void EmpGen_Click(object sender, EventArgs e)
        {

        }

        private void EmpName_Click(object sender, EventArgs e)
        {

        }

        private void EmpEdu_Click(object sender, EventArgs e)
        {

        }

        private void Emppos_Click(object sender, EventArgs e)
        {

        }

        private void EmpAdd_Click(object sender, EventArgs e)
        {

        }

        private void Empphone_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void EmpId_Click(object sender, EventArgs e)
        {

        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("********* EMPLOYEE SUMMARY********", new Font("Century Gothic", 20, FontStyle.Bold),Brushes.Red,new Point(180));
            e.Graphics.DrawString("Employee Id:  " + EmpId.Text+"\t Employee Name: "+EmpName.Text ,   new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 100));
            e.Graphics.DrawString("Employee Address:  " + EmpAdd.Text + "\t Employee Phone: " + Empphone.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 160));
            e.Graphics.DrawString("Employee Position:  " + Emppos.Text + "\t Employee Education: " + EmpEdu.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 220));
          
            e.Graphics.DrawString("Employee Gender:  " + EmpGen.Text + "\t Employee DOB: " + EmpDob.Text, new Font("Century Gothic", 18, FontStyle.Regular), Brushes.Blue, new Point(20, 260));
            e.Graphics.DrawString("********* EMPLOYEE DETAILS********", new Font("Century Gothic", 20, FontStyle.Bold), Brushes.Red, new Point(180,300));
        }
    }
}
