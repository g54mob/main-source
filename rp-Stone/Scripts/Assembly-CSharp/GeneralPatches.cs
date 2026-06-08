using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GeneralPatches
{
	public static void AfterProgressLoaded()
	{
		if (Features.PREV_VERSION < new Version(0, 19, 0) && QuestController.singleton.GetStarDifficultyForQuest("rocky_plateau") > 3)
		{
			QuestController.singleton.SetStarDifficultyForQuest(3, "rocky_plateau");
		}
		if (Features.PREV_VERSION < new Version(0, 21, 2) && Inventory.Singleton.HasItemById("moon_stone") && QuestController.singleton.GetStarDifficultyForQuest("rocky_plateau") < 5)
		{
			Inventory.Singleton.RemoveItemById("moon_stone");
		}
		if (Features.PREV_VERSION < new Version(0, 30, 0))
		{
			if (AdditionalSettings.isPlayerNameSet)
			{
				HeroSettings.name = AdditionalSettings.playerName;
			}
			if (Inventory.Singleton.HasItemById("moon_stone"))
			{
				HeroSettings.bigHeadEnabled = true;
			}
		}
		if (Features.PREV_VERSION < new Version(1, 6, 0) && Inventory.Singleton.HasItemById("moon_stone"))
		{
			QuestController.singleton.MakeAvailable("mutate");
		}
		if (Features.PREV_APP_VERSION < new Version(2, 19, 2))
		{
			MigrateHistoricalBackupExtension();
		}
		if (OuroborosWeapon.singleton != null && OuroborosWeapon.singleton.level <= 1 && Features.PREV_VERSION < new Version(2, 17, 0))
		{
			QuestController singleton = QuestController.singleton;
			if (singleton.IsAvailable("mutate") && !singleton.IsAvailable("prepare_paint") && !singleton.IsAvailable("make_paintbrush") && !singleton.IsAvailable("upgrade_ouroboros"))
			{
				singleton.MakeAvailable("fetch_water");
				singleton.MarkAsUnseen("fetch_water");
				singleton.MarkAsUnplayed("fetch_water");
			}
		}
		if (OuroborosWeapon.singleton != null && OuroborosWeapon.singleton.level >= 3 && Features.PREV_VERSION < new Version(2, 17, 3))
		{
			OuroborosWeapon.singleton.level = 2;
		}
		if (Features.PREV_VERSION < new Version(2, 21, 0))
		{
			OfflineFarmController.singleton.ClearStatsForQuest("fungus_forest");
		}
		if (Features.PREV_VERSION < new Version(2, 22, 0))
		{
			OfflineFarmController.singleton.ClearStatsForQuest("temple");
		}
		if (Features.PREV_VERSION < new Version(2, 23, 0))
		{
			OfflineFarmController.singleton.ClearStatsForQuest("caustic_caves");
		}
		if (Features.PREV_VERSION < new Version(2, 24, 0))
		{
			OfflineFarmController.singleton.ClearStatsForQuest("rocky_plateau");
		}
		if (Features.PREV_VERSION < new Version(3, 2, 0) && Features.VERSION >= new Version(3, 2, 0))
		{
			Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ki_crystal");
			if (firstItemWithId != null)
			{
				firstItemWithId.count *= 5;
			}
		}
		if (Features.PREV_VERSION < new Version(3, 8, 0))
		{
			OfflineFarmController.singleton.ClearStatsForQuest("deadwood_valley");
		}
		if (Features.PREV_VERSION < new Version(3, 11, 0))
		{
			GoalController.singleton.TryToUnlockWorkstationTask();
		}
		if (!(Features.PREV_VERSION < new Version(3, 16, 1)))
		{
			return;
		}
		List<string> groupIDsWeHaveSeen = Inventory.Singleton.GetGroupIDsWeHaveSeen();
		for (int num = groupIDsWeHaveSeen.Count - 1; num >= 0; num--)
		{
			string text = groupIDsWeHaveSeen[num];
			if (text.Contains(":") || text.Contains("_lv16") || text.Contains("_lv32") || text.Contains("_lv64") || text.Contains("_lv128") || text.Contains("_lv256") || text.Contains("_lv512") || text.Contains("_lv1024") || text.Contains("_lv2048") || text.Contains("_lv4096") || text.Contains("_lv8192"))
			{
				groupIDsWeHaveSeen.RemoveAt(num);
			}
		}
	}

	public static void PreStorageLoad(AStorage storage)
	{
		if (!(storage is SteamCloudStorage))
		{
			return;
		}
		SteamCloudBugMigration steamCloudBugMigration = new SteamCloudBugMigration();
		if (steamCloudBugMigration.IsMigrationRequired)
		{
			try
			{
				steamCloudBugMigration.Perform();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}
	}

	private static void MigrateHistoricalBackupExtension()
	{
		try
		{
			if (!(SaveFiles.singleton.storage is SteamCloudStorage steamCloudStorage))
			{
				return;
			}
			string[] files = Directory.GetFiles(steamCloudStorage.GetStoragePath());
			string value = "historical_";
			string value2 = ".txt";
			string text = ".backup";
			string[] array = files;
			foreach (string text2 in array)
			{
				FileInfo fileInfo = new FileInfo(text2);
				if (fileInfo.Name.StartsWith(value) && fileInfo.Extension.EndsWith(value2))
				{
					string text3 = text2 + text;
					if (!File.Exists(text3))
					{
						Utils.Log("Moving \"" + text2 + "\" to \"" + text3 + "\"");
						File.Move(text2, text3);
					}
					else
					{
						Utils.Log("Deleting \"" + text2 + "\"");
						File.Delete(text2);
					}
				}
			}
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
	}
}
