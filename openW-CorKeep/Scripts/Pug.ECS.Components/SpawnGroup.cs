using Unity.Entities;
using Unity.Mathematics;

public struct SpawnGroup
{
	public ObjectDataCD killRequirement;

	public BlobArray<SpawnObject> spawnObjects;

	public int weight;

	public InstancedSpawnGroup GetInstance(ref Random rng, float scaleSpawnNumbers = 1f)
	{
		InstancedSpawnGroup result = default(InstancedSpawnGroup);
		for (int i = 0; i < spawnObjects.Length; i++)
		{
			int item = (int)math.floor(scaleSpawnNumbers * rng.NextFloat(spawnObjects[i].amountToSpawn.min, spawnObjects[i].amountToSpawn.max + 1));
			if (item > 0)
			{
				result.spawnObjects.Add(in spawnObjects[i].objectData.objectID);
				result.spawnObjectAmounts.Add(in item);
			}
		}
		return result;
	}
}
