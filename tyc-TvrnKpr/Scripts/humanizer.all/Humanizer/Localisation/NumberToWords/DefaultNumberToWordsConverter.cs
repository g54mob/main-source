using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	internal class DefaultNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private readonly CultureInfo _culture;

		public DefaultNumberToWordsConverter(CultureInfo culture)
		{
		}

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}
	}
}
