using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct OctopusBossHasAppearedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool Value;
}
