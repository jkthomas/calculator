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

        private void addNumbers(object sender, EventArgs e)
        {
            memoryValueLabel.Text = (float.Parse(valueTextBox.Text, CultureInfo.InvariantCulture.NumberFormat) +
                float.Parse(memoryValueLabel.Text, CultureInfo.InvariantCulture.NumberFormat)).ToString();

            valueTextBox.Text = "";
        }
        private void numberButtonClicked(object sender, EventArgs e)
        {
            string value = (sender as Button).Text;

            valueTextBox.AppendText(value);
        }
    }
}
