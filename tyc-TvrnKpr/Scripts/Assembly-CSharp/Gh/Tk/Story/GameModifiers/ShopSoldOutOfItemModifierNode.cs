namespace Gh.Tk.Story.GameModifiers
{
	public class ShopSoldOutOfItemModifierNode : ShopGameModifierBaseNode
	{
		[DropDownChoice(typeof(StoryHelper), "GetAllGameItemTemplateIds")]
		public string itemKey;

		public static bool IsItemSoldOut(string itemKey)
		{
			return false;
		}

		public override string GetAlertTextKey()
		{
			return null;
		}
	}
}
