using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct SoulsInfoCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool hasUnlockedSouls;
}
