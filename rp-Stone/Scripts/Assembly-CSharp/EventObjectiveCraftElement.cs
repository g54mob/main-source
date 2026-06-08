public class EventObjectiveCraftElement : EventObjectiveBase
{
	private ItemData.Element element;

	private string keyword;

	public EventObjectiveCraftElement(int goal, ItemData.Element element, string elementName, string keyword = null, string keywordName = null)
		: base("craft_element", goal)
	{
		this.element = element;
		this.keyword = keyword;
		if (keywordName != null)
		{
			string arg = TranslateIfTID(keywordName).Replace("<element>", TranslateIfTID(elementName));
			description = string.Format(Te.xt("tid_q_basic_craft_weapon"), goal, arg);
		}
		else
		{
			description = string.Format(Te.xt("tid_q_basic_craft_type"), goal, TranslateIfTID(elementName));
		}
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
		if (result.resultingItem.element == element && (keyword == null || result.resultingItem.GetGroupId().Contains(keyword)))
		{
			int num = ItemFactory.GetLevelDisplayIntegerForItem(result.resultingItem) - 1;
			if (num > progress)
			{
				AddProgress(num - progress);
			}
		}
	}
}
