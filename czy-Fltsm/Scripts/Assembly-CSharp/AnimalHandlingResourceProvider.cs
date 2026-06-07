public class AnimalHandlingResourceProvider : ResourceProvider
{
	public AnimalHandlingResourceProvider(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter)
		: base(constructible, subInventoryType, inventorySpaceLimiter, AssignmentType.AnimalHandling)
	{
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return agent.GlobalHaulingPriorities.AnimalHandling;
	}

	public override int GetCapacityPriority()
	{
		return 0;
	}
}
