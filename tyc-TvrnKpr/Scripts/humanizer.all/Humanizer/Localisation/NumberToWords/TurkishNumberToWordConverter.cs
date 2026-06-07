using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class TurkishNumberToWordConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly Dictionary<char, string> OrdinalSuffix;

		private static readonly Dictionary<char, string> TupleSuffix;

		public override string Convert(long input)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		public override string ConvertToTuple(int number)
		{
			return null;
		}
	}
}
