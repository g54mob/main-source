using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class AfrikaansNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly Dictionary<int, string> OrdinalExceptions;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private string Convert(int number, bool isOrdinal)
		{
			return null;
		}

		private static string GetUnitValue(int number, bool isOrdinal)
		{
			return null;
		}

		private static string RemoveOnePrefix(string toWords)
		{
			return null;
		}

		private static bool ExceptionNumbersToWords(int number, out string words)
		{
			words = null;
			return false;
		}
	}
}
