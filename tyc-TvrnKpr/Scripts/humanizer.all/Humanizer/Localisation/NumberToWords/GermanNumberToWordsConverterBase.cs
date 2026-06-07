using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal abstract class GermanNumberToWordsConverterBase : GenderedNumberToWordsConverter
	{
		private readonly string[] UnitsMap;

		private readonly string[] TensMap;

		private readonly string[] UnitsOrdinal;

		private readonly string[] HundredOrdinalSingular;

		private readonly string[] HundredOrdinalPlural;

		private readonly string[] ThousandOrdinalSingular;

		private readonly string[] ThousandOrdinalPlural;

		private readonly string[] MillionOrdinalSingular;

		private readonly string[] MillionOrdinalPlural;

		private readonly string[] BillionOrdinalSingular;

		private readonly string[] BillionOrdinalPlural;

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private void CollectParts(ICollection<string> parts, ref long number, long divisor, bool addSpaceBeforeNextPart, string pluralFormat, string singular)
		{
		}

		private void CollectOrdinalParts(ICollection<string> parts, ref int number, int divisor, bool evaluateNoRest, string[] pluralFormats, string[] singulars)
		{
		}

		private string Part(string pluralFormat, string singular, long number)
		{
			return null;
		}

		private int NoRestIndex(int number)
		{
			return 0;
		}

		private string GetEndingForGender(GrammaticalGender gender)
		{
			return null;
		}

		protected virtual string GetTens(long tens)
		{
			return null;
		}
	}
}
