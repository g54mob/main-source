using System;
using System.Globalization;

namespace NGenerics.DataStructures.Mathematical
{
	[Serializable]
	public struct ComplexNumber : IEquatable<ComplexNumber>, ICloneable
	{
		private double real;

		private double imaginary;

		public ComplexNumber Conjugate
		{
			get
			{
				return new ComplexNumber(real, -1.0 * imaginary);
			}
		}

		public double Modulus
		{
			get
			{
				return Math.Sqrt(real * real + imaginary * imaginary);
			}
		}

		public double Real
		{
			get
			{
				return real;
			}
			set
			{
				real = value;
			}
		}

		public double Imaginary
		{
			get
			{
				return imaginary;
			}
			set
			{
				imaginary = value;
			}
		}

		public ComplexNumber AdditiveInverse
		{
			get
			{
				return new ComplexNumber(real * -1.0, imaginary * -1.0);
			}
		}

		public double AbsoluteValue
		{
			get
			{
				return Math.Sqrt(real * real + imaginary * imaginary);
			}
		}

		public ComplexNumber Reciprocal
		{
			get
			{
				if (real == 0.0 && imaginary == 0.0)
				{
					throw new InvalidOperationException("Finding the Reciprocal of the complex number is only defined for non-zero (real, imaginary) numbers.");
				}
				double num = real * real + imaginary * imaginary;
				return new ComplexNumber(real / num, imaginary * -1.0 / num);
			}
		}

		public static ComplexNumber AdditiveIdentity
		{
			get
			{
				return new ComplexNumber(0.0, 0.0);
			}
		}

		public static ComplexNumber MultiplicativeIdentity
		{
			get
			{
				return new ComplexNumber(1.0, 0.0);
			}
		}

		public ComplexNumber(double real, double imaginary)
		{
			this.real = real;
			this.imaginary = imaginary;
		}

		public bool Equals(ComplexNumber other)
		{
			return this == other;
		}

		public ComplexNumber Multiply(ComplexNumber complex)
		{
			return MultiplyInternal(this, complex);
		}

		public ComplexNumber Multiply(double number)
		{
			return MultiplyInternal(this, number);
		}

		public ComplexNumber Divide(ComplexNumber number)
		{
			return DivideInternal(this, number);
		}

		public ComplexNumber Divide(double number)
		{
			return DivideInternal(this, number);
		}

		public ComplexNumber Add(ComplexNumber number)
		{
			return AddInternal(this, number);
		}

		public ComplexNumber Subtract(ComplexNumber complex)
		{
			return SubtractInternal(this, complex);
		}

		public IMathematicalMatrix ToMatrix()
		{
			Matrix matrix = new Matrix(2, 2);
			matrix[0, 0] = real;
			matrix[0, 1] = -1.0 * imaginary;
			matrix[1, 0] = imaginary;
			matrix[1, 1] = real;
			return matrix;
		}

		public static ComplexNumber operator +(ComplexNumber left, ComplexNumber right)
		{
			return AddInternal(left, right);
		}

		public static ComplexNumber operator -(ComplexNumber left, ComplexNumber right)
		{
			return SubtractInternal(left, right);
		}

		public static ComplexNumber operator *(ComplexNumber left, ComplexNumber right)
		{
			return MultiplyInternal(left, right);
		}

		public static ComplexNumber operator /(ComplexNumber left, ComplexNumber right)
		{
			return DivideInternal(left, right);
		}

		public static ComplexNumber operator /(ComplexNumber complexNumber, double number)
		{
			return DivideInternal(complexNumber, number);
		}

		public static ComplexNumber operator *(ComplexNumber complexNumber, double number)
		{
			return MultiplyInternal(complexNumber, number);
		}

		public static ComplexNumber operator *(double number, ComplexNumber complexNumber)
		{
			return new ComplexNumber(complexNumber.real * number, complexNumber.imaginary * number);
		}

		public static bool operator ==(ComplexNumber left, ComplexNumber right)
		{
			if (left.real == right.real)
			{
				return left.imaginary == right.imaginary;
			}
			return false;
		}

		public static bool operator !=(ComplexNumber left, ComplexNumber right)
		{
			return !(left == right);
		}

		public static explicit operator string(ComplexNumber complexNumber)
		{
			return complexNumber.ToString();
		}

		public static implicit operator ComplexNumber(double real)
		{
			return new ComplexNumber(real, 0.0);
		}

		bool IEquatable<ComplexNumber>.Equals(ComplexNumber other)
		{
			if (real == other.real)
			{
				return imaginary == other.imaginary;
			}
			return false;
		}

		public object Clone()
		{
			return new ComplexNumber(real, imaginary);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} + {1}i", real, imaginary);
		}

		public override bool Equals(object obj)
		{
			if (obj == null || obj.GetType() != GetType())
			{
				return false;
			}
			return this == (ComplexNumber)obj;
		}

		public override int GetHashCode()
		{
			return real.GetHashCode() ^ (imaginary.GetHashCode() & real.GetHashCode());
		}

		private static ComplexNumber MultiplyInternal(ComplexNumber left, ComplexNumber right)
		{
			return new ComplexNumber(left.Real * right.Real - left.Imaginary * right.Imaginary, left.Real * right.Imaginary + left.Imaginary * right.Real);
		}

		private static ComplexNumber MultiplyInternal(ComplexNumber left, double right)
		{
			return new ComplexNumber(left.Real * right, left.Imaginary * right);
		}

		private static ComplexNumber DivideInternal(ComplexNumber left, double right)
		{
			return new ComplexNumber(left.Real / right, left.Imaginary / right);
		}

		private static ComplexNumber DivideInternal(ComplexNumber left, ComplexNumber right)
		{
			ComplexNumber conjugate = right.Conjugate;
			ComplexNumber complexNumber = left.Multiply(conjugate);
			ComplexNumber complexNumber2 = right.Multiply(conjugate);
			return new ComplexNumber(complexNumber.Real / complexNumber2.Real, complexNumber.Imaginary / complexNumber2.Real);
		}

		private static ComplexNumber AddInternal(ComplexNumber left, ComplexNumber right)
		{
			return new ComplexNumber(left.Real + right.Real, left.Imaginary + right.Imaginary);
		}

		private static ComplexNumber SubtractInternal(ComplexNumber left, ComplexNumber right)
		{
			return new ComplexNumber(left.Real - right.Real, left.Imaginary - right.Imaginary);
		}
	}
}
