using System;
using System.Text;

namespace ImmutableType
{
    public class Polynom
    {
        #region Fields and properties

        private double[] arrayOfCoefficients { get; set; }

        #endregion
        
        #region Constructions

        public Polynom() : this(Array.Empty<double>()) { }

        public Polynom(double[] array)
        {
            arrayOfCoefficients = array;
        }

        #endregion

        #region Overrided object's methods

        public override string ToString()
        {
            if (arrayOfCoefficients == null)
            {
                throw new ArgumentNullException(nameof(arrayOfCoefficients));
            }

            StringBuilder returnString = new StringBuilder();
            returnString.Append($"({arrayOfCoefficients[0]})");
            for (int i = 1; i < arrayOfCoefficients.Length; i++)
            {
                returnString.Append($" + ({arrayOfCoefficients[i]})x^{i}");
            }
            
            return returnString.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynom comparePolynom = obj as Polynom;

            if ((object)comparePolynom == null)
            {
                return false;
            }

            if (arrayOfCoefficients.Length != comparePolynom.arrayOfCoefficients.Length)
            {
                return false;
            }

            for (int i = 0; i < this.arrayOfCoefficients.Length; i++)
            {
                if (arrayOfCoefficients[i].CompareTo(comparePolynom.arrayOfCoefficients[i]) != 0)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Overloaded operations

        private static Polynom Add(Polynom left, Polynom right)
        {
            double[] returnArray = new double[Math.Max(left.arrayOfCoefficients.Length, right.arrayOfCoefficients.Length)];
            int indexOfSmallerArray;
            double[] biggerArray;
            double[] smallerArray;

            if (right.arrayOfCoefficients.Length < left.arrayOfCoefficients.Length)
            {
                indexOfSmallerArray = right.arrayOfCoefficients.Length - 1;
                biggerArray = left.arrayOfCoefficients;
                smallerArray = right.arrayOfCoefficients;
            }
            else
            {
                indexOfSmallerArray = left.arrayOfCoefficients.Length - 1;
                biggerArray = right.arrayOfCoefficients;
                smallerArray = left.arrayOfCoefficients;
            }

            for (int i = 0; i < returnArray.Length; i++)
            {
                while (indexOfSmallerArray < smallerArray.Length)
                {
                    returnArray[i] = left.arrayOfCoefficients[i] + right.arrayOfCoefficients[i];
                    indexOfSmallerArray++;
                }

                returnArray[i] += biggerArray[i];
            }

            return new Polynom(returnArray);
        }

        private static Polynom Substruct(Polynom left, Polynom right)
        {
            double[] returnArray = new double[Math.Max(left.arrayOfCoefficients.Length, right.arrayOfCoefficients.Length)];
            int indexOfSmallerArray;
            double[] biggerArray;
            double[] smallerArray;

            if (right.arrayOfCoefficients.Length < left.arrayOfCoefficients.Length)
            {
                indexOfSmallerArray = right.arrayOfCoefficients.Length - 1;
                biggerArray = left.arrayOfCoefficients;
                smallerArray = right.arrayOfCoefficients;
            }
            else
            {
                indexOfSmallerArray = left.arrayOfCoefficients.Length - 1;
                biggerArray = right.arrayOfCoefficients;
                smallerArray = left.arrayOfCoefficients;
            }

            for (int i = 0; i < returnArray.Length; i++)
            {
                while (indexOfSmallerArray < smallerArray.Length)
                {
                    returnArray[i] = left.arrayOfCoefficients[i] - right.arrayOfCoefficients[i];
                    indexOfSmallerArray++;
                }

                returnArray[i] -= biggerArray[i];
            }

            return new Polynom(returnArray);
        }

        private static Polynom Multiply(Polynom left, Polynom right)
        {
            double[] returnArray = new double[left.arrayOfCoefficients.Length+right.arrayOfCoefficients.Length-1];

            for (int i = 0; i < left.arrayOfCoefficients.Length; i++)
            {
                for (int j = 0; j < right.arrayOfCoefficients.Length; j++)
                {
                    returnArray[i + j] += left.arrayOfCoefficients[i] * right.arrayOfCoefficients[j];
                }
            }

            return new Polynom(returnArray);
        }

        private static Polynom Devide(Polynom left, double value)
        {
            double[] returnArray = new double[left.arrayOfCoefficients.Length];

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = left.arrayOfCoefficients[i] / value;
            }

            return new Polynom(returnArray);
        }

        #endregion

        #region Overloaded operators

        public static Polynom operator +(Polynom left, Polynom right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (left.arrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.arrayOfCoefficients.Length == 0)
            {
                return left;
            }

            return Add(left, right);
        }

        public static Polynom operator -(Polynom left, Polynom right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (left.arrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.arrayOfCoefficients.Length == 0)
            {
                return left;
            }

            return Substruct(left, right);
        }

        public static Polynom operator *(Polynom left, Polynom right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (right == null)
            {
                throw new ArgumentNullException(nameof(right));
            }

            if (left.arrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.arrayOfCoefficients.Length == 0)
            {
                return left;
            }

            return Multiply(left, right);
        }

        public static Polynom operator /(Polynom left, double right)
        {
            if (left == null)
            {
                throw new ArgumentNullException(nameof(left));
            }

            if (left.arrayOfCoefficients.Length == 0)
            {
                return left;
            }

            if (right == 0)
            {
                throw new DivideByZeroException(nameof(right));
            }

            return Devide(left, right);
        }

        #endregion
    }
}
