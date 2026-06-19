using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct TitanShrineCD : IComponentData, IQueryTypeParameter
{
	public ObjectID titanObjectID;
}
