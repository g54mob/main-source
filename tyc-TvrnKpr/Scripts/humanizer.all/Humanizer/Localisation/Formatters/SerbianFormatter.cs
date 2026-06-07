namespace Humanizer.Localisation.Formatters
{
	internal class SerbianFormatter : DefaultFormatter
	{
		private const string PaucalPostfix = "_Paucal";

		public SerbianFormatter(string localeCode)
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
