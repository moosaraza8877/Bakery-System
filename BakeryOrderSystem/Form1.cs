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

namespace BakeryOrderSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtPassword.Text = "";
            checkBox1.Checked = false;
            label3.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();
            try
            {
                string query = "SELECT * FROM LoginDetails WHERE userName = '" + txtUsername.Text + "' AND userPassword = '" + txtPassword.Text + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);
                if(txtUsername.Text == "" || txtPassword.Text == "")
                {
                    MessageBox.Show("Please enter the username or password", "Error");
                }
                else
                {
                    if (dtbl.Rows.Count == 1)
                    {
                        Form2 f2 = new Form2();
                        this.Hide();
                        f2.ShowDialog();
                        this.Close();
                        txtPassword.UseSystemPasswordChar = true;
                    }
                    else
                    {
                        int count = 0;
                        MessageBox.Show("Invalid Username or Password!","Error");
                        count++;
                        if (count == 1)
                        {
                            label3.Visible = true;
                        }
                    }
                }   
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            txtUsername.Text = txtPassword.Text = "";
            Form3 f3 = new Form3();
            f3.ShowDialog();
            f3.Close();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            label3.Visible = false;
        }
    }
}
