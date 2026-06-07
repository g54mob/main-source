using Humanizer.Localisation.DateToOrdinalWords;

namespace Humanizer.Configuration
{
	internal class DateToOrdinalWordsConverterRegistry : LocaliserRegistry<IDateToOrdinalWordConverter>
	{
		public DateToOrdinalWordsConverterRegistry()
			: base((IDateToOrdinalWordConverter)default(_00210))
		{
		}
	}
}
