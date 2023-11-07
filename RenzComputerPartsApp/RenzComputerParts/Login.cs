using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenzComputerParts
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        string customerName;
        string customerID;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "admin")
                {
                    Admin admin = new Admin(this);
                    admin.Show();
                    this.Hide();
                }
                else
                {
                    Connection.Connection.DB();
                    DBHelper.DBHelper.gen = "select * from [Customer] where [Username] = '" + txtUsername.Text + "'and [Password] = '" + txtPassword.Text + "'";
                    DBHelper.DBHelper.command = new OleDbCommand(DBHelper.DBHelper.gen, Connection.Connection.connect);
                    DBHelper.DBHelper.DBReader = DBHelper.DBHelper.command.ExecuteReader();

                    if (DBHelper.DBHelper.DBReader.HasRows)
                    {
                        DBHelper.DBHelper.DBReader.Read();

                        this.customerName = (DBHelper.DBHelper.DBReader["username"].ToString());
                        this.customerID = (DBHelper.DBHelper.DBReader["password"].ToString());

                        timer1.Enabled = true;
                        timer1.Start();
                        timer1.Interval = 1;
                        progressBar1.Maximum = 150;
                        timer1.Tick += new EventHandler(timer1_Tick);

                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password");

                    }
                }
            }
            catch (Exception ex)
            {
                Connection.Connection.connect.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value != 150)
            {
                progressBar1.Value++;
            }
            else
            {
                timer1.Stop();
                progressBar1.Value = 0;
                MainMenu main = new MainMenu(customerName, customerID, this);
                this.Hide();
                main.Show();
            }
        }

        private void btnCreateAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateCustomerAccount createAccount = new CreateCustomerAccount();
            createAccount.ShowDialog();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
