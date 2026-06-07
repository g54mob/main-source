using System.Globalization;

namespace Humanizer.Localisation.Formatters
{
	internal class IcelandicFormatter : DefaultFormatter
	{
		private const string LocaleCode = "is";

		private readonly CultureInfo _localCulture;

		public IcelandicFormatter()
			: base(null)
		{
		}

		public override string DataUnitHumanize(DataUnit dataUnit, double count, bool toSymbol = true)
		{
			return null;
		}

		protected override string Format(string resourceKey, int number, bool toWords = false)
		{
			return null;
		}
	}
}
