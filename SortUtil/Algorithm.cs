using System;
using System.Collections.Generic;

namespace SortUtil
{
    /// <summary>
    /// Class gives one static method to sort jagged array
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
            int lengthWithoutNulls = array.Length;

            NullExclusion(array, ref lengthWithoutNulls);

            int i = 0;
            bool isSorted = true;

            while (isSorted)
            {
                isSorted = false;
                for (int j = 0; j < lengthWithoutNulls - i - 1; j++)
                {
                    if (comp.Compare(array[j], array[j + 1]) > 0)
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        isSorted = true;
                    }
                }

                i++;
            }
        }

        /// <summary>
        /// Method puts all null subarrays to the end of jagged array
        /// </summary>
        /// <param name="array">
        /// Initial array
        /// </param>
        /// <param name="lengthWithoutNulls">
        /// Length of array without elements which are null
        /// </param>
        private static void NullExclusion(int[][] array, ref int lengthWithoutNulls)
        {
            for (int j = 0; j < lengthWithoutNulls; j++)
            {
                if (array[j] == null && array[lengthWithoutNulls - 1] != null)
                {
                    Swap(ref array[j], ref array[lengthWithoutNulls - 1]);
                    lengthWithoutNulls--;
                }
                else
                {
                    while (array[lengthWithoutNulls - 1] == null && lengthWithoutNulls > j)
                    {
                        lengthWithoutNulls--;
                    }

                    Swap(ref array[j], ref array[lengthWithoutNulls - 1]);
                }
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