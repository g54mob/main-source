namespace Humanizer.Localisation.Formatters
{
	internal class MalteseFormatter : DefaultFormatter
	{
		private const string DualPostfix = "_Dual";

		private static readonly string[] DualResourceKeys;

		public MalteseFormatter(string localeCode)
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
