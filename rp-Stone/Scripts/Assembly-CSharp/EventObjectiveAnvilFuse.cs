public class EventObjectiveAnvilFuse : EventObjectiveBase
{
	private string itemId;

	public EventObjectiveAnvilFuse(int goal, string itemId, string itemName)
		: base("anvil_fuse", goal)
	{
		this.itemId = itemId;
		string starRatingStringForDisplayLevel = ItemFactory.GetStarRatingStringForDisplayLevel(goal);
		description = string.Format(Te.xt("Craft a {0} {1}"), starRatingStringForDisplayLevel, TranslateIfTID(itemName));
	}

	public override void Init()
	{
		AnvilScreen.singleton.OnFuse += HandleAnvilItemFused;
	}

	public override void End()
	{
		AnvilScreen.singleton.OnFuse -= HandleAnvilItemFused;
	}

	private void HandleAnvilItemFused(ItemFactory.Result result)
	{
		if (result.resultingItem.id == itemId)
		{
			int num = ItemFactory.GetLevelDisplayIntegerForItem(result.resultingItem) - 1;
			if (num > progress)
			{
				AddProgress(num - progress);
			}
		}
	}
}
