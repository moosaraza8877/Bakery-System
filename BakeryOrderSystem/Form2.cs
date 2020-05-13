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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void rbtnSweets_CheckedChanged(object sender, EventArgs e)
        {
            rbtnSweets.ForeColor = Color.Green;
            rbtnNimko.ForeColor = Color.Red;
            rbtnBakers.ForeColor = Color.Red;
            numericUpDown1.Value = 0;
            txtPrice.Text = "";
            txtTotalPrice.Text = "";
            comboBox1.Items.Clear();
            
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Sweets";
            comm.Connection = conn;
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    comboBox1.Items.Add(name);
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

        private void rbtnNimko_CheckedChanged(object sender, EventArgs e)
        {
            rbtnNimko.ForeColor = Color.Green;
            rbtnSweets.ForeColor = Color.Red;
            rbtnBakers.ForeColor = Color.Red;
            numericUpDown1.Value = 0;
            txtPrice.Text = "";
            txtTotalPrice.Text = "";
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Nimko";
            comm.Connection = conn;
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    comboBox1.Items.Add(name);
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

        private void rbtnBakers_CheckedChanged(object sender, EventArgs e)
        {
            rbtnBakers.ForeColor = Color.Green;
            rbtnSweets.ForeColor = Color.Red;
            rbtnNimko.ForeColor = Color.Red;
            numericUpDown1.Value = 0;
            txtPrice.Text = "";
            txtTotalPrice.Text = "";
            comboBox1.Items.Clear();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM Bakers";
            comm.Connection = conn;
            try
            {
                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    comboBox1.Items.Add(name);
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

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Item(s) cannot be added to list with this quantity", "Error");
                }
                else
                {
                    string[] array = new string[4];
                    array[0] = comboBox1.SelectedItem.ToString();
                    array[1] = txtPrice.Text;
                    array[2] = numericUpDown1.Value.ToString();
                    array[3] = txtTotalPrice.Text;

                    ListViewItem lvi = new ListViewItem(array);
                    listView1.Items.Add(lvi);

                    double Cnt = 0;
                    for (int i = 0; i < listView1.Items.Count; i++)
                    {
                        Cnt = Cnt + Convert.ToDouble(listView1.Items[i].SubItems[3].Text);
                        txtNet.Text = txtPaid.Text = txtBalance.Text = "";
                    }
                    txtSubTotal.Text = Cnt.ToString();
                    txtNet.Text = txtSubTotal.Text;
                    txtPaid.ReadOnly = false;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Are you sure want to clear the page!", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    numericUpDown1.Value = 0;
                    txtPaid.ReadOnly = true;
                    listView1.SelectedItems.Clear();
                    txtPrice.Text = "";
                    txtTotalPrice.Text = "";
                    txtSubTotal.Text = "";
                    txtNet.Text = "";
                    txtPaid.Text = "";
                    txtBalance.Text = "";
                    rbtnSweets.Checked = false;
                    rbtnNimko.Checked = false;
                    rbtnBakers.Checked = false;
                    rbtnSweets.ForeColor = Color.Black;
                    rbtnNimko.ForeColor = Color.Black;
                    rbtnBakers.ForeColor = Color.Black;
                    listView1.Items.Clear();
                    comboBox2.SelectedItem = "0%";
                    comboBox1.Text = "";
                    comboBox1.Items.Clear();
                    btnSave.Enabled = false;
                }
                else
                    return;
            }
            else
            {
                numericUpDown1.Value = 0;
                txtPaid.ReadOnly = true;
                listView1.SelectedItems.Clear();
                txtPrice.Text = "";
                txtTotalPrice.Text = "";
                txtSubTotal.Text = "";
                txtNet.Text = "";
                txtPaid.Text = "";
                txtBalance.Text = "";
                rbtnSweets.Checked = false;
                rbtnNimko.Checked = false;
                rbtnBakers.Checked = false;
                rbtnSweets.ForeColor = Color.Black;
                rbtnNimko.ForeColor = Color.Black;
                rbtnBakers.ForeColor = Color.Black;
                listView1.Items.Clear();
                comboBox2.SelectedItem = "0%";
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                btnSave.Enabled = false;
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                numericUpDown1.Value = 0;
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        double a, b, c;
                        a = Convert.ToDouble(listView1.Items[i].SubItems[3].Text);
                        b = Convert.ToDouble(txtSubTotal.Text);
                        c = b - a;
                        txtSubTotal.Text = c.ToString();
                        listView1.Items[i].Remove();
                    }
                }
                comboBox2.SelectedItem = "0%";
                txtNet.Text = txtPaid.Text = txtBalance.Text = "";
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            try
            {
                errorProvider1.Clear();

                if (txtPaid.Text.Length > 0)
                {
                    int a, b, c;
                    c = 0;
                    a = Convert.ToInt32(txtPaid.Text);
                    b = Convert.ToInt32(txtNet.Text);
                    if (Convert.ToInt32(txtPaid.Text) < Convert.ToInt32(txtNet.Text))
                    {
                        errorProvider1.SetError(txtBalance, "Paid amount cannot be less than Net amount!");
                        btnSave.Enabled = false;
                    }
                    else
                    {
                        c = Math.Abs(b - a);
                        btnSave.Enabled = true;
                    }
                    txtBalance.Text = c.ToString();
                }
                else
                {
                    txtBalance.Text = "";
                }
            }
            catch(Exception)
            {
                //MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            txtTotalPrice.Text = "";
            
            if (rbtnSweets.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Sweets WHERE swName = '"+comboBox1.Text+"'";
                comm.Connection = conn;
                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtPrice.Text = finalPrice[0];
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
            if (rbtnNimko.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Nimko WHERE niName = '" + comboBox1.Text + "'";
                comm.Connection = conn;
                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtPrice.Text = finalPrice[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (rbtnBakers.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Bakers WHERE baName = '" + comboBox1.Text + "'";
                comm.Connection = conn;
                try
                {
                    SqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtPrice.Text = finalPrice[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            try
            {
                if (comboBox2.SelectedItem.ToString() == "0%")
                {
                    txtNet.Text = txtSubTotal.Text;

                }
                if (comboBox2.SelectedItem.ToString() == "5%")
                {
                    int a, b, c;
                    a = Convert.ToInt32(txtSubTotal.Text);
                    b = a * 5 / 100;
                    c = a - b;
                    txtNet.Text = c.ToString();
                    
                }
                if (comboBox2.SelectedItem.ToString() == "10%")
                {
                    int a, b, c;
                    a = Convert.ToInt32(txtSubTotal.Text);
                    b = a * 10 / 100;
                    c = a - b;
                    txtNet.Text = c.ToString();
                    
                }
            }
            catch (Exception)
            {

            }
        }

        private void comboBox2_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox2, "It cannot allow to edit changes in this field!");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count == 0)
            {
                Form1 f1 = new Form1();
                this.Hide();
                this.Close();
                f1.ShowDialog();
            }
            else
            {
                DialogResult dr = new DialogResult();
                dr = MessageBox.Show("Do you want to logout with current shopping?", "Confirmation", MessageBoxButtons.YesNo);
                if (dr == System.Windows.Forms.DialogResult.Yes)
                {
                    Form1 f1 = new Form1();
                    this.Hide();
                    this.Close();
                    f1.ShowDialog();
                }
                else
                {
                    return;
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                MoreItemPnl.Visible = true;
                txtMoreItem.ReadOnly = true;
                txtMorePrice.ReadOnly = true;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton1.ForeColor = Color.Black;
                radioButton2.ForeColor = Color.Black;
                radioButton3.ForeColor = Color.Black;
                MoreItemPnl.Visible = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double a, b, c;
            a = Convert.ToDouble(txtPrice.Text);
            b = Convert.ToDouble(numericUpDown1.Value);
            c = a * b;
            txtTotalPrice.Text = c.ToString();
        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMoreItem.ReadOnly = false;
            txtMorePrice.ReadOnly = false;
            txtMoreItem.Text = txtMorePrice.Text = "";
            radioButton1.ForeColor = Color.Green;
            radioButton2.ForeColor = Color.Red;
            radioButton3.ForeColor = Color.Red;
        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMoreItem.ReadOnly = false;
            txtMorePrice.ReadOnly = false;
            txtMoreItem.Text = txtMorePrice.Text = "";
            radioButton2.ForeColor = Color.Green;
            radioButton1.ForeColor = Color.Red;
            radioButton3.ForeColor = Color.Red;
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {
            txtMoreItem.ReadOnly = false;
            txtMorePrice.ReadOnly = false;
            txtMoreItem.Text = txtMorePrice.Text = "";
            radioButton3.ForeColor = Color.Green;
            radioButton1.ForeColor = Color.Red;
            radioButton2.ForeColor = Color.Red;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (radioButton1.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "INSERT INTO Sweets VALUES ('" + txtMoreItem.Text + "','" + txtMorePrice.Text + "')";
                    if (txtMoreItem.Text == "")
                    {
                        errorProvider1.SetError(txtMoreItem, "This field is mandatory!");
                    }
                    else if (txtMorePrice.Text == "")
                    {
                        errorProvider1.SetError(txtMorePrice, "This field is mandatory!");
                    }
                    else
                    {
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Entered Successfully");
                        txtMoreItem.Text = txtMorePrice.Text = "";
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
            else if (radioButton2.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "INSERT INTO Nimko VALUES ('" + txtMoreItem.Text + "','" + txtMorePrice.Text + "')";
                    if (txtMoreItem.Text == "")
                    {
                        errorProvider1.SetError(txtMoreItem, "This field is mandatory!");
                    }
                    else if (txtMorePrice.Text == "")
                    {
                        errorProvider1.SetError(txtMorePrice, "This field is mandatory!");
                    }
                    else
                    {
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Entered Successfully");
                        txtMoreItem.Text = txtMorePrice.Text = "";
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
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "INSERT INTO Bakers VALUES ('" + txtMoreItem.Text + "','" + txtMorePrice.Text + "')";
                    if (txtMoreItem.Text == "")
                    {
                        errorProvider1.SetError(txtMoreItem, "This field is mandatory!");
                    }
                    else if (txtMorePrice.Text == "")
                    {
                        errorProvider1.SetError(txtMorePrice, "This field is mandatory!");
                    }
                    else
                    {
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Entered Successfully");
                        txtMoreItem.Text = txtMorePrice.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtMoreItem.Text = txtMorePrice.Text = "";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                UpdAndDelPnl.Visible = true;
            }
            else
            {
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                radioButton6.Checked = false;
                radioButton4.ForeColor = Color.Black;
                radioButton5.ForeColor = Color.Black;
                radioButton6.ForeColor = Color.Black;
                UpdAndDelPnl.Visible = false;
                listBox1.Items.Clear();
                panel1.Visible = false;
                txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            panel1.Visible = false;
            txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";

            radioButton4.ForeColor = Color.Green;
            radioButton5.ForeColor = Color.Red;
            radioButton6.ForeColor = Color.Red;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Sweets";
                comm.Connection = conn;

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    listBox1.Items.Add(name);
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

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            panel1.Visible = false;
            txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";

            radioButton5.ForeColor = Color.Green;
            radioButton4.ForeColor = Color.Red;
            radioButton6.ForeColor = Color.Red;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Nimko";
                comm.Connection = conn;

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    listBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            panel1.Visible = false;
            txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";

            radioButton6.ForeColor = Color.Green;
            radioButton4.ForeColor = Color.Red;
            radioButton5.ForeColor = Color.Red;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();

            try
            {
                SqlCommand comm = new SqlCommand();
                comm.CommandText = "SELECT * FROM Bakers";
                comm.Connection = conn;

                SqlDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader.GetString(0);
                    listBox1.Items.Add(name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnResetagain_Click(object sender, EventArgs e)
        {
            txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
        }

        private void tbpManage_Enter(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            errorProvider1.Clear();
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void tbpManage_Leave(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void tbpOrder_Enter(object sender, EventArgs e)
        {
            numericUpDown1.Value = 0;
            txtTotalPrice.Text = "";
            if (txtNet.Text == "")
            {
                comboBox2.Text = "0%";
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "SELECT * FROM Sweets WHERE swName = '" + listBox1.Text + "'";
                    comm.Connection = conn;

                    SqlDataReader reader = comm.ExecuteReader();
                    panel1.Visible = true;
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtUpdAndDel.Text = name;
                        txtUpdAndDelPr.Text = finalPrice[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else if (radioButton5.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "SELECT * FROM Nimko WHERE niName = '" + listBox1.Text + "'";
                    comm.Connection = conn;

                    SqlDataReader reader = comm.ExecuteReader();
                    panel1.Visible = true;
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtUpdAndDel.Text = name;
                        txtUpdAndDelPr.Text = finalPrice[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();

                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "SELECT * FROM Bakers WHERE baName = '" + listBox1.Text + "'";
                    comm.Connection = conn;

                    SqlDataReader reader = comm.ExecuteReader();
                    panel1.Visible = true;
                    while (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string price = reader.GetDecimal(1).ToString();
                        string[] finalPrice = price.Split('.');
                        txtUpdAndDel.Text = name;
                        txtUpdAndDelPr.Text = finalPrice[0];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "UPDATE Sweets SET swName = '" + txtUpdAndDel.Text + "', swPrice = '" + txtUpdAndDelPr.Text + "' WHERE swName = '" + listBox1.SelectedItem + "'";
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, txtUpdAndDel.Text);
                    txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                    panel1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (radioButton5.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "UPDATE Nimko SET niName = '" + txtUpdAndDel.Text + "', niPrice = '" + txtUpdAndDelPr.Text + "' WHERE niName = '" + listBox1.SelectedItem + "'";
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, txtUpdAndDel.Text);
                    txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                    panel1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            if (radioButton6.Checked == true)
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                conn.Open();
                try
                {
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "UPDATE Bakers SET baName = '" + txtUpdAndDel.Text + "', baPrice = '" + txtUpdAndDelPr.Text + "' WHERE baName = '" + listBox1.SelectedItem + "'";
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Record Updated Successfully");
                    int index = listBox1.SelectedIndex;
                    listBox1.Items.RemoveAt(index);
                    listBox1.Items.Insert(index, txtUpdAndDel.Text);
                    txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                    panel1.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtUpdAndDel.Text != "" && txtUpdAndDelPr.Text != "")
            {
                if (radioButton4.Checked == true)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                    conn.Open();

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "DELETE FROM Sweets WHERE swName = '" + txtUpdAndDel.Text + "' AND swPrice = '" + txtUpdAndDelPr.Text + "'";
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully");
                        int index = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(index);
                        txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                        panel1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                if (radioButton5.Checked == true)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                    conn.Open();

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "DELETE FROM Nimko WHERE niName = '" + txtUpdAndDel.Text + "' AND niPrice = '" + txtUpdAndDelPr.Text + "'";
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully");
                        int index = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(index);
                        txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                        panel1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
                if (radioButton6.Checked == true)
                {
                    SqlConnection conn = new SqlConnection();
                    conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
                    conn.Open();

                    try
                    {
                        SqlCommand comm = new SqlCommand();
                        comm.CommandText = "DELETE FROM Bakers WHERE baName = '" + txtUpdAndDel.Text + "' AND baPrice = '" + txtUpdAndDelPr.Text + "'";
                        comm.Connection = conn;
                        comm.ExecuteNonQuery();
                        MessageBox.Show("Record Deleted Successfully");
                        int index = listBox1.SelectedIndex;
                        listBox1.Items.RemoveAt(index);
                        txtUpdAndDel.Text = txtUpdAndDelPr.Text = "";
                        panel1.Visible = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        int c = 0;
        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true;";
            conn.Open();
            try
            {
                string[] list = new string[listView1.Items.Count];
                string[] price = new string[listView1.Items.Count];
                string[] Qty = new string[listView1.Items.Count];
                string[] total = new string[listView1.Items.Count];

                int i = 0;
                while (listView1.Items.Count > 0)
                {
                    list[i] = listView1.Items[i].SubItems[0].ToString();
                    price[i] = listView1.Items[i].SubItems[1].ToString();
                    Qty[i] = listView1.Items[i].SubItems[2].ToString();
                    total[i] = listView1.Items[i].SubItems[3].ToString();
                    i++;
                    if (i == listView1.Items.Count) break;
                }

                SqlCommand comm = new SqlCommand();
                for (int j = 0; j < list.Length; j++)
                {
                    int l1 = list[j].IndexOf('}');
                    int l2 = price[j].IndexOf('}');
                    int l3 = Qty[j].IndexOf('}');
                    int l4 = total[j].IndexOf('}');

                    comm.CommandText = "INSERT INTO History VALUES ('" + list[j].Substring(18, l1 - 18) + "','" + price[j].Substring(18, l2 - 18) + "','" + Qty[j].Substring(18, l3 - 18) + "','" + total[j].Substring(18, l4 - 18) + "')";
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                }

                MessageBox.Show("Thanks for Shopping, Next Customer Please!");

                c++;
                lblCustomerNo.Text = c.ToString();
                btnSave.Enabled = false;
                deleteInsert();
                numericUpDown1.Value = 0;
                txtPaid.ReadOnly = true;
                listView1.SelectedItems.Clear();
                txtPrice.Text = "";
                txtTotalPrice.Text = "";
                txtSubTotal.Text = "";
                txtNet.Text = "";
                txtPaid.Text = "";
                txtBalance.Text = "";
                rbtnSweets.Checked = false;
                rbtnNimko.Checked = false;
                rbtnBakers.Checked = false;
                rbtnSweets.ForeColor = Color.Black;
                rbtnNimko.ForeColor = Color.Black;
                rbtnBakers.ForeColor = Color.Black;
                listView1.Items.Clear();
                comboBox2.SelectedItem = "0%";
                comboBox1.Text = "";
                comboBox1.Items.Clear();
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

        public void deleteInsert()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true";
            conn.Open();

            SqlCommand comm1 = new SqlCommand();
            comm1.CommandText = "INSERT INTO TotalCustomers VALUES('" + lblCustomerNo.Text + "')";
            comm1.Connection = conn;
            comm1.ExecuteNonQuery();

            conn.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (mskSecurity.Text == "")
            {
                MessageBox.Show("Please enter the security code for history");
            }
            else
            {
                if (mskSecurity.Text == "12345")
                {
                    Form4 f4 = new Form4();
                    f4.ShowDialog();
                    mskSecurity.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid security code");
                }
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
                mskSecurity.UseSystemPasswordChar = false;
            else
                mskSecurity.UseSystemPasswordChar = true;
        }

        private void tbpManage_ControlAdded(object sender, ControlEventArgs e)
        {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }

        private void btnContact_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed & Manufactured by Mr. Moosa Raza " +
                            " Email us: moosaraza8877@gmail.com" +
                            " Whatsapp Number: 0304-2557489", "Help & Support");
        }
    }
}
