using Unity.Entities;

public struct SpawnRootsInAreaCD : IComponentData, IQueryTypeParameter
{
	public int PendingSpawns;

	public bool HasCreatedSubAreas;
}
