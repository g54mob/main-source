namespace Humanizer.Localisation.NumberToWords
{
	internal class ChineseNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private bool IsSpecial(long number)
		{
			return false;
		}

		private string Convert(long number, bool isOrdinal, bool isSpecial)
		{
			return null;
		}
	}
}
