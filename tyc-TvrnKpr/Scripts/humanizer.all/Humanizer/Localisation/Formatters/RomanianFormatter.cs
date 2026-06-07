using System.Globalization;

namespace Humanizer.Localisation.Formatters
{
	internal class RomanianFormatter : DefaultFormatter
	{
		private const int PrepositionIndicatingDecimals = 2;

		private const int MaxNumeralWithNoPreposition = 19;

		private const int MinNumeralWithNoPreposition = 1;

		private const string UnitPreposition = " de";

		private const string RomanianCultureCode = "ro";

		private static readonly double Divider;

		private readonly CultureInfo _romanianCulture;

		public RomanianFormatter()
			: base(null)
		{
		}

		protected override string Format(string resourceKey, int number, bool toWords = false)
		{
			return null;
		}

		private static bool ShouldUsePreposition(int number)
		{
			return false;
		}
	}
}
