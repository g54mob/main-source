using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct GiantCicadaBossHasAppearedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool Value;
}
