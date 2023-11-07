using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenzComputerParts
{
    public partial class Admin : Form
    {
        private readonly Login loginForm;

        public Admin(Login loginForm)
        {
            InitializeComponent();

            LoadData();
            this.loginForm = loginForm;
        }

        private void LoadData()
        {
            DBHelper.DBHelper.fill("select * from [item]", listItem);
        }

        private void ClearFields()
        {
            txtPrice.Text = "";
            txtItemName.Text = "";
            txtDescription.Text = "";
            txtID.Text = "";
            txtStocks.Value = 0;

            itemImage.Image = null;
        }



        private void ModifyFields(bool Enabled)
        {
            txtItemName.Enabled = Enabled;
            txtDescription.Enabled = Enabled;
            txtStocks.Enabled = Enabled;
            txtPrice.Enabled = Enabled;
        }



        private void btnNewItem_Click(object sender, EventArgs e)
        {
            ModifyFields(true);
            ClearFields();

            btnNewItem.Enabled = false;
            btnSaveItem.Enabled = true;
        }



        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemImage.Image != null)
                {
                    string sql = "insert into [Item]([ItemName], [ItemDescription], [ItemStocks], [ItemSellingPrice])" +
                    "values('" + txtItemName.Text + "', '" + txtDescription.Text + "', " + txtStocks.Value.ToString() + ", '" + txtPrice.Text + "')";
                    DBHelper.DBHelper.ModifyRecord(sql);
                    MessageBox.Show("Item Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    itemImage.Image.Save(Application.StartupPath + $"\\Parts_Image\\{txtItemName.Text}.jpg");


                    ClearFields();
                    LoadData();

                    ModifyFields(false);

                    btnNewItem.Enabled = true;
                    btnSaveItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Please insert image for this product");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select an item first");
            }
            else
            {
                if (btnUpdate.Text == "Update Item")
                {
                    btnUpdate.Text = "Save Updates";
                    ModifyFields(true);
                }
                else if (btnUpdate.Text == "Save Updates")
                {
                    string sql = "update [Item] set [ItemName] = '" + txtItemName.Text + "', " +
                        "[ItemDescription] = '" + txtDescription.Text + "', [ItemStocks] = " + txtStocks.Value + ", " +
                        "[ItemSellingPrice] = " + txtPrice.Text + " where [ItemID] = " + txtID.Text + "";
                    DBHelper.DBHelper.ModifyRecord(sql);

                    MessageBox.Show("Item Updated", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadData();
                    ClearFields();
                    btnUpdate.Text = "Update Item";
                    ModifyFields(false);
                }
            }
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Select an item first");
            }
            else
            {
                DialogResult delete = MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (delete == DialogResult.Yes)
                {
                    string sql = "delete from [Item] where [ItemID] = " + txtID.Text + "";
                    DBHelper.DBHelper.ModifyRecord(sql);

                    itemImage.Image.Dispose();
                    File.Delete(Application.StartupPath + $"\\Parts_Image\\{txtItemName.Text}.jpg");

                    MessageBox.Show("Item Deleted", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                    ClearFields();
                    ModifyFields(false);
                }
            }
        }



        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";

            if (open.ShowDialog() == DialogResult.OK)
            {
                itemImage.Image = new Bitmap(open.FileName);
            }
        }



        private void listItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = listItem[0, e.RowIndex].Value.ToString();
            txtItemName.Text = listItem[1, e.RowIndex].Value.ToString();
            txtDescription.Text = listItem[2, e.RowIndex].Value.ToString();
            txtStocks.Value = decimal.Parse(listItem[3, e.RowIndex].Value.ToString());
            txtPrice.Text = listItem[4, e.RowIndex].Value.ToString();

            try
            {
                itemImage.Image = Image.FromFile(Application.StartupPath + $"\\Parts_Image\\{txtItemName.Text}.jpg");
            }
            catch
            {
                itemImage.Image = null;
            }
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



        private void btnPurchases_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CustomerPurchases purchase = new CustomerPurchases();
            purchase.ShowDialog();
        }

        private void txtItemName_TextChanged(object sender, EventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
