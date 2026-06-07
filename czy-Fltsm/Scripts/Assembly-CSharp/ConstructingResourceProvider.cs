public class ConstructingResourceProvider : ResourceProvider
{
	public ConstructingResourceProvider(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter)
		: base(constructible, subInventoryType, inventorySpaceLimiter, AssignmentType.Constructing)
	{
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return agent.GlobalHaulingPriorities.Constructing;
	}

	public override int GetCapacityPriority()
	{
		return 100;
	}
}
