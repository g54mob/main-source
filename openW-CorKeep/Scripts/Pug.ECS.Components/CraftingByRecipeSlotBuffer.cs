using Unity.Entities;
using Unity.NetCode;

public struct CraftingByRecipeSlotBuffer : IBufferElementData
{
	[GhostField]
	public int currentlyCraftingIndex;
}
