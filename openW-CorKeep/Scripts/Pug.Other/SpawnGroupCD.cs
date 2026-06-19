using Unity.Entities;

public struct SpawnGroupCD : IComponentData, IQueryTypeParameter
{
	public Entity spawner;

	public float spawnSize;
}
