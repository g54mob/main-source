using System;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyQuestsController : MonoBehaviour
{
	[Serializable]
	public class OptimalTime
	{
		public string locId;

		public int time;
	}

	private List<string> LOCATION_IDs = new List<string>(new string[8] { "rocky_plateau", "deadwood_valley", "caustic_caves", "fungus_forest", "undead_crypt", "bronze_mine", "icy_ridge", "temple" });

	public OptimalTime[] optimalTimes;

	public float improveByPercent;

	public int minImprove;

	public int maxImprove;

	public Data.WeeklyQuest activeQuest;

	private int prevAverageTime;

	public int questCount { get; private set; }

	public DateTime expiration { get; private set; }

	public static WeeklyQuestsController singleton { get; private set; }

	public event Action<Data.WeeklyQuest> OnWeeklyCompleted;

	private Data.WeeklyQuest GenerateQuest()
	{
		Data.WeeklyQuest weeklyQuest = new Data.WeeklyQuest();
		if (Inventory.Singleton.GetFirstItemWithId("moon_stone") == null)
		{
			weeklyQuest.type = Data.WeeklyQuest.Type.FindAllStones;
			return weeklyQuest;
		}
		Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("ouroboros_stone");
		Item firstItemWithId2 = Inventory.Singleton.GetFirstItemWithId("star_stone");
		if (firstItemWithId != null && firstItemWithId.level == 1)
		{
			if (firstItemWithId2 != null && firstItemWithId2.level == 1)
			{
				weeklyQuest.type = Data.WeeklyQuest.Type.UpgradeStarOuro;
			}
			else
			{
				weeklyQuest.type = Data.WeeklyQuest.Type.UpgradeOuroboros;
			}
			return weeklyQuest;
		}
		if (firstItemWithId2 != null && firstItemWithId2.level == 1)
		{
			weeklyQuest.type = Data.WeeklyQuest.Type.UpgradeStarStone;
			return weeklyQuest;
		}
		int num = 15;
		List<string> list = new List<string>();
		for (int i = 0; i < LOCATION_IDs.Count; i++)
		{
			string text = LOCATION_IDs[i];
			if (QuestController.singleton.GetStarDifficultyForQuest(text) < num)
			{
				list.Add(text);
				continue;
			}
			Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(text, num);
			if (statsForQuest == null || Mathf.RoundToInt(statsForQuest.averageTime.GetValue()) == 0)
			{
				list.Add(text);
			}
		}
		if (list.Count > 0)
		{
			weeklyQuest.type = Data.WeeklyQuest.Type.ImproveStars;
			int index = UnityEngine.Random.Range(0, list.Count);
			string questId = (weeklyQuest.locId = list[index]);
			int starDifficultyForQuest = QuestController.singleton.GetStarDifficultyForQuest(questId);
			if (starDifficultyForQuest < 5)
			{
				weeklyQuest.goal = 5;
			}
			else if (starDifficultyForQuest % 5 == 1)
			{
				weeklyQuest.goal = starDifficultyForQuest + 1;
			}
			else if (starDifficultyForQuest % 5 == 0 && starDifficultyForQuest < num)
			{
				if (QuestController.singleton.HasCompletedAtDifficulty(questId, starDifficultyForQuest))
				{
					weeklyQuest.goal = starDifficultyForQuest + 1;
				}
				else
				{
					weeklyQuest.goal = starDifficultyForQuest;
				}
			}
			else
			{
				weeklyQuest.goal = starDifficultyForQuest;
			}
			return weeklyQuest;
		}
		weeklyQuest.type = Data.WeeklyQuest.Type.ImproveTime;
		int index2 = UnityEngine.Random.Range(0, LOCATION_IDs.Count);
		string text2 = (weeklyQuest.locId = LOCATION_IDs[index2]);
		Data.QuestStats statsForQuest2 = OfflineFarmController.singleton.GetStatsForQuest(text2, num);
		if (statsForQuest2 == null || Mathf.RoundToInt(statsForQuest2.averageTime.GetValue()) == 0)
		{
			weeklyQuest.goal = 99999;
		}
		else
		{
			int num2 = 0;
			OptimalTime[] array = optimalTimes;
			foreach (OptimalTime optimalTime in array)
			{
				if (optimalTime.locId == text2)
				{
					num2 = optimalTime.time;
					break;
				}
			}
			int num3 = Mathf.RoundToInt(statsForQuest2.averageTime.GetValue());
			if (num3 <= num2)
			{
				weeklyQuest.goal = num3 - 15;
			}
			else
			{
				int num4 = num3 - num2;
				num4 = Mathf.RoundToInt((float)num4 * improveByPercent);
				num4 = Mathf.Clamp(num4, minImprove, maxImprove);
				weeklyQuest.goal = num3 - num4;
			}
		}
		return weeklyQuest;
	}

	private void CompleteQuest()
	{
		activeQuest.completed = true;
		CustomQuestsController.Singleton.customQuestsScreen.MarkDirty();
		GameStates.Singleton.navBar.questStoneButton.SetState(QuestStoneNavButton.State.KiTreasureAvailable);
		AnalyticsMacros.WeeklyQuestCompleted();
		if (this.OnWeeklyCompleted != null)
		{
			this.OnWeeklyCompleted(activeQuest);
		}
	}

	private void HandleItemAdded(Item item, int count)
	{
		if (activeQuest == null || activeQuest.completed)
		{
			return;
		}
		if (activeQuest.type == Data.WeeklyQuest.Type.FindAllStones && item.id == "moon_stone")
		{
			CompleteQuest();
		}
		else if (activeQuest.type == Data.WeeklyQuest.Type.UpgradeOuroboros && item.id == "ouroboros_stone" && item.level > 1)
		{
			CompleteQuest();
		}
		else if (activeQuest.type == Data.WeeklyQuest.Type.UpgradeStarStone && item.id == "star_stone" && item.level > 1)
		{
			CompleteQuest();
		}
		else
		{
			if (activeQuest.type != Data.WeeklyQuest.Type.UpgradeStarOuro)
			{
				return;
			}
			if (item.id == "ouroboros_stone" && item.level > 1)
			{
				Item firstItemWithId = Inventory.Singleton.GetFirstItemWithId("star_stone");
				if (firstItemWithId != null && firstItemWithId.level > 1)
				{
					CompleteQuest();
				}
			}
			else if (item.id == "star_stone" && item.level > 1)
			{
				Item firstItemWithId2 = Inventory.Singleton.GetFirstItemWithId("ouroboros_stone");
				if (firstItemWithId2 != null && firstItemWithId2.level > 1)
				{
					CompleteQuest();
				}
			}
		}
	}

	private void HandleQuestCompleted(Data.Quest questCompleted, bool firstCompletion)
	{
		if (activeQuest != null && !activeQuest.completed && activeQuest.type == Data.WeeklyQuest.Type.ImproveStars && questCompleted.id == activeQuest.locId && questCompleted.level >= activeQuest.goal)
		{
			CompleteQuest();
		}
	}

	public void ReportQuestCompletionTime(string questId, int difficulty, int time)
	{
		if (activeQuest == null || activeQuest.completed)
		{
			return;
		}
		int num = 15;
		if (activeQuest.type != Data.WeeklyQuest.Type.ImproveTime || difficulty != num || !(questId == activeQuest.locId))
		{
			return;
		}
		Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(questId, difficulty);
		if (statsForQuest == null)
		{
			return;
		}
		int num2 = Mathf.RoundToInt(statsForQuest.averageTime.GetValue());
		if (num2 <= 0)
		{
			CompleteQuest();
			return;
		}
		if (num2 <= activeQuest.goal)
		{
			CompleteQuest();
			return;
		}
		if (num2 < prevAverageTime)
		{
			CustomQuestsController.Singleton.customQuestsScreen.MarkDirty();
		}
		WeeklyQuestProgressCard.singleton.Show(prevAverageTime, num2, activeQuest.goal);
	}

	public void SetupPreviousAverageTime(string questId, int difficulty)
	{
		if (activeQuest != null && !activeQuest.completed && activeQuest.type == Data.WeeklyQuest.Type.ImproveTime && questId == activeQuest.locId)
		{
			Data.QuestStats statsForQuest = OfflineFarmController.singleton.GetStatsForQuest(questId, difficulty);
			if (statsForQuest != null)
			{
				prevAverageTime = Mathf.RoundToInt(statsForQuest.averageTime.GetValue());
			}
		}
	}

	public void TryGenerateNew()
	{
		if (QuestController.singleton.IsAvailable("uulaa_shop") && (activeQuest == null || !activeQuest.completed) && ((activeQuest == null && questCount == 0) || DateTime.Now >= expiration))
		{
			Internal_GenerateNew();
		}
	}

	private void Internal_GenerateNew()
	{
		activeQuest = GenerateQuest();
		questCount++;
		expiration = DateTime.Now;
		TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
		int i;
		for (i = 0; expiration.DayOfWeek != DayOfWeek.Monday || i == 0; i++)
		{
			expiration += timeSpan;
		}
		if (questCount <= 1 && i <= 2)
		{
			expiration += new TimeSpan(7, 0, 0, 0);
		}
		expiration = new DateTime(expiration.Year, expiration.Month, expiration.Day, 0, 0, 0);
		GameStates.Singleton.navBar.questStoneButton.SetState(QuestStoneNavButton.State.KiTreasureAvailable);
	}

	public void DevRefresh()
	{
		Internal_GenerateNew();
		CustomQuestsController.Singleton.customQuestsScreen.MarkDirty();
	}

	public void ResetClock()
	{
		if (QuestController.singleton.IsAvailable("uulaa_shop"))
		{
			DevRefresh();
		}
	}

	public string Serialize()
	{
		SlimJson.BeginSerialization();
		if (activeQuest != null)
		{
			SlimJson.AddProperty("activeQuest", activeQuest.ToString());
		}
		SlimJson.AddProperty("questCount", questCount);
		SlimJson.AddProperty("expiration", expiration);
		return SlimJson.EndSerialization();
	}

	public void Parse(string sjson)
	{
		if (sjson != null)
		{
			activeQuest = SlimJson.Parse(sjson, "activeQuest", Data.WeeklyQuest.FromString);
			questCount = SlimJson.ParseInt(sjson, "questCount");
			expiration = SlimJson.ParseDateTime(sjson, "expiration");
		}
		else
		{
			ClearProgress();
		}
		TryGenerateNew();
	}

	public void ClearProgress()
	{
		activeQuest = null;
		questCount = 0;
		expiration = DateTime.Now;
	}

	private void Start()
	{
		Inventory.Singleton.OnItemAdded += HandleItemAdded;
		QuestController.singleton.OnQuestCompleted += HandleQuestCompleted;
	}

	private void Awake()
	{
		singleton = this;
	}
}
