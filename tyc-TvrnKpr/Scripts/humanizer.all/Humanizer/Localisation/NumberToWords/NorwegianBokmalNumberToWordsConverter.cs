using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class NorwegianBokmalNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		private static readonly Dictionary<int, string> OrdinalExceptions;

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string Convert(int number, bool isOrdinal, GrammaticalGender gender)
		{
			return null;
		}

		private static string GetUnitValue(int number, bool isOrdinal)
		{
			return null;
		}

		private static bool ExceptionNumbersToWords(int number, out string words)
		{
			words = null;
			return false;
		}

		private string Part(string pluralFormat, string singular, int number, bool postfixSpace = false)
		{
			return null;
		}
	}
}
