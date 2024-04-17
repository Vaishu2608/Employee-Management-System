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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Employee
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
        }
        private readonly string connectionstring = File.ReadAllText("Conn.txt");

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("AddEmployee", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();

            conn.Open();
            if (EmpId.Text == "" || Empadd.Text == " " || EmpName.Text == "" || Empadd.Text == "" || ComboEDu.Text == "")
            {
                MessageBox.Show("Missing some fields!!!");
            }
            else
            {
                try
                { cmd.Parameters.AddWithValue("@Mode", "insert");
                    cmd.Parameters.AddWithValue("EmpId", EmpId.Text);
                    cmd.Parameters.AddWithValue("EmpName", EmpName.Text);
                    cmd.Parameters.AddWithValue("EmpAdd", Empadd.Text);
                    cmd.Parameters.AddWithValue("EmpPos", ComBoposition.Text);
                    cmd.Parameters.AddWithValue("EmpDOB", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("EmpPhone", txtphone.Text);
                    cmd.Parameters.AddWithValue("EmpEducation", ComboEDu.Text);

                    cmd.Parameters.AddWithValue("User_Image", imagepath);

                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("EmpGen", radioButton1.Text);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("EmpGen", radioButton2.Text);
                    }
                    int V = cmd.ExecuteNonQuery();
                    if (V != 0)
                    {
                        MessageBox.Show("Record Created successfully");
                    }
                    conn.Close();
                    populate();
                    clearData(); ;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
        private string imagepath;
        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);
                imagepath = openFileDialog.FileName;

            }
        }
        private void clearData()
        {
            Empadd.Text = "";
            EmpId.Text = "";
            EmpName.Text = "";
            txtphone.Text = " ";
            pictureBox1.Image = null;
            ComBoposition.Text = null;
            ComboEDu.Text = null;
            radioButton1.Text = null;
            radioButton2.Text = null;
            dateTimePicker1.Text = null;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index;
            index = e.RowIndex;

            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            EmpId.Text = selectedRow.Cells[0].Value.ToString();
            EmpName.Text = selectedRow.Cells[1].Value.ToString(); // Assuming Name is in the second column (index 1)
            Empadd.Text = selectedRow.Cells[2].Value.ToString(); // Assuming PIN is in the third column (index 2)
            ComBoposition.Text = selectedRow.Cells[3].Value.ToString(); // Assuming Ac_balance is in the fourth column (index 3)
            ComboEDu.Text = selectedRow.Cells[8].Value.ToString(); // Assuming Adhar_No is in the fifth column (index 4)
            dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString(); // Assuming Address is in the sixth column (index 5)
            txtphone.Text = selectedRow.Cells[5].Value.ToString();                                                       //string sss= selectedRow.Cells[5].Value.ToString();
                                                                                                                         // Assuming the seventh column (index 6) contains the radio button value (Ac_type)
                                                                                                                         // Assuming the seventh column (index 6) contains the radio button value (EmpGen)
            if (selectedRow.Cells[6].Value.ToString() == "Male")  // Replace "Male" with the actual value of radioButton1
            {
                radioButton1.Checked = true;
            }
            else if (selectedRow.Cells[6].Value.ToString() == "Female")  // Replace "Female" with the actual value of radioButton2
            {
                radioButton2.Checked = true;
            }

            // Assuming the eighth column (index 7) contains the image path
            imagepath = selectedRow.Cells[7].Value.ToString();
            if (!string.IsNullOrEmpty(imagepath) && File.Exists(imagepath))
            {
                pictureBox1.Image = Image.FromFile(imagepath);
            }
            else
            {
                // Handle the case when the image path is not valid or empty
                pictureBox1.Image = null; // Clear the image
            }

        }

        private void populate()
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            string query = "select * from Employee";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = ds.Tables[0];
            conn.Close();



        }
        private void Employee_Load(object sender, EventArgs e)
        {

            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "")
            {
                MessageBox.Show("Enter the Employee ID ");
            } else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionstring);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mode", "Update");
                    cmd.Parameters.AddWithValue("EmpId", EmpId.Text);
                    cmd.Parameters.AddWithValue("EmpName", EmpName.Text);
                    cmd.Parameters.AddWithValue("EmpAdd", Empadd.Text);
                    cmd.Parameters.AddWithValue("EmpPos", ComBoposition.Text);
                    cmd.Parameters.AddWithValue("EmpDOB", dateTimePicker1.Text);
                    cmd.Parameters.AddWithValue("EmpPhone", txtphone.Text);
                    cmd.Parameters.AddWithValue("EmpEducation", ComboEDu.Text);

                    cmd.Parameters.AddWithValue("User_Image", imagepath);

                    if (radioButton1.Checked)
                    {
                        cmd.Parameters.AddWithValue("EmpGen", radioButton1.Text);

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("EmpGen", radioButton2.Text);
                    }
                    int V = cmd.ExecuteNonQuery();
                    if (V != 0)
                    {
                        MessageBox.Show("Record updated successfully");
                    }
                    connection.Close();
                    populate();
                    clearData(); ;


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (EmpId.Text == "")
            {
                MessageBox.Show("Enter the Employee ID ");
            }
            else
            {
                try
                {
                    SqlConnection connection = new SqlConnection(connectionstring);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("AddEmployee", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Mode", "Delete");
                     cmd.Parameters.AddWithValue("EmpId", EmpId.Text);
                      cmd.Parameters.AddWithValue("EmpName",EmpName.Text);
                   
                  

                    
                    int V = cmd.ExecuteNonQuery();
                    if (V != 0)
                    {
                        MessageBox.Show("Record Deleted successfully");
                    }
                    connection.Close();
                    populate();
                    clearData();

                } catch (Exception ex)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }

}
