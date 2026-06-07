namespace Humanizer.Localisation.Formatters
{
	internal class CroatianFormatter : DefaultFormatter
	{
		private const string DualTrialQuadralPostfix = "_DualTrialQuadral";

		public CroatianFormatter()
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}
	}
}
