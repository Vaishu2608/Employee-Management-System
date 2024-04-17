using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employee
{
    public partial class New_admin : Form
    {
        public New_admin()
        {
            InitializeComponent();
        }
        private readonly string connectionstring = File.ReadAllText("Conn.txt");
        private void New_admin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            SqlCommand cmd = new SqlCommand("AddAdmin", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter();

            conn.Open();
            if (Uid.Text == "" || Pass.Text == " " || Branch.Text == "" )
            {
                MessageBox.Show("Missing some fields!!!");
            }
            else
            {
                try
                {
                    
                    cmd.Parameters.AddWithValue("AdminId", Uid.Text);
                    cmd.Parameters.AddWithValue("Password", Pass.Text);
                    cmd.Parameters.AddWithValue("Branch", Branch.Text);


                    int V = cmd.ExecuteNonQuery();
                    if (V != 0)
                    {
                        MessageBox.Show("Record Created successfully");
                    }
                    conn.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
    }

