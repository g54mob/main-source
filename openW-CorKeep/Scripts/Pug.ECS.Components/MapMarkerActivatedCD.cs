using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct MapMarkerActivatedCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public bool Value;

	[GhostField]
	public bool Hidden;
}
