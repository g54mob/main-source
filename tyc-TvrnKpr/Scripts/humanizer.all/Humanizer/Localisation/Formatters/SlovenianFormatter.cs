namespace Humanizer.Localisation.Formatters
{
	internal class SlovenianFormatter : DefaultFormatter
	{
		private const string DualPostfix = "_Dual";

		private const string TrialQuadralPostfix = "_TrialQuadral";

		public SlovenianFormatter()
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
