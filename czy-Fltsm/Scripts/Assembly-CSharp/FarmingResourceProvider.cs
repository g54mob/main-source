public class FarmingResourceProvider : ResourceProvider
{
	public FarmingResourceProvider(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter)
		: base(constructible, subInventoryType, inventorySpaceLimiter, AssignmentType.Farming)
	{
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return agent.GlobalHaulingPriorities.Farming;
	}

	public override int GetCapacityPriority()
	{
		return 100;
	}
}
