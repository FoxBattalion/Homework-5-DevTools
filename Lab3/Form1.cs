using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FoxLab3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        /* Name:William Fox
         * Date:11/03/2022
         * This program calculates an annuity */
        double totalPayments = 0.00;
        const int MINYEARS = 5;
        const string NAME = "William Fox";
        private void picHelp_Click(object sender, EventArgs e)
        {   //message box for when someone clicks the "Help" picture
            //convert the constant MINYEARS to string in the message box
            //convert lblRatePerYear to a double so it will read as a percentage
            double ratePerYear = Convert.ToDouble(lblRatePerYear.Text) / 100;
            MessageBox.Show("This program reads in 2 numbers:\n \tFuture Value: amount of \"$\"\n\tYears: must be at least "
                + MINYEARS.ToString() + " \nand calculates payments based on:\n\tYearly interest rate of " + ratePerYear.ToString("P1"), NAME);
        }
        
        private void btnExit_Click(object sender, EventArgs e)
        {
            
            //Message box for when the form closses that also tallies total payments calculated while it was running
            //Also convert the total payments to string in the message box
            MessageBox.Show("Thanks for using this program!\nTotal payments = "+totalPayments.ToString("C2"),NAME);
            //close the form
            this.Close();
        }
        /*create a function for:
         *Hide the solution groupbox
         *Blank out text boxes and payments label
         *focus the cursor on the top textbox
         */
        private void ResetAll()
        {
            grpSolution.Hide();
            txtFutureValue.Text = "";
            txtYears.Text = "";
            lblMonthPay.Text = "";
            txtFutureValue.Focus();
        }

        private void Form_Load()
        {   ResetAll();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {   //convert the user input for future value to a double
                double futureValue = Convert.ToDouble(txtFutureValue.Text);
                //
                double yearRate = Convert.ToDouble(lblRatePerYear.Text)/100;
                //convert the user years input to integer
                int year = Convert.ToInt32(txtYears.Text);
                //display a message box if the years are less than 5
                if (year<5)
                {
                    MessageBox.Show("Years must be at least "+MINYEARS, NAME);
                    txtYears.Focus();
                    txtYears.Select();
                }
                //Now write out the formula to solve for the amount payed monthly 
                else
                {
                   double monthlyAmount = (yearRate / 12 * futureValue) / (Math.Pow(yearRate / 12 + 1, year * 12)-1);
                    //show the solution group box to make it appear
                    grpSolution.Show();
                    //display the answer in the label
                    lblMonthPay.Text = monthlyAmount.ToString("C2");
                    //Add every result together to get the total payments
                    totalPayments = totalPayments+monthlyAmount;

                }
                
            }
            catch
            {   //error message for when someone inputs an incorret input
                MessageBox.Show("Message encountered:\nInput string was not in a correct format",NAME);
            }
            
        }
    }

}
