using System;
using System.Configuration;
using System.Text;

namespace ImmutableType
{
    public class Polynom
    {
        #region Fields and properties

        private double[] ArrayOfCoefficients { get; }  //DON'T FORGET TO REWRITE WITH C# 7.2 FEATURE (REF READONLY)
        private int degree { get; }
        private static double accuracy { get; }
        
        #endregion
        
        #region Constructions

        public Polynom() : this(Array.Empty<double>()) { }
        
        public Polynom(double[] array) //DON'T FORGET TO REWRITE IT WITH PARAMS!!!1!1
        {
            ArrayOfCoefficients = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                ArrayOfCoefficients[i] = array[i];
            }

            int index = ArrayOfCoefficients.Length - 1;
            while (ArrayOfCoefficients[index] == 0 && index >= 0)
            {
                index--;
            }

            degree = index;
        }

        static Polynom()
        {
            string str = ConfigurationManager.AppSettings.Get("Accuracy");

            try
            {
                accuracy = Double.Parse(str);
            }
            catch (Exception e)
            {
                accuracy = 0.000001;
            }
        }

        #endregion

        #region API

        public bool Equals(Polynom polynom)
        {
            if (polynom == null || polynom.GetType() != typeof(Polynom) ||
                ArrayOfCoefficients.Length != polynom.ArrayOfCoefficients.Length)
            {
                return false;
            }

            if (ReferenceEquals(this, polynom))
            {
                return true;
            }

            for (int i = 0; i < ArrayOfCoefficients.Length; i++)
            {
                if (ArrayOfCoefficients[i] - polynom.ArrayOfCoefficients[i] > accuracy)
                {
                    return false;
                }
            }

            return true;
        }

        #region Overrided object's methods

        public override string ToString()
        {
            if (ArrayOfCoefficients == null)
            {
                throw new ArgumentNullException(nameof(ArrayOfCoefficients));
            }

            StringBuilder returnString = new StringBuilder();
            returnString.Append($"({ArrayOfCoefficients[0]})");
            for (int i = 1; i < ArrayOfCoefficients.Length; i++)
            {
                returnString.Append($" + ({ArrayOfCoefficients[i]})x^{i}");
            }

            return returnString.ToString();
        }

        public override bool Equals(Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            Polynom comparePolynom = obj as Polynom;

            if (comparePolynom == null)
            {
                return false;
            }

            return Equals(comparePolynom);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        #region Overloaded operators

        public static Polynom operator -(Polynom polynom)
        {
            double[] newArray = new double[polynom.ArrayOfCoefficients.Length];
            for (int i = 0; i < newArray.Length; i++)
            {
                newArray[i] = -polynom.ArrayOfCoefficients[i];
            }

            return new Polynom(newArray);
        }

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

            if (left.ArrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.ArrayOfCoefficients.Length == 0)
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

            if (left.ArrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.ArrayOfCoefficients.Length == 0)
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

            if (left.ArrayOfCoefficients.Length == 0)
            {
                return right;
            }

            if (right.ArrayOfCoefficients.Length == 0)
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

            if (left.ArrayOfCoefficients.Length == 0)
            {
                return left;
            }

            if (right == 0)
            {
                throw new DivideByZeroException(nameof(right));
            }

            return Devide(left, right);
        }

        //public static bool operator ==(Polynom left, Polynom right)
        //{
        //    if (left == null)
        //    {
        //        throw new ArgumentNullException(nameof(left));
        //    }

        //    if (right == null)
        //    {
        //        throw new ArgumentNullException(nameof(right));
        //    }

        //    if (ReferenceEquals(left,right))
        //    {
        //        return true;
        //    }

        //    return left.Equals(right);
        //}

        //public static bool operator !=(Polynom left, Polynom right)
        //{
        //    return !left.Equals(right);
        //}

        #endregion

        #endregion
        
        #region Overloaded Methods

        private static Polynom Add(Polynom left, Polynom right)
        {
            double[] returnArray = new double[Math.Max(left.ArrayOfCoefficients.Length, right.ArrayOfCoefficients.Length)];
            int indexOfSmallerArray;
            double[] biggerArray;
            double[] smallerArray;

            if (right.ArrayOfCoefficients.Length < left.ArrayOfCoefficients.Length)
            {
                indexOfSmallerArray = right.ArrayOfCoefficients.Length - 1;
                biggerArray = left.ArrayOfCoefficients;
                smallerArray = right.ArrayOfCoefficients;
            }
            else
            {
                indexOfSmallerArray = left.ArrayOfCoefficients.Length - 1;
                biggerArray = right.ArrayOfCoefficients;
                smallerArray = left.ArrayOfCoefficients;
            }

            for (int i = 0; i < returnArray.Length; i++)
            {
                while (i <= indexOfSmallerArray)
                {
                    returnArray[i] = left.ArrayOfCoefficients[i] + right.ArrayOfCoefficients[i];
                    i++;
                }

                returnArray[i] += biggerArray[i];
            }

            return new Polynom(returnArray);
        }

        private static Polynom Substruct(Polynom left, Polynom right)
        {
            return Add(left, -right);
        }

        private static Polynom Multiply(Polynom left, Polynom right)
        {
            double[] returnArray = new double[left.ArrayOfCoefficients.Length+right.ArrayOfCoefficients.Length-1];

            for (int i = 0; i < left.ArrayOfCoefficients.Length; i++)
            {
                for (int j = 0; j < right.ArrayOfCoefficients.Length; j++)
                {
                    returnArray[i + j] += left.ArrayOfCoefficients[i] * right.ArrayOfCoefficients[j];
                }
            }

            return new Polynom(returnArray);
        }

        private static Polynom Devide(Polynom left, double value)
        {
            double[] returnArray = new double[left.ArrayOfCoefficients.Length];

            for (int i = 0; i < returnArray.Length; i++)
            {
                returnArray[i] = left.ArrayOfCoefficients[i] / value;
            }

            return new Polynom(returnArray);
        }

        #endregion
        
    }
}