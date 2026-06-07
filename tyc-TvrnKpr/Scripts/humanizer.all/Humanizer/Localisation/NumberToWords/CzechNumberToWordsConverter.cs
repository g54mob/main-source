using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	internal class CzechNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] BillionsMap;

		private static readonly string[] MillionsMap;

		private static readonly string[] ThousandsMap;

		private static readonly string[] HundredsMap;

		private static readonly string[] TensMap;

		private static readonly string[] UnitsMap;

		private static readonly string[] UnitsMasculineOverrideMap;

		private static readonly string[] UnitsFeminineOverrideMap;

		private static readonly string[] UnitsNeuterOverride;

		private static readonly string[] UnitsIntraOverride;

		private readonly CultureInfo _culture;

		public CzechNumberToWordsConverter(CultureInfo culture)
		{
		}

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string UnitByGender(long number, GrammaticalGender? gender)
		{
			return null;
		}

		private void CollectLessThanThousand(List<string> parts, long number, GrammaticalGender? gender)
		{
		}

		private void CollectThousandAndAbove(List<string> parts, ref long number, long divisor, GrammaticalGender gender, string[] map)
		{
		}
	}
}
