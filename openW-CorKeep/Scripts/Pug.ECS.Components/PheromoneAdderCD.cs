using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct PheromoneAdderCD : IComponentData, IQueryTypeParameter
{
	public PheromoneMask mask;
}
