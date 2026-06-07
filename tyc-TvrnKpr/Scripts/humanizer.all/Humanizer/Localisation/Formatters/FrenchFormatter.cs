namespace Humanizer.Localisation.Formatters
{
	internal class FrenchFormatter : DefaultFormatter
	{
		private const string DualPostfix = "_Dual";

		public FrenchFormatter(string localeCode)
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
