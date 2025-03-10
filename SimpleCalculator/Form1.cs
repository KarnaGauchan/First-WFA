using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        double operand1, operand2, result;
        Operations oper = new Operations();


        private void btnAdd_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(txtOperand1.Text);
            operand2 = Convert.ToDouble(txtOperand2.Text);
            result = Calculator.Library.Calculator.Add(operand1,operand2);
            txtResult.Text = result.ToString();
        }

        private void btnSub_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(txtOperand1.Text);
            operand2 = Convert.ToDouble(txtOperand2.Text);
            result = Calculator.Library.Calculator.Sub(operand1, operand2);
            txtResult.Text = result.ToString();
        }


        private void btnMul_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(txtOperand1.Text);
            operand2 = Convert.ToDouble(txtOperand2.Text);
            result = Calculator.Library.Calculator.Mul(operand1, operand2);
            txtResult.Text = result.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operand1 = Convert.ToDouble(txtOperand1.Text);
            operand2 = Convert.ToDouble(txtOperand2.Text);
            result = Calculator.Library.Calculator.Div(operand1, operand2);
            txtResult.Text = result.ToString();
        }

        private void txtOperand1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar)==false && char.IsControl(e.KeyChar) && (e.KeyChar=='.'? txtOperand1.Text.Contains('.')==true:true))
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public Form1()
        {
            InitializeComponent();
        }
    }
}
