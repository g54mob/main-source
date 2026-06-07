using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords.Romanian
{
	internal class RomanianOrdinalNumberConverter
	{
		private readonly Dictionary<int, string> _ordinalsUnder10;

		private readonly string _femininePrefix;

		private readonly string _masculinePrefix;

		private readonly string _feminineSuffix;

		private readonly string _masculineSuffix;

		public string Convert(int number, GrammaticalGender gender)
		{
			return null;
		}

		private string getPartByGender(string multiGenderPart, GrammaticalGender gender)
		{
			return null;
		}
	}
}
