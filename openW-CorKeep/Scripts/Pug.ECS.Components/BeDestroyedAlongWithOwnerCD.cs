using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct BeDestroyedAlongWithOwnerCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity owner;
}
