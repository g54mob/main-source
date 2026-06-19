using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct OwnerReferenceCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity owner;
}
