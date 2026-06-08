using System.Collections.Generic;

public class EventObjectiveOpenTreasure : EventObjectiveBase
{
	private string treasureId;

	public EventObjectiveOpenTreasure(int goal, string treasureId = null, string treasureName = null)
		: base("open_treasure", goal)
	{
		this.treasureId = treasureId;
		if (treasureName != null)
		{
			description = string.Format(Te.xt("tid_q_basic_open_treasure"), TranslateIfTID(treasureName));
		}
		else
		{
			description = Te.xt("tid_q_basic_open_any_treas");
		}
	}

	public override void Init()
	{
		TreasureItem.OnTreasureOpened += HandleTreasureOpened;
	}

	public override void End()
	{
		TreasureItem.OnTreasureOpened -= HandleTreasureOpened;
	}

	private void HandleTreasureOpened(string itemId, string groupId, List<Item> items, List<int> amounts)
	{
		if (treasureId == null || itemId.Contains(treasureId))
		{
			AddProgress();
		}
	}
}
