using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct HydraBossVulnerableEntityCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public Entity entity;
}
