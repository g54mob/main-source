using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class IndianNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private static readonly Dictionary<long, string> OrdinalExceptions;

		private static readonly string[] Tillnineteen;

		private static readonly string[] Tens;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		public string NumberToText(long number)
		{
			return null;
		}

		private static bool ExceptionNumbersToWords(long number, out string words)
		{
			words = null;
			return false;
		}
	}
}
