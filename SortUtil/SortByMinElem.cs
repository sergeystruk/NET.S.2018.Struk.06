using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SortUtil
{
    /// <summary>
    /// Class with one Compare method to sort jagged array by min value of its rows
    /// </summary>
    public class SortByMinElem : IComparer<int[]>
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
        /// 1, if min of first element is bigger then min of second element
        /// -1, if min of first element is lower then min of second element
        /// 0, in other cases
        /// </returns>
        public int Compare(int[] a, int[] b)
        {
            if (a.Min() > b.Min())
            {
                return 1;
            }

            if (a.Min() < b.Min())
            {
                return -1;
            }

            return 0;
        }
    }
}