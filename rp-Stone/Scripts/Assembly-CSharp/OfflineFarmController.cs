using System;
using System.Collections.Generic;
using SafeTypes;
using UnityEngine;

public class OfflineFarmController : MonoBehaviour
{
	public struct OfflineRunInfo
	{
		public string questId;

		public int difficulty;

		public int loopCount;

		public int treasuresFound;

		public float averageLoopSeconds;

		public int totalTimeSeconds;

		public bool runEndsInDeath;

		public int kiGained;

		public int resGained;

		public Data.Resource resGainedType;

		public int resSpentAmountA;

		public Data.Resource resSpentTypeA;

		public int resSpentAmountB;

		public Data.Resource resSpentTypeB;

		public int aetherNeeded;

		public int aetherUsed;

		public int fireNeeded;

		public int fireUsed;

		public int iceNeeded;

		public int iceUsed;

		public int poisonNeeded;

		public int poisonUsed;

		public int vigorNeeded;

		public int vigorUsed;
	}

	public class OfflineRunSummary
	{
		public string locationName;

		public int treasureCount;

		public float secondsPerTreasure;

		public int treasuresPerLoop;

		public DateTime startTime;

		public int totalSeconds;

		public static OfflineRunSummary FromString(string sjson)
		{
			return new OfflineRunSummary
			{
				locationName = SlimJson.Parse(sjson, "name"),
				treasureCount = SlimJson.ParseInt(sjson, "count"),
				secondsPerTreasure = SlimJson.ParseFloat(sjson, "seconds"),
				treasuresPerLoop = SlimJson.ParseInt(sjson, "treasuresPerLoop", 1),
				startTime = SlimJson.ParseDateTime(sjson, "startTime"),
				totalSeconds = SlimJson.ParseInt(sjson, "totalSeconds")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("name", locationName);
			SlimJson.AddProperty("count", treasureCount);
			SlimJson.AddProperty("seconds", secondsPerTreasure);
			SlimJson.AddProperty("treasuresPerLoop", treasuresPerLoop);
			SlimJson.AddProperty("startTime", startTime);
			SlimJson.AddProperty("totalSeconds", totalSeconds);
			return SlimJson.EndSerialization();
		}
	}

	public class ActiveRunInfo
	{
		public string questId;

		public int difficulty;

		public int treasuresPerLoop;

		public DateTime startTime;

		public int seed;

		public static ActiveRunInfo FromString(string sjson)
		{
			return new ActiveRunInfo
			{
				questId = SlimJson.Parse(sjson, "questId"),
				difficulty = SlimJson.ParseInt(sjson, "difficulty"),
				treasuresPerLoop = SlimJson.ParseInt(sjson, "treasuresPerLoop", 1),
				startTime = SlimJson.ParseDateTime(sjson, "startTime"),
				seed = SlimJson.ParseInt(sjson, "seed")
			};
		}

		public override string ToString()
		{
			SlimJson.BeginSerialization();
			SlimJson.AddProperty("questId", questId);
			SlimJson.AddProperty("difficulty", difficulty);
			SlimJson.AddProperty("treasuresPerLoop", treasuresPerLoop);
			SlimJson.AddProperty("startTime", startTime);
			SlimJson.AddProperty("seed", seed);
			return SlimJson.EndSerialization();
		}
	}

	public struct RewardsInfo
	{
		public int[] treasuresCount;

		public int kiGained;

		public int resGainedAmount;

		public Data.Resource resGainedType;

		public int resSpentAmountA;

		public Data.Resource resSpentTypeA;

		public int resSpentAmountB;

		public Data.Resource resSpentTypeB;
	}

	private const int OUROBOROS_ANIMATION_DURATION = 118;

	private const int TREASURE_FOUND_DIALOG_DURATION = 36;

	private const string PLAYER_PREFS_SUMMARY_KEY = "OFFLINE_FARM_SUMMARY";

	public OfflineRunSummary runSummary;

	public ActiveRunInfo activeRun;

	private DateTime lastRewardTime = DateTime.MinValue;

	private DateTime lastSkullnataUpgradeTime = DateTime.MinValue;

	private HashSet<string> questStatIds = new HashSet<string>();

	private List<Data.QuestStats> questStats = new List<Data.QuestStats>();

	private List<Data.QuestStats> questStatsTemporary;

	private int loopCount;

	private SafeInt totalHealthLost;

	private SafeInt totalHealthGained;

	private SafeInt totalKiGained;

	private SafeInt totalResGained;

	private SafeInt totalDamageDealt;

	private SafeInt totalDevourDamage;

	private SafeInt totalDevouredAEther;

	private SafeInt totalDevouredFire;

	private SafeInt totalDevouredIce;

	private SafeInt totalDevouredPoison;

	private SafeInt totalDevouredVigor;

	public static OfflineFarmController singleton { get; private set; }

	public OfflineRunInfo ComputeOfflineRunInfo(string questId, int difficulty, bool isForRewards = false)
	{
		Data.QuestStats questStats = GetStatsForQuest(questId, difficulty);
		if (questStats == null && isForRewards)
		{
			questStats = GetStatsForQuestTemporaryData(questId, difficulty);
		}
		if (questStats == null)
		{
			return default(OfflineRunInfo);
		}
		float num = 0f;
		bool flag = false;
		int starDifficultyForQuest = QuestController.singleton.GetStarDifficultyForQuest(questId);
		if (starDifficultyForQuest > difficulty)
		{
			int num2 = starDifficultyForQuest - difficulty;
			if (num2 >= 3)
			{
				num = 1f;
				flag = true;
			}
			else
			{
				switch (num2)
				{
				case 2:
					num = 0.66667f;
					break;
				case 1:
					num = 0.33333f;
					break;
				}
			}
		}
		OfflineRunInfo result = default(OfflineRunInfo);
		int num3 = ComputeMaxTreasuresFound();
		int treasuresPerLoop = GetTreasuresPerLoop(questId, difficulty);
		int num4 = 1;
		if (num3 > treasuresPerLoop)
		{
			num4 = Mathf.CeilToInt((float)num3 / (float)treasuresPerLoop);
		}
		int num5 = Mathf.RoundToInt(num * (float)num4);
		float value = questStats.averageHPLost.GetValue();
		float value2 = questStats.averageHPGained.GetValue();
		float num6 = (value - value2) * (float)num4;
		float num7 = GameStates.Singleton.hero.MaxHitpoints;
		bool flag2 = num6 >= num7 && !flag;
		if (flag2)
		{
			float num8 = 0f;
			Potion item = Potion.GetItem();
			if (item.type == Potion.Type.Healing || item.type == Potion.Type.Armor)
			{
				num8 = 1f;
			}
			else if (item.type == Potion.Type.Vampiric)
			{
				num8 = 1.5f;
			}
			else if (item.type == Potion.Type.Cleanse)
			{
				num8 = 0.5f;
			}
			if (num8 > 0f && item.autoRefill)
			{
				int num9 = 9999;
				for (int i = 0; i < item.costs.Count; i++)
				{
					Data.Cost cost = item.costs[i];
					int b = (int)InventoryResources.singleton.GetResourceOfType(cost.resource) / cost.amount;
					num9 = Mathf.Min(num9, b);
				}
				int num10 = 0;
				float num11 = num7;
				int num12 = 0;
				for (int j = 0; j < num4; j++)
				{
					num11 -= value;
					num11 += value2;
					if (num11 <= 5f && num9 > num12)
					{
						num11 += num7 * num8;
						if (num11 > num7)
						{
							num11 = num7;
						}
						num12++;
					}
					num10++;
					if (num11 <= 0f)
					{
						break;
					}
				}
				if (num4 > num10)
				{
					num4 = num10;
				}
				else
				{
					flag2 = false;
				}
				if (item.costs.Count > 0)
				{
					result.resSpentAmountA = item.costs[0].amount * num12;
					result.resSpentTypeA = item.costs[0].resource;
				}
				if (item.costs.Count > 1)
				{
					result.resSpentAmountB = item.costs[1].amount * num12;
					result.resSpentTypeB = item.costs[1].resource;
				}
			}
			else
			{
				num4 = Mathf.FloorToInt(num7 / (value - value2));
			}
			if (num4 < num5)
			{
				num4 = num5;
			}
			num3 = num4 * treasuresPerLoop;
		}
		int num13 = 0;
		int num14 = 0;
		result.aetherNeeded = Mathf.RoundToInt((float)num4 * questStats.averageDevouredAEther.GetValue());
		result.fireNeeded = Mathf.RoundToInt((float)num4 * questStats.averageDevouredFire.GetValue());
		result.iceNeeded = Mathf.RoundToInt((float)num4 * questStats.averageDevouredIce.GetValue());
		result.poisonNeeded = Mathf.RoundToInt((float)num4 * questStats.averageDevouredPoison.GetValue());
		result.vigorNeeded = Mathf.RoundToInt((float)num4 * questStats.averageDevouredVigor.GetValue());
		if (result.aetherNeeded > 0)
		{
			num13 += result.aetherNeeded;
			int runestoneMaterialCount = Inventory.Singleton.GetRunestoneMaterialCount(ItemData.Element.AEther);
			if (runestoneMaterialCount < result.aetherNeeded)
			{
				result.aetherUsed = runestoneMaterialCount;
				num14 += result.aetherNeeded - runestoneMaterialCount;
			}
			else
			{
				result.aetherUsed = result.aetherNeeded;
			}
		}
		if (result.fireNeeded > 0)
		{
			num13 += result.fireNeeded;
			int runestoneMaterialCount2 = Inventory.Singleton.GetRunestoneMaterialCount(ItemData.Element.Fire);
			if (runestoneMaterialCount2 < result.fireNeeded)
			{
				result.fireUsed = runestoneMaterialCount2;
				num14 += result.fireNeeded - runestoneMaterialCount2;
			}
			else
			{
				result.fireUsed = result.fireNeeded;
			}
		}
		_ = result.iceNeeded;
		_ = 0;
		_ = result.poisonNeeded;
		_ = 0;
		_ = result.vigorNeeded;
		_ = 0;
		float num15 = 0f;
		float value3 = questStats.averageDamageDealt.GetValue();
		if (value3 > 0f && num13 > 0 && num14 > 0)
		{
			float value4 = questStats.averageDevourDamage.GetValue();
			float num16 = (float)num14 / (float)num13;
			num15 = value4 * num16 / value3;
		}
		float num17 = questStats.averageTime.GetValue() / 30f;
		float num18 = num17 * num15;
		num17 += num18;
		int num19 = Mathf.RoundToInt(num17 * (float)num4 + 3.9333334f * (float)(num4 - 1) + 1.2f * (float)num3);
		if (num19 <= 0)
		{
			return new OfflineRunInfo
			{
				runEndsInDeath = flag2
			};
		}
		float num20 = questStats.averageKiGained.GetValue();
		float num21 = 1.25f;
		float num22 = num17 * num21;
		if (num20 > num22)
		{
			num20 = num22;
		}
		float num23 = num20 * 0.15f;
		num20 += UnityEngine.Random.Range(0f - num23, num23);
		int kiGained = Mathf.RoundToInt(num20 * (float)num4);
		int resGained = 0;
		Data.Resource resource = Data.Resource.Stone;
		float num24 = questStats.averageResGained.GetValue();
		if (num24 > 0f)
		{
			switch (questId)
			{
			case "deadwood_valley":
				resource = Data.Resource.Wood;
				break;
			case "caustic_caves":
				resource = Data.Resource.Tar;
				break;
			case "bronze_mine":
				resource = Data.Resource.Bronze;
				break;
			}
			int num25 = 150;
			switch (resource)
			{
			case Data.Resource.Stone:
				num25 = 160;
				if (difficulty >= 6)
				{
					num25 = 288;
				}
				break;
			case Data.Resource.Tar:
				num25 = 30;
				if (difficulty == 4)
				{
					num25 = 27;
				}
				if (difficulty >= 5)
				{
					num25 = 21;
				}
				break;
			case Data.Resource.Bronze:
				num25 = 28;
				if (difficulty >= 4)
				{
					num25 = 20;
				}
				break;
			}
			if (num24 > (float)num25)
			{
				num24 = num25;
			}
			num23 = num24 * 0.2f;
			num24 += UnityEngine.Random.Range(0f - num23, num23);
			resGained = Mathf.RoundToInt(num24 * (float)num4);
		}
		result.questId = questId;
		result.difficulty = difficulty;
		result.loopCount = num4;
		result.treasuresFound = num3;
		result.averageLoopSeconds = num17;
		result.totalTimeSeconds = num19;
		result.runEndsInDeath = flag2;
		result.kiGained = kiGained;
		result.resGained = resGained;
		result.resGainedType = resource;
		return result;
	}

	public void ProcessRewards()
	{
		ClearSummary();
		if (activeRun == null)
		{
			return;
		}
		string questId = activeRun.questId;
		int difficulty = activeRun.difficulty;
		int treasuresPerLoop = activeRun.treasuresPerLoop;
		DateTime startTime = activeRun.startTime;
		int seed = activeRun.seed;
		activeRun = null;
		if (startTime < lastRewardTime)
		{
			startTime = lastRewardTime;
		}
		OfflineRunInfo offlineRunInfo = ComputeOfflineRunInfo(questId, difficulty, isForRewards: true);
		if (offlineRunInfo.treasuresFound <= 0)
		{
			return;
		}
		DateTime dateTimeNow = GetDateTimeNow();
		float num = (float)(dateTimeNow - startTime).TotalSeconds;
		if (num < offlineRunInfo.averageLoopSeconds)
		{
			return;
		}
		int num2 = offlineRunInfo.treasuresFound;
		int num3 = offlineRunInfo.loopCount;
		if (num < (float)offlineRunInfo.totalTimeSeconds)
		{
			num3 = 1;
			num -= offlineRunInfo.averageLoopSeconds;
			float num4 = offlineRunInfo.averageLoopSeconds + 5.133333f;
			num3 += Mathf.FloorToInt(num / num4);
			num2 = num3 * treasuresPerLoop;
			if (num2 <= 0)
			{
				return;
			}
		}
		if (num2 > offlineRunInfo.treasuresFound)
		{
			num2 = offlineRunInfo.treasuresFound;
		}
		RewardsInfo rewardsInfo = new RewardsInfo
		{
			treasuresCount = new int[10]
		};
		string expectedTreasureId = QuestController.singleton.GetQuestByIdAndDifficulty(questId, difficulty).expectedTreasureId;
		int num5 = num2;
		TreasureFactory.singleton.SetSeed(seed);
		List<ItemData.Element> possibleElements = TreasureFactory.singleton.MakeListOfPossibleElements();
		while (num5 > 0)
		{
			num5--;
			Data.Treasure treasureWithId = TreasureFactory.singleton.GetTreasureWithId(expectedTreasureId, difficulty, questId);
			TreasureItem item;
			if (EvaluateOmegaUpgradeToSkullnata(treasureWithId))
			{
				rewardsInfo.treasuresCount[5]++;
				item = TreasureFactory.singleton.MakeTreasureItem("treasure_upgrade", "skullnata", possibleElements);
				Inventory.Singleton.AddItem(item);
				continue;
			}
			if (treasureWithId.type == TreasureItem.Type.Gold)
			{
				rewardsInfo.treasuresCount[6]++;
				item = TreasureFactory.singleton.MakeTreasureItem("mushroom_shop", "treasure_gold", possibleElements);
			}
			else
			{
				if (treasureWithId.type == TreasureItem.Type.Emerald)
				{
					rewardsInfo.treasuresCount[7]++;
					continue;
				}
				if (treasureWithId.type == TreasureItem.Type.Sapphire)
				{
					rewardsInfo.treasuresCount[8]++;
					continue;
				}
				if (treasureWithId.type == TreasureItem.Type.Ruby)
				{
					rewardsInfo.treasuresCount[9]++;
					continue;
				}
				if (treasureWithId.type > TreasureItem.Type.Epic)
				{
					continue;
				}
				int type = (int)treasureWithId.type;
				rewardsInfo.treasuresCount[type]++;
				string itemId = "treasure_" + type;
				item = ItemFactory.singleton.MakeItem(itemId) as TreasureItem;
			}
			item.itemsInTreasure = treasureWithId.items;
			Inventory.Singleton.AddItem(item);
		}
		if (offlineRunInfo.resGained > 0)
		{
			rewardsInfo.resGainedAmount = offlineRunInfo.resGained * num3 / offlineRunInfo.loopCount;
			rewardsInfo.resGainedType = offlineRunInfo.resGainedType;
			InventoryResources.singleton.AddResourceOfType(rewardsInfo.resGainedType, rewardsInfo.resGainedAmount);
		}
		if (offlineRunInfo.kiGained > 0)
		{
			rewardsInfo.kiGained = offlineRunInfo.kiGained * num3 / offlineRunInfo.loopCount;
			InventoryResources.singleton.AddResourceOfType(Data.Resource.Xi, rewardsInfo.kiGained);
		}
		if (offlineRunInfo.resSpentAmountA > 0)
		{
			rewardsInfo.resSpentAmountA = offlineRunInfo.resSpentAmountA * num3 / offlineRunInfo.loopCount;
			rewardsInfo.resSpentTypeA = offlineRunInfo.resSpentTypeA;
			InventoryResources.singleton.RemoveResourceOfType(rewardsInfo.resSpentTypeA, rewardsInfo.resSpentAmountA);
		}
		if (offlineRunInfo.resSpentAmountB > 0)
		{
			rewardsInfo.resSpentAmountB = offlineRunInfo.resSpentAmountB * num3 / offlineRunInfo.loopCount;
			rewardsInfo.resSpentTypeB = offlineRunInfo.resSpentTypeB;
			InventoryResources.singleton.RemoveResourceOfType(rewardsInfo.resSpentTypeB, rewardsInfo.resSpentAmountB);
		}
		if (lastRewardTime < dateTimeNow || lastRewardTime == DateTime.MinValue)
		{
			lastRewardTime = dateTimeNow;
		}
		SequentialPopupManager.singleton.ScheduleOfflineFarmRewards(rewardsInfo);
	}

	public bool BeginOfflineFarm(Data.Quest questData, int difficulty)
	{
		OfflineRunInfo offlineRunInfo = singleton.ComputeOfflineRunInfo(questData.id, difficulty);
		if (offlineRunInfo.treasuresFound > 0)
		{
			string id = questData.id;
			int treasuresPerLoop = GetTreasuresPerLoop(id, difficulty);
			activeRun = new ActiveRunInfo();
			activeRun.questId = id;
			activeRun.difficulty = difficulty;
			activeRun.treasuresPerLoop = treasuresPerLoop;
			activeRun.startTime = GetDateTimeNow();
			activeRun.seed = UnityEngine.Random.Range(0, 999999);
			if (activeRun.startTime < lastRewardTime)
			{
				activeRun.startTime = lastRewardTime;
			}
			runSummary = new OfflineRunSummary();
			runSummary.locationName = Te.xt(questData.name);
			runSummary.treasureCount = Mathf.Min(offlineRunInfo.loopCount * treasuresPerLoop, offlineRunInfo.treasuresFound);
			runSummary.secondsPerTreasure = (float)offlineRunInfo.totalTimeSeconds / (float)offlineRunInfo.loopCount;
			runSummary.treasuresPerLoop = treasuresPerLoop;
			runSummary.startTime = activeRun.startTime;
			runSummary.totalSeconds = offlineRunInfo.totalTimeSeconds;
			SaveSummary();
			ReportQuestDifficultySelected(id, difficulty);
			NotificationMacros.OfflineFarmingComplete(runSummary.locationName, activeRun.startTime.AddSeconds(runSummary.totalSeconds));
			return true;
		}
		return false;
	}

	private int ComputeMaxTreasuresFound()
	{
		int treasurePickupLimit = Inventory.Singleton.GetTreasurePickupLimit();
		treasurePickupLimit -= Inventory.Singleton.GetTreasures().Count;
		if (treasurePickupLimit < 0)
		{
			treasurePickupLimit = 0;
		}
		return treasurePickupLimit;
	}

	private int GetTreasuresPerLoop(string questId, int difficulty)
	{
		int num = 1;
		if (questId == "caustic_caves" && difficulty >= 5)
		{
			num++;
		}
		else if (questId == "rocky_plateau" && difficulty > 5 && EventController.singleton.IsEventActiveAndStarted("summer"))
		{
			num++;
		}
		else if (questId == "undead_crypt" && EventController.singleton.IsEventActiveAndStarted("halloween"))
		{
			num++;
		}
		else if (questId == "icy_ridge" && EventController.singleton.IsEventActiveAndStarted("winter"))
		{
			num++;
		}
		else if (questId == "fungus_forest" && EventController.singleton.IsEventActiveAndStarted("spring"))
		{
			num++;
		}
		else if (questId == "bronze_mine" && EventController.singleton.IsEventActiveAndStarted("guardian_2x"))
		{
			num++;
		}
		else if (questId == "deadwood_valley" && EventController.singleton.IsEventActiveAndStarted("xyloalgia_2x"))
		{
			num++;
		}
		else if (questId == "temple" && EventController.singleton.IsEventActiveAndStarted("nagaraja_2x"))
		{
			num++;
		}
		return num;
	}

	public bool HasActiveRun()
	{
		return GetActiveRunSummary() != null;
	}

	public OfflineRunSummary GetActiveRunSummary()
	{
		if (runSummary != null)
		{
			return runSummary;
		}
		if (PlayerPrefs.HasKey("OFFLINE_FARM_SUMMARY"))
		{
			string sjson = PlayerPrefs.GetString("OFFLINE_FARM_SUMMARY");
			runSummary = OfflineRunSummary.FromString(sjson);
			return runSummary;
		}
		return null;
	}

	private void SaveSummary()
	{
		PlayerPrefs.SetString("OFFLINE_FARM_SUMMARY", runSummary.ToString());
		PlayerPrefs.Save();
	}

	private void ClearSummary()
	{
		runSummary = null;
		PlayerPrefs.DeleteKey("OFFLINE_FARM_SUMMARY");
	}

	private bool EvaluateOmegaUpgradeToSkullnata(Data.Treasure treasureData)
	{
		if (treasureData.type == TreasureItem.Type.Rare && lastSkullnataUpgradeTime.DayOfYear != DateTime.Now.DayOfYear && Utils.random.Next(50) == 1)
		{
			lastSkullnataUpgradeTime = DateTime.Now;
			return true;
		}
		return false;
	}

	public int GetLastPlayedDifficulty(string questId)
	{
		return GetStatsForQuest(questId, 0)?.lastPlayedDifficulty ?? 0;
	}

	public void ReportQuestDifficultySelected(string questId, int difficulty)
	{
		if (difficulty >= 3)
		{
			GetStatsForQuest(questId, 0, createIfNeeded: true).lastPlayedDifficulty = difficulty;
		}
		ClearLoopTrackingStats();
		loopCount = 0;
	}

	public Data.QuestStats GetStatsForQuest(string questId, int difficulty, bool createIfNeeded = false)
	{
		if (difficulty > 0)
		{
			questId += difficulty;
		}
		if (questStatIds.Contains(questId))
		{
			for (int i = 0; i < this.questStats.Count; i++)
			{
				Data.QuestStats questStats = this.questStats[i];
				if (questStats.questId == questId)
				{
					return questStats;
				}
			}
		}
		if (createIfNeeded)
		{
			Data.QuestStats questStats2 = new Data.QuestStats();
			questStats2.questId = questId;
			this.questStats.Add(questStats2);
			questStatIds.Add(questId);
			return questStats2;
		}
		return null;
	}

	public Data.QuestStats GetStatsForQuestTemporaryData(string questId, int difficulty)
	{
		if (questStatsTemporary == null)
		{
			return null;
		}
		if (difficulty > 0)
		{
			questId += difficulty;
		}
		for (int i = 0; i < questStatsTemporary.Count; i++)
		{
			Data.QuestStats questStats = questStatsTemporary[i];
			if (questStats.questId == questId)
			{
				return questStats;
			}
		}
		return null;
	}

	public void ReportQuestCompletionTime(string questId, int difficulty, int time)
	{
		if (difficulty >= 3 && !EventController.singleton.IsPreventingLocationStatsUpdate())
		{
			Data.QuestStats statsForQuest = GetStatsForQuest(questId, difficulty, createIfNeeded: true);
			if (statsForQuest.bestTime <= 0 || time < statsForQuest.bestTime)
			{
				statsForQuest.bestTime = time;
			}
			float num = 0.21f;
			if (loopCount == 0)
			{
				num = 0.03f;
			}
			loopCount++;
			if (statsForQuest.averageTime.GetValue() <= 0f)
			{
				statsForQuest.averageTime = new SafeFloat(time);
				statsForQuest.averageHPLost = new SafeFloat(totalHealthLost.GetValue());
				statsForQuest.averageHPGained = new SafeFloat(totalHealthGained.GetValue());
			}
			else
			{
				float value = statsForQuest.averageTime.GetValue() * (1f - num) + (float)time * num;
				statsForQuest.averageTime = new SafeFloat(value);
				float value2 = statsForQuest.averageHPLost.GetValue() * (1f - num) + (float)totalHealthLost.GetValue() * num;
				statsForQuest.averageHPLost = new SafeFloat(value2);
				float value3 = statsForQuest.averageHPGained.GetValue() * (1f - num) + (float)totalHealthGained.GetValue() * num;
				statsForQuest.averageHPGained = new SafeFloat(value3);
			}
			float value4 = statsForQuest.averageKiGained.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageKiGained = new SafeFloat(totalKiGained.GetValue());
				statsForQuest.averageResGained = new SafeFloat(totalResGained.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalKiGained.GetValue() * num;
				statsForQuest.averageKiGained = new SafeFloat(value4);
				value4 = statsForQuest.averageResGained.GetValue() * (1f - num) + (float)totalResGained.GetValue() * num;
				statsForQuest.averageResGained = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDamageDealt.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDamageDealt = new SafeFloat(totalDamageDealt.GetValue());
			}
			else
			{
				float value5 = value4 * (1f - num) + (float)totalDamageDealt.GetValue() * num;
				statsForQuest.averageDamageDealt = new SafeFloat(value5);
			}
			value4 = statsForQuest.averageDevourDamage.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevourDamage = new SafeFloat(totalDevourDamage.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevourDamage.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDevouredAEther.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevouredAEther = new SafeFloat(totalDevouredAEther.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevouredAEther.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDevouredFire.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevouredFire = new SafeFloat(totalDevouredFire.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevouredFire.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDevouredIce.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevouredIce = new SafeFloat(totalDevouredIce.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevouredIce.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDevouredPoison.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevouredPoison = new SafeFloat(totalDevouredPoison.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevouredPoison.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			value4 = statsForQuest.averageDevouredVigor.GetValue();
			if (value4 <= 0f)
			{
				statsForQuest.averageDevouredVigor = new SafeFloat(totalDevouredVigor.GetValue());
			}
			else
			{
				value4 = value4 * (1f - num) + (float)totalDevouredVigor.GetValue() * num;
				statsForQuest.averageDevourDamage = new SafeFloat(value4);
			}
			ClearLoopTrackingStats();
		}
	}

	private void ClearLoopTrackingStats()
	{
		totalHealthLost = default(SafeInt);
		totalHealthGained = default(SafeInt);
		totalKiGained = default(SafeInt);
		totalResGained = default(SafeInt);
		totalDamageDealt = default(SafeInt);
		totalDevourDamage = default(SafeInt);
		totalDevouredAEther = default(SafeInt);
		totalDevouredFire = default(SafeInt);
		totalDevouredIce = default(SafeInt);
		totalDevouredPoison = default(SafeInt);
		totalDevouredVigor = default(SafeInt);
	}

	private void HandleCharacterTookDamage(Character c, Damage dmg)
	{
		if (c == GameStates.Singleton.hero)
		{
			totalHealthLost += dmg.hitpointsLost;
		}
		else if (c is Enemy)
		{
			totalDamageDealt += dmg.amount;
			if (dmg.tags.Contains("Devour"))
			{
				totalDevourDamage += dmg.amount;
			}
		}
	}

	private void HandleCharacterWasHealed(Character c, Damage heal)
	{
		if (c == GameStates.Singleton.hero && !heal.tags.Contains("potion"))
		{
			totalHealthGained += heal.amount;
		}
	}

	public void ReportRuneDevoured(ItemData.Element runeType, int amount)
	{
		switch (runeType)
		{
		case ItemData.Element.AEther:
			totalDevouredAEther += amount;
			break;
		case ItemData.Element.Fire:
			totalDevouredFire += amount;
			break;
		case ItemData.Element.Ice:
			totalDevouredIce += amount;
			break;
		case ItemData.Element.Poison:
			totalDevouredPoison += amount;
			break;
		case ItemData.Element.Vigor:
			totalDevouredVigor += amount;
			break;
		}
	}

	public void ReportResourceGained(Data.Resource type, int amount)
	{
		if (type == Data.Resource.Xi)
		{
			totalKiGained += amount;
		}
		else
		{
			totalResGained += amount;
		}
	}

	public void ClearStatsForQuest(string questId)
	{
		if (questStatsTemporary == null)
		{
			questStatsTemporary = new List<Data.QuestStats>();
		}
		for (int num = this.questStats.Count - 1; num >= 0; num--)
		{
			Data.QuestStats questStats = this.questStats[num];
			if (questStats.questId.StartsWith(questId))
			{
				questStatsTemporary.Add(questStats);
				this.questStats.RemoveAt(num);
				if (questStatIds.Contains(questStats.questId))
				{
					questStatIds.Remove(questStats.questId);
				}
			}
		}
	}

	public DateTime GetDateTimeNow()
	{
		return DateTime.UtcNow;
	}

	public void ResetClock()
	{
		lastRewardTime = DateTime.MinValue;
	}

	public void ClearProgress()
	{
		questStats.Clear();
		questStatIds.Clear();
		if (questStatsTemporary != null)
		{
			questStatsTemporary.Clear();
			questStatsTemporary = null;
		}
		activeRun = null;
		lastRewardTime = DateTime.MinValue;
	}

	public void Serialize()
	{
		SlimJson.AddProperty("stats", questStats.ToArray());
		if (activeRun != null)
		{
			SlimJson.AddProperty("activeRun", activeRun.ToString());
		}
		if (lastRewardTime != DateTime.MinValue)
		{
			SlimJson.AddProperty("lastRewardTime", lastRewardTime);
		}
		if (lastSkullnataUpgradeTime != DateTime.MinValue)
		{
			SlimJson.AddProperty("skullnata", lastSkullnataUpgradeTime);
		}
	}

	public void Parse(string sjson)
	{
		ClearProgress();
		Data.QuestStats[] array = SlimJson.ParseArray(sjson, "stats", Data.QuestStats.FromString);
		if (array != null)
		{
			foreach (Data.QuestStats questStats in array)
			{
				if (!questStatIds.Contains(questStats.questId))
				{
					this.questStats.Add(questStats);
					questStatIds.Add(questStats.questId);
				}
			}
		}
		activeRun = SlimJson.Parse(sjson, "activeRun", ActiveRunInfo.FromString);
		if (SlimJson.HasKey(sjson, "lastRewardTime"))
		{
			lastRewardTime = SlimJson.ParseDateTime(sjson, "lastRewardTime");
		}
		if (SlimJson.HasKey(sjson, "skullnata"))
		{
			lastSkullnataUpgradeTime = SlimJson.ParseDateTime(sjson, "skullnata");
		}
	}

	private void Awake()
	{
		singleton = this;
		Character.OnCharacterTookDamage += HandleCharacterTookDamage;
		Character.OnCharacterWasHealed += HandleCharacterWasHealed;
	}

	private void OnDestroy()
	{
		Character.OnCharacterTookDamage -= HandleCharacterTookDamage;
		Character.OnCharacterWasHealed -= HandleCharacterWasHealed;
	}
}
