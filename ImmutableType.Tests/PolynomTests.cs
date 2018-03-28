using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ImmutableType;

namespace ImmutableType.Tests
{
    [TestFixture]
    public class PolynomTests
    {
        private static double[] firstArray = { 3.2, -4.5, 7.88, -99.87 };
        private static double[] secondArray = {-3.2, 5.6, 11};

        private static Polynom first = new Polynom(firstArray);
        private static Polynom second = new Polynom(secondArray);

        [Test]
        public void ToString_Test()
        {
            double[] ar = { 3.2, -4.5, 7.88, -99.87 };
            Polynom p = new Polynom(ar);
            string result = "(3,2) + (-4,5)x^1 + (7,88)x^2 + (-99,87)x^3";

            Assert.AreEqual(first.ToString(), result);
        }

        [Test]
        public void AdditionTest()
        {
            double[] expectedArray = {0, 1.1, 18.88, -98.87};

            Polynom actual = first + second;
            Polynom expected = new Polynom(expectedArray);

            Assert.AreEqual(actual, expected);
        }


    }
}
