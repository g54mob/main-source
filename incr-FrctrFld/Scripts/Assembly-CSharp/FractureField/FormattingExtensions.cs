using System;
using System.Collections.Generic;

namespace FractureField
{
	public static class FormattingExtensions
	{
		private static List<string> suffixes;

		public static string Format(this Enum value)
		{
			return null;
		}

		public static string Format(this int number, FormatOptions options = null)
		{
			return null;
		}

		public static string Format(this long number, FormatOptions options = null)
		{
			return null;
		}

		public static string Format(this float number, FormatOptions options = null)
		{
			return null;
		}

		public static string FormatMultiplier(this float number)
		{
			return null;
		}

		private static void GetMantissaAndExponentBase10(float value, out float mantissa, out int exponent)
		{
			mantissa = default(float);
			exponent = default(int);
		}

		private static string FormatNumberWithSuffixString(float number)
		{
			return null;
		}

		private static string GetSuffixForNumber(long suffixIndex)
		{
			return null;
		}

		private static void CreateAndFillSuffixesList()
		{
		}

		private static void FillSuffixesList()
		{
		}

		private static void GenerateCombinations(string prefix, int length, char[] characters, List<string> results)
		{
		}
	}
}
