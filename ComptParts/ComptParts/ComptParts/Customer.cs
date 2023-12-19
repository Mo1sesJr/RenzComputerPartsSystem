using System;
using System.Collections;
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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void item_SelectedIndexChanged(object sender, EventArgs e)
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
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\1.jpg";


            }
            if (item.Text == "Processor")
            {
                tbprice.Text = num2.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\2.jpg";


            }
            if (item.Text == "RAM 8GB")
            {
                tbprice.Text = num3.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\3.jpg";


            }
            if (item.Text == "RAM 4GB")
            {
                tbprice.Text = num5.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug'\4].jpg";


            }
            if (item.Text == "POWER SUPPLY")
            {
                tbprice.Text = num6.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\5.jpg";


            }
            if (item.Text == "CPU COOLER")
            {
                tbprice.Text = num7.ToString();
             pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\6.jpg";


            }
            if (item.Text == "SSD 240GB")
            {
                tbprice.Text = num8.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\7.jpg";


            }
            if (item.Text == "SSD 130GB")
            {
                tbprice.Text = num9.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\8.jpg";


            }
            if (item.Text == "KEYBOARD")
            {
                tbprice.Text = num10.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\9.jpg";


            }
            if (item.Text == "MOUSE")
            {
                tbprice.Text = num11.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\10.jpg";


            }
            if (item.Text == "HDD 500GB")
            {
                tbprice.Text = num12.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\11.jpg";


            }
            if (item.Text == "HDD 1TERBYTE")
            {
                tbprice.Text = num12.ToString();
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\12.jpg";


            }

            

        }

        private void dgvStocks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbstock_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Are you sure you want to Buy this Item?\n" +
                " You cannoot Delete The Item ",
"Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {

                int num1 = Convert.ToInt32(tbprice.Text);
                int num2 = Convert.ToInt32(tbquantity.Text);
                int num3 = Convert.ToInt32(tbstock.Text);

                int num4 = Convert.ToInt32(tbNumber.Text);

                tbstock.Text = (num3 - num2).ToString();

                string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                int num11 = Convert.ToInt32(tbprice.Text);

                string query = "INSERT INTO CustStock1 (itemNum,Parts,Stock,Price,Quantity,TypeP) VALUES ('" + tbNumber.Text + "','" + item.Text + "','" + tbstock.Text + "','" + tbprice.Text + "','" + tbquantity.Text + "','" + tbp.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Inserted");
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();

                string conn1 = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con1 = new SqlConnection(conn1);
                con1.Open();
                string query1 = "UPDATE Stock1 SET Parts  = '" + tbItem.Text +
                                  "',  Stock    ='" + tbstock.Text +

                                     "', Price      ='" +
                        tbprice.Text +

                          "'WHERE itemNum = '" + num4 + "'";
                Customer_Load(sender, e);
                SqlCommand command1 = new SqlCommand(query1, con1);
                command1.ExecuteNonQuery();

                //  con.Close();
                con1.Close();
                MessageBox.Show("Updated!");

                dgvItem.Rows.Add(tbNumber.Text, tbItem.Text, tbstock.Text, tbprice.Text, tbquantity.Text, tbp.Text);

                Customer_Load(sender, e);
            }
        }
        public void clearItem()
        {
            tbNumber.Clear();
            tbItem.Clear();
            tbprice.Clear();
            tbstock.Clear();
            tbquantity.Clear();
            tbstock.Clear();
            tbp.Clear();

        }
        private void getsum()
        {
            double sum = 0;

            for (int i = 0; i < dgvItem.RowCount - 1; i++)
            {
                sum += Convert.ToDouble(dgvItem.Rows[i].Cells[3].Value);
            }
            tbrslt.Text = sum.ToString("N2");
        
    }

        private void Customer_Load(object sender, EventArgs e)
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

        private void dgvStocks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbNumber.Text = dgvStocks[0, e.RowIndex].Value.ToString();
            tbItem.Text = dgvStocks[1, e.RowIndex].Value.ToString();
            tbstock.Text = dgvStocks[2, e.RowIndex].Value.ToString();
            tbprice.Text = dgvStocks[3, e.RowIndex].Value.ToString();

        }

        private void rbcash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbcash.Checked)
            {
                tbp.Text = "Cash";
            
            }
        }

        private void rbgcash_CheckedChanged(object sender, EventArgs e)
        {
            if (rbgcash.Checked)
            {
                tbp.Text = "Gcash";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            MessageBox.Show("Thank you For Buying!");
            dgvItem.Rows.Clear();
            Customer_Load(sender, e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            getsum();
            panel1.Visible = true;
        }

        private void tbItem_TextChanged(object sender, EventArgs e)
        {

            if (tbItem.Text == "motherboard")
            {
                pb1.ImageLocation = @"C:\Users\moise\OneDrive\Desktop\ComptParts\ComptParts\ComptParts\bin\Debug\1.jpg";

            }
            if (tbItem.Text == "Processor")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\2.jpg";

            }
            if (tbItem.Text == "RAM 8GB")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\3.jpg";

            }
            if (tbItem.Text == "RAM 4GB")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\4].jpg";

            }
            if (tbItem.Text == "POWER SUPPLYs")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\5.jpg";

            }
            if (tbItem.Text == "CPU COOLER")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\6.jpg";

            }
            if (tbItem.Text == "SSD 240GB")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\7.jpg";

            }
            if (tbItem.Text == "SSD 130GB")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\8.jpg";

            }
            if (tbItem.Text == "KEYBOARD")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\9.jpg";

            }
            if (tbItem.Text == "MOUSE")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\10.jpg";

            }
            if (tbItem.Text == "HDD 500GB")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\11.jpg";

            }
            if (tbItem.Text == "HDD 1TERBYTE")
            {
                pb1.ImageLocation = @"C:\Users\Zeo Alejandro\Desktop\New folder\ComptParts\ComptParts\bin\Debug\12.jpg";

            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
