using Unity.Entities;

[InternalBufferCapacity(9)]
public struct MerchantItemInfoBuffer : IBufferElementData
{
	public ObjectID objectID;

	public int amount;

	public MerchantItemRequirement requirementToBeAvailable;
}
