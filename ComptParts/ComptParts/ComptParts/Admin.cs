using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComptParts
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(conn);
            con.Open();
            string query = "Select * From Stock1";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(reader);

            dgvStocks.DataSource = table;
            con.Close();
        }

        private void cmbitem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int num1 = 4400;
            int num2 = 2300;
            int num3 = 1800;
            int num5 = 1200;
            int num6 = 1100;
            int num7 = 800;
            int num8 = 1400;
            int num9 = 800;
 int num10 = 700;
 int num11 = 400;
 int num12 = 1000;
                if (item.Text == "motherboard")
            { 
            tbprice.Text = num1.ToString();
            
            }
            if (item.Text == "Processor")
            {
                tbprice.Text = num2.ToString();

            }
            if (item.Text == "RAM 8GB")
            {
                tbprice.Text = num3.ToString();

            }
            if (item.Text == "RAM 4GB")
            {
                tbprice.Text = num5.ToString();

            }
            if (item.Text == "POWER SUPPLY")
            {
                tbprice.Text = num6.ToString();

            }
            if (item.Text == "CPU COOLER")
            {
                tbprice.Text = num7.ToString();

            }
            if (item.Text == "SSD 240GB")
            {
                tbprice.Text = num8.ToString();

            }
            if (item.Text == "SSD 130GB")
            {
                tbprice.Text = num9.ToString();

            }
            if (item.Text == "KEYBOARD")
            {
                tbprice.Text = num10.ToString();

            }
            if (item.Text == "MOUSE")
            {
                tbprice.Text = num11.ToString();

            }
            if (item.Text == "HDD 500GB")
            {
                tbprice.Text = num12.ToString();

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(tbprice.Text);
            string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(conn);
            con.Open();

            string query = "INSERT INTO Stock1 (itemNum,Parts,Stock,Price) VALUES ('" + tbNumber.Text + "','" + item.Text + "','" + tbstock.Text + "','" + tbprice.Text + "')";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Inserted");
            Admin_Load(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to delete this record? ",
"Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                int num = Convert.ToInt32(tbNumber.Text);

                string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(conn);
                con.Open();


                string query = "Delete from Stock1 where itemNum = " + num + " ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Deleted!");

                Admin_Load(sender, e);
            }
        }

        private void dgvStocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNumber.Text = dgvStocks[0, e.RowIndex].Value.ToString();
            tbItem.Text = dgvStocks[1, e.RowIndex].Value.ToString();
            tbstock.Text = dgvStocks[2, e.RowIndex].Value.ToString();
            tbprice.Text = dgvStocks[3, e.RowIndex].Value.ToString();
     

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int num1 = Convert.ToInt32(tbprice.Text);
     
            int num3 = Convert.ToInt32(tbstock.Text);
            int num4 = Convert.ToInt32(tbNumber.Text);

            SqlConnection con = new SqlConnection("Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False");
            con.Open();
            string query = "UPDATE Stock1 SET Parts  = '" + tbItem.Text +
                              "',  Stock    ='" + num3 +

                                 "', Price      ='" +
                     num1 +




                      "'WHERE itemNum = '" + num4 + "'";
            SqlCommand command = new SqlCommand(query, con);
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Updated!");

            Admin_Load(sender, e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void dgvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
