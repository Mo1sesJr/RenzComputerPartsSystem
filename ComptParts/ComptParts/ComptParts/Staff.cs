using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComptParts
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
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

            string conn1 = "Data Source=MOISESJR\\SQLEXPRESS;Initial Catalog=order1;Integrated Security=True;Encrypt=False";
            SqlConnection con1 = new SqlConnection(conn1);
            con1.Open();
            string query1 = "Select * From Custiomer";
            SqlCommand command1 = new SqlCommand(query1, con1);
            SqlDataReader reader1 = command1.ExecuteReader();
            DataTable table1 = new DataTable();
            table1.Load(reader1);

            dgvAcounts.DataSource = table1;
            con1.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}
