using System.Collections.Generic;
using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.NumberToWords
{
	internal class UkrainianNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] HundredsMap;

		private static readonly string[] TensMap;

		private static readonly string[] UnitsMap;

		private static readonly string[] UnitsOrdinalPrefixes;

		private static readonly string[] TensOrdinalPrefixes;

		private static readonly string[] TensOrdinal;

		private static readonly string[] UnitsOrdinal;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static void CollectPartsUnderOneThousand(ICollection<string> parts, long number, GrammaticalGender gender)
		{
		}

		private static string GetPrefix(int number)
		{
			return null;
		}

		private static void CollectParts(ICollection<string> parts, ref long number, long divisor, GrammaticalGender gender, params string[] forms)
		{
		}

		private static void CollectOrdinalParts(ICollection<string> parts, ref int number, int divisor, GrammaticalGender gender, string prefixedForm, params string[] forms)
		{
		}

		private static int GetIndex(RussianGrammaticalNumber number)
		{
			return 0;
		}

		private static string ChooseOneForGrammaticalNumber(long number, string[] forms)
		{
			return null;
		}

		private static string GetEndingForGender(GrammaticalGender gender, int number)
		{
			return null;
		}
	}
}
