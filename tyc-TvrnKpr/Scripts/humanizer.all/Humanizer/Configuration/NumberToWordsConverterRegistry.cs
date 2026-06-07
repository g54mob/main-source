using Humanizer.Localisation.NumberToWords;

namespace Humanizer.Configuration
{
	internal class NumberToWordsConverterRegistry : LocaliserRegistry<INumberToWordsConverter>
	{
		public NumberToWordsConverterRegistry()
			: base((INumberToWordsConverter)default(_00210))
		{
		}
	}
}
