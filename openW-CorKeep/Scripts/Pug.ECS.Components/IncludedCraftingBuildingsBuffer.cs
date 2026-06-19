using Unity.Entities;

[InternalBufferCapacity(0)]
public struct IncludedCraftingBuildingsBuffer : IBufferElementData
{
	public ObjectID objectID;

	public int amountOfCraftingOptions;
}
