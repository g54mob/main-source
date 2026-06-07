using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class KoreanNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap1;

		private static readonly string[] UnitsMap2;

		private static readonly string[] UnitsMap3;

		private static readonly Dictionary<long, string> OrdinalExceptions;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private string ConvertImpl(long number, bool isOrdinal)
		{
			return null;
		}
	}
}
