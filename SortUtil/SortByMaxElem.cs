using System.Collections.Generic;
using System.Linq;

namespace SortUtil
{
    /// <summary>
    /// Class with one Compare method to sort jagged array by max value of its rows
    /// </summary>
    public class SortByMaxElem : IComparer<int[]>
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
        /// 1, if max of first element is bigger then max of second
        /// -1, if max of first element is lower then max of second
        /// 0, in other cases
        /// </returns>
        public int Compare(int[] a, int[] b)
        {
            if (a.Max() > b.Max())
            {
                return 1;
            }

            if (a.Max() < b.Max())
            {
                return -1;
            }

            return 0;
        }
    }
}