namespace Humanizer.Localisation.Formatters
{
	internal class CzechSlovakPolishFormatter : DefaultFormatter
	{
		private const string PaucalPostfix = "_Paucal";

		public CzechSlovakPolishFormatter(string localeCode)
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
