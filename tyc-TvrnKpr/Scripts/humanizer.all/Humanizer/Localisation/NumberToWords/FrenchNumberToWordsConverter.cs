using System.Collections.Generic;

namespace Humanizer.Localisation.NumberToWords
{
	internal class FrenchNumberToWordsConverter : FrenchNumberToWordsConverterBase
	{
		protected override void CollectPartsUnderAHundred(ICollection<string> parts, ref long number, GrammaticalGender gender, bool pluralize)
		{
		}

		protected override string GetTens(long tens)
		{
			return null;
		}
	}
}
