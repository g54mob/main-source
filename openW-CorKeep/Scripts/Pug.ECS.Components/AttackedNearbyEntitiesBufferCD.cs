using Unity.Entities;

[InternalBufferCapacity(8)]
public struct AttackedNearbyEntitiesBufferCD : IBufferElementData
{
	public Entity entity;
}
