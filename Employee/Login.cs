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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Employee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private readonly string connectionstring = File.ReadAllText("Conn.txt");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string AdminId;
            string Password;

            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                try
                {
                    string query = "SELECT * FROM Admin WHERE AdminId = @AdminId AND Password = @Password";
                    SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                    sda.SelectCommand.Parameters.AddWithValue("@AdminId", Uid.Text);
                    sda.SelectCommand.Parameters.AddWithValue("@Password", Pass.Text);

                    DataTable dtable = new DataTable();
                    sda.Fill(dtable);

                    if (dtable.Rows.Count > 0)
                    {
                        AdminId = Uid.Text.ToString();
                        Password = Pass.Text.ToString();

                        MessageBox.Show("You Are Logged in Successfully");
                        Home home = new Home();
                        home.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Account Details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Uid.Clear();
                        Pass.Clear();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Database Error:" + ex.ToString());
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Uid.Text = " ";
            Pass.Text = " ";
        }

        private void button3_Click(object sender, EventArgs e)
        {
             New_admin new_Admin = new New_admin();
            new_Admin.Show();

        }
    }
}
