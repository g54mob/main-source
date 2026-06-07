using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class ArabicNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] Groups;

		private static readonly string[] AppendedGroups;

		private static readonly string[] PluralGroups;

		private static readonly string[] OnesGroup;

		private static readonly string[] TensGroup;

		private static readonly string[] HundredsGroup;

		private static readonly string[] AppendedTwos;

		private static readonly string[] Twos;

		private static readonly string[] FeminineOnesGroup;

		private static readonly Dictionary<string, string> OrdinalExceptions;

		private static readonly Dictionary<string, string> FeminineOrdinalExceptions;

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static string ParseNumber(string word, int number, GrammaticalGender gender)
		{
			return null;
		}
	}
}
