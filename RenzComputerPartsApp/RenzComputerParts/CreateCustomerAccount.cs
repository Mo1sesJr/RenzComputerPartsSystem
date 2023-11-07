using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenzComputerParts
{
    public partial class CreateCustomerAccount : Form
    {
        public CreateCustomerAccount()
        {
            InitializeComponent();
        }

        private void btnSaveCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into [Customer]([CustName], [Username], [Password])" +
                    "values('" + txtName.Text + "', '" + txtUsername.Text + "', '" + txtPassword.Text + "')";
                DBHelper.DBHelper.ModifyRecord(sql);
                MessageBox.Show("Account saved! You can now login.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
