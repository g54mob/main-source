namespace Humanizer.Localisation.NumberToWords
{
	internal class RomanianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}
	}
}
