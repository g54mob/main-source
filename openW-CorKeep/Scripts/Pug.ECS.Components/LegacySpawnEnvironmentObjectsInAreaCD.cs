using Unity.Entities;

public struct LegacySpawnEnvironmentObjectsInAreaCD : IComponentData, IQueryTypeParameter
{
	public int pendingSubAreas;

	public bool hasSpawnedSubParts;

	public bool fillPartialSubMap;
}
