public class CookingResourceProvider : ResourceProvider
{
	public CookingResourceProvider(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter)
		: base(constructible, subInventoryType, inventorySpaceLimiter, AssignmentType.Cooking)
	{
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return agent.GlobalHaulingPriorities.Cooking;
	}
}
