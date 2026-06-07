using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class GreekNumberToWordsConverter : GenderlessNumberToWordsConverter
	{
		private readonly string[] UnitMap;

		private readonly string[] UnitsMap;

		private readonly string[] TensMap;

		private readonly string[] TensNoDiacriticsMap;

		private readonly string[] HundredMap;

		private readonly string[] HundredsMap;

		private static readonly Dictionary<long, string> ΟrdinalMap;

		public override string Convert(long number)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number)
		{
			return null;
		}

		private string GetOneDigitOrdinal(int number)
		{
			return null;
		}

		private string GetTwoDigigOrdinal(int number)
		{
			return null;
		}

		private string GetThreeDigitOrdinal(int number)
		{
			return null;
		}

		private string GetFourDigitOrdinal(int number)
		{
			return null;
		}

		private string ConvertImpl(long number, bool returnPluralized)
		{
			return null;
		}

		private string ConvertIntΒ13(long number, bool returnPluralized)
		{
			return null;
		}

		private string ConvertIntBH(long number, bool returnPluralized)
		{
			return null;
		}

		private string ConvertIntBT(long number, bool returnPluralized)
		{
			return null;
		}

		private string ConvertIntBM(long number)
		{
			return null;
		}

		private string ConvertIntBB(long number)
		{
			return null;
		}

		private string ConvertIntBTR(long number)
		{
			return null;
		}
	}
}
