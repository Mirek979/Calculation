using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculation
{
    public partial class Form1 : Form
    {
        Double result = 0;
        String operation = "";
        bool enter_value = false;
        String firstnum, secundum;
        public Form1()
        {
            InitializeComponent();
        }

        private void txtDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void numbers_Only(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if ((txtDisplay.Text == "0") || (enter_value))
                txtDisplay.Text = "";
            enter_value = false;

            if (b.Text == ".")
            {
                if (!txtDisplay.Text.Contains("."))
                    txtDisplay.Text = txtDisplay.Text + b.Text;
            }
            else
            {
                txtDisplay.Text = txtDisplay.Text + b.Text;
            }
        }

        private void operators_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;

            if (result != 0)
            {
                btnEquals.PerformClick();
                enter_value = true;
                operation = b.Text;
                lblShowOp.Text = result + "  " + operation;
            }
            else
            {
                operation = b.Text;
                result = Double.Parse(txtDisplay.Text);
                enter_value = true;
                lblShowOp.Text = result + " " + operation;
            }
            firstnum = lblShowOp.Text;
            operation = "";



         

        }

    

       

        private void btnEquals_Click(object sender, EventArgs e)
        {
            secundum = txtDisplay.Text;
            lblShowOp.Text = "";
            switch(operation)
            {
                case "+":
                    txtDisplay.Text = (result + Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "-":
                    txtDisplay.Text = (result - Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "*":
                    txtDisplay.Text = (result * Double.Parse(txtDisplay.Text)).ToString();
                    break;
                case "/":
                    txtDisplay.Text = (result / Double.Parse(txtDisplay.Text)).ToString();
                    break;
                default:
                    break;
            }
            result = Double.Parse(txtDisplay.Text);
            operation = "";

            btnClearHistory.Visible = true;
            rtbDisplayHistory.AppendText(firstnum + "  " + secundum + " = " + "\n");
            rtbDisplayHistory.AppendText("\n\t" + txtDisplay.Text + "\n\n");
            label1.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
            result = 0;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtDisplay.Text = "";
        }

        private void lblHistoryDisplay(object sender, EventArgs e)
        {
            
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            rtbDisplayHistory.Clear();
            if (label1.Text == "")
            {
                label1.Text = "Není tu historie";
            }
            btnClearHistory.Visible = false;
            rtbDisplayHistory.ScrollBars = 0;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(txtDisplay.Text.Length > 0)
            {
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);

            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
            }
        }
    }
}
