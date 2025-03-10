using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace SimpleCalculatorUnitTestUsingLibraryClass.Test
{
    [TestClass]
    public class SimpleCalculator_UnitTestingClass_UsingClassLibrary
    {
        double numerator = 20, denominator = 4, actual = 0;
        [TestMethod]
        public void Test_Addition()
        {
            actual=Calculator.Library.Calculator.Add(numerator, denominator);
            Assert.AreEqual(24, actual);
        }
        [TestMethod]
        public void Test_Subtraction()
        {
            actual = Calculator.Library.Calculator.Sub(numerator, denominator);
            Assert.AreEqual(16, actual);
        }
        [TestMethod]
        public void Test_Multiplication()
        {
            actual = Calculator.Library.Calculator.Mul(numerator, denominator);
            Assert.AreEqual(80, actual);
        }
        [TestMethod]
        public void Test_Division()
        {
            actual = Calculator.Library.Calculator.Div(numerator, denominator);
            Assert.AreEqual(5, actual);
        }
    }
}
