using System;
using System.Collections.Generic;
using System.Globalization;

namespace viperOSK
{
	public static class OSK_GlyphHandler
	{
		private enum Script
		{
			Latin = 0,
			Greek = 1,
			Cyrillic = 2,
			Arabic = 3,
			Armenian = 4
		}

		private struct Range
		{
			public int Start;

			public int End;

			public Range(int s, int e)
			{
				Start = 0;
				End = 0;
			}
		}

		public static List<(string, TEnum)> BuildAssignments<TEnum>(OSK_LanguagePackage profile) where TEnum : struct, Enum
		{
			return null;
		}

		public static Dictionary<string, TEnum> BuildLookup<TEnum>(OSK_LanguagePackage profile) where TEnum : struct, Enum
		{
			return null;
		}

		private static Script ResolvePrimaryScript(CultureInfo culture)
		{
			return default(Script);
		}

		private static IReadOnlyList<Range> GetRangesForScript(Script script)
		{
			return null;
		}

		private static List<Range> ToIntRanges(List<HexRange> hexRanges)
		{
			return null;
		}

		private static bool TryParseHex(string hex, out int value)
		{
			value = default(int);
			return false;
		}

		private static List<Range> MergeRanges(IReadOnlyList<Range> a, List<Range> b)
		{
			return null;
		}

		private static List<Range> ExcludeRanges(List<Range> source, List<Range> excludes)
		{
			return null;
		}

		private static List<string> EnumerateLetterGlyphs(List<Range> ranges, bool includeUppercase, bool includeLowercase, bool collapseCase, bool preferLowercase, Script? scriptForSpecials)
		{
			return null;
		}

		private static string Canonicalize(string s, Script? script)
		{
			return null;
		}

		private static bool IsValidCodePoint(int cp)
		{
			return false;
		}

		private static bool IsSurrogate(int cp)
		{
			return false;
		}

		private static bool IsLetter(UnicodeCategory c)
		{
			return false;
		}

		private static bool IsUppercase(UnicodeCategory c)
		{
			return false;
		}

		private static bool IsLowercase(UnicodeCategory c)
		{
			return false;
		}

		private static int ToCodePoint(string s)
		{
			return 0;
		}

		private static List<TEnum> GetGlyphEnumSlots<TEnum>() where TEnum : struct, Enum
		{
			return null;
		}

		private static bool TryParseGlyphSuffix(string name, out int n)
		{
			n = default(int);
			return false;
		}
	}
}
