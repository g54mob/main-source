using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class FinnishNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] OrdinalUnitsMap;

		private static readonly Dictionary<int, string> OrdinalExceptions;

		public override string Convert(long input)
		{
			return null;
		}

		private string GetOrdinalUnit(int number, bool useExceptions)
		{
			return null;
		}

		private string ToOrdinal(int number, bool useExceptions)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}
	}
}
