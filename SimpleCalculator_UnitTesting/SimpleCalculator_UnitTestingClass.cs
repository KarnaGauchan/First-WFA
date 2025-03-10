using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;

namespace SimpleCalculator_UnitTesting
{
  
    [TestClass]
    public class SimpleCalculator_UnitTestingClass
    {
        Operations oper = new Operations();

        double Operand1 = 20, Operand2 = 4;
        [TestMethod]
        public void Test_Addition()
        {
            Assert.AreEqual(oper.Add(Operand1, Operand2), 24);
        }

        [TestMethod]
        public void Test_Subtraction()
        {
            Assert.AreEqual(oper.Sub(Operand1, Operand2), 16);
        }

        [TestMethod]
        public void Test_Multiplication()
        {
            Assert.AreEqual(oper.Mul(Operand1, Operand2), 80);
        }

        [TestMethod]
        public void Test_Division()
        {
            Assert.AreEqual(oper.Div(Operand1, Operand2), 5);
        }
    }
}
