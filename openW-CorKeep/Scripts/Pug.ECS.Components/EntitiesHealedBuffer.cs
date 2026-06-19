using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(0)]
public struct EntitiesHealedBuffer : IBufferElementData
{
	[GhostField]
	public Entity entity;
}
