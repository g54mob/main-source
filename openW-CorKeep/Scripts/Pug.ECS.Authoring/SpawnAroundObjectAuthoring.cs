using System;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class SpawnAroundObjectAuthoring : MonoBehaviour
{
	[Serializable]
	public class SpawnEntry
	{
		public bool onlySpawnIfInCombat;

		public bool spawnCrittersInsteadOfObject;

		public float critterDespawnDistance = 50f;

		public ObjectData objectToSpawn;

		public int limitNumberSpawned = 50;

		public float minReachedLimitCooldown;

		public float maxReachedLimitCooldown;

		public float maxSpawnDistance = 40f;

		public float minSpawnCooldown = 1f;

		public float maxSpawnCooldown = 2f;

		[Tooltip("After the max number of spawned objects has been reached, a cooldown is started.")]
		public Season onlySpawnsInSeason;

		public bool objectIsPersistent;

		public bool spawnCloseToPlayers;

		[Tooltip("Biomes where this object can spawn. If empty, it spawns in all biomes.")]
		public List<Biome> spawnsInBiome;

		[Tooltip("Also check if the player is inside the biome, with padding.")]
		public bool playerNeedsToBeInsideBiome;

		[Tooltip("If assigned, the object will not spawn within maxSpawnDistance from this object.")]
		public ObjectID avoidSpawnCloseToObject;

		public ConditionID requiredCondition;
	}

	public List<SpawnEntry> spawnEntries;
}
