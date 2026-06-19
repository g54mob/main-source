using System;
using System.Collections.Generic;
using System.IO;
using Pug.UnityExtensions;
using PugTilemap;
using UnityEngine;

namespace PugMods
{
	public static class SpawnTable
	{
		[Serializable]
		private class ModEnvironmentSpawnData
		{
			[Serializable]
			public struct SpawnCheck
			{
				public EnvironmentalSpawnChance.Source spawnChanceSource;

				public float spawnChance;

				public WorldGenSettingDependentValue<float> spawnChanceFromWorldGenSetting;

				[Tooltip("Only spawns in this biome. None means any.")]
				public Biome biome;

				[Tooltip("We will only spawn on this tile surface.")]
				public TileType tileType;

				[Tooltip("List of allowed tilesets. Empty means any.")]
				public List<Tileset> tilesets;

				public EnvironmentSpawnData.SpawnCheck.AdjacentTileList adjacentTiles;

				[Tooltip("A blocked area is for example a dungeon or custom scene.")]
				public bool canSpawnInBlockedArea;

				[Tooltip("Skip spawning this object when filling in a partial map when a new biome is added.")]
				public bool skipSpawnForPartialMaps;
			}

			public string name;

			public SpawnCheck spawnCheck;

			public List<SpawnObjectData> spawns;

			public ModEnvironmentSpawnData()
			{
			}

			public ModEnvironmentSpawnData(EnvironmentSpawnData spawnData)
			{
				name = spawnData.name;
				spawnCheck = new SpawnCheck
				{
					spawnChanceSource = spawnData.spawnCheck.spawnChance.source,
					spawnChance = spawnData.spawnCheck.spawnChance.constantValue.pc,
					spawnChanceFromWorldGenSetting = spawnData.spawnCheck.spawnChance.worldGenDependentValue,
					biome = spawnData.spawnCheck.biome,
					tileType = spawnData.spawnCheck.tileType,
					tilesets = spawnData.spawnCheck.tilesets,
					adjacentTiles = spawnData.spawnCheck.adjacentTiles,
					canSpawnInBlockedArea = spawnData.spawnCheck.canSpawnInBlockedArea,
					skipSpawnForPartialMaps = spawnData.spawnCheck.skipSpawnForPartialMaps
				};
				spawns = spawnData.spawns;
			}

			public EnvironmentSpawnData ToEnvironmentSpawnData()
			{
				return new EnvironmentSpawnData
				{
					name = name,
					spawnCheck = new EnvironmentSpawnData.SpawnCheck
					{
						spawnChance = new EnvironmentalSpawnChance
						{
							source = spawnCheck.spawnChanceSource,
							constantValue = new PlatformDependentValue<float>(spawnCheck.spawnChance),
							worldGenDependentValue = spawnCheck.spawnChanceFromWorldGenSetting
						},
						biome = spawnCheck.biome,
						tileType = spawnCheck.tileType,
						tilesets = spawnCheck.tilesets,
						adjacentTiles = spawnCheck.adjacentTiles,
						canSpawnInBlockedArea = spawnCheck.canSpawnInBlockedArea,
						skipSpawnForPartialMaps = spawnCheck.skipSpawnForPartialMaps
					},
					spawns = spawns
				};
			}
		}

		[Serializable]
		public class ModRespawnData
		{
			[Serializable]
			public struct SpawnCheck
			{
				public EnvironmentalSpawnChance.Source spawnChanceSource;

				public float spawnChance;

				public WorldGenSettingDependentValue<float> spawnChanceFromWorldGenSetting;

				[Tooltip("Only spawns in this biome. None means any.")]
				public Biome biome;

				[Tooltip("The respawn chance will be multiplied with ((1 - respawnChanceDecay) ^ (amount of already existing entities)) effectively reducing the respawn chance when there are more entities of same type.")]
				public float spawnChanceDecay;

				[Tooltip("The maximum amount to spawn per valid tile.")]
				public float maxSpawnPerTile;

				[Tooltip("The max number of objects that can spawn per respawn.")]
				public int maxSpawnsPerRespawn;

				[Tooltip("The minimum amount of valid tiles required to spawn at all in a respawn area. No requirement if left as 0.")]
				public float minTilesRequired;

				[Tooltip("We will only spawn on this tile surface.")]
				public TileType tileType;

				[Tooltip("List of allowed tilesets. Empty means any.")]
				public List<Tileset> tilesets;

				public RespawnData.SpawnCheck.AdjacentTileList adjacentTiles;
			}

			public string name;

			public SpawnCheck spawnCheck;

			public List<SpawnObjectData> spawns;

			public ModRespawnData()
			{
			}

			public ModRespawnData(RespawnData respawnData)
			{
				name = respawnData.name;
				spawnCheck = new SpawnCheck
				{
					spawnChanceSource = respawnData.spawnCheck.spawnChance.source,
					spawnChance = respawnData.spawnCheck.spawnChance.constantValue.pc,
					spawnChanceFromWorldGenSetting = respawnData.spawnCheck.spawnChance.worldGenDependentValue,
					biome = respawnData.spawnCheck.biome,
					spawnChanceDecay = respawnData.spawnCheck.spawnChanceDecay,
					maxSpawnPerTile = respawnData.spawnCheck.maxSpawnPerTile.pc,
					maxSpawnsPerRespawn = respawnData.spawnCheck.maxSpawnsPerRespawn,
					minTilesRequired = respawnData.spawnCheck.minTilesRequired,
					tileType = respawnData.spawnCheck.tileType,
					tilesets = respawnData.spawnCheck.tilesets,
					adjacentTiles = respawnData.spawnCheck.adjacentTiles
				};
				spawns = respawnData.spawns;
			}

			public RespawnData ToRespawnData()
			{
				return new RespawnData
				{
					name = name,
					spawnCheck = new RespawnData.SpawnCheck
					{
						spawnChance = new EnvironmentalSpawnChance
						{
							source = spawnCheck.spawnChanceSource,
							constantValue = new PlatformDependentValue<float>(spawnCheck.spawnChance),
							worldGenDependentValue = spawnCheck.spawnChanceFromWorldGenSetting
						},
						biome = spawnCheck.biome,
						spawnChanceDecay = spawnCheck.spawnChanceDecay,
						maxSpawnPerTile = new PlatformDependentValue<float>(spawnCheck.maxSpawnPerTile),
						maxSpawnsPerRespawn = spawnCheck.maxSpawnsPerRespawn,
						minTilesRequired = spawnCheck.minTilesRequired,
						tileType = spawnCheck.tileType,
						tilesets = spawnCheck.tilesets,
						adjacentTiles = spawnCheck.adjacentTiles
					},
					spawns = spawns
				};
			}
		}

		public static void Init(EnvironmentSpawnObjectsTable spawnTable)
		{
			foreach (string confFolder in Config.ConfFolders)
			{
				UpdateFromFiles(confFolder, spawnTable.spawnObjects, spawnTable.respawnObjects);
			}
		}

		private static void UpdateFromFiles(string directoryPath, List<EnvironmentSpawnData> spawnModList, List<RespawnData> respawnModList)
		{
			string path = directoryPath + "/Spawn/Initial";
			string path2 = directoryPath + "/Spawn/Respawn";
			if (Directory.Exists(path))
			{
				foreach (string item in Directory.EnumerateFiles(path, "*.json", SearchOption.AllDirectories))
				{
					try
					{
						string json = File.ReadAllText(item);
						ModEnvironmentSpawnData modEnvironmentSpawnData = new ModEnvironmentSpawnData();
						JsonUtility.FromJsonOverwrite(json, modEnvironmentSpawnData);
						if (string.IsNullOrEmpty(modEnvironmentSpawnData.name))
						{
							Debug.Log("Skipping spawn " + item + " without name");
							continue;
						}
						int i;
						for (i = 0; i < spawnModList.Count; i++)
						{
							if (string.Equals(modEnvironmentSpawnData.name, spawnModList[i].name, StringComparison.InvariantCultureIgnoreCase))
							{
								if (Config.ExtraLog)
								{
									Debug.Log("Updating spawn " + modEnvironmentSpawnData.name + " with values from " + item);
								}
								spawnModList[i] = modEnvironmentSpawnData.ToEnvironmentSpawnData();
								break;
							}
						}
						if (i == spawnModList.Count)
						{
							if (Config.ExtraLog)
							{
								Debug.Log("Adding spawn " + modEnvironmentSpawnData.name + " from " + item);
							}
							spawnModList.Add(modEnvironmentSpawnData.ToEnvironmentSpawnData());
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			if (!Directory.Exists(path2))
			{
				return;
			}
			foreach (string item2 in Directory.EnumerateFiles(path2, "*.json", SearchOption.AllDirectories))
			{
				try
				{
					string json2 = File.ReadAllText(item2);
					ModRespawnData modRespawnData = new ModRespawnData();
					JsonUtility.FromJsonOverwrite(json2, modRespawnData);
					if (string.IsNullOrEmpty(modRespawnData.name))
					{
						Debug.Log("Skipping respawn " + item2 + " without name");
						continue;
					}
					int j;
					for (j = 0; j < respawnModList.Count; j++)
					{
						if (string.Equals(modRespawnData.name, respawnModList[j].name, StringComparison.InvariantCultureIgnoreCase))
						{
							if (Config.ExtraLog)
							{
								Debug.Log("Updating respawn " + modRespawnData.name + " with values from " + item2);
							}
							respawnModList[j] = modRespawnData.ToRespawnData();
							break;
						}
					}
					if (j == respawnModList.Count)
					{
						if (Config.ExtraLog)
						{
							Debug.Log("Adding respawn " + modRespawnData.name + " from " + item2);
						}
						respawnModList.Add(modRespawnData.ToRespawnData());
					}
				}
				catch (Exception exception2)
				{
					Debug.LogException(exception2);
				}
			}
		}

		private static List<ModEnvironmentSpawnData> GetEnvironmentSpawns(EnvironmentSpawnObjectsTable spawnTable)
		{
			List<ModEnvironmentSpawnData> list = new List<ModEnvironmentSpawnData>(spawnTable.spawnObjects.Count);
			foreach (EnvironmentSpawnData spawnObject in spawnTable.spawnObjects)
			{
				list.Add(new ModEnvironmentSpawnData(spawnObject));
			}
			return list;
		}

		private static List<ModRespawnData> GetRespawns(EnvironmentSpawnObjectsTable spawnTable)
		{
			List<ModRespawnData> list = new List<ModRespawnData>(spawnTable.respawnObjects.Count);
			foreach (RespawnData respawnObject in spawnTable.respawnObjects)
			{
				list.Add(new ModRespawnData(respawnObject));
			}
			return list;
		}
	}
}
