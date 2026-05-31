using System.Collections.Generic;

namespace RTLTMPro
{
	public static class GlyphFixer
	{
		public static Dictionary<char, char> EnglishToFarsiNumberMap;

		public static Dictionary<char, char> EnglishToHinduNumberMap;

		public static void Fix(FastStringBuilder input, FastStringBuilder output, bool preserveNumbers, bool farsi, bool fixTextTags)
		{
		}

		public static void FixYah(FastStringBuilder text, bool farsi)
		{
		}

		private static bool HandleSpecialLam(FastStringBuilder input, FastStringBuilder output, int i)
		{
			return false;
		}

		public static void FixNumbers(FastStringBuilder text, bool farsi)
		{
		}

		public static void FixNumbersOutsideOfTags(FastStringBuilder text, bool farsi)
		{
		}

		private static bool IsLeadingLetter(FastStringBuilder letters, int index)
		{
			return false;
		}

		private static bool IsFinishingLetter(FastStringBuilder letters, int index)
		{
			return false;
		}

		private static bool IsMiddleLetter(FastStringBuilder letters, int index)
		{
			return false;
		}
	}
}
