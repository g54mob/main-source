using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

namespace Aggro.Core
{
	public struct Fixed : IEquatable<Fixed>, IComparable<Fixed>, IFormattable
	{
		public int integer;

		public int fractional;

		public const int FRACTIONAL_SIZE = 2147483400;

		public const long FRACTIONAL_SIZE_LONG = 2147483400L;

		public const ulong FRACTIONAL_SIZE_ULONG = 2147483400uL;

		public const int PER_PERCENTAGE_AMOUNT = 21474834;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed Fraction(int numerator, int denominator)
		{
			Fixed result = new Fixed
			{
				integer = numerator / denominator
			};
			int num = math.abs(numerator);
			uint num2 = (uint)math.abs(denominator);
			ulong num3 = (uint)num % num2;
			num3 *= 2147483400;
			num3 /= num2;
			result.fractional = (int)num3;
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed Percentage(int baseValue, int percentage)
		{
			Fixed result = default(Fixed);
			result.fractional = baseValue;
			result.ApplyPercentage(percentage);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Fixed(int v)
		{
			return new Fixed
			{
				fractional = 0,
				integer = v
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator int(Fixed f)
		{
			return f.integer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Fixed(float v)
		{
			return (double)v;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Fixed(double v)
		{
			Fixed result = default(Fixed);
			double i;
			double s = math.modf(v, out i);
			result.fractional = (int)math.lerp(0.0, 2147483400.0, s);
			result.integer = Mathf.RoundToInt((float)i);
			return result;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static explicit operator float(Fixed f)
		{
			return (float)f.integer + math.unlerp(0f, 2.1474834E+09f, f.fractional);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator +(Fixed f1, Fixed f2)
		{
			f1.integer += f2.integer;
			long num = (long)f1.fractional + (long)f2.fractional;
			f1.integer += (int)(num / 2147483400);
			f1.fractional = (int)(num % 2147483400);
			return f1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator -(Fixed f)
		{
			f.integer = -f.integer;
			f.fractional = -f.fractional;
			return f;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator -(Fixed f1, Fixed f2)
		{
			return f1 + -f2;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator *(Fixed f1, Fixed f2)
		{
			long num = f1.integer;
			long num2 = f1.fractional;
			long num3 = f2.integer;
			long num4 = f2.fractional;
			long num5 = num * num3 * 2147483400;
			long num6 = num * num4;
			long num7 = num3 * num2;
			long num8 = num2 * num4 / 2147483400;
			long num9 = num5 + num6 + num7 + num8;
			return new Fixed
			{
				integer = (int)(num9 / 2147483400),
				fractional = (int)(num9 % 2147483400)
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator /(Fixed f1, Fixed f2)
		{
			return f1 * (1f / (float)f2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator /(Fixed f, int value)
		{
			long num = (long)f.integer * 2147483400L + f.fractional;
			num /= value;
			return new Fixed
			{
				integer = (int)(num / 2147483400),
				fractional = (int)(num % 2147483400)
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public void ApplyPercentage(int percentage)
		{
			long num = (long)integer * 2147483400L + fractional;
			num *= percentage;
			num /= 100;
			integer = (int)(num / 2147483400);
			fractional = (int)(num % 2147483400);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator ==(Fixed f1, Fixed f2)
		{
			if (f1.integer == f2.integer)
			{
				return f1.fractional == f2.fractional;
			}
			return false;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator !=(Fixed f1, Fixed f2)
		{
			return !(f1 == f2);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <(Fixed f1, Fixed f2)
		{
			if (f1.integer == f2.integer)
			{
				return f1.fractional < f2.fractional;
			}
			return f1.integer < f2.integer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >(Fixed f1, Fixed f2)
		{
			if (f1.integer == f2.integer)
			{
				return f1.fractional > f2.fractional;
			}
			return f1.integer > f2.integer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator <=(Fixed f1, Fixed f2)
		{
			if (f1.integer == f2.integer)
			{
				return f1.fractional <= f2.fractional;
			}
			return f1.integer <= f2.integer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static bool operator >=(Fixed f1, Fixed f2)
		{
			if (f1.integer == f2.integer)
			{
				return f1.fractional >= f2.fractional;
			}
			return f1.integer >= f2.integer;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator ++(Fixed f1)
		{
			f1.integer++;
			return f1;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static Fixed operator --(Fixed f1)
		{
			f1.integer--;
			return f1;
		}

		public bool Equals(Fixed other)
		{
			if (integer == other.integer)
			{
				return fractional == other.fractional;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is Fixed other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return HashCode.Combine(integer, fractional);
		}

		public int CompareTo(Fixed other)
		{
			if (integer != other.integer)
			{
				return integer - other.integer;
			}
			return fractional - other.fractional;
		}

		public override string ToString()
		{
			return ((float)this).ToString(CultureInfo.CurrentCulture);
		}

		public string ToString(string format, IFormatProvider formatProvider)
		{
			return ((float)this).ToString(format, formatProvider);
		}
	}
}
