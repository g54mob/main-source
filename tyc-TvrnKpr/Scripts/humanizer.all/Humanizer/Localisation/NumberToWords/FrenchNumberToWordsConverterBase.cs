using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal abstract class FrenchNumberToWordsConverterBase : GenderedNumberToWordsConverter
	{
		private static readonly string[] UnitsMap;

		private static readonly string[] TensMap;

		public override string Convert(long number, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		protected static string GetUnits(long number, GrammaticalGender gender)
		{
			return null;
		}

		private static void CollectHundreds(ICollection<string> parts, ref long number, long d, string form, bool pluralize)
		{
		}

		private void CollectParts(ICollection<string> parts, ref long number, long d, string form)
		{
		}

		private void CollectPartsUnderAThousand(ICollection<string> parts, long number, GrammaticalGender gender, bool pluralize)
		{
		}

		private void CollectThousands(ICollection<string> parts, ref long number, int d, string form)
		{
		}

		protected virtual void CollectPartsUnderAHundred(ICollection<string> parts, ref long number, GrammaticalGender gender, bool pluralize)
		{
		}

		protected virtual string GetTens(long tens)
		{
			return null;
		}
	}
}
