using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace PugWorldGen
{
	public class DungeonSpawnTable : MonoBehaviour
	{
		[Serializable]
		public class DungeonSpawnTableBiome
		{
			public string tableName;

			public WorldGenerationTypeDependentValue<Biome> biome;

			[FormerlySerializedAs("legacyMinDistanceFromCore")]
			public int minDistanceFromCoreInClassicWorlds;

			[Range(0f, 1f)]
			public float anyDungeonSpawnChance;

			public List<DungeonSpawnTableEntry> spawnEntries;
		}

		[Serializable]
		public class DungeonSpawnTableEntry
		{
			public GameObject prefab;

			public float spawnWeight;

			[Range(0f, 1f)]
			public float spawnChance;
		}

		public List<DungeonSpawnTableBiome> biomes;

		private void OnValidate()
		{
			foreach (DungeonSpawnTableBiome biome in biomes)
			{
				float num = 0f;
				foreach (DungeonSpawnTableEntry spawnEntry in biome.spawnEntries)
				{
					num += spawnEntry.spawnWeight;
				}
				foreach (DungeonSpawnTableEntry spawnEntry2 in biome.spawnEntries)
				{
					spawnEntry2.spawnChance = ((num > 0f) ? (biome.anyDungeonSpawnChance * (spawnEntry2.spawnWeight / num)) : 0f);
				}
			}
		}
	}
}
