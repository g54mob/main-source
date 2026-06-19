using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct ClientSubMapLayerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public TileCD layer;

	[GhostField]
	public ClientSubMapLayer data;
}
