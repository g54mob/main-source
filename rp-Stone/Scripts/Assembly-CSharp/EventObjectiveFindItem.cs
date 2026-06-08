public class EventObjectiveFindItem : EventObjectiveBase
{
	private string itemId;

	public EventObjectiveFindItem(int goal, string itemId, string itemName)
		: base("find_item", goal)
	{
		this.itemId = itemId;
		description = string.Format(Te.xt("Find the {0}"), TranslateIfTID(itemName));
	}

	public override void Init()
	{
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId(itemId);
		if (firstItemWithId != null)
		{
			AddProgress(firstItemWithId.count);
		}
		Inventory.Singleton.OnItemGained += HandleItemGained;
	}

	public override void End()
	{
		Inventory.Singleton.OnItemGained -= HandleItemGained;
	}

	private void HandleItemGained(Item item, int count)
	{
		if (item.id == itemId)
		{
			AddProgress(count);
		}
	}
}
