using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class BanglaNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] HundredsMap;

		private static readonly Dictionary<int, string> OrdinalExceptions;

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		public override string Convert(long input)
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
