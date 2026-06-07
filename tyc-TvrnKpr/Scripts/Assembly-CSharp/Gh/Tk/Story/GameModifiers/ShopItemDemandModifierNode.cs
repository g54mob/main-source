namespace Gh.Tk.Story.GameModifiers
{
	public class ShopItemDemandModifierNode : ShopGameModifierBaseNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string itemKey;

		public ShopItemDemand demand;

		public override string GetAlertTextKey()
		{
			return null;
		}

		public override void OnTrigger(ActiveStory story)
		{
		}

		public void InvalidatePatronSecondaryShoppingNeed()
		{
		}

		public override void Complete(ActiveStory story)
		{
		}
	}
}
