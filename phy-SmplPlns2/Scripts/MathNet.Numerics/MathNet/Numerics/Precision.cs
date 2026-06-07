using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime;
using System.Runtime.InteropServices;
using MathNet.Numerics.LinearAlgebra;

namespace MathNet.Numerics
{
	public static class Precision
	{
		[StructLayout(LayoutKind.Explicit)]
		private struct SingleIntUnion
		{
			[FieldOffset(0)]
			public float Single;

			[FieldOffset(0)]
			public int Int32;
		}

		private const int DoubleWidth = 53;

		private const int SingleWidth = 24;

		public static readonly double DoublePrecision = Math.Pow(2.0, -53.0);

		public static readonly double PositiveDoublePrecision = 2.0 * DoublePrecision;

		public static readonly double SinglePrecision = Math.Pow(2.0, -24.0);

		public static readonly double PositiveSinglePrecision = 2.0 * SinglePrecision;

		public static readonly double MachineEpsilon = MeasureMachineEpsilon();

		public static readonly double PositiveMachineEpsilon = MeasurePositiveMachineEpsilon();

		public static readonly int DoubleDecimalPlaces = (int)Math.Floor(Math.Abs(Math.Log10(DoublePrecision)));

		public static readonly int SingleDecimalPlaces = (int)Math.Floor(Math.Abs(Math.Log10(SinglePrecision)));

		private static readonly double DefaultDoubleAccuracy = DoublePrecision * 10.0;

		private static readonly float DefaultSingleAccuracy = (float)(SinglePrecision * 10.0);

		private static readonly double[] NegativePowersOf10 = new double[21]
		{
			1.0, 0.1, 0.01, 0.001, 0.0001, 1E-05, 1E-06, 1E-07, 1E-08, 1E-09,
			1E-10, 1E-11, 1E-12, 1E-13, 1E-14, 1E-15, 1E-16, 1E-17, 1E-18, 1E-19,
			1E-20
		};

		public static int CompareTo(this double a, double b, double maximumAbsoluteError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return a.CompareTo(b);
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a.CompareTo(b);
			}
			if (a.AlmostEqual(b, maximumAbsoluteError))
			{
				return 0;
			}
			return a.CompareTo(b);
		}

		public static int CompareTo(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return a.CompareTo(b);
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a.CompareTo(b);
			}
			if (a.AlmostEqual(b, decimalPlaces))
			{
				return 0;
			}
			return a.CompareTo(b);
		}

		public static int CompareToRelative(this double a, double b, double maximumError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return a.CompareTo(b);
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a.CompareTo(b);
			}
			if (a.AlmostEqualRelative(b, maximumError))
			{
				return 0;
			}
			return a.CompareTo(b);
		}

		public static int CompareToRelative(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return a.CompareTo(b);
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a.CompareTo(b);
			}
			if (a.AlmostEqualRelative(b, decimalPlaces))
			{
				return 0;
			}
			return a.CompareTo(b);
		}

		public static int CompareToNumbersBetween(this double a, double b, long maxNumbersBetween)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return a.CompareTo(b);
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a.CompareTo(b);
			}
			if (a.AlmostEqualNumbersBetween(b, maxNumbersBetween))
			{
				return 0;
			}
			return a.CompareTo(b);
		}

		public static bool IsLarger(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareTo(b, decimalPlaces) > 0;
		}

		public static bool IsLarger(this float a, float b, int decimalPlaces)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareTo(a, b, decimalPlaces) > 0;
		}

		public static bool IsLarger(this double a, double b, double maximumAbsoluteError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareTo(b, maximumAbsoluteError) > 0;
		}

		public static bool IsLarger(this float a, float b, double maximumAbsoluteError)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareTo(a, b, maximumAbsoluteError) > 0;
		}

		public static bool IsLargerRelative(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToRelative(b, decimalPlaces) > 0;
		}

		public static bool IsLargerRelative(this float a, float b, int decimalPlaces)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToRelative(a, b, decimalPlaces) > 0;
		}

		public static bool IsLargerRelative(this double a, double b, double maximumError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToRelative(b, maximumError) > 0;
		}

		public static bool IsLargerRelative(this float a, float b, double maximumError)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToRelative(a, b, maximumError) > 0;
		}

		public static bool IsLargerNumbersBetween(this double a, double b, long maxNumbersBetween)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToNumbersBetween(b, maxNumbersBetween) > 0;
		}

		public static bool IsLargerNumbersBetween(this float a, float b, long maxNumbersBetween)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToNumbersBetween(a, b, maxNumbersBetween) > 0;
		}

		public static bool IsSmaller(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareTo(b, decimalPlaces) < 0;
		}

		public static bool IsSmaller(this float a, float b, int decimalPlaces)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareTo(a, b, decimalPlaces) < 0;
		}

		public static bool IsSmaller(this double a, double b, double maximumAbsoluteError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareTo(b, maximumAbsoluteError) < 0;
		}

		public static bool IsSmaller(this float a, float b, double maximumAbsoluteError)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareTo(a, b, maximumAbsoluteError) < 0;
		}

		public static bool IsSmallerRelative(this double a, double b, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToRelative(b, decimalPlaces) < 0;
		}

		public static bool IsSmallerRelative(this float a, float b, int decimalPlaces)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToRelative(a, b, decimalPlaces) < 0;
		}

		public static bool IsSmallerRelative(this double a, double b, double maximumError)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToRelative(b, maximumError) < 0;
		}

		public static bool IsSmallerRelative(this float a, float b, double maximumError)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToRelative(a, b, maximumError) < 0;
		}

		public static bool IsSmallerNumbersBetween(this double a, double b, long maxNumbersBetween)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return a.CompareToNumbersBetween(b, maxNumbersBetween) < 0;
		}

		public static bool IsSmallerNumbersBetween(this float a, float b, long maxNumbersBetween)
		{
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			return CompareToNumbersBetween(a, b, maxNumbersBetween) < 0;
		}

		public static bool IsFinite(this double value)
		{
			if (!double.IsNaN(value))
			{
				return !double.IsInfinity(value);
			}
			return false;
		}

		public static int Magnitude(this double value)
		{
			if (value.Equals(0.0))
			{
				return 0;
			}
			double num = Math.Log10(Math.Abs(value));
			int num2 = (int)Truncate(num);
			if (!(num < 0.0) || (double)num2 == num)
			{
				return num2;
			}
			return num2 - 1;
		}

		public static int Magnitude(this float value)
		{
			if (value.Equals(0f))
			{
				return 0;
			}
			float num = Convert.ToSingle(Math.Log10(Math.Abs(value)));
			int num2 = (int)Truncate(num);
			if (!(num < 0f) || (float)num2 == num)
			{
				return num2;
			}
			return num2 - 1;
		}

		public static double ScaleUnitMagnitude(this double value)
		{
			if (value.Equals(0.0))
			{
				return value;
			}
			int num = value.Magnitude();
			return value * Math.Pow(10.0, -num);
		}

		private static long AsDirectionalInt64(double value)
		{
			long num = BitConverter.DoubleToInt64Bits(value);
			if (num < 0)
			{
				return long.MinValue - num;
			}
			return num;
		}

		private static int AsDirectionalInt32(float value)
		{
			int num = SingleToInt32Bits(value);
			if (num < 0)
			{
				return int.MinValue - num;
			}
			return num;
		}

		public static double Increment(this double value, int count = 1)
		{
			if (double.IsInfinity(value) || double.IsNaN(value) || count == 0)
			{
				return value;
			}
			if (count < 0)
			{
				return value.Decrement(-count);
			}
			long num = BitConverter.DoubleToInt64Bits(value);
			num = ((num >= 0) ? (num + count) : (num - count));
			if (num == long.MinValue)
			{
				return 0.0;
			}
			return BitConverter.Int64BitsToDouble(num);
		}

		public static double Decrement(this double value, int count = 1)
		{
			if (double.IsInfinity(value) || double.IsNaN(value) || count == 0)
			{
				return value;
			}
			if (count < 0)
			{
				return value.Increment(-count);
			}
			long num = BitConverter.DoubleToInt64Bits(value);
			if (num == 0L)
			{
				num = long.MinValue;
			}
			num = ((num >= 0) ? (num - count) : (num + count));
			return BitConverter.Int64BitsToDouble(num);
		}

		public static double CoerceZero(this double a, int maxNumbersBetween)
		{
			return a.CoerceZero((long)maxNumbersBetween);
		}

		public static double CoerceZero(this double a, long maxNumbersBetween)
		{
			if (maxNumbersBetween < 0)
			{
				throw new ArgumentOutOfRangeException("maxNumbersBetween");
			}
			if (double.IsInfinity(a) || double.IsNaN(a))
			{
				return a;
			}
			if (0.0.NumbersBetween(a) <= (ulong)maxNumbersBetween)
			{
				return 0.0;
			}
			return a;
		}

		public static double CoerceZero(this double a, double maximumAbsoluteError)
		{
			if (maximumAbsoluteError < 0.0)
			{
				throw new ArgumentOutOfRangeException("maximumAbsoluteError");
			}
			if (double.IsInfinity(a) || double.IsNaN(a))
			{
				return a;
			}
			if (Math.Abs(a) < maximumAbsoluteError)
			{
				return 0.0;
			}
			return a;
		}

		public static double CoerceZero(this double a)
		{
			return a.CoerceZero(DoublePrecision);
		}

		public static (double, double) RangeOfMatchingFloatingPointNumbers(this double value, long maxNumbersBetween)
		{
			if (maxNumbersBetween < 1)
			{
				throw new ArgumentOutOfRangeException("maxNumbersBetween");
			}
			if (double.IsInfinity(value))
			{
				return (value, value);
			}
			if (double.IsNaN(value))
			{
				return (double.NaN, double.NaN);
			}
			long num = BitConverter.DoubleToInt64Bits(value);
			if (num < 0)
			{
				double item = ((Math.Abs(long.MinValue - num) < maxNumbersBetween) ? BitConverter.Int64BitsToDouble(maxNumbersBetween + (long.MinValue - num)) : BitConverter.Int64BitsToDouble(num - maxNumbersBetween));
				return ((Math.Abs(num) < maxNumbersBetween) ? double.MinValue : BitConverter.Int64BitsToDouble(num + maxNumbersBetween), item);
			}
			double item2 = ((long.MaxValue - num < maxNumbersBetween) ? double.MaxValue : BitConverter.Int64BitsToDouble(num + maxNumbersBetween));
			return ((num > maxNumbersBetween) ? BitConverter.Int64BitsToDouble(num - maxNumbersBetween) : BitConverter.Int64BitsToDouble(long.MinValue + (maxNumbersBetween - num)), item2);
		}

		public static double MaximumMatchingFloatingPointNumber(this double value, long maxNumbersBetween)
		{
			return value.RangeOfMatchingFloatingPointNumbers(maxNumbersBetween).Item2;
		}

		public static double MinimumMatchingFloatingPointNumber(this double value, long maxNumbersBetween)
		{
			return value.RangeOfMatchingFloatingPointNumbers(maxNumbersBetween).Item1;
		}

		public static (long, long) RangeOfMatchingNumbers(this double value, double relativeDifference)
		{
			if (relativeDifference < 0.0)
			{
				throw new ArgumentOutOfRangeException("relativeDifference");
			}
			if (double.IsInfinity(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (double.IsNaN(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			if (value.Equals(0.0))
			{
				long num = BitConverter.DoubleToInt64Bits(relativeDifference);
				return (num, num);
			}
			long num2 = AsDirectionalInt64(value + relativeDifference * Math.Abs(value));
			long num3 = AsDirectionalInt64(value - relativeDifference * Math.Abs(value));
			long num4 = AsDirectionalInt64(value);
			return (Math.Abs(num4 - num3), Math.Abs(num2 - num4));
		}

		[CLSCompliant(false)]
		public static ulong NumbersBetween(this double a, double b)
		{
			if (double.IsNaN(a) || double.IsInfinity(a))
			{
				throw new ArgumentOutOfRangeException("a");
			}
			if (double.IsNaN(b) || double.IsInfinity(b))
			{
				throw new ArgumentOutOfRangeException("b");
			}
			long num = AsDirectionalInt64(a);
			long num2 = AsDirectionalInt64(b);
			if (!(a >= b))
			{
				return (ulong)(num2 - num);
			}
			return (ulong)(num - num2);
		}

		public static double EpsilonOf(this double value)
		{
			if (double.IsInfinity(value) || double.IsNaN(value))
			{
				return double.NaN;
			}
			long num = BitConverter.DoubleToInt64Bits(value);
			if (num == 0L)
			{
				num++;
				return BitConverter.Int64BitsToDouble(num) - value;
			}
			if (num-- < 0)
			{
				return BitConverter.Int64BitsToDouble(num) - value;
			}
			return value - BitConverter.Int64BitsToDouble(num);
		}

		public static float EpsilonOf(this float value)
		{
			if (float.IsInfinity(value) || float.IsNaN(value))
			{
				return float.NaN;
			}
			int num = SingleToInt32Bits(value);
			if (num == 0)
			{
				num++;
				return Int32BitsToSingle(num) - value;
			}
			if (num-- < 0)
			{
				return Int32BitsToSingle(num) - value;
			}
			return value - Int32BitsToSingle(num);
		}

		public static double PositiveEpsilonOf(this double value)
		{
			return 2.0 * value.EpsilonOf();
		}

		public static float PositiveEpsilonOf(this float value)
		{
			return 2f * value.EpsilonOf();
		}

		private static double MeasureMachineEpsilon()
		{
			double num = 1.0;
			while (1.0 - num / 2.0 < 1.0)
			{
				num /= 2.0;
			}
			return num;
		}

		private static double MeasurePositiveMachineEpsilon()
		{
			double num = 1.0;
			while (1.0 + num / 2.0 > 1.0)
			{
				num /= 2.0;
			}
			return num;
		}

		public static double RoundToMultiple(this double number, double basis)
		{
			return Math.Round(number / basis, MidpointRounding.AwayFromZero) * basis;
		}

		public static float RoundToMultiple(this float number, float basis)
		{
			return (float)((double)number).RoundToMultiple((double)basis);
		}

		public static decimal RoundToMultiple(this decimal number, decimal basis)
		{
			return Math.Round(number / basis, MidpointRounding.AwayFromZero) * basis;
		}

		public static double RoundToPower(this double number, double basis)
		{
			if (!(number < 0.0))
			{
				return Math.Pow(basis, Math.Round(Math.Log(number, basis), MidpointRounding.AwayFromZero));
			}
			return 0.0 - Math.Pow(basis, Math.Round(Math.Log(0.0 - number, basis), MidpointRounding.AwayFromZero));
		}

		public static float RoundToPower(this float number, float basis)
		{
			return (float)((double)number).RoundToPower((double)basis);
		}

		public static double Round(this double number, int digits)
		{
			if (digits < 0)
			{
				return number.RoundToMultiple(Math.Pow(10.0, -digits));
			}
			return Math.Round(number, digits, MidpointRounding.AwayFromZero);
		}

		public static float Round(this float number, int digits)
		{
			return (float)((double)number).Round(digits);
		}

		public static decimal Round(this decimal number, int digits)
		{
			if (digits < 0)
			{
				return number.RoundToMultiple((decimal)Math.Pow(10.0, -digits));
			}
			return Math.Round(number, digits, MidpointRounding.AwayFromZero);
		}

		public static int Round(this int number, int digits)
		{
			if (digits < 0)
			{
				return (int)Round((decimal)number, digits);
			}
			return number;
		}

		[CLSCompliant(false)]
		public static uint Round(this uint number, int digits)
		{
			if (digits < 0)
			{
				return (uint)Round((decimal)number, digits);
			}
			return number;
		}

		public static long Round(this long number, int digits)
		{
			if (digits < 0)
			{
				return (long)Round((decimal)number, digits);
			}
			return number;
		}

		[CLSCompliant(false)]
		public static ulong Round(this ulong number, int digits)
		{
			if (digits < 0)
			{
				return (ulong)Round((decimal)number, digits);
			}
			return number;
		}

		public static short Round(this short number, int digits)
		{
			if (digits < 0)
			{
				return (short)Round((decimal)number, digits);
			}
			return number;
		}

		[CLSCompliant(false)]
		public static ushort Round(this ushort number, int digits)
		{
			if (digits < 0)
			{
				return (ushort)Round((decimal)number, digits);
			}
			return number;
		}

		public static BigInteger Round(this BigInteger number, int digits)
		{
			if (digits >= 0)
			{
				return number;
			}
			BigInteger bigInteger = number / BigInteger.Pow(10, -digits - 1);
			BigInteger bigInteger2 = bigInteger / 10;
			if (bigInteger - bigInteger2 * 10 >= 5L)
			{
				bigInteger2 += (BigInteger)1;
			}
			return bigInteger2 * BigInteger.Pow(10, -digits);
		}

		[TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
		private static double Truncate(double value)
		{
			return Math.Truncate(value);
		}

		private static int SingleToInt32Bits(float value)
		{
			SingleIntUnion singleIntUnion = new SingleIntUnion
			{
				Single = value
			};
			return singleIntUnion.Int32;
		}

		private static float Int32BitsToSingle(int value)
		{
			SingleIntUnion singleIntUnion = new SingleIntUnion
			{
				Int32 = value
			};
			return singleIntUnion.Single;
		}

		public static bool AlmostEqualNorm(this double a, double b, double diff, double maximumAbsoluteError)
		{
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a == b;
			}
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			return Math.Abs(diff) < maximumAbsoluteError;
		}

		public static bool AlmostEqualNorm<T>(this T a, T b, double maximumAbsoluteError) where T : IPrecisionSupport<T>
		{
			double a2 = a.Norm();
			double b2 = b.Norm();
			T otherValue = b;
			return a2.AlmostEqualNorm(b2, a.NormOfDifference(otherValue), maximumAbsoluteError);
		}

		public static bool AlmostEqualNormRelative(this double a, double b, double diff, double maximumError)
		{
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a == b;
			}
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			if (Math.Abs(a) < DoublePrecision || Math.Abs(b) < DoublePrecision)
			{
				return Math.Abs(diff) < maximumError;
			}
			if ((a == 0.0 && Math.Abs(b) < maximumError) || (b == 0.0 && Math.Abs(a) < maximumError))
			{
				return true;
			}
			return Math.Abs(diff) < maximumError * Math.Max(Math.Abs(a), Math.Abs(b));
		}

		public static bool AlmostEqualNormRelative<T>(this T a, T b, double maximumError) where T : IPrecisionSupport<T>
		{
			double a2 = a.Norm();
			double b2 = b.Norm();
			T otherValue = b;
			return a2.AlmostEqualNormRelative(b2, a.NormOfDifference(otherValue), maximumError);
		}

		public static bool AlmostEqual(this double a, double b, double maximumAbsoluteError)
		{
			return a.AlmostEqualNorm(b, a - b, maximumAbsoluteError);
		}

		public static bool AlmostEqual(this float a, float b, double maximumAbsoluteError)
		{
			return AlmostEqualNorm(a, b, a - b, maximumAbsoluteError);
		}

		public static bool AlmostEqual(this Complex a, Complex b, double maximumAbsoluteError)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), maximumAbsoluteError);
		}

		public static bool AlmostEqual(this Complex32 a, Complex32 b, double maximumAbsoluteError)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), maximumAbsoluteError);
		}

		public static bool AlmostEqualRelative(this double a, double b, double maximumError)
		{
			return a.AlmostEqualNormRelative(b, a - b, maximumError);
		}

		public static bool AlmostEqualRelative(this float a, float b, double maximumError)
		{
			return AlmostEqualNormRelative(a, b, a - b, maximumError);
		}

		public static bool AlmostEqualRelative(this Complex a, Complex b, double maximumError)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), maximumError);
		}

		public static bool AlmostEqualRelative(this Complex32 a, Complex32 b, double maximumError)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), maximumError);
		}

		public static bool AlmostEqual(this double a, double b)
		{
			return a.AlmostEqualNorm(b, a - b, DefaultDoubleAccuracy);
		}

		public static bool AlmostEqual(this float a, float b)
		{
			return AlmostEqualNorm(a, b, a - b, DefaultSingleAccuracy);
		}

		public static bool AlmostEqual(this Complex a, Complex b)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), DefaultDoubleAccuracy);
		}

		public static bool AlmostEqual(this Complex32 a, Complex32 b)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), DefaultSingleAccuracy);
		}

		public static bool AlmostEqualRelative(this double a, double b)
		{
			return a.AlmostEqualNormRelative(b, a - b, DefaultDoubleAccuracy);
		}

		public static bool AlmostEqualRelative(this float a, float b)
		{
			return AlmostEqualNormRelative(a, b, a - b, DefaultSingleAccuracy);
		}

		public static bool AlmostEqualRelative(this Complex a, Complex b)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), DefaultDoubleAccuracy);
		}

		public static bool AlmostEqualRelative(this Complex32 a, Complex32 b)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), DefaultSingleAccuracy);
		}

		public static bool AlmostEqualNorm(this double a, double b, double diff, int decimalPlaces)
		{
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a == b;
			}
			return Math.Abs(diff) < Pow10(-decimalPlaces) * 0.5;
		}

		public static bool AlmostEqualNorm<T>(this T a, T b, int decimalPlaces) where T : IPrecisionSupport<T>
		{
			double a2 = a.Norm();
			double b2 = b.Norm();
			T otherValue = b;
			return a2.AlmostEqualNorm(b2, a.NormOfDifference(otherValue), decimalPlaces);
		}

		public static bool AlmostEqualNormRelative(this double a, double b, double diff, int decimalPlaces)
		{
			if (decimalPlaces < 0)
			{
				throw new ArgumentOutOfRangeException("decimalPlaces");
			}
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a == b;
			}
			if (a.Equals(b))
			{
				return true;
			}
			if (Math.Abs(a) < DoublePrecision || Math.Abs(b) < DoublePrecision)
			{
				return Math.Abs(diff) < Pow10(-decimalPlaces) * 0.5;
			}
			int val = a.Magnitude();
			int val2 = b.Magnitude();
			int num = Math.Max(val, val2);
			if (num > Math.Min(val, val2) + 1)
			{
				return false;
			}
			return Math.Abs(diff) < Pow10(num - decimalPlaces) * 0.5;
		}

		public static bool AlmostEqualNormRelative<T>(this T a, T b, int decimalPlaces) where T : IPrecisionSupport<T>
		{
			double a2 = a.Norm();
			double b2 = b.Norm();
			T otherValue = b;
			return a2.AlmostEqualNormRelative(b2, a.NormOfDifference(otherValue), decimalPlaces);
		}

		public static bool AlmostEqual(this double a, double b, int decimalPlaces)
		{
			return a.AlmostEqualNorm(b, a - b, decimalPlaces);
		}

		public static bool AlmostEqual(this float a, float b, int decimalPlaces)
		{
			return AlmostEqualNorm(a, b, a - b, decimalPlaces);
		}

		public static bool AlmostEqual(this Complex a, Complex b, int decimalPlaces)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), decimalPlaces);
		}

		public static bool AlmostEqual(this Complex32 a, Complex32 b, int decimalPlaces)
		{
			return a.Norm().AlmostEqualNorm(b.Norm(), a.NormOfDifference(b), decimalPlaces);
		}

		public static bool AlmostEqualRelative(this double a, double b, int decimalPlaces)
		{
			return a.AlmostEqualNormRelative(b, a - b, decimalPlaces);
		}

		public static bool AlmostEqualRelative(this float a, float b, int decimalPlaces)
		{
			return AlmostEqualNormRelative(a, b, a - b, decimalPlaces);
		}

		public static bool AlmostEqualRelative(this Complex a, Complex b, int decimalPlaces)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), decimalPlaces);
		}

		public static bool AlmostEqualRelative(this Complex32 a, Complex32 b, int decimalPlaces)
		{
			return a.Norm().AlmostEqualNormRelative(b.Norm(), a.NormOfDifference(b), decimalPlaces);
		}

		public static bool AlmostEqualNumbersBetween(this double a, double b, long maxNumbersBetween)
		{
			if (maxNumbersBetween < 1)
			{
				throw new ArgumentOutOfRangeException("maxNumbersBetween");
			}
			if (double.IsInfinity(a) || double.IsInfinity(b))
			{
				return a == b;
			}
			if (double.IsNaN(a) || double.IsNaN(b))
			{
				return false;
			}
			long num = AsDirectionalInt64(a);
			long num2 = AsDirectionalInt64(b);
			if (!(a > b))
			{
				return num + maxNumbersBetween >= num2;
			}
			return num2 + maxNumbersBetween >= num;
		}

		public static bool AlmostEqualNumbersBetween(this float a, float b, int maxNumbersBetween)
		{
			if (maxNumbersBetween < 1)
			{
				throw new ArgumentOutOfRangeException("maxNumbersBetween");
			}
			if (float.IsInfinity(a) || float.IsInfinity(b))
			{
				return a == b;
			}
			if (float.IsNaN(a) || float.IsNaN(b))
			{
				return false;
			}
			int num = AsDirectionalInt32(a);
			int num2 = AsDirectionalInt32(b);
			if (!(a > b))
			{
				return num + maxNumbersBetween >= num2;
			}
			return num2 + maxNumbersBetween >= num;
		}

		public static bool ListAlmostEqual(this IList<double> a, IList<double> b, double maximumAbsoluteError)
		{
			return ListForAll(a, b, AlmostEqual, maximumAbsoluteError);
		}

		public static bool ListAlmostEqual(this IList<float> a, IList<float> b, double maximumAbsoluteError)
		{
			return ListForAll(a, b, AlmostEqual, maximumAbsoluteError);
		}

		public static bool ListAlmostEqual(this IList<Complex> a, IList<Complex> b, double maximumAbsoluteError)
		{
			return ListForAll(a, b, AlmostEqual, maximumAbsoluteError);
		}

		public static bool ListAlmostEqual(this IList<Complex32> a, IList<Complex32> b, double maximumAbsoluteError)
		{
			return ListForAll(a, b, AlmostEqual, maximumAbsoluteError);
		}

		public static bool ListAlmostEqualRelative(this IList<double> a, IList<double> b, double maximumError)
		{
			return ListForAll(a, b, AlmostEqualRelative, maximumError);
		}

		public static bool ListAlmostEqualRelative(this IList<float> a, IList<float> b, double maximumError)
		{
			return ListForAll(a, b, AlmostEqualRelative, maximumError);
		}

		public static bool ListAlmostEqualRelative(this IList<Complex> a, IList<Complex> b, double maximumError)
		{
			return ListForAll(a, b, AlmostEqualRelative, maximumError);
		}

		public static bool ListAlmostEqualRelative(this IList<Complex32> a, IList<Complex32> b, double maximumError)
		{
			return ListForAll(a, b, AlmostEqualRelative, maximumError);
		}

		public static bool ListAlmostEqual(this IList<double> a, IList<double> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqual, decimalPlaces);
		}

		public static bool ListAlmostEqual(this IList<float> a, IList<float> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqual, decimalPlaces);
		}

		public static bool ListAlmostEqual(this IList<Complex> a, IList<Complex> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqual, decimalPlaces);
		}

		public static bool ListAlmostEqual(this IList<Complex32> a, IList<Complex32> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqual, decimalPlaces);
		}

		public static bool ListAlmostEqualRelative(this IList<double> a, IList<double> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqualRelative, decimalPlaces);
		}

		public static bool ListAlmostEqualRelative(this IList<float> a, IList<float> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqualRelative, decimalPlaces);
		}

		public static bool ListAlmostEqualRelative(this IList<Complex> a, IList<Complex> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqualRelative, decimalPlaces);
		}

		public static bool ListAlmostEqualRelative(this IList<Complex32> a, IList<Complex32> b, int decimalPlaces)
		{
			return ListForAll(a, b, AlmostEqualRelative, decimalPlaces);
		}

		public static bool ListAlmostEqualNorm<T>(this IList<T> a, IList<T> b, double maximumAbsoluteError) where T : IPrecisionSupport<T>
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null || a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (!a[i].AlmostEqualNorm(b[i], maximumAbsoluteError))
				{
					return false;
				}
			}
			return true;
		}

		public static bool ListAlmostEqualNormRelative<T>(this IList<T> a, IList<T> b, double maximumError) where T : IPrecisionSupport<T>
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null || a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (!a[i].AlmostEqualNormRelative(b[i], maximumError))
				{
					return false;
				}
			}
			return true;
		}

		private static bool ListForAll<T, TP>(IList<T> a, IList<T> b, Func<T, T, TP, bool> predicate, TP parameter)
		{
			if (a == null && b == null)
			{
				return true;
			}
			if (a == null || b == null || a.Count != b.Count)
			{
				return false;
			}
			for (int i = 0; i < a.Count; i++)
			{
				if (!predicate(a[i], b[i], parameter))
				{
					return false;
				}
			}
			return true;
		}

		public static bool AlmostEqual<T>(this MathNet.Numerics.LinearAlgebra.Vector<T> a, MathNet.Numerics.LinearAlgebra.Vector<T> b, double maximumAbsoluteError) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNorm(b.L2Norm(), (a - b).L2Norm(), maximumAbsoluteError);
		}

		public static bool AlmostEqualRelative<T>(this MathNet.Numerics.LinearAlgebra.Vector<T> a, MathNet.Numerics.LinearAlgebra.Vector<T> b, double maximumError) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNormRelative(b.L2Norm(), (a - b).L2Norm(), maximumError);
		}

		public static bool AlmostEqual<T>(this MathNet.Numerics.LinearAlgebra.Vector<T> a, MathNet.Numerics.LinearAlgebra.Vector<T> b, int decimalPlaces) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNorm(b.L2Norm(), (a - b).L2Norm(), decimalPlaces);
		}

		public static bool AlmostEqualRelative<T>(this MathNet.Numerics.LinearAlgebra.Vector<T> a, MathNet.Numerics.LinearAlgebra.Vector<T> b, int decimalPlaces) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNormRelative(b.L2Norm(), (a - b).L2Norm(), decimalPlaces);
		}

		public static bool AlmostEqual<T>(this Matrix<T> a, Matrix<T> b, double maximumAbsoluteError) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNorm(b.L2Norm(), (a - b).L2Norm(), maximumAbsoluteError);
		}

		public static bool AlmostEqualRelative<T>(this Matrix<T> a, Matrix<T> b, double maximumError) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNormRelative(b.L2Norm(), (a - b).L2Norm(), maximumError);
		}

		public static bool AlmostEqual<T>(this Matrix<T> a, Matrix<T> b, int decimalPlaces) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNorm(b.L2Norm(), (a - b).L2Norm(), decimalPlaces);
		}

		public static bool AlmostEqualRelative<T>(this Matrix<T> a, Matrix<T> b, int decimalPlaces) where T : struct, IEquatable<T>, IFormattable
		{
			return a.L2Norm().AlmostEqualNormRelative(b.L2Norm(), (a - b).L2Norm(), decimalPlaces);
		}

		private static double Pow10(int y)
		{
			if (-NegativePowersOf10.Length >= y || y > 0)
			{
				return Math.Pow(10.0, y);
			}
			return NegativePowersOf10[-y];
		}
	}
}
