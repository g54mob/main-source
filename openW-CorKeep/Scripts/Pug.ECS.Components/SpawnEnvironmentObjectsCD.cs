using Unity.Entities;
using Unity.Mathematics;

public struct SpawnEnvironmentObjectsCD : IComponentData, IQueryTypeParameter
{
	public bool respawn;

	public bool fillPartialSubMap;

	public int2 position;

	public Entity optionalSpawnEntityRef;

	public int2 size => new int2(16, 16);
}
