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

namespace ComptParts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbuser.Text == "Renz" && tbpass.Text == "Lubas")
            {
                string user = tbuser.Text;
                string pass = tbpass.Text;
                string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Select * From AdminAcc Where ID = @firstname and Pass = @pass", con);
                cmd.Parameters.AddWithValue("@firstname", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Logging in " + tbuser.Text);


                    Admin Ad = new Admin();
                    Ad.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Account!");



                }
                con.Open();
            }
            else if (tbuser.Text == "Staff" && tbpass.Text == "Only")
            {
                string user = tbuser.Text;
                string pass = tbpass.Text;
                string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Select * From Staff Where ID = @firstname and Pass = @pass", con);
                cmd.Parameters.AddWithValue("@firstname", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Logging in " + tbuser.Text);


                    Staff st = new Staff();
                    st.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Account!");



                }
                con.Open();

            }
            else
            {
                string user = tbuser.Text;
                string pass = tbpass.Text;
                string conn = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand("Select * From Custiomer Where ID = @firstname and Pass = @pass", con);
                cmd.Parameters.AddWithValue("@firstname", user);
                cmd.Parameters.AddWithValue("@pass", pass);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Logging in " + tbuser.Text);


                    Customer Ct = new Customer();
                    Ct.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Incorrect Account!");



                }
                con.Open();



            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
