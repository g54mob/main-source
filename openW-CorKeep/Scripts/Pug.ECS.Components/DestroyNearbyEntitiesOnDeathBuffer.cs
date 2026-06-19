using Unity.Entities;

[InternalBufferCapacity(0)]
public struct DestroyNearbyEntitiesOnDeathBuffer : IBufferElementData
{
	public ObjectID objectID;
}
