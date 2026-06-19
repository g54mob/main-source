using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MinionCountTrackerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public int count;
}
