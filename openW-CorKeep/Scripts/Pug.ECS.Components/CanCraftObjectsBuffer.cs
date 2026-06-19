using Unity.Entities;

[InternalBufferCapacity(0)]
public struct CanCraftObjectsBuffer : IBufferElementData
{
	public ObjectID objectID;

	public int amount;

	public int entityAmountToConsume;

	public bool allowCraftingNone;

	public float craftingTimeOverride;
}
