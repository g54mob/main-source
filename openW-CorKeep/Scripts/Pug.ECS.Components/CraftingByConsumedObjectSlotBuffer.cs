using Unity.Entities;

public struct CraftingByConsumedObjectSlotBuffer : IBufferElementData
{
	public ContainedObjectsBuffer previousConsumedItem;
}
