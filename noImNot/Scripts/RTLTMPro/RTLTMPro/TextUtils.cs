namespace RTLTMPro
{
	public static class TextUtils
	{
		private const char LowerCaseA = 'a';

		private const char UpperCaseA = 'A';

		private const char LowerCaseZ = 'z';

		private const char UpperCaseZ = 'Z';

		private const char HebrewLow = '\u0591';

		private const char HebrewHigh = '״';

		private const char ArabicBaseBlockLow = '\u0600';

		private const char ArabicBaseBlockHigh = 'ۿ';

		private const char ArabicExtendedABlockLow = 'ࢠ';

		private const char ArabicExtendedABlockHigh = '\u08ff';

		private const char ArabicExtendedBBlockLow = 'ࡰ';

		private const char ArabicExtendedBBlockHigh = '\u089f';

		private const char ArabicPresentationFormsABlockLow = 'ﭐ';

		private const char ArabicPresentationFormsABlockHigh = '﷿';

		private const char ArabicPresentationFormsBBlockLow = 'ﹰ';

		private const char ArabicPresentationFormsBBlockHigh = '\ufeff';

		public static bool IsPunctuation(char ch)
		{
			return false;
		}

		public static bool IsNumber(char ch, bool preserveNumbers, bool farsi)
		{
			return false;
		}

		public static bool IsEnglishNumber(char ch)
		{
			return false;
		}

		public static bool IsFarsiNumber(char ch)
		{
			return false;
		}

		public static bool IsHinduNumber(char ch)
		{
			return false;
		}

		public static bool IsEnglishLetter(char ch)
		{
			return false;
		}

		public static bool IsHebrewCharacter(char ch)
		{
			return false;
		}

		public static bool IsArabicCharacter(char ch)
		{
			return false;
		}

		public static bool IsRTLCharacter(char ch)
		{
			return false;
		}

		public static bool IsGlyphFixedArabicCharacter(char ch)
		{
			return false;
		}

		public static bool IsRTLInput(string input)
		{
			return false;
		}
	}
}
