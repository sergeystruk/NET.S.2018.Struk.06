using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace SortUtil.Tests
{
    [TestFixture]
    public class AlgorithmTests
    {
        [Test]
        public void Sort_TestSortByMaxValue()
        {
            int[][] initArray = new int[3][];
            initArray[0] = new int[] { int.MaxValue, 321, 234 };
            initArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            initArray[2] = new int[] { 123, 111 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 123, 111 };
            expectedArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            expectedArray[2] = new int[] { int.MaxValue, 321, 234 };

            SortByMaxElem sortCase = new SortByMaxElem();
            Algorithm.Sort(initArray, sortCase);

            CollectionAssert.AreEqual(initArray,expectedArray);
        }

        [Test]
        public void Sort_TestSortByMinValue()
        {
            int[][] initArray = new int[3][];
            initArray[0] = new int[] { int.MaxValue, 321, 234 };
            initArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            initArray[2] = new int[] { 123, 111 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 789, 987, int.MinValue, 0, 15 };
            expectedArray[1] = new int[] {123, 111};
            expectedArray[2] = new int[] { int.MaxValue, 321, 234 };

            SortByMinElem sortCase = new SortByMinElem();
            Algorithm.Sort(initArray, sortCase);

            CollectionAssert.AreEqual(initArray, expectedArray);
        }

        [Test]
        public void Sort_TestSortBySum()
        {
            int[][] initArray = new int[3][];
            initArray[0] = new int[] { int.MaxValue, 321, 234 };
            initArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            initArray[2] = new int[] { 123, 111 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 789, 987, int.MinValue, 0, 15 };
            expectedArray[1] = new int[] { 123, 111 };
            expectedArray[2] = new int[] { int.MaxValue, 321, 234 };

            SortBySum sortCase = new SortBySum();
            Algorithm.Sort(initArray, sortCase);

            CollectionAssert.AreEqual(initArray, expectedArray);
        }

        [Test]
        public void Sort_TestWithNullSubArray()
        {
            int[][] initArray = new int[3][];
            initArray[0] = null;
            initArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            initArray[2] = new int[] { 123, 111 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 789, 987, int.MinValue, 0, 15 };
            expectedArray[1] = new int[] { 123, 111 };
            expectedArray[2] = null;

            SortBySum sortCase = new SortBySum();
            Algorithm.Sort(initArray, sortCase);

            CollectionAssert.AreEqual(initArray, expectedArray);
        }

        [Test]
        public void Sort_TestSortWithNullComparer()
        {
            int[][] initArray = new int[3][];
            initArray[0] = new int[] { int.MaxValue, 321, 234 };
            initArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            initArray[2] = new int[] { 123, 111 };

            int[][] expectedArray = new int[3][];
            expectedArray[0] = new int[] { 123, 111 };
            expectedArray[1] = new int[] { 789, 987, int.MinValue, 0, 15 };
            expectedArray[2] = new int[] { int.MaxValue, 321, 234 };
            
            Assert.Throws<ArgumentNullException>(() => Algorithm.Sort(initArray, null));
        }

        public void Sort_TestSortWithNullArray()
        {
            SortByMaxElem sortCase = new SortByMaxElem();
            Assert.Throws<ArgumentNullException>(() => Algorithm.Sort(null, sortCase));
        }
    }
}
