using System;

namespace Humanizer.Localisation.DateToOrdinalWords
{
	internal class DefaultDateToOrdinalWordConverter : IDateToOrdinalWordConverter
	{
		public virtual string Convert(DateTime date)
		{
			return null;
		}

		public virtual string Convert(DateTime date, GrammaticalCase grammaticalCase)
		{
			return null;
		}
	}
}
