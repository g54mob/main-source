using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct PugDamageCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity Entity;

	[GhostField]
	public int Damage;
}
