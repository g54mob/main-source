using System.Text.RegularExpressions;

namespace Humanizer
{
	public static class StringHumanizeExtensions
	{
		private static readonly Regex PascalCaseWordPartsRegex;

		private static readonly Regex FreestandingSpacingCharRegex;

		static StringHumanizeExtensions()
		{
		}

		private static string FromUnderscoreDashSeparatedWords(string input)
		{
			return null;
		}

		private static string FromPascalCase(string input)
		{
			return null;
		}

		public static string Humanize(this string input)
		{
			return null;
		}

		public static string Humanize(this string input, LetterCasing casing)
		{
			return null;
		}
	}
}
