namespace Humanizer.Localisation.NumberToWords
{
	internal class LatvianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly string[] HundredsMap;

		private static readonly string[] UnitsOrdinal;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int input, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetOrdinalEndingForGender(GrammaticalGender gender)
		{
			return null;
		}

		private static string GetCardinalEndingForGender(GrammaticalGender gender, long number)
		{
			return null;
		}
	}
}
