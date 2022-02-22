using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderCalc
{
    public partial class frmOrder : Form
    {
        int[] productID;
        string[] productDescription;
        double[] productPrice;
        public frmOrder()
        {
            InitializeComponent();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            productID = new int[5];
            productDescription= new string[5];
            productPrice = new double[5];

            productID[0] = 3115;
            productDescription[0] = "USB Scanner";
            productPrice[0] = 49.99;

            productID[1] = 3116;
            productDescription[1] = "Monitor 17";
            productPrice[1] = 159.99;

            productID[2] = 3117;
            productDescription[2] = "Mono Laser Printer";
            productPrice[2] = 129.99;

            productID[3] = 3118;
            productDescription[3] = "LCD/TV Monitor 19";
            productPrice[3] = 319.99;

            productID[4] = 3119;
            productDescription[4] = "Colour Laser Printer";
            productPrice[4] = 349.99;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            foreach(TextBox txtBox in frmOrder.ActiveForm.Controls.OfType<TextBox>())
            {
                txtBox.Clear();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnClear.PerformClick();
        }
        
        private bool GetProductInfo(int ID, int quantity, out string[] productInfo)
        {
            productInfo = new string[4];

            for(int i =0; i < productID.Length; i++)
            {
                if(productID[i] == ID)
                {
                    productInfo[0] = productID[i].ToString();
                    productInfo[1] = productDescription[i];
                    productInfo[2] = productPrice[i].ToString("C");
                    
                    double total = productPrice[i] * quantity;

                    //Console.WriteLine(total);

                    productInfo[3] = total.ToString();

                    return true;
                }
            }
            return false;
        }

        private void setTotals(double[] price)
        {
            double total = 0.00;
            foreach(double dbl in price)
            {
                total += dbl;
            }

            txtOrderSubtotal.Text = total.ToString("C");
            if(total> 5000)
            {
                txtOrderDiscount.Text = "10%";
                total -= total * 0.1;
                txtOrderTotal.Text = total.ToString("C");
            }
            else
            {
                txtOrderDiscount.Text = "0%";
                txtOrderTotal.Text = txtOrderSubtotal.Text;
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            string[] productinfo;
            int ID;
            int Quantity;
            double[] price = new double[4];

            if (int.TryParse(txtProductID1.Text, out ID) && int.TryParse(txtProductQuantity1.Text, out Quantity))
            {
                if(GetProductInfo(ID, Quantity, out productinfo))
                {
                    txtProductID1.Text = productinfo[0];
                    txtProductDescription1.Text = productinfo[1];
                    txtProductPrice1.Text = productinfo[2];
                    txtProductTotal1.Text = "£" + productinfo[3];

                    price[0] = double.Parse(productinfo[3]);
                }
                else
                {
                    MessageBox.Show($"Could not find product with ID {ID}", "ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*
            else
            {
                MessageBox.Show("ID was not a valid input", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            if (int.TryParse(txtProductID2.Text, out ID) && int.TryParse(txtProductQuantity2.Text, out Quantity))
            {
                if(GetProductInfo(ID, Quantity, out productinfo))
                {
                    txtProductID2.Text = productinfo[0];
                    txtProductDescription2.Text = productinfo[1];
                    txtProductPrice2.Text = productinfo[2];
                    txtProductTotal2.Text = "£" + productinfo[3];

                    price[1] = double.Parse(productinfo[3]);
                }
                else
                {
                    MessageBox.Show($"Could not find product with ID {ID}", "ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            /*
            else
            {
                MessageBox.Show("ID was not a valid input", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            if (int.TryParse(txtProductID3.Text, out ID) && int.TryParse(txtProductQuantity3.Text, out Quantity))
            {
                if(GetProductInfo(ID, Quantity, out productinfo))
                {
                    txtProductID3.Text = productinfo[0];
                    txtProductDescription3.Text = productinfo[1];
                    txtProductPrice3.Text = productinfo[2];
                    txtProductTotal3.Text = "£" + productinfo[3];

                    price[2] = double.Parse(productinfo[3]);
                }
                else
                {
                    MessageBox.Show($"Could not find product with ID {ID}", "ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            /*
            else
            {
                MessageBox.Show("ID was not a valid input", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            if (int.TryParse(txtProductID4.Text, out ID) && int.TryParse(txtProductQuantity4.Text, out Quantity))
            {
                if(GetProductInfo(ID, Quantity, out productinfo))
                {
                    txtProductID4.Text = productinfo[0];
                    txtProductDescription4.Text = productinfo[1];
                    txtProductPrice4.Text = productinfo[2];
                    txtProductTotal4.Text = "£" + productinfo[3];

                    price[3] = double.Parse(productinfo[3]);
                }
                else
                {
                    MessageBox.Show($"Could not find product with ID {ID}", "ID not found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            /*
            else
            {
                MessageBox.Show("ID was not a valid input", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/

            setTotals(price);
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnCalc.PerformClick();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
