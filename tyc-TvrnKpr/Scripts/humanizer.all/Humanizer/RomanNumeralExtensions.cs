using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Humanizer
{
	public static class RomanNumeralExtensions
	{
		private const int NumberOfRomanNumeralMaps = 13;

		private static readonly IDictionary<string, int> RomanNumerals;

		private static readonly Regex ValidRomanNumeral;

		public static int FromRoman(this string input)
		{
			return 0;
		}

		public static string ToRoman(this int input)
		{
			return null;
		}

		private static bool IsInvalidRomanNumeral(string input)
		{
			return false;
		}
	}
}
