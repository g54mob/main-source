public class CraftingResourceProvider : ResourceProvider
{
	public CraftingResourceProvider(IConstructible constructible, SubInventoryType subInventoryType, IInventorySpaceLimiter inventorySpaceLimiter)
		: base(constructible, subInventoryType, inventorySpaceLimiter, AssignmentType.Crafting)
	{
	}

	public override int GetAssignmentPriority(Agent agent, int haulingPriority)
	{
		return agent.GlobalHaulingPriorities.Crafting;
	}
}
