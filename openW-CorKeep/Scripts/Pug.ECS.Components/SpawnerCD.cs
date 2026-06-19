using Unity.Entities;
using Unity.Mathematics;

public struct SpawnerCD : IComponentData, IQueryTypeParameter
{
	public float minSpawnDistance;

	public float maxSpawnDistance;

	public int maxNumberSpawned;

	public float forgetWhenThisFarAway;

	public int2 lastPosition;

	public bool disableSpawnWhenStationary;
}
