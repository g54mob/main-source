using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime;
using System.Runtime.Serialization;

namespace MathNet.Numerics
{
	[Serializable]
	[DataContract(Namespace = "urn:MathNet/Numerics")]
	public readonly struct Complex32 : IFormattable, IEquatable<Complex32>
	{
		[DataMember(Order = 1)]
		private readonly float _real;

		[DataMember(Order = 2)]
		private readonly float _imag;

		public static readonly Complex32 Zero = new Complex32(0f, 0f);

		public static readonly Complex32 One = new Complex32(1f, 0f);

		public static readonly Complex32 ImaginaryOne = new Complex32(0f, 1f);

		public static readonly Complex32 PositiveInfinity = new Complex32(float.PositiveInfinity, float.PositiveInfinity);

		public static readonly Complex32 NaN = new Complex32(float.NaN, float.NaN);

		public float Real
		{
			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
			get
			{
				return _real;
			}
		}

		public float Imaginary
		{
			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
			get
			{
				return _imag;
			}
		}

		public float Phase
		{
			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
			get
			{
				if (_imag != 0f || !(_real < 0f))
				{
					return (float)Math.Atan2(_imag, _real);
				}
				return MathF.PI;
			}
		}

		public float Magnitude
		{
			[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
			get
			{
				if (float.IsNaN(_real) || float.IsNaN(_imag))
				{
					return float.NaN;
				}
				if (float.IsInfinity(_real) || float.IsInfinity(_imag))
				{
					return float.PositiveInfinity;
				}
				float num = Math.Abs(_real);
				float num2 = Math.Abs(_imag);
				if (num > num2)
				{
					double num3 = num2 / num;
					return num * (float)Math.Sqrt(1.0 + num3 * num3);
				}
				if (num == 0f)
				{
					return num2;
				}
				double num4 = num / num2;
				return num2 * (float)Math.Sqrt(1.0 + num4 * num4);
			}
		}

		public float MagnitudeSquared => _real * _real + _imag * _imag;

		public Complex32 Sign
		{
			get
			{
				if (float.IsPositiveInfinity(_real) && float.IsPositiveInfinity(_imag))
				{
					return new Complex32(0.70710677f, 0.70710677f);
				}
				if (float.IsPositiveInfinity(_real) && float.IsNegativeInfinity(_imag))
				{
					return new Complex32(0.70710677f, -0.70710677f);
				}
				if (float.IsNegativeInfinity(_real) && float.IsPositiveInfinity(_imag))
				{
					return new Complex32(-0.70710677f, -0.70710677f);
				}
				if (float.IsNegativeInfinity(_real) && float.IsNegativeInfinity(_imag))
				{
					return new Complex32(-0.70710677f, 0.70710677f);
				}
				float num = SpecialFunctions.Hypotenuse(_real, _imag);
				if (num == 0f)
				{
					return Zero;
				}
				return new Complex32(_real / num, _imag / num);
			}
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public Complex32(float real, float imaginary)
		{
			_real = real;
			_imag = imaginary;
		}

		public static Complex32 FromPolarCoordinates(float magnitude, float phase)
		{
			return new Complex32(magnitude * (float)Math.Cos(phase), magnitude * (float)Math.Sin(phase));
		}

		public bool IsZero()
		{
			if (_real == 0f)
			{
				return _imag == 0f;
			}
			return false;
		}

		public bool IsOne()
		{
			if (_real == 1f)
			{
				return _imag == 0f;
			}
			return false;
		}

		public bool IsImaginaryOne()
		{
			if (_real == 0f)
			{
				return _imag == 1f;
			}
			return false;
		}

		public bool IsNaN()
		{
			if (!float.IsNaN(_real))
			{
				return float.IsNaN(_imag);
			}
			return true;
		}

		public bool IsInfinity()
		{
			if (!float.IsInfinity(_real))
			{
				return float.IsInfinity(_imag);
			}
			return true;
		}

		public bool IsReal()
		{
			return _imag == 0f;
		}

		public bool IsRealNonNegative()
		{
			if (_imag == 0f)
			{
				return _real >= 0f;
			}
			return false;
		}

		public Complex32 Exponential()
		{
			float num = (float)Math.Exp(_real);
			if (IsReal())
			{
				return new Complex32(num, 0f);
			}
			return new Complex32(num * (float)Math.Cos(_imag), num * (float)Math.Sin(_imag));
		}

		public Complex32 NaturalLogarithm()
		{
			if (IsRealNonNegative())
			{
				return new Complex32((float)Math.Log(_real), 0f);
			}
			return new Complex32(0.5f * (float)Math.Log(MagnitudeSquared), Phase);
		}

		public Complex32 CommonLogarithm()
		{
			return NaturalLogarithm() / 2.3025851f;
		}

		public Complex32 Logarithm(float baseValue)
		{
			return NaturalLogarithm() / (float)Math.Log(baseValue);
		}

		public Complex32 Power(Complex32 exponent)
		{
			if (IsZero())
			{
				if (exponent.IsZero())
				{
					return One;
				}
				if (exponent.Real > 0f)
				{
					return Zero;
				}
				if (exponent.Real < 0f)
				{
					if (exponent.Imaginary != 0f)
					{
						return new Complex32(float.PositiveInfinity, float.PositiveInfinity);
					}
					return new Complex32(float.PositiveInfinity, 0f);
				}
				return NaN;
			}
			return (exponent * NaturalLogarithm()).Exponential();
		}

		public Complex32 Root(Complex32 rootExponent)
		{
			return Power(1f / rootExponent);
		}

		public Complex32 Square()
		{
			if (IsReal())
			{
				return new Complex32(_real * _real, 0f);
			}
			return new Complex32(_real * _real - _imag * _imag, 2f * _real * _imag);
		}

		public Complex32 SquareRoot()
		{
			if (IsRealNonNegative())
			{
				return new Complex32((float)Math.Sqrt(_real), 0f);
			}
			float num = Math.Abs(Real);
			float num2 = Math.Abs(Imaginary);
			double num4;
			if (num >= num2)
			{
				float num3 = Imaginary / Real;
				num4 = Math.Sqrt(num) * Math.Sqrt(0.5 * (1.0 + Math.Sqrt(1f + num3 * num3)));
			}
			else
			{
				float num5 = Real / Imaginary;
				num4 = Math.Sqrt(num2) * Math.Sqrt(0.5 * ((double)Math.Abs(num5) + Math.Sqrt(1f + num5 * num5)));
			}
			return (Real >= 0f) ? new Complex32((float)num4, (float)((double)Imaginary / (2.0 * num4))) : ((!(Imaginary >= 0f)) ? new Complex32((float)((double)num2 / (2.0 * num4)), (float)(0.0 - num4)) : new Complex32((float)((double)num2 / (2.0 * num4)), (float)num4));
		}

		public (Complex32, Complex32) SquareRoots()
		{
			Complex32 complex = SquareRoot();
			return (complex, -complex);
		}

		public (Complex32, Complex32, Complex32) CubicRoots()
		{
			float magnitude = (float)Math.Pow(Magnitude, 1.0 / 3.0);
			float num = Phase / 3f;
			return (FromPolarCoordinates(magnitude, num), FromPolarCoordinates(magnitude, num + MathF.PI * 2f / 3f), FromPolarCoordinates(magnitude, num - MathF.PI * 2f / 3f));
		}

		public static bool operator ==(Complex32 complex1, Complex32 complex2)
		{
			return complex1.Equals(complex2);
		}

		public static bool operator !=(Complex32 complex1, Complex32 complex2)
		{
			return !complex1.Equals(complex2);
		}

		public static Complex32 operator +(Complex32 summand)
		{
			return summand;
		}

		public static Complex32 operator -(Complex32 subtrahend)
		{
			return new Complex32(0f - subtrahend._real, 0f - subtrahend._imag);
		}

		public static Complex32 operator +(Complex32 summand1, Complex32 summand2)
		{
			return new Complex32(summand1._real + summand2._real, summand1._imag + summand2._imag);
		}

		public static Complex32 operator -(Complex32 minuend, Complex32 subtrahend)
		{
			return new Complex32(minuend._real - subtrahend._real, minuend._imag - subtrahend._imag);
		}

		public static Complex32 operator +(Complex32 summand1, float summand2)
		{
			return new Complex32(summand1._real + summand2, summand1._imag);
		}

		public static Complex32 operator -(Complex32 minuend, float subtrahend)
		{
			return new Complex32(minuend._real - subtrahend, minuend._imag);
		}

		public static Complex32 operator +(float summand1, Complex32 summand2)
		{
			return new Complex32(summand2._real + summand1, summand2._imag);
		}

		public static Complex32 operator -(float minuend, Complex32 subtrahend)
		{
			return new Complex32(minuend - subtrahend._real, 0f - subtrahend._imag);
		}

		public static Complex32 operator *(Complex32 multiplicand, Complex32 multiplier)
		{
			return new Complex32(multiplicand._real * multiplier._real - multiplicand._imag * multiplier._imag, multiplicand._real * multiplier._imag + multiplicand._imag * multiplier._real);
		}

		public static Complex32 operator *(float multiplicand, Complex32 multiplier)
		{
			return new Complex32(multiplier._real * multiplicand, multiplier._imag * multiplicand);
		}

		public static Complex32 operator *(Complex32 multiplicand, float multiplier)
		{
			return new Complex32(multiplicand._real * multiplier, multiplicand._imag * multiplier);
		}

		public static Complex32 operator /(Complex32 dividend, Complex32 divisor)
		{
			if (dividend.IsZero() && divisor.IsZero())
			{
				return NaN;
			}
			if (divisor.IsZero())
			{
				return PositiveInfinity;
			}
			float real = dividend.Real;
			float imaginary = dividend.Imaginary;
			float real2 = divisor.Real;
			float imaginary2 = divisor.Imaginary;
			if (Math.Abs(imaginary2) <= Math.Abs(real2))
			{
				return InternalDiv(real, imaginary, real2, imaginary2, swapped: false);
			}
			return InternalDiv(imaginary, real, imaginary2, real2, swapped: true);
		}

		private static Complex32 InternalDiv(float a, float b, float c, float d, bool swapped)
		{
			float num = d / c;
			float num2 = 1f / (c + d * num);
			float real;
			float num3;
			if (num != 0f)
			{
				real = (a + b * num) * num2;
				num3 = (b - a * num) * num2;
			}
			else
			{
				real = (a + d * (b / c)) * num2;
				num3 = (b - d * (a / c)) * num2;
			}
			if (swapped)
			{
				num3 = 0f - num3;
			}
			return new Complex32(real, num3);
		}

		public static Complex32 operator /(float dividend, Complex32 divisor)
		{
			if (dividend == 0f && divisor.IsZero())
			{
				return NaN;
			}
			if (divisor.IsZero())
			{
				return PositiveInfinity;
			}
			float real = divisor.Real;
			float imaginary = divisor.Imaginary;
			if (Math.Abs(imaginary) <= Math.Abs(real))
			{
				return InternalDiv(dividend, 0f, real, imaginary, swapped: false);
			}
			return InternalDiv(0f, dividend, imaginary, real, swapped: true);
		}

		public static Complex32 operator /(Complex32 dividend, float divisor)
		{
			if (dividend.IsZero() && divisor == 0f)
			{
				return NaN;
			}
			if (divisor == 0f)
			{
				return PositiveInfinity;
			}
			return new Complex32(dividend._real / divisor, dividend._imag / divisor);
		}

		public Complex32 Conjugate()
		{
			return new Complex32(_real, 0f - _imag);
		}

		public Complex32 Reciprocal()
		{
			if (IsZero())
			{
				return Zero;
			}
			return 1f / this;
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.CurrentCulture, "({0}, {1})", _real, _imag);
		}

		public string ToString(string format)
		{
			CultureInfo currentCulture = CultureInfo.CurrentCulture;
			float real = _real;
			string arg = real.ToString(format, CultureInfo.CurrentCulture);
			real = _imag;
			return string.Format(currentCulture, "({0}, {1})", arg, real.ToString(format, CultureInfo.CurrentCulture));
		}

		public string ToString(IFormatProvider provider)
		{
			return string.Format(provider, "({0}, {1})", _real, _imag);
		}

		public string ToString(string format, IFormatProvider provider)
		{
			float real = _real;
			string arg = real.ToString(format, provider);
			real = _imag;
			return string.Format(provider, "({0}, {1})", arg, real.ToString(format, provider));
		}

		public bool Equals(Complex32 other)
		{
			if (IsNaN() || other.IsNaN())
			{
				return false;
			}
			if (IsInfinity() && other.IsInfinity())
			{
				return true;
			}
			if (_real.AlmostEqual(other._real))
			{
				return _imag.AlmostEqual(other._imag);
			}
			return false;
		}

		public override int GetHashCode()
		{
			int num = 27;
			int num2 = 13 * num;
			float real = _real;
			num = num2 + real.GetHashCode();
			int num3 = 13 * num;
			real = _imag;
			return num3 + real.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is Complex32 other)
			{
				return Equals(other);
			}
			return false;
		}

		public static Complex32 Parse(string value, IFormatProvider formatProvider = null)
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
			float num = ParsePart(ref token, out imaginary, formatProvider);
			if (token == null)
			{
				if (!imaginary)
				{
					return new Complex32(num, 0f);
				}
				return new Complex32(0f, num);
			}
			if (token.Value == textInfo.ListSeparator)
			{
				token = token.Next;
				if (imaginary)
				{
					throw new FormatException();
				}
				bool imaginary3;
				float imaginary2 = ParsePart(ref token, out imaginary3, formatProvider);
				return new Complex32(num, imaginary2);
			}
			bool imaginary4;
			float num2 = ParsePart(ref token, out imaginary4, formatProvider);
			if (!(imaginary ^ imaginary4))
			{
				throw new FormatException();
			}
			if (!imaginary)
			{
				return new Complex32(num, num2);
			}
			return new Complex32(num2, num);
		}

		private static float ParsePart(ref LinkedListNode<string> token, out bool imaginary, IFormatProvider format)
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
			float num = GlobalizationHelper.ParseSingle(ref token, format.GetCultureInfo());
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
			return 0f - num;
		}

		public static bool TryParse(string value, out Complex32 result)
		{
			return TryParse(value, null, out result);
		}

		public static bool TryParse(string value, IFormatProvider formatProvider, out Complex32 result)
		{
			try
			{
				result = Parse(value, formatProvider);
				return true;
			}
			catch (ArgumentNullException)
			{
				result = Zero;
				return false;
			}
			catch (FormatException)
			{
				result = Zero;
				return false;
			}
		}

		public static explicit operator Complex32(decimal value)
		{
			return new Complex32((float)value, 0f);
		}

		public static explicit operator Complex32(Complex value)
		{
			return new Complex32((float)value.Real, (float)value.Imaginary);
		}

		public static implicit operator Complex32(byte value)
		{
			return new Complex32((int)value, 0f);
		}

		public static implicit operator Complex32(short value)
		{
			return new Complex32(value, 0f);
		}

		[CLSCompliant(false)]
		public static implicit operator Complex32(sbyte value)
		{
			return new Complex32(value, 0f);
		}

		[CLSCompliant(false)]
		public static implicit operator Complex32(ushort value)
		{
			return new Complex32((int)value, 0f);
		}

		public static implicit operator Complex32(int value)
		{
			return new Complex32(value, 0f);
		}

		public static implicit operator Complex32(BigInteger value)
		{
			return new Complex32((long)value, 0f);
		}

		public static implicit operator Complex32(long value)
		{
			return new Complex32(value, 0f);
		}

		[CLSCompliant(false)]
		public static implicit operator Complex32(uint value)
		{
			return new Complex32(value, 0f);
		}

		[CLSCompliant(false)]
		public static implicit operator Complex32(ulong value)
		{
			return new Complex32(value, 0f);
		}

		public static implicit operator Complex32(float value)
		{
			return new Complex32(value, 0f);
		}

		public static explicit operator Complex32(double value)
		{
			return new Complex32((float)value, 0f);
		}

		public Complex ToComplex()
		{
			return new Complex(_real, _imag);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Negate(Complex32 value)
		{
			return -value;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Conjugate(Complex32 value)
		{
			return value.Conjugate();
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Add(Complex32 left, Complex32 right)
		{
			return left + right;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Subtract(Complex32 left, Complex32 right)
		{
			return left - right;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Multiply(Complex32 left, Complex32 right)
		{
			return left * right;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Divide(Complex32 dividend, Complex32 divisor)
		{
			return dividend / divisor;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Reciprocal(Complex32 value)
		{
			return value.Reciprocal();
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Sqrt(Complex32 value)
		{
			return value.SquareRoot();
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static double Abs(Complex32 value)
		{
			return value.Magnitude;
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Exp(Complex32 value)
		{
			return value.Exponential();
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Pow(Complex32 value, Complex32 power)
		{
			return value.Power(power);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Pow(Complex32 value, float power)
		{
			return value.Power(power);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Log(Complex32 value)
		{
			return value.NaturalLogarithm();
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Log(Complex32 value, float baseValue)
		{
			return value.Logarithm(baseValue);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		public static Complex32 Log10(Complex32 value)
		{
			return value.CommonLogarithm();
		}

		public static Complex32 Sin(Complex32 value)
		{
			return (Complex32)value.ToComplex().Sin();
		}

		public static Complex32 Cos(Complex32 value)
		{
			return (Complex32)value.ToComplex().Cos();
		}

		public static Complex32 Tan(Complex32 value)
		{
			return (Complex32)value.ToComplex().Tan();
		}

		public static Complex32 Asin(Complex32 value)
		{
			return (Complex32)value.ToComplex().Asin();
		}

		public static Complex32 Acos(Complex32 value)
		{
			return (Complex32)value.ToComplex().Acos();
		}

		public static Complex32 Atan(Complex32 value)
		{
			return (Complex32)value.ToComplex().Atan();
		}

		public static Complex32 Sinh(Complex32 value)
		{
			return (Complex32)value.ToComplex().Sinh();
		}

		public static Complex32 Cosh(Complex32 value)
		{
			return (Complex32)value.ToComplex().Cosh();
		}

		public static Complex32 Tanh(Complex32 value)
		{
			return (Complex32)value.ToComplex().Tanh();
		}
	}
}
