namespace Humanizer.Localisation.NumberToWords
{
	internal class CentralKurdishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] KurdishHundredsMap;

		private static readonly string[] KurdishTensMap;

		private static readonly string[] KurdishUnitsMap;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private bool IsVowel(char c)
		{
			return false;
		}
	}
}
