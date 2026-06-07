using System;

namespace Utf8Json.Internal.DoubleConversion
{
	internal static class DoubleToStringConverter
	{
		private enum FastDtoaMode
		{
			FAST_DTOA_SHORTEST = 0,
			FAST_DTOA_SHORTEST_SINGLE = 1
		}

		private enum DtoaMode
		{
			SHORTEST = 0,
			SHORTEST_SINGLE = 1
		}

		private enum Flags
		{
			NO_FLAGS = 0,
			EMIT_POSITIVE_EXPONENT_SIGN = 1,
			EMIT_TRAILING_DECIMAL_POINT = 2,
			EMIT_TRAILING_ZERO_AFTER_POINT = 4,
			UNIQUE_ZERO = 8
		}

		[ThreadStatic]
		private static byte[] decimalRepBuffer;

		[ThreadStatic]
		private static byte[] exponentialRepBuffer;

		[ThreadStatic]
		private static byte[] toStringBuffer;

		private static readonly byte[] infinity_symbol_;

		private static readonly byte[] nan_symbol_;

		private static readonly Flags flags_;

		private static readonly char exponent_character_;

		private static readonly int decimal_in_shortest_low_;

		private static readonly int decimal_in_shortest_high_;

		private const int kBase10MaximalLength = 17;

		private const int kFastDtoaMaximalLength = 17;

		private const int kFastDtoaMaximalSingleLength = 9;

		private const int kMinimalTargetExponent = -60;

		private const int kMaximalTargetExponent = -32;

		private static readonly uint[] kSmallPowersOfTen;

		private static byte[] GetDecimalRepBuffer(int size)
		{
			return null;
		}

		private static byte[] GetExponentialRepBuffer(int size)
		{
			return null;
		}

		private static byte[] GetToStringBuffer()
		{
			return null;
		}

		public static int GetBytes(ref byte[] buffer, int offset, float value)
		{
			return 0;
		}

		public static int GetBytes(ref byte[] buffer, int offset, double value)
		{
			return 0;
		}

		private static bool RoundWeed(byte[] buffer, int length, ulong distance_too_high_w, ulong unsafe_interval, ulong rest, ulong ten_kappa, ulong unit)
		{
			return false;
		}

		private static void BiggestPowerTen(uint number, int number_bits, out uint power, out int exponent_plus_one)
		{
			power = default(uint);
			exponent_plus_one = default(int);
		}

		private static bool DigitGen(DiyFp low, DiyFp w, DiyFp high, byte[] buffer, out int length, out int kappa)
		{
			length = default(int);
			kappa = default(int);
			return false;
		}

		private static bool Grisu3(double v, FastDtoaMode mode, byte[] buffer, out int length, out int decimal_exponent)
		{
			length = default(int);
			decimal_exponent = default(int);
			return false;
		}

		private static bool FastDtoa(double v, FastDtoaMode mode, byte[] buffer, out int length, out int decimal_point)
		{
			length = default(int);
			decimal_point = default(int);
			return false;
		}

		private static bool HandleSpecialValues(double value, ref StringBuilder result_builder)
		{
			return false;
		}

		private static bool ToShortestIeeeNumber(double value, ref StringBuilder result_builder, DtoaMode mode)
		{
			return false;
		}

		private static void CreateDecimalRepresentation(byte[] decimal_digits, int length, int decimal_point, int digits_after_point, ref StringBuilder result_builder)
		{
		}

		private static void CreateExponentialRepresentation(byte[] decimal_digits, int length, int exponent, ref StringBuilder result_builder)
		{
		}

		private static bool DoubleToAscii(double v, DtoaMode mode, int requested_digits, byte[] vector, out bool sign, out int length, out int point)
		{
			sign = default(bool);
			length = default(int);
			point = default(int);
			return false;
		}
	}
}
