using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BirdBossHasAppearedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool Value;
}
