using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
[InternalBufferCapacity(5)]
public struct CollectedSoulsBuffer : IBufferElementData
{
	[GhostField]
	public SoulID soulId;
}
