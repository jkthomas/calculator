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
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void numberButtonClicked(object sender, EventArgs e)
        {
            if (!(valueTextBox.TextLength == valueTextBox.MaxLength))
            {
                string value = (sender as Button).Text;
                if (!(value.Equals(",") && (valueTextBox.Text.Contains(",") || valueTextBox.Text.Equals(""))))
                {
                    valueTextBox.AppendText(value);
                }

                infoLabel.Text = "Please proceed with calculations...";
                infoLabel.ForeColor = Color.Black;
            }
            else
            {
                infoLabel.Text = "You have reached maximum number length.";
                infoLabel.ForeColor = Color.Red;
            }

        }

        private void operationButtonClicked(object sender, EventArgs e)
        {
            try
            {
                string memoryNumber = memoryValueLabel.Text.Replace(",", ".");
                string textboxNumber = valueTextBox.Text.Replace(",", ".");
                decimal number1, number2;
                checked
                {
                    number1 = decimal.Parse(memoryNumber, CultureInfo.InvariantCulture);
                    number2 = decimal.Parse(textboxNumber, CultureInfo.InvariantCulture);
                }
                string value = (sender as Button).Text;

                checked
                {
                    if (value.Equals("+"))
                        memoryValueLabel.Text = (number1 + number2).ToString("0.00000");
                    if (value.Equals("-"))
                        memoryValueLabel.Text = (number1 - number2).ToString("0.00000");
                    if (value.Equals("*"))
                        memoryValueLabel.Text = (number1 * number2).ToString("0.00000");
                    if (value.Equals("/"))
                        memoryValueLabel.Text = (number1 / number2).ToString("0.00000");
                }
                infoLabel.Text = "Please proceed with calculations...";
                infoLabel.ForeColor = Color.Black;
            }
            catch (OverflowException)
            {
                infoLabel.Text = "Too big values provided, buy full version for bigger numbers support.";
                infoLabel.ForeColor = Color.Red;
            }
            catch (FormatException)
            {
                infoLabel.Text = "Please proceed with calculations...";
                infoLabel.ForeColor = Color.Black;
            }
            catch(DivideByZeroException)
            {
                infoLabel.Text = "It is not allowed to divide by 0";
                infoLabel.ForeColor = Color.Red;
            }
            finally
            {
                valueTextBox.Text = "";
            }
        }

        private void clearAllButton_Click(object sender, EventArgs e)
        {
            valueTextBox.Text = "";
            memoryValueLabel.Text = "0";
        }

        private void clearOneButton_Click(object sender, EventArgs e)
        {
            string textBox = valueTextBox.Text;
            if (!(textBox.Length == 0))
            {
                valueTextBox.Text = textBox.Substring(0, textBox.Length - 1);
            }
        }
    }
}
