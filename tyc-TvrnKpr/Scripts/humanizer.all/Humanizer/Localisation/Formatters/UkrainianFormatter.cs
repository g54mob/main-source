using Humanizer.Localisation.GrammaticalNumber;

namespace Humanizer.Localisation.Formatters
{
	internal class UkrainianFormatter : DefaultFormatter
	{
		public UkrainianFormatter()
			: base(null)
		{
		}

		protected override string GetResourceKey(string resourceKey, int number)
		{
			return null;
		}

		private string GetSuffix(RussianGrammaticalNumber grammaticalNumber)
		{
			return null;
		}
	}
}
