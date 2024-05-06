using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollegeFeeCalculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Naming each of the variables and giving them either a string or double value
            string firstName, lastName, age;
            double price, majorPrice, totalPrice;

            // Storing values from textboxes while also trimming any leading/following whitespaces
            firstName = txtFirstName.Text.Trim();
            lastName = txtLastName.Text.Trim();
            age = txtAge.Text.Trim();

            // Show error message if no First name is entered
            if (firstName.Length == 0)
            {
                MessageBox.Show("Please enter a valid First name");
                txtFirstName.Focus();
                txtFirstName.Clear();
                return;
            }

            // Show error message if no last Name is entered
            if (lastName.Length == 0) 
            {
                MessageBox.Show("Please enter a valid Last Name");
                txtLastName.Focus();
                txtLastName.Clear();
                return;
            }

            // Show error message if no Age is entered
            if (age.Length == 0)
            {
                MessageBox.Show("Please enter a valid Age");
                txtAge.Focus();
                txtAge.Clear();
                return;
            }

            // Show error message if no major is chosen
            if (cmbMajor.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter your declared major");
                cmbMajor.Focus();
                cmbMajor.SelectedIndex = -1;
                return;
            }

            // Makes price $10,000 if the in-state box is selected, otherwise price is $15,000
            if (chkResidentStatus.Checked)
            {
                price = 10000;
            }
            else
            {
                price = 15000;
            }

            // Adds a price to the combo box selection that the user chooses
            if (cmbMajor.SelectedItem == "Computer Science")
            {
                majorPrice = 2000;
            }
            else if (cmbMajor.SelectedItem == "Business Administration")
            {
                majorPrice = 1500;
            }
            else if (cmbMajor.SelectedItem == "Arts and Humanities")
            {
                majorPrice = 1000;
            }
            else if (cmbMajor.SelectedItem == "Sciences")
            {
                majorPrice = 1800;
            }
            else
            {
                majorPrice = 0;
            }

            // Creates new variable called totalPrice that is the majorPrice + price (of in-state or out of state)
            totalPrice = price + majorPrice;

            // Displays the total price as a currency value
            txtCalculate.Text = totalPrice.ToString(("C")); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clearing all fields when "clear" button is hit
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAge.Clear();
            txtCalculate.Clear();
            cmbMajor.SelectedIndex = -1;
            chkResidentStatus.Checked = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            // Closing the application
            this.Close();
        }
    }
}
