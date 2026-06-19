using Unity.Entities;
using Unity.NetCode;

[GhostComponent(PrefabType = GhostPrefabType.Server)]
public struct PheromoneSensorCD : IComponentData, IQueryTypeParameter
{
	public PheromoneMask invertDirection;

	public PheromoneDirection direction;

	public bool reset;
}
