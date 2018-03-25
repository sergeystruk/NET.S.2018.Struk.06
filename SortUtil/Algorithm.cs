using System;
using System.Collections.Generic;

namespace SortUtil
{
    /// <summary>
    /// Class gives one static methodto sort jagged array
    /// </summary>
    public static class Algorithm
    {
        #region API
        
        /// <summary>
        /// Method which sorts array
        /// </summary>
        /// <param name="array">
        /// Initial jagged array to sort
        /// </param>
        /// <param name="comp">
        /// The case of sorting the array
        /// </param>
        public static void Sort(int[][] array, IComparer<int[]> comp)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (comp == null)
            {
                throw new ArgumentNullException(nameof(comp));
            }

            BubbleSort(array, comp);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Method which gives logic of BubbleSort
        /// </summary>
        /// <param name="array">
        /// Initial jagged array to sort
        /// </param>
        /// <param name="comp">
        /// The case of sorting the array
        /// </param>
        private static void BubbleSort(int[][] array, IComparer<int[]> comp)
        {
            int numberOfNulls = 0;
            for (int j = 0; j < array.Length - numberOfNulls; j++)
            {
                if (array[j] == null)
                {
                    Swap(ref array[j], ref array[array.Length-1-numberOfNulls]);
                    numberOfNulls++;
                }
            }

            int i = 0;
            bool t = true;
            int n = array.Length - numberOfNulls;

            while (t)
            {
                t = false;
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (comp.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        t = true;
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Method which swaps two elements
        /// </summary>
        /// <param name="a">
        /// First element
        /// </param>
        /// <param name="b">
        /// Second element
        /// </param>
        private static void Swap(ref int[] a, ref int[] b)
        {
            int[] temp = a;
            a = b;
            b = temp;
        }
    }
    
    #endregion
}