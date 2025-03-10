using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Age_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpCurDate.Value < dtpDOB.Value)
                {
                    MessageBox.Show("Current date must be greater than the DOB");
                }
                int age = dtpCurDate.Value.Year - dtpDOB.Value.Year;
                if (dtpDOB.Value.AddYears(age) > dtpCurDate.Value)
                    age--;
                lblAge.Text = "Your age is:" + age.ToString();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error Message");
            }
        }
    }
}
