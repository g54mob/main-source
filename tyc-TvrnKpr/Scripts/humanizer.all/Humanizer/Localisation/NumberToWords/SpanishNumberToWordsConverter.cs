using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class SpanishNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private static readonly string[] HundredsRootMap;

		private static readonly string[] HundredthsRootMap;

		private static readonly string[] OrdinalsRootMap;

		private static readonly string[] TensMap;

		private static readonly string[] TenthsRootMap;

		private static readonly string[] ThousandthsRootMap;

		private static readonly string[] TupleMap;

		private static readonly string[] UnitsMap;

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string Convert(long number, WordForm wordForm, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender, WordForm wordForm)
		{
			return null;
		}

		public override string ConvertToTuple(int number)
		{
			return null;
		}

		private static string BuildWord(IReadOnlyList<string> wordParts)
		{
			return null;
		}

		private static string ConvertHundreds(in long inputNumber, out long remainder, GrammaticalGender gender)
		{
			remainder = default(long);
			return null;
		}

		private static string ConvertHundredths(in int number, out int remainder, GrammaticalGender gender)
		{
			remainder = default(int);
			return null;
		}

		private static string ConvertMappedOrdinalNumber(in int number, in int divisor, IReadOnlyList<string> map, out int remainder, GrammaticalGender gender)
		{
			remainder = default(int);
			return null;
		}

		private static string ConvertOrdinalUnits(in int number, GrammaticalGender gender, WordForm wordForm)
		{
			return null;
		}

		private static string ConvertTenths(in int number, out int remainder, GrammaticalGender gender)
		{
			remainder = default(int);
			return null;
		}

		private static string ConvertThousandths(in int number, out int remainder, GrammaticalGender gender)
		{
			remainder = default(int);
			return null;
		}

		private static string ConvertUnits(long inputNumber, GrammaticalGender gender, WordForm wordForm = WordForm.Normal)
		{
			return null;
		}

		private static IReadOnlyList<string> GetGenderedHundredsMap(GrammaticalGender gender)
		{
			return null;
		}

		private static string GetGenderedOne(GrammaticalGender gender, WordForm wordForm = WordForm.Normal)
		{
			return null;
		}

		private static string GetGenderedTwentyOne(GrammaticalGender gender, WordForm wordForm = WordForm.Normal)
		{
			return null;
		}

		private static bool HasOrdinalAbbreviation(int number, WordForm wordForm)
		{
			return false;
		}

		private static bool IsRoundBillion(int number)
		{
			return false;
		}

		private static bool IsRoundMillion(int number)
		{
			return false;
		}

		private static string PluralizeGreaterThanMillion(string singularWord)
		{
			return null;
		}

		private string ConvertGreaterThanMillion(in long inputNumber, out long remainder)
		{
			remainder = default(long);
			return null;
		}

		private string ConvertRoundBillionths(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string ConvertTensAndHunderdsOfThousandths(in int number, out int remainder, GrammaticalGender gender)
		{
			remainder = default(int);
			return null;
		}

		private string ConvertThousands(in long inputNumber, out long remainder, GrammaticalGender gender)
		{
			remainder = default(long);
			return null;
		}
	}
}
