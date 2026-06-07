namespace Humanizer.Localisation.NumberToWords
{
	internal class VietnameseNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private const int OneBillion = 1000000000;

		private const int OneMillion = 1000000;

		private static readonly string[] NumberVerbalPairs;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private string ConvertToOrdinalImpl(int number)
		{
			return null;
		}

		private static string ConvertImpl(long number, bool hasTens = false, bool isGreaterThanOneHundred = false)
		{
			return null;
		}
	}
}
