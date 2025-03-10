using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    public class Operations
    {
        public double Add(double operand1, double operand2)
        {
            return operand1 + operand2;
        }

        public double Sub(double operand1, double operand2)
        {
            return operand1 - operand2;
        }
        public double Mul(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
        public double Div(double operand1, double operand2)
        {
            return operand1 / operand2;
        }
    }
}
