using NUnit.Framework;

namespace ImmutableType.Tests
{
    [TestFixture]
    public class PolynomTests
    {
        private static readonly double[] firstArray = { 3.2, -4.5, 7.88, -99.87 };
        private static readonly double[] secondArray = {-3.2, 5.6, 11};

        private static Polynom first = new Polynom(firstArray);
        private static Polynom second = new Polynom(secondArray);

        [Test]
        public void Polynom_ToStringTest()
        {
            double[] ar = { 3.2, -4.5, 7.88, -99.87 };
            Polynom p = new Polynom(ar);
            string result = "(3,2) + (-4,5)x^1 + (7,88)x^2 + (-99,87)x^3";

            Assert.AreEqual(first.ToString(), result);
        }

        [Test]
        public void Polynom_AdditionTest()
        {
            double[] expectedArray = {0, 1.1, 18.88, -98.87};

            Polynom actual = first + second;
            Polynom expected = new Polynom(expectedArray);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Polynom_SubstructionTest()
        {
            double[] expectedArray = {6.4, -10.1, -3.12, -99.87};

            Polynom actual = first - second;
            Polynom expected = new Polynom(expectedArray);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Polynom_MultyplyingTest()
        {
            double[] expectedArray = { -10.24, -2.56, 96.256, 345.856, -645.952, -1098.57 };

            Polynom actual = first * second;
            Polynom expected = new Polynom(expectedArray);

            Assert.AreEqual(actual, expected);
        }

        [Test]
        public void Polynom_DivisonTest()
        {
            double[] expectedArray = { -1.6, 2.8, 5.5 };

            Polynom actual = second / 2;
            Polynom expected = new Polynom(expectedArray);

            Assert.AreEqual(actual, expected);
        }
    }
}
