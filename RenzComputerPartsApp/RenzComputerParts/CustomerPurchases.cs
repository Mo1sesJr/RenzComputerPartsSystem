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
    public partial class CustomerPurchases : Form
    {
        public CustomerPurchases()
        {
            InitializeComponent();

            LoadData();
        }

        public void LoadData()
        {
            DBHelper.DBHelper.fill("select * from [CustomerPurchase]", listPurchases);
        }

        private void CustomerPurchases_Load(object sender, EventArgs e)
        {

        }
    }
}
