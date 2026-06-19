using System;
using System.Collections.Generic;
using System.IO;
using PugTilemap;
using UnityEngine;

namespace PugMods
{
	public static class Fishing
	{
		[Serializable]
		private class FishBiomeLootModFile
		{
			public Biome biome;

			public LootTableID junkLoot;

			public LootTableID fishLoot;
		}

		[Serializable]
		private class FishWaterLootModFile
		{
			public Tileset waterType;

			public LootTableID junkLoot;

			public LootTableID fishLoot;
		}

		[Serializable]
		public class FishStruggleModFile
		{
			public ObjectID fish;

			public List<FishingTable.FishStruggleData> struggleData;
		}

		public static void Init(FishingTable fishingTable)
		{
			List<FishBiomeLootModFile> biomeLootList = GetBiomeLootList(fishingTable);
			List<FishWaterLootModFile> waterLootList = GetWaterLootList(fishingTable);
			List<FishStruggleModFile> fishStruggleList = GetFishStruggleList(fishingTable);
			foreach (string confFolder in Config.ConfFolders)
			{
				UpdateFromFiles(confFolder, biomeLootList, waterLootList, fishStruggleList);
			}
			fishingTable.fishingInfos.Clear();
			foreach (FishBiomeLootModFile item3 in biomeLootList)
			{
				FishingTable.FishingInfo item = new FishingTable.FishingInfo
				{
					biomes = new List<Biome>(),
					waterTilesets = new List<Tileset>(),
					fishLootTableID = item3.fishLoot,
					lootTableID = item3.junkLoot
				};
				item.biomes.Add(item3.biome);
				fishingTable.fishingInfos.Add(item);
			}
			foreach (FishWaterLootModFile item4 in waterLootList)
			{
				FishingTable.FishingInfo item2 = new FishingTable.FishingInfo
				{
					biomes = new List<Biome>(),
					waterTilesets = new List<Tileset>(),
					fishLootTableID = item4.fishLoot,
					lootTableID = item4.junkLoot
				};
				item2.waterTilesets.Add(item4.waterType);
				fishingTable.fishingInfos.Add(item2);
			}
			fishingTable.fishStruggleInfos.Clear();
			foreach (FishStruggleModFile item5 in fishStruggleList)
			{
				fishingTable.fishStruggleInfos.Add(new FishingTable.FishStruggleInfo
				{
					fishID = item5.fish,
					struggleData = item5.struggleData
				});
			}
		}

		private static void UpdateFromFiles(string directoryPath, List<FishBiomeLootModFile> biomeFishLootList, List<FishWaterLootModFile> waterFishLootList, List<FishStruggleModFile> struggleModList)
		{
			string path = directoryPath + "/Loot/Fishing/Biome";
			if (Directory.Exists(path))
			{
				foreach (string item in Directory.EnumerateFiles(path, "*.json"))
				{
					try
					{
						string json = File.ReadAllText(item);
						FishBiomeLootModFile fishBiomeLootModFile = new FishBiomeLootModFile();
						JsonUtility.FromJsonOverwrite(json, fishBiomeLootModFile);
						if (fishBiomeLootModFile.biome == Biome.None)
						{
							Debug.Log("Skipping loot mod " + item + " with biome None (0)");
							continue;
						}
						int i;
						for (i = 0; i < biomeFishLootList.Count; i++)
						{
							if (fishBiomeLootModFile.biome == biomeFishLootList[i].biome)
							{
								if (Config.ExtraLog)
								{
									Debug.Log($"Updating biome fish loot for {fishBiomeLootModFile.biome} with values from {item}");
								}
								biomeFishLootList[i] = fishBiomeLootModFile;
								break;
							}
						}
						if (i == biomeFishLootList.Count)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Adding biome fish loot for {fishBiomeLootModFile.biome} from {item}");
							}
							biomeFishLootList.Add(fishBiomeLootModFile);
						}
					}
					catch (Exception exception)
					{
						Debug.LogException(exception);
					}
				}
			}
			string path2 = directoryPath + "/Loot/Fishing/Water";
			if (Directory.Exists(path2))
			{
				foreach (string item2 in Directory.EnumerateFiles(path2, "*.json"))
				{
					try
					{
						string json2 = File.ReadAllText(item2);
						FishWaterLootModFile fishWaterLootModFile = new FishWaterLootModFile();
						JsonUtility.FromJsonOverwrite(json2, fishWaterLootModFile);
						if (fishWaterLootModFile.fishLoot == LootTableID.Empty && fishWaterLootModFile.junkLoot == LootTableID.Empty)
						{
							Debug.Log("Skipping loot mod " + item2 + " without loot");
							continue;
						}
						int j;
						for (j = 0; j < waterFishLootList.Count; j++)
						{
							if (fishWaterLootModFile.waterType == waterFishLootList[j].waterType)
							{
								if (Config.ExtraLog)
								{
									Debug.Log($"Updating water fish loot for {fishWaterLootModFile.waterType} water with values from {item2}");
								}
								waterFishLootList[j] = fishWaterLootModFile;
								break;
							}
						}
						if (j == waterFishLootList.Count)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Adding water fish loot for {fishWaterLootModFile.waterType} water from {item2}");
							}
							waterFishLootList.Add(fishWaterLootModFile);
						}
					}
					catch (Exception exception2)
					{
						Debug.LogException(exception2);
					}
				}
			}
			string path3 = directoryPath + "/Fishing";
			if (!Directory.Exists(path3))
			{
				return;
			}
			foreach (string item3 in Directory.EnumerateFiles(path3, "*.json"))
			{
				try
				{
					string json3 = File.ReadAllText(item3);
					FishStruggleModFile fishStruggleModFile = new FishStruggleModFile();
					JsonUtility.FromJsonOverwrite(json3, fishStruggleModFile);
					if (fishStruggleModFile.fish == ObjectID.None)
					{
						Debug.Log("Skipping fish mod " + item3 + " with type None");
						continue;
					}
					int k;
					for (k = 0; k < struggleModList.Count; k++)
					{
						if (fishStruggleModFile.fish == struggleModList[k].fish)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Updating fish {fishStruggleModFile.fish} with struggle data from {item3}");
							}
							struggleModList[k] = fishStruggleModFile;
							break;
						}
					}
					if (k == struggleModList.Count)
					{
						if (Config.ExtraLog)
						{
							Debug.Log($"Adding fish {fishStruggleModFile.fish} with struggle data from {item3}");
						}
						struggleModList.Add(fishStruggleModFile);
					}
				}
				catch (Exception exception3)
				{
					Debug.LogException(exception3);
				}
			}
		}

		private static List<FishBiomeLootModFile> GetBiomeLootList(FishingTable fishingTable)
		{
			List<FishBiomeLootModFile> list = new List<FishBiomeLootModFile>();
			foreach (FishingTable.FishingInfo fishingInfo in fishingTable.fishingInfos)
			{
				if (fishingInfo.biomes.Count == 0)
				{
					continue;
				}
				foreach (Biome biome in fishingInfo.biomes)
				{
					list.Add(new FishBiomeLootModFile
					{
						biome = biome,
						fishLoot = fishingInfo.fishLootTableID,
						junkLoot = fishingInfo.lootTableID
					});
				}
			}
			return list;
		}

		private static List<FishWaterLootModFile> GetWaterLootList(FishingTable fishingTable)
		{
			List<FishWaterLootModFile> list = new List<FishWaterLootModFile>();
			foreach (FishingTable.FishingInfo fishingInfo in fishingTable.fishingInfos)
			{
				foreach (Tileset waterTileset in fishingInfo.waterTilesets)
				{
					list.Add(new FishWaterLootModFile
					{
						waterType = waterTileset,
						fishLoot = fishingInfo.fishLootTableID,
						junkLoot = fishingInfo.lootTableID
					});
				}
			}
			return list;
		}

		private static List<FishStruggleModFile> GetFishStruggleList(FishingTable fishingTable)
		{
			List<FishStruggleModFile> list = new List<FishStruggleModFile>();
			foreach (FishingTable.FishStruggleInfo fishStruggleInfo in fishingTable.fishStruggleInfos)
			{
				FishStruggleModFile item = new FishStruggleModFile
				{
					fish = fishStruggleInfo.fishID,
					struggleData = fishStruggleInfo.struggleData
				};
				list.Add(item);
			}
			return list;
		}
	}
}
