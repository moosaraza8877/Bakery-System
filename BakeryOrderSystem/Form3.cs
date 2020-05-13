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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }

        public void Delete()
        {
            int id = 0;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM LoginDetails";
            comm.Connection = conn;
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
            conn.Close();

            SqlConnection conn1 = new SqlConnection();
            conn1.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn1.Open();

            SqlCommand comm1 = new SqlCommand();
            comm1.CommandText = "DELETE FROM LoginDetails WHERE userID = '" + id + "'";
            comm1.Connection = conn1;
            comm1.ExecuteNonQuery();
            conn1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            try
            {
                Delete();
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "INSERT INTO LoginDetails VALUES('" + textBox1.Text + "','" + textBox3.Text + "')";
                comm.Connection = conn;
                if (textBox1.Text == "")
                {
                    errorProvider1.SetError(textBox1, "This field is Mandatory!");
                }
                else if (textBox2.Text == "")
                {
                    errorProvider1.SetError(textBox2, "This field is Mandatory!");
                }
                else if (textBox3.Text == "")
                {
                    errorProvider1.SetError(textBox3, "This field is Mandatory!");
                }
                else
                {
                    if (textBox2.Text != textBox3.Text)
                    {
                        MessageBox.Show("Passwords are different, Please same these fields");
                    }
                    else
                    {
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Username and Password is restored and changed!");
                        textBox1.Text = textBox2.Text = textBox3.Text = "";
                        this.Close();
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
                textBox2.UseSystemPasswordChar = false;
                textBox3.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox3.UseSystemPasswordChar = true;
            }
        }
    }
}
