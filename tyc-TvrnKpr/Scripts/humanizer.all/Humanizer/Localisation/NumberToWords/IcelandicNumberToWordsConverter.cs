using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class IcelandicNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private class Fact
		{
			public long Power { get; set; }

			public GrammaticalGender Gender { get; set; }

			public string Plural { get; set; }

			public string Single { get; set; }

			public string OrdinalPrefix { get; set; }
		}

		private static readonly string[] UnitsMap;

		private static readonly string[] FeminineUnitsMap;

		private static readonly string[] MasculineUnitsMap;

		private static readonly string[] NeuterUnitsMap;

		private static readonly string[] TensMap;

		private static readonly string[] UnitsOrdinalPrefixes;

		private static readonly string[] TensOrdinalPrefixes;

		private const string AndSplit = "og";

		private static readonly Dictionary<int, Fact> PowerOfTenMap;

		private static bool IsAndSplitNeeded(int number)
		{
			return false;
		}

		private static string GetOrdinalEnding(GrammaticalGender gender)
		{
			return null;
		}

		private static void GetUnits(ICollection<string> builder, long number, GrammaticalGender gender)
		{
		}

		private static void CollectOrdinalParts(ICollection<string> builder, int threeDigitPart, Fact conversionRule, GrammaticalGender partGender, GrammaticalGender ordinalGender)
		{
		}

		private static string CollectOrdinalPartsUnderAHundred(int number, GrammaticalGender gender)
		{
			return null;
		}

		private static void CollectParts(IList<string> parts, ref long number, ref bool needsAnd, Fact rule)
		{
		}

		private static void CollectPart(ICollection<string> parts, long number, Fact rule)
		{
		}

		private static void CollectPartUnderOneThousand(ICollection<string> builder, long number, GrammaticalGender gender)
		{
		}

		private static void CollectOrdinal(IList<string> parts, ref int number, ref bool needsAnd, Fact rule, GrammaticalGender gender)
		{
		}

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}
	}
}
