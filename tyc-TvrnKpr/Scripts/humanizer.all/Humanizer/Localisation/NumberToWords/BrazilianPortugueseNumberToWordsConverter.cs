namespace Humanizer.Localisation.NumberToWords
{
	internal class BrazilianPortugueseNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] PortugueseUnitsMap;

		private static readonly string[] PortugueseTensMap;

		private static readonly string[] PortugueseHundredsMap;

		private static readonly string[] PortugueseOrdinalUnitsMap;

		private static readonly string[] PortugueseOrdinalTensMap;

		private static readonly string[] PortugueseOrdinalHundredsMap;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static string ApplyGender(string toWords, GrammaticalGender gender)
		{
			return null;
		}

		private static string ApplyOrdinalGender(string toWords, GrammaticalGender gender)
		{
			return null;
		}
	}
}
