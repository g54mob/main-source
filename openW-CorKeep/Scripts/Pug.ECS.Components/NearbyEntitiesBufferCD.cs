using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
[InternalBufferCapacity(8)]
public struct NearbyEntitiesBufferCD : IBufferElementData
{
	public Entity entity;
}
