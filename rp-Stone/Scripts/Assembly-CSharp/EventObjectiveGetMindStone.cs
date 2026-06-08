public class EventObjectiveGetMindStone : EventObjectiveBase
{
	public EventObjectiveGetMindStone()
		: base("get_mind_stone", 1)
	{
		description = Te.xt("tid_q_basic_get_mind_stone");
	}

	public override bool CheckConditions()
	{
		return !Inventory.Singleton.HasItemById("mind_stone");
	}

	public override void Init()
	{
		Inventory.Singleton.OnItemAdded += HandleItemAdded;
	}

	public override void End()
	{
		Inventory.Singleton.OnItemAdded -= HandleItemAdded;
	}

	private void HandleItemAdded(Item item, int count)
	{
		if (item.id == "mind_stone")
		{
			AddProgress();
		}
	}
}
