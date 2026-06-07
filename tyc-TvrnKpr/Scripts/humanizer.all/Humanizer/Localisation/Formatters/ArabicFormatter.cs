namespace Humanizer.Localisation.Formatters
{
	internal class ArabicFormatter : DefaultFormatter
	{
		private const string DualPostfix = "_Dual";

		private const string PluralPostfix = "_Plural";

		public ArabicFormatter()
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
