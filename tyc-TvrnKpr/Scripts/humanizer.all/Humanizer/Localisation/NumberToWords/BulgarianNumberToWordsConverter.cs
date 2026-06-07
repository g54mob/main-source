namespace Humanizer.Localisation.NumberToWords
{
	internal class BulgarianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly string[] HundredsMap;

		private static readonly string[] HundredsOrdinalMap;

		private static readonly string[] UnitsOrdinal;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		private string Convert(long input, GrammaticalGender gender, bool isOrdinal, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int input, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetEndingForGender(GrammaticalGender gender, long input)
		{
			return null;
		}
	}
}
