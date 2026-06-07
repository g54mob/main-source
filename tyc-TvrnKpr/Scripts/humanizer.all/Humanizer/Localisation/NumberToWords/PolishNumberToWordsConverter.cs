using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	internal class PolishNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] HundredsMap;

		private static readonly string[] TensMap;

		private static readonly string[] UnitsMap;

		private static readonly string[][] PowersOfThousandMap;

		private const long MaxPossibleDivisor = 1000000000000000000L;

		private readonly CultureInfo _culture;

		public PolishNumberToWordsConverter(CultureInfo culture)
		{
		}

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static void CollectParts(ICollection<string> parts, long input, GrammaticalGender gender)
		{
		}

		private static void CollectPartsUnderThousand(ICollection<string> parts, int number, GrammaticalGender gender)
		{
		}

		private static string GetPowerOfThousandNameForm(int multiplier, int power)
		{
			return null;
		}
	}
}
