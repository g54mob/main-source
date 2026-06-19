using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct CoreBossOrbCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity boss;
}
