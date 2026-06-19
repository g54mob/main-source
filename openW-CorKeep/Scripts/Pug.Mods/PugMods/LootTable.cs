using System;
using System.Collections.Generic;
using System.IO;
using Pug.UnityExtensions;
using UnityEngine;

namespace PugMods
{
	public static class LootTable
	{
		[Serializable]
		private class LootModFile
		{
			public LootTableID lootTableID;

			public Pug.UnityExtensions.RangeInt uniqueDrops;

			public bool dontAllowDuplicates;

			public List<Loot> loots;
		}

		[Serializable]
		public class Loot
		{
			public ObjectID objectID;

			public float weight;

			public Pug.UnityExtensions.RangeInt amount;

			public bool isOneOfGuaranteedToDrop;

			public Biome onlyDropsInBiome;
		}

		public static void Init(LootTableBank lootTableBank)
		{
			List<LootModFile> lootList = GetLootList(lootTableBank.biomeLootTables);
			foreach (string confFolder in Config.ConfFolders)
			{
				UpdateFromFiles(confFolder, lootList);
			}
			lootTableBank.biomeLootTables.Clear();
			lootTableBank.biomeLootTables.Add(new BiomeLootTables
			{
				lootTables = new List<global::LootTable>()
			});
			foreach (LootModFile item in lootList)
			{
				global::LootTable lootTable = new global::LootTable
				{
					id = item.lootTableID,
					minUniqueDrops = item.uniqueDrops.min,
					maxUniqueDrops = item.uniqueDrops.max,
					dontAllowDuplicates = item.dontAllowDuplicates,
					guaranteedLootInfos = new List<LootInfo>(),
					lootInfos = new List<LootInfo>()
				};
				foreach (Loot loot in item.loots)
				{
					lootTable.lootInfos.Add(new LootInfo
					{
						objectID = loot.objectID,
						amount = loot.amount,
						weight = loot.weight,
						isPartOfGuaranteedDrop = loot.isOneOfGuaranteedToDrop,
						onlyDropsInBiome = loot.onlyDropsInBiome
					});
				}
				lootTableBank.biomeLootTables[0].lootTables.Add(lootTable);
			}
			lootTableBank.OnAfterDeserialize();
		}

		private static void UpdateFromFiles(string directoryPath, List<LootModFile> lootModFileList)
		{
			string path = directoryPath + "/Loot";
			if (!Directory.Exists(path))
			{
				return;
			}
			foreach (string item in Directory.EnumerateFiles(path, "*.json"))
			{
				try
				{
					string json = File.ReadAllText(item);
					LootModFile lootModFile = new LootModFile();
					JsonUtility.FromJsonOverwrite(json, lootModFile);
					if (lootModFile.lootTableID == LootTableID.Empty)
					{
						Debug.Log("Skipping loot mod " + item + " for loot table Empty (0)");
						continue;
					}
					int i;
					for (i = 0; i < lootModFileList.Count; i++)
					{
						if (lootModFile.lootTableID == lootModFileList[i].lootTableID)
						{
							if (Config.ExtraLog)
							{
								Debug.Log($"Updating loot for {lootModFile.lootTableID} with values from {item}");
							}
							lootModFileList[i] = lootModFile;
							break;
						}
					}
					if (i == lootModFileList.Count)
					{
						if (Config.ExtraLog)
						{
							Debug.Log($"Adding loot for {lootModFile.lootTableID} from {item}");
						}
						lootModFileList.Add(lootModFile);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		private static List<LootModFile> GetLootList(List<BiomeLootTables> biomeLootTables)
		{
			List<LootModFile> list = new List<LootModFile>();
			foreach (BiomeLootTables biomeLootTable in biomeLootTables)
			{
				foreach (global::LootTable lootTable in biomeLootTable.lootTables)
				{
					LootModFile lootModFile = new LootModFile
					{
						lootTableID = lootTable.id,
						uniqueDrops = new Pug.UnityExtensions.RangeInt
						{
							min = lootTable.minUniqueDrops,
							max = lootTable.maxUniqueDrops
						},
						dontAllowDuplicates = lootTable.dontAllowDuplicates,
						loots = new List<Loot>()
					};
					foreach (LootInfo lootInfo in lootTable.lootInfos)
					{
						lootModFile.loots.Add(new Loot
						{
							objectID = lootInfo.objectID,
							amount = lootInfo.amount,
							weight = lootInfo.weight,
							isOneOfGuaranteedToDrop = lootInfo.isPartOfGuaranteedDrop,
							onlyDropsInBiome = lootInfo.onlyDropsInBiome
						});
					}
					list.Add(lootModFile);
				}
			}
			return list;
		}
	}
}
