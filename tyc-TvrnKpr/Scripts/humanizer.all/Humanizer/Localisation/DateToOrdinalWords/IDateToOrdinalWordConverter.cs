using System;

namespace Humanizer.Localisation.DateToOrdinalWords
{
	public interface IDateToOrdinalWordConverter
	{
		string Convert(DateTime date);

		string Convert(DateTime date, GrammaticalCase grammaticalCase);
	}
}
