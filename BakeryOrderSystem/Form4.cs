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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM History";
            comm.Connection = conn;

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                ListViewItem lvi = new ListViewItem(dr[1].ToString());
                lvi.SubItems.Add(dr[2].ToString());
                lvi.SubItems.Add(dr[3].ToString());
                lvi.SubItems.Add(dr[4].ToString());
                listView1.Items.Add(lvi);
            }

            double Cnt = 0;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                Cnt = Cnt + Convert.ToDouble(listView1.Items[i].SubItems[3].Text);
            }
            lblTotalSale.Text = Cnt.ToString();

            lblTotalItems.Text = listView1.Items.Count.ToString();
            receivingCustomers();
        }

        public void receivingCustomers()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source = DESKTOP-R5FBKUE\SQLEXPRESS; Initial Catalog = BakerySystem; Integrated Security = true";
            conn.Open();

            SqlCommand comm = new SqlCommand();
            comm.CommandText = "SELECT * FROM TotalCustomers";
            comm.Connection = conn;

            SqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                int cust = dr.GetInt32(0);
                lblCustomerTotal.Text = cust.ToString();
            }
            conn.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
