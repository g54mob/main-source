using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CoreBossOrbsBuffer : IBufferElementData
{
	[GhostField]
	public Entity orb;
}
