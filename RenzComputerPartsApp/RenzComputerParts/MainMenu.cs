using RenzComputerParts.DBHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenzComputerParts
{
    public partial class MainMenu : Form
    {
        private readonly string customerName;
        private readonly string customerID;
        private readonly Login loginForm;

        public MainMenu(string CustomerName, string CustomerID, Login loginForm)
        {
            InitializeComponent();

            customerName = CustomerName;
            customerID = CustomerID;
            this.loginForm = loginForm;
            lblHeader.Text = $"Welcome {customerName}!";
        }

        private void PrintPanelContents(Panel panel)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += (sender, e) =>
            {
                Bitmap bitmap = new Bitmap(panel.Width, panel.Height);
                panel.DrawToBitmap(bitmap, panel.ClientRectangle);
                e.Graphics.DrawImage(bitmap, new Point(0, 0));
                bitmap.Dispose();
            };



            
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            PaperSize paperSize = new PaperSize("A4", panel.Width, panel.Height);
            SetPrintPreviewPaperSize(printPreviewDialog, paperSize);

            printPreviewDialog.ShowDialog();

        }

        private void SetPrintPreviewPaperSize(PrintPreviewDialog printPreviewDialog, PaperSize paperSize)
        {
            PrintDocument printDocument = printPreviewDialog.Document;
            printDocument.DefaultPageSettings.PaperSize = paperSize;

            printPreviewDialog.Document = null;
            printPreviewDialog.Document = printDocument;
        }

        private void ClearFields()
        {
            listParts.Text = "";
            lblPrice.Text = "";
            lblStocks.Text = "";
            txtQuantity.Value = 0;

            itemImage.Image = null;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            int numStocks = int.Parse(lblStocks.Tag.ToString());

            if (numStocks <= 0)
            {
                MessageBox.Show("No stocks left for this item");
            }
            else
            {
                if (txtQuantity.Value > numStocks)
                {
                    MessageBox.Show($"Only {numStocks} stocks left for this item. Please input less number of order.");
                }
                else if (txtQuantity.Value == 0)
                {
                    MessageBox.Show("Please input valid quantity");
                }
                else
                {
                    var selectedItem = listParts.SelectedItem.ToString().Split('-')[1];
                    var selectedItemID = listParts.SelectedItem.ToString().Split('-')[0];
                    var totalPrice = double.Parse(lblPrice.Tag.ToString()) * double.Parse(txtQuantity.Value.ToString());
                    this.listPurchase.Rows.Add(selectedItem, txtQuantity.Value, totalPrice, selectedItemID);

                    double sum = 0;
                    for (int i = 0; i < listPurchase.Rows.Count; i++)
                    {
                        sum = sum + double.Parse(listPurchase.Rows[i].Cells[2].Value.ToString());
                    }

                    lblTotal.Text = sum.ToString();
                    ClearFields();
                }
            }
        }



        private void MainMenu_Load(object sender, EventArgs e)
        {
            listParts.Items.Clear();
            GetItemsData.GetAllItems(listParts);
        }



        private void listParts_SelectedValueChanged(object sender, EventArgs e)
        {
            var a = listParts.SelectedItem.ToString();
            var itemID = int.Parse(a.Split('-')[0]);
            GetItemsData.LoadData(itemID, itemImage, lblPrice, lblStocks);

        }



        private void btnPay_Click(object sender, EventArgs e)
        {
            if (txtPayment.Text == "")
            {
                MessageBox.Show("Please input payment first");
            }
            else if (listPurchase.Rows.Count == 0)
            {
                MessageBox.Show("Please select an item first");
            }
            else
            {
                if (double.Parse(txtPayment.Text) >= double.Parse(lblTotal.Text))
                {
                    var Payment = double.Parse(txtPayment.Text);
                    var TotalPrice = double.Parse(lblTotal.Text);
                    var change = Payment - TotalPrice;

                    lblChange.Text = change.ToString();
                    lblCustomerName.Text = customerName;
                    lblDatePurchased.Text = DateTime.Now.ToLongDateString();

                    for (int i = 0; i < listPurchase.Rows.Count; i++)
                    {
                        string purchasedItem = listPurchase.Rows[i].Cells[0].Value.ToString();
                        string quantity = listPurchase.Rows[i].Cells[1].Value.ToString();
                        string price = listPurchase.Rows[i].Cells[2].Value.ToString();
                        string itemID = listPurchase.Rows[i].Cells[3].Value.ToString();

                        string sql = "insert into [CustomerPurchase]([Customer], [PurchasedItem]," +
                            "[Quantity], [TotalPrice], [Payment], [DatePurchased])values" +
                            "('" 
                            + this.customerName + "', '" 
                            + purchasedItem + "', "
                            + quantity + ", '" 
                            + price + "', '" 
                            + txtPayment.Text + "', '" 
                            + DateTime.Now.ToLongDateString() + "')";

                        DBHelper.DBHelper.ModifyRecord(sql);

                        string queryStocks = "update [Item] set [ItemStocks] = [ItemStocks] - " + quantity + " where [ItemID] = " + itemID + "";
                        DBHelper.DBHelper.ModifyRecord(queryStocks);
                    }

                    MessageBox.Show("Succesfuly Paid!");
                    PrintPanelContents(receiptPanel);
                    listParts.Items.Clear();
                    GetItemsData.GetAllItems(listParts);
                }
                else
                {
                    MessageBox.Show("Please check all the payment information if valid.");
                }
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in listPurchase.SelectedRows)
            {
                listPurchase.Rows.RemoveAt(row.Index);
            }
        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            listPurchase.Rows.Clear();
            ClearFields();
            lblChange.Text = "";
            lblTotal.Text = "";
            txtPayment.Text = "";
        }



        private void btnLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult close = MessageBox.Show("Are you sure you want to logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (close == DialogResult.Yes)
            {
                loginForm.Show();
                this.Close();
            }
        }

        private void listParts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
