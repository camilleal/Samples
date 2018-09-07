using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            /*****************************************
             * this method calculates the total
             * for an invoice depending on a 
             * discount that's based on the subtotal
             * ***************************************/

            // get the subtotal amount from the Subtotal text box

            decimal invoiceSubtotal = Convert.ToDecimal(txtSubtotal.Text);

            // determine a discount % based on the Subtotal value entered

            decimal discountPercent = 0m;
            if (invoiceSubtotal >=500)
            {
                discountPercent = .2m;
            }
            else if (invoiceSubtotal >= 250 && invoiceSubtotal < 500)
            {
                discountPercent = .15m;
            }
            else if (invoiceSubtotal >= 100 && invoiceSubtotal < 250)
            {
                discountPercent = .1m;
            }

            // calculate the discountAmount and invoiceTotal 

            decimal discountAmount = invoiceSubtotal * discountPercent;
            decimal invoiceTotal = invoiceSubtotal - discountAmount;

            // format and display calculated values in text boxes 

            txtDiscountPercent.Text = discountPercent.ToString("p1");
            txtDiscountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            // change focus to the Subtotal text box

            txtSubtotal.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
