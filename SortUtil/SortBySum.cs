using System.Collections;
using System.Collections.Generic;

namespace SortUtil
{
    /// <summary>
    /// Class with one Compare method to sort jagged array by sum of values in its rows
    /// </summary>
    public class SortBySum:IComparer<int[]>
    {
        /// <summary>
        /// Overrided IComparer method 
        /// </summary>
        /// <param name="a">
        /// First element
        /// </param>
        /// <param name="b">
        /// Second element
        /// </param>
        /// <returns>
        /// 1, if sum of first element is bigger then sum of second
        /// -1, if sum of first element is lower then sum of second
        /// 0, in other cases
        /// </returns>
        public int Compare(int[] a, int[] b)
        {
            long sumA = 0;
            long sumB = 0;

            if (a.Length < b.Length)
            {
                for (int i = 0; i < b.Length; i++)
                {
                    if (i < a.Length)
                    {
                        sumA += a[i];
                    }

                    sumB += b[i];
                }
            }
            else
            {
                for (int i = 0; i < a.Length; i++)
                {
                    if (i < b.Length)
                    {
                        sumB += b[i];
                    }

                    sumA += a[i];
                }
            }

            if (sumA > sumB)
            {
                return 1;
            }

            if (sumA < sumB)
            {
                return -1;
            }

            return 0;
        }
    }
}