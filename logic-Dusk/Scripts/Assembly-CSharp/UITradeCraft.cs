public class UITradeCraft : UICraftingList
{
	public override void Refresh()
	{
		base.CurrentHighlightedIndex = -1;
		if (craftingItems != null && craftingItems.Length > 0)
		{
			if (craftingItems[0].ModificationList == null)
			{
				craftingItems[0].AddModification(new CraftFuelMod());
			}
			base.CurrentHighlightedIndex = 0;
		}
	}
}
