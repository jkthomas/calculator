using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void numberButtonClicked(object sender, EventArgs e)
        {
            if(!(valueTextBox.TextLength == valueTextBox.MaxLength))
            {
                string value = (sender as Button).Text;
                if (!(value.Equals(",") && (valueTextBox.Text.Contains(",") || valueTextBox.Text.Equals(""))))
                {
                    valueTextBox.AppendText(value);
                }
            } else
            {
                infoLabel.Text = "You have reached maximum number length.";
            }
            
        }

        private void addNumbers(object sender, EventArgs e)
        {
            try
            {
                string memoryNumber = memoryValueLabel.Text.Replace(",", ".");
                string textboxNumber = valueTextBox.Text.Replace(",", ".");
                float number1, number2;
                checked
                {
                    number1 = float.Parse(memoryNumber, CultureInfo.InvariantCulture);
                    number2 = float.Parse(textboxNumber, CultureInfo.InvariantCulture);
                }
                
                memoryValueLabel.Text = (number1 + number2).ToString("F");
            }
            catch (OverflowException)
            {
                infoLabel.Text = "Too big values provided, buy full version for bigger numbers support.";
            }
            valueTextBox.Text = "";
        }

        private void substract(object sender, EventArgs e)
        {

        }

        private void multiply(object sender, EventArgs e)
        {

        }

        private void divide(object sender, EventArgs e)
        {

        }
    }
}
