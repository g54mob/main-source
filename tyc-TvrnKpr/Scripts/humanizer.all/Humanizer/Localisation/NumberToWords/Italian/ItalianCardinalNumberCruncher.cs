using System;
using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Italian
{
	internal class ItalianCardinalNumberCruncher
	{
		protected enum ThreeDigitSets
		{
			Units = 0,
			Thousands = 1,
			Millions = 2,
			Billions = 3,
			More = 4
		}

		protected readonly int _fullNumber;

		protected readonly List<int> _threeDigitParts;

		protected readonly GrammaticalGender _gender;

		protected ThreeDigitSets _nextSet;

		protected static string[] _unitsNumberToText;

		protected static string[] _tensOver20NumberToText;

		protected static string[] _teensUnder20NumberToText;

		protected static string[] _hundredNumberToText;

		public ItalianCardinalNumberCruncher(int number, GrammaticalGender gender)
		{
		}

		public string Convert()
		{
			return null;
		}

		protected static List<int> SplitEveryThreeDigits(int number)
		{
			return null;
		}

		public Func<int, string> GetNextPartConverter()
		{
			return null;
		}

		protected static string ThreeDigitSetConverter(int number, bool thisIsLastSet = false)
		{
			return null;
		}

		protected string UnitsConverter(int number)
		{
			return null;
		}

		protected static string ThousandsConverter(int number)
		{
			return null;
		}

		protected static string MillionsConverter(int number)
		{
			return null;
		}

		protected static string BillionsConverter(int number)
		{
			return null;
		}
	}
}
