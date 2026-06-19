using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct WallBossBufferElement : IBufferElementData
{
	[GhostField]
	public Entity wallBoss;

	[GhostField]
	public int segmentNumber;
}
