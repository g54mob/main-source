using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.All)]
public struct AuraDistanceOverrideCD : IComponentData, IQueryTypeParameter
{
	[GhostField]
	public float distance;
}
