using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime;

namespace MathNet.Numerics
{
	public static class ComplexExtensions
	{
		public static double MagnitudeSquared(this Complex32 complex)
		{
			return complex.Real * complex.Real + complex.Imaginary * complex.Imaginary;
		}

		public static double MagnitudeSquared(this Complex complex)
		{
			return complex.Real * complex.Real + complex.Imaginary * complex.Imaginary;
		}

		public static Complex Sign(this Complex complex)
		{
			if (double.IsPositiveInfinity(complex.Real) && double.IsPositiveInfinity(complex.Imaginary))
			{
				return new Complex(0.7071067811865476, 0.7071067811865476);
			}
			if (double.IsPositiveInfinity(complex.Real) && double.IsNegativeInfinity(complex.Imaginary))
			{
				return new Complex(0.7071067811865476, -0.7071067811865476);
			}
			if (double.IsNegativeInfinity(complex.Real) && double.IsPositiveInfinity(complex.Imaginary))
			{
				return new Complex(-0.7071067811865476, -0.7071067811865476);
			}
			if (double.IsNegativeInfinity(complex.Real) && double.IsNegativeInfinity(complex.Imaginary))
			{
				return new Complex(-0.7071067811865476, 0.7071067811865476);
			}
			double num = SpecialFunctions.Hypotenuse(complex.Real, complex.Imaginary);
			if (num == 0.0)
			{
				return Complex.Zero;
			}
			return new Complex(complex.Real / num, complex.Imaginary / num);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Conjugate(this Complex complex)
		{
			return Complex.Conjugate(complex);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Reciprocal(this Complex complex)
		{
			return Complex.Reciprocal(complex);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Exp(this Complex complex)
		{
			return Complex.Exp(complex);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Ln(this Complex complex)
		{
			return Complex.Log(complex);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Log10(this Complex complex)
		{
			return Complex.Log10(complex);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex Log(this Complex complex, double baseValue)
		{
			return Complex.Log(complex, baseValue);
		}

		public static Complex Power(this Complex complex, Complex exponent)
		{
			if (complex.IsZero())
			{
				if (exponent.IsZero())
				{
					return Complex.One;
				}
				if (exponent.Real > 0.0)
				{
					return Complex.Zero;
				}
				if (exponent.Real < 0.0)
				{
					if (exponent.Imaginary != 0.0)
					{
						return new Complex(double.PositiveInfinity, double.PositiveInfinity);
					}
					return new Complex(double.PositiveInfinity, 0.0);
				}
				return new Complex(double.NaN, double.NaN);
			}
			return Complex.Pow(complex, exponent);
		}

		public static Complex Root(this Complex complex, Complex rootExponent)
		{
			return Complex.Pow(complex, 1 / rootExponent);
		}

		public static Complex Square(this Complex complex)
		{
			if (complex.IsReal())
			{
				return new Complex(complex.Real * complex.Real, 0.0);
			}
			return new Complex(complex.Real * complex.Real - complex.Imaginary * complex.Imaginary, 2.0 * complex.Real * complex.Imaginary);
		}

		public static Complex SquareRoot(this Complex complex)
		{
			if (complex.IsRealNonNegative())
			{
				return new Complex(Math.Sqrt(complex.Real), 0.0);
			}
			double num = Math.Abs(complex.Real);
			double num2 = Math.Abs(complex.Imaginary);
			double num4;
			if (num >= num2)
			{
				double num3 = complex.Imaginary / complex.Real;
				num4 = Math.Sqrt(num) * Math.Sqrt(0.5 * (1.0 + Math.Sqrt(1.0 + num3 * num3)));
			}
			else
			{
				double num5 = complex.Real / complex.Imaginary;
				num4 = Math.Sqrt(num2) * Math.Sqrt(0.5 * (Math.Abs(num5) + Math.Sqrt(1.0 + num5 * num5)));
			}
			return (complex.Real >= 0.0) ? new Complex(num4, complex.Imaginary / (2.0 * num4)) : ((!(complex.Imaginary >= 0.0)) ? new Complex(num2 / (2.0 * num4), 0.0 - num4) : new Complex(num2 / (2.0 * num4), num4));
		}

		public static (Complex, Complex) SquareRoots(this Complex complex)
		{
			Complex complex2 = complex.SquareRoot();
			return (complex2, -complex2);
		}

		public static (Complex, Complex, Complex) CubicRoots(this Complex complex)
		{
			double magnitude = Math.Pow(complex.Magnitude, 1.0 / 3.0);
			double num = complex.Phase / 3.0;
			return (Complex.FromPolarCoordinates(magnitude, num), Complex.FromPolarCoordinates(magnitude, num + Math.PI * 2.0 / 3.0), Complex.FromPolarCoordinates(magnitude, num - Math.PI * 2.0 / 3.0));
		}

		public static bool IsZero(this Complex complex)
		{
			if (complex.Real == 0.0)
			{
				return complex.Imaginary == 0.0;
			}
			return false;
		}

		public static bool IsOne(this Complex complex)
		{
			if (complex.Real == 1.0)
			{
				return complex.Imaginary == 0.0;
			}
			return false;
		}

		public static bool IsImaginaryOne(this Complex complex)
		{
			if (complex.Real == 0.0)
			{
				return complex.Imaginary == 1.0;
			}
			return false;
		}

		public static bool IsNaN(this Complex complex)
		{
			if (!double.IsNaN(complex.Real))
			{
				return double.IsNaN(complex.Imaginary);
			}
			return true;
		}

		public static bool IsInfinity(this Complex complex)
		{
			if (!double.IsInfinity(complex.Real))
			{
				return double.IsInfinity(complex.Imaginary);
			}
			return true;
		}

		public static bool IsReal(this Complex complex)
		{
			return complex.Imaginary == 0.0;
		}

		public static bool IsRealNonNegative(this Complex complex)
		{
			if (complex.Imaginary == 0.0)
			{
				return complex.Real >= 0.0;
			}
			return false;
		}

		public static double Norm(this Complex complex)
		{
			return complex.MagnitudeSquared();
		}

		public static double Norm(this Complex32 complex)
		{
			return complex.MagnitudeSquared;
		}

		public static double NormOfDifference(this Complex complex, Complex otherValue)
		{
			return (complex - otherValue).MagnitudeSquared();
		}

		public static double NormOfDifference(this Complex32 complex, Complex32 otherValue)
		{
			return (complex - otherValue).MagnitudeSquared;
		}

		public static Complex ToComplex(this string value)
		{
			return value.ToComplex(null);
		}

		public static Complex ToComplex(this string value, IFormatProvider formatProvider)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			value = value.Trim();
			if (value.Length == 0)
			{
				throw new FormatException();
			}
			if (value.StartsWith("(", StringComparison.Ordinal))
			{
				if (!value.EndsWith(")", StringComparison.Ordinal))
				{
					throw new FormatException();
				}
				value = value.Substring(1, value.Length - 2).Trim();
			}
			NumberFormatInfo numberFormatInfo = formatProvider.GetNumberFormatInfo();
			TextInfo textInfo = formatProvider.GetTextInfo();
			string[] keywords = new string[8] { textInfo.ListSeparator, numberFormatInfo.NaNSymbol, numberFormatInfo.NegativeInfinitySymbol, numberFormatInfo.PositiveInfinitySymbol, "+", "-", "i", "j" };
			LinkedList<string> linkedList = new LinkedList<string>();
			GlobalizationHelper.Tokenize(linkedList.AddFirst(value), keywords, 0);
			LinkedListNode<string> token = linkedList.First;
			bool imaginary;
			double num = ParsePart(ref token, out imaginary, formatProvider);
			if (token == null)
			{
				if (!imaginary)
				{
					return new Complex(num, 0.0);
				}
				return new Complex(0.0, num);
			}
			if (token.Value == textInfo.ListSeparator)
			{
				token = token.Next;
				if (imaginary)
				{
					throw new FormatException();
				}
				bool imaginary3;
				double imaginary2 = ParsePart(ref token, out imaginary3, formatProvider);
				return new Complex(num, imaginary2);
			}
			bool imaginary4;
			double num2 = ParsePart(ref token, out imaginary4, formatProvider);
			if (!(imaginary ^ imaginary4))
			{
				throw new FormatException();
			}
			if (!imaginary)
			{
				return new Complex(num, num2);
			}
			return new Complex(num2, num);
		}

		private static double ParsePart(ref LinkedListNode<string> token, out bool imaginary, IFormatProvider format)
		{
			imaginary = false;
			if (token == null)
			{
				throw new FormatException();
			}
			if (token.Value == "+")
			{
				token = token.Next;
				if (token == null)
				{
					throw new FormatException();
				}
			}
			bool flag = false;
			if (token.Value == "-")
			{
				flag = true;
				token = token.Next;
				if (token == null)
				{
					throw new FormatException();
				}
			}
			if (string.Compare(token.Value, "i", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(token.Value, "j", StringComparison.OrdinalIgnoreCase) == 0)
			{
				imaginary = true;
				token = token.Next;
				if (token == null)
				{
					return (!flag) ? 1 : (-1);
				}
			}
			double num = GlobalizationHelper.ParseDouble(ref token, format.GetCultureInfo());
			if (token != null && (string.Compare(token.Value, "i", StringComparison.OrdinalIgnoreCase) == 0 || string.Compare(token.Value, "j", StringComparison.OrdinalIgnoreCase) == 0))
			{
				if (imaginary)
				{
					throw new FormatException();
				}
				imaginary = true;
				token = token.Next;
			}
			if (!flag)
			{
				return num;
			}
			return 0.0 - num;
		}

		public static bool TryToComplex(this string value, out Complex result)
		{
			return value.TryToComplex(null, out result);
		}

		public static bool TryToComplex(this string value, IFormatProvider formatProvider, out Complex result)
		{
			try
			{
				result = value.ToComplex(formatProvider);
				return true;
			}
			catch (ArgumentNullException)
			{
				result = Complex.Zero;
				return false;
			}
			catch (FormatException)
			{
				result = Complex.Zero;
				return false;
			}
		}

		public static Complex32 ToComplex32(this string value)
		{
			return Complex32.Parse(value);
		}

		public static Complex32 ToComplex32(this string value, IFormatProvider formatProvider)
		{
			return Complex32.Parse(value, formatProvider);
		}

		public static bool TryToComplex32(this string value, out Complex32 result)
		{
			return Complex32.TryParse(value, out result);
		}

		public static bool TryToComplex32(this string value, IFormatProvider formatProvider, out Complex32 result)
		{
			return Complex32.TryParse(value, formatProvider, out result);
		}
	}
}
