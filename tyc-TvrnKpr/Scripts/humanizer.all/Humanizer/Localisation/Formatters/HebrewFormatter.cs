namespace Humanizer.Localisation.Formatters
{
	internal class HebrewFormatter : DefaultFormatter
	{
		private const string DualPostfix = "_Dual";

		private const string PluralPostfix = "_Plural";

		public HebrewFormatter()
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
