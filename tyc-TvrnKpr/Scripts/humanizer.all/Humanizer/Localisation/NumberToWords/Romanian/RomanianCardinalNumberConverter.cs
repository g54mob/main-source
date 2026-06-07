using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian
{
	internal class RomanianCardinalNumberConverter
	{
		private enum ThreeDigitSets
		{
			Units = 0,
			Thousands = 1,
			Millions = 2,
			Billions = 3,
			More = 4
		}

		private readonly string[] _units;

		private readonly string[] _teensUnder20NumberToText;

		private readonly string[] _tensOver20NumberToText;

		private readonly string _feminineSingular;

		private readonly string _masculineSingular;

		private readonly string _joinGroups;

		private readonly string _joinAbove20;

		private readonly string _minusSign;

		public string Convert(int number, GrammaticalGender gender)
		{
			return null;
		}

		private List<int> SplitEveryThreeDigits(int number)
		{
			return null;
		}

		private Func<int, GrammaticalGender, string> GetNextPartConverter(ThreeDigitSets currentSet)
		{
			return null;
		}

		private string ThreeDigitSetConverter(int number, GrammaticalGender gender, bool thisIsLastSet = false)
		{
			return null;
		}

		private string getPartByGender(string multiGenderPart, GrammaticalGender gender)
		{
			return null;
		}

		private bool IsAbove20(int number)
		{
			return false;
		}

		private string HundredsToText(int hundreds)
		{
			return null;
		}

		private string UnitsConverter(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string ThousandsConverter(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string MillionsConverter(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string BillionsConverter(int number, GrammaticalGender gender)
		{
			return null;
		}
	}
}
