using Pug.UnityExtensions;
using Unity.Entities;
using Unity.Mathematics;

public struct SpawnEntityOnDeathCD : IComponentData, IQueryTypeParameter
{
	public ObjectID objectToSpawn;

	public int objectVariation;

	public float spawnChance;

	public float3 offset;

	public RangeInt amount;

	public int maxAmountAllowedWithinRadius;

	public float maxAmountCheckRadius;

	public bool dontSpawnIfKilledByDestroyTimer;
}
