using System;
using System.Collections.Generic;

namespace ParadoxNotion
{
	public static class StringUtils
	{
		public const string SPACE = " ";

		public const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

		public static readonly char[] CHAR_SPACE_ARRAY;

		private static Dictionary<string, string> splitCaseCache;

		public static string SplitCamelCase(this string s)
		{
			return null;
		}

		public static string CapitalizeFirst(this string s)
		{
			return null;
		}

		public static string CapLength(this string s, int max)
		{
			return null;
		}

		public static string GetCapitals(this string s)
		{
			return null;
		}

		public static string FormatError(this string input)
		{
			return null;
		}

		public static string GetAlphabetLetter(int index)
		{
			return null;
		}

		public static string GetStringWithinOuter(this string input, char from, char to)
		{
			return null;
		}

		public static string GetStringWithinInner(this string input, char from, char to)
		{
			return null;
		}

		public static string ReplaceWithin(this string text, char startChar, char endChar, Func<string, string> Process)
		{
			return null;
		}

		public static float ScoreSearchMatch(string input, string leafName, string categoryName = "")
		{
			return 0f;
		}

		public static bool SearchMatch(string input, string leafName, string categoryName = "")
		{
			return false;
		}

		public static string ToStringAdvanced(this object o)
		{
			return null;
		}
	}
}
