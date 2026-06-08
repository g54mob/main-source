public class EventObjectiveBuyTreasure : EventObjectiveBase
{
	private string treasureId;

	public EventObjectiveBuyTreasure(int goal, string treasureId = null, string treasureName = null)
		: base("buy_treasure", goal)
	{
		this.treasureId = treasureId;
		if (treasureName != null)
		{
			description = string.Format(Te.xt("tid_q_basic_buy_item"), TranslateIfTID(treasureName));
		}
		else
		{
			description = Te.xt("tid_q_basic_buy_any_treas");
		}
	}

	public override void Init()
	{
		ShopController.OnItemPurchased += HandleItemPurchased;
	}

	public override void End()
	{
		ShopController.OnItemPurchased -= HandleItemPurchased;
	}

	private void HandleItemPurchased(Item item)
	{
		if (item is TreasureItem && (treasureId == null || item.id.Contains(treasureId)))
		{
			AddProgress();
		}
	}
}
