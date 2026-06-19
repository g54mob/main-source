using Unity.Entities;

public struct SpawnDungeonsAndScenesInArea : IComponentData, IQueryTypeParameter
{
	public int PendingSpawns;
}
