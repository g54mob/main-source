using System.Collections.Generic;
using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class SpawnAroundObjectConverter : SingleAuthoringComponentConverter<SpawnAroundObjectAuthoring>
{
	private static ulong ConvertBiomesToBitMask(IReadOnlyList<Biome> biomes)
	{
		ulong num = 0uL;
		for (int i = 0; i < biomes.Count; i++)
		{
			num |= (ulong)(1L << (int)biomes[i]);
		}
		return num;
	}

	protected override void Convert(SpawnAroundObjectAuthoring authoring)
	{
		Season season = (Application.isPlaying ? Manager.prefs.season : Season.None);
		foreach (SpawnAroundObjectAuthoring.SpawnEntry spawnEntry in authoring.spawnEntries)
		{
			int limitNumberSpawned = ((spawnEntry.onlySpawnsInSeason == Season.None || spawnEntry.onlySpawnsInSeason == season) ? spawnEntry.limitNumberSpawned : 0);
			Entity entity = CreateAdditionalEntity();
			AddComponentData(entity, new SpawnEntitiesAroundEntityCD
			{
				mainEntity = base.PrimaryEntity,
				limitNumberSpawned = limitNumberSpawned,
				minReachedLimitCooldown = spawnEntry.minReachedLimitCooldown,
				maxReachedLimitCooldown = spawnEntry.maxReachedLimitCooldown,
				maxSpawnDistance = spawnEntry.maxSpawnDistance,
				critterDespawnDistance = spawnEntry.critterDespawnDistance,
				objectToSpawn = spawnEntry.objectToSpawn,
				onlySpawnIfInCombat = spawnEntry.onlySpawnIfInCombat,
				spawnCrittersInsteadOfObject = spawnEntry.spawnCrittersInsteadOfObject,
				minSpawnCooldown = spawnEntry.minSpawnCooldown,
				maxSpawnCooldown = spawnEntry.maxSpawnCooldown,
				objectIsPersistent = spawnEntry.objectIsPersistent,
				spawnCloseToPlayers = spawnEntry.spawnCloseToPlayers,
				spawnsInBiomeBitMask = ConvertBiomesToBitMask(spawnEntry.spawnsInBiome),
				playerNeedsToBeInsideBiome = spawnEntry.playerNeedsToBeInsideBiome,
				avoidSpawnCloseToObject = spawnEntry.avoidSpawnCloseToObject,
				requiredCondition = spawnEntry.requiredCondition
			});
		}
	}
}
