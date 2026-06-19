using Unity.Entities;

public struct CanBeDiscoveredCD : IComponentData, IQueryTypeParameter
{
	public float DistanceToDiscoverSq;
}
