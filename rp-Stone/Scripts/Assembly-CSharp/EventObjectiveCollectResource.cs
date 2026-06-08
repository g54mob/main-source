public class EventObjectiveCollectResource : EventObjectiveBase
{
	private Data.Resource resourceType;

	public EventObjectiveCollectResource(int goal, Data.Resource resourceType, string itemName)
		: base("collect_resource", goal)
	{
		this.resourceType = resourceType;
		description = string.Format(Te.xt("tid_q_basic_collect_resource"), TranslateIfTID(itemName));
	}

	public override void Init()
	{
		InventoryResources.singleton.OnResourceAdded += HandleItemGained;
	}

	public override void End()
	{
		InventoryResources.singleton.OnResourceAdded -= HandleItemGained;
	}

	private void HandleItemGained(Data.Resource resourceType, int amount)
	{
		if (resourceType == this.resourceType)
		{
			AddProgress(amount);
		}
	}
}
