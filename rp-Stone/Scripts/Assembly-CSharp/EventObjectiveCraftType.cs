public class EventObjectiveCraftType : EventObjectiveBase
{
	private string keyword;

	public EventObjectiveCraftType(int goal, string keyword, string keywordName)
		: base("craft_type", goal)
	{
		this.keyword = keyword;
		description = string.Format(Te.xt("tid_q_basic_craft_weapon"), goal, TranslateIfTID(keywordName));
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
		if (result.resultingItem.GetGroupId().Contains(keyword))
		{
			int num = ItemFactory.GetLevelDisplayIntegerForItem(result.resultingItem) - 1;
			if (num > progress)
			{
				AddProgress(num - progress);
			}
		}
	}
}
