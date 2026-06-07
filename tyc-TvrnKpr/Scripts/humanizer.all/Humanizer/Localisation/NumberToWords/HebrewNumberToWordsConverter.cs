using System;
using System.Collections.Generic;
using System.Globalization;

namespace Humanizer.Localisation.NumberToWords
{
	internal class HebrewNumberToWordsConverter : GenderedNumberToWordsConverter
	{
		private class DescriptionAttribute : Attribute
		{
			public string Description { get; set; }

			public DescriptionAttribute(string description)
			{
			}
		}

		private enum Group
		{
			Hundreds = 100,
			Thousands = 1000,
			[Description("מיליון")]
			Millions = 1000000,
			[Description("מיליארד")]
			Billions = 1000000000
		}

		private static readonly string[] UnitsFeminine;

		private static readonly string[] UnitsMasculine;

		private static readonly string[] TensUnit;

		private readonly CultureInfo _culture;

		public HebrewNumberToWordsConverter(CultureInfo culture)
		{
		}

		public override string Convert(long input, GrammaticalGender gender, bool addAnd = true)
		{
			return null;
		}

		public override string ConvertToOrdinal(int number, GrammaticalGender gender)
		{
			return null;
		}

		private void ToBigNumber(int number, Group group, List<string> parts)
		{
		}

		private void ToThousands(int number, List<string> parts)
		{
		}

		private static void ToHundreds(int number, List<string> parts)
		{
		}
	}
}
