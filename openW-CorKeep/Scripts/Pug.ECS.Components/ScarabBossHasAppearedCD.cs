using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ScarabBossHasAppearedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool Value;
}
