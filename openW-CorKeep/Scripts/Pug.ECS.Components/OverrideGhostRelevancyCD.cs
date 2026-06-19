using Unity.Entities;
using Unity.Mathematics;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct OverrideGhostRelevancyCD : IComponentData, IQueryTypeParameter
{
	public float2 rect;
}
