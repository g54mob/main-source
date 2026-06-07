using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	internal class CroatianNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private readonly CultureInfo _culture;

		public CroatianNumberToWordsConverter(CultureInfo culture)
		{
		}

		public override string Convert(long input)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private string Part(string singular, string dual, string trialQuadral, string plural, int number)
		{
			return null;
		}
	}
}
