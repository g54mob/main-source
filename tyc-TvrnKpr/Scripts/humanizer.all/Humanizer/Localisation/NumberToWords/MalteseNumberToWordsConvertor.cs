namespace Humanizer.Localisation.NumberToWords
{
	internal class MalteseNumberToWordsConvertor : GenderedNumberToWordsConverter
	{
		private static readonly string[] OrdinalOverrideMap;

		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly string[] HundredsMap;

		private static readonly string[] PrefixMap;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetTens(long value, bool usePrefixMap, bool usePrefixMapForLowerDigits, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetHundreds(long value, bool usePrefixMap, bool usePrefixMapForLowerValueDigits, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetThousands(long value, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetMillions(long value, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetPrefixText(long thousands, long tensInThousands, string singular, string dual, string plural, bool usePrefixMapForLowerValueDigits, GrammaticalGender gender)
		{
			return null;
		}
	}
}
