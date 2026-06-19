using Unity.Entities;

public struct SpawnEntitiesAroundEntityCD : IComponentData, IQueryTypeParameter
{
	public Entity mainEntity;

	public ObjectDataCD objectToSpawn;

	public ulong spawnsInBiomeBitMask;

	public bool playerNeedsToBeInsideBiome;

	public float maxSpawnDistance;

	public int limitNumberSpawned;

	public float minReachedLimitCooldown;

	public float maxReachedLimitCooldown;

	public float critterDespawnDistance;

	public float timer;

	public float minSpawnCooldown;

	public float maxSpawnCooldown;

	public bool onlySpawnIfInCombat;

	public bool spawnCrittersInsteadOfObject;

	public bool objectIsPersistent;

	public bool spawnCloseToPlayers;

	public int spawnCounter;

	public ObjectID avoidSpawnCloseToObject;

	public ConditionID requiredCondition;

	public ConditionData addAffixConditionOnSpawn;
}
