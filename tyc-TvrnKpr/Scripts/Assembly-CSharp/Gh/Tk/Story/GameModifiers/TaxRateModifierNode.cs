namespace Gh.Tk.Story.GameModifiers
{
	public class TaxRateModifierNode : GameModifierNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetTaxCategories")]
		public string taxCategory;

		public int rate;

		public static int GetTaxRate(string category)
		{
			return 0;
		}

		private static ActiveStory FindLastActiveNode(string category)
		{
			return null;
		}

		public override string GetAlertTextKey()
		{
			return null;
		}
	}
}
