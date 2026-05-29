using System;

namespace Utf8Json.Internal.DoubleConversion
{
	internal static class StringToDouble
	{
		[ThreadStatic]
		private static byte[] copyBuffer;

		private const int kMaxExactDoubleIntegerDecimalDigits = 15;

		private const int kMaxUint64DecimalDigits = 19;

		private const int kMaxDecimalPower = 309;

		private const int kMinDecimalPower = -324;

		private const ulong kMaxUint64 = 18446744073709551615uL;

		private static readonly double[] exact_powers_of_ten;

		private static readonly int kExactPowersOfTenSize;

		private const int kMaxSignificantDecimalDigits = 780;

		private static byte[] GetCopyBuffer()
		{
			return null;
		}

		private static Vector TrimLeadingZeros(Vector buffer)
		{
			return default(Vector);
		}

		private static Vector TrimTrailingZeros(Vector buffer)
		{
			return default(Vector);
		}

		private static void CutToMaxSignificantDigits(Vector buffer, int exponent, byte[] significant_buffer, out int significant_exponent)
		{
			significant_exponent = default(int);
		}

		private static void TrimAndCut(Vector buffer, int exponent, byte[] buffer_copy_space, int space_size, out Vector trimmed, out int updated_exponent)
		{
			trimmed = default(Vector);
			updated_exponent = default(int);
		}

		private static ulong ReadUint64(Vector buffer, out int number_of_read_digits)
		{
			number_of_read_digits = default(int);
			return 0uL;
		}

		private static void ReadDiyFp(Vector buffer, out DiyFp result, out int remaining_decimals)
		{
			result = default(DiyFp);
			remaining_decimals = default(int);
		}

		private static bool DoubleStrtod(Vector trimmed, int exponent, out double result)
		{
			result = default(double);
			return false;
		}

		private static DiyFp AdjustmentPowerOfTen(int exponent)
		{
			return default(DiyFp);
		}

		private static bool DiyFpStrtod(Vector buffer, int exponent, out double result)
		{
			result = default(double);
			return false;
		}

		private static bool ComputeGuess(Vector trimmed, int exponent, out double guess)
		{
			guess = default(double);
			return false;
		}

		public static double? Strtod(Vector buffer, int exponent)
		{
			return null;
		}

		public static float? Strtof(Vector buffer, int exponent)
		{
			return null;
		}
	}
}
