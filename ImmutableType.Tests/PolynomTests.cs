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
        [Test]
        public void ToString_Test()
        {
            double[] coefficients = {3.2, -4.5, 7.88, -99.87};
            Polynom p = new Polynom(coefficients);

            string result = "(3,2) + (-4,5)x^1 + (7,88)x^2 + (-99,87)x^3";

            Assert.AreEqual(p.ToString(), result);
        }


    }
}
