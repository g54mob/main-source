using System;
using System.Collections.Generic;
using UnityEngine;

public class AchievementManager : MonoBehaviour
{
	public List<Achievement> allAchievements = new List<Achievement>();

	[Header("Reward Icons Setup")]
	public List<RewardCategoryIcon> rewardCategoryIcons = new List<RewardCategoryIcon>();

	private Dictionary<string, bool> completedState = new Dictionary<string, bool>();

	private Dictionary<string, bool> claimedState = new Dictionary<string, bool>();

	[Header("Debug")]
	[Tooltip("Enter an Achievement ID here and use the Context Menu to complete it.")]
	public string debugAchievementIDToComplete;

	private const string SAVE_PREFIX = "Ach_";

	private const string COMPLETED_SUFFIX = "_Completed";

	private const string CLAIMED_SUFFIX = "_Claimed";

	private double totalMoneyEarned;

	private int totalXpEarned;

	private int perfectCatches;

	private int criticalClicks;

	private int passiveIncomeEarned;

	private int passiveFishCaught;

	private int energyExpended;

	private int multiCatches;

	private int tripleCatches;

	private int oneShotCatches;

	private int currentPerfectStreak;

	private int bestPerfectStreak;

	private int currentMultiCatchStreak;

	private int bestMultiCatchStreak;

	private const string PP_MONEY_EARNED = "AchStat_MoneyEarned";

	private const string PP_MONEY_EARNED_DBL = "AchStat_MoneyEarnedDbl";

	private const string PP_XP_EARNED = "AchStat_XpEarned";

	private const string PP_PERFECT_CATCHES = "AchStat_PerfectCatches";

	private const string PP_CRIT_CLICKS = "AchStat_CritClicks";

	private const string PP_PASSIVE_INCOME = "AchStat_PassiveIncome";

	private const string PP_PASSIVE_FISH = "AchStat_PassiveFish";

	private const string PP_ENERGY_SPENT = "AchStat_EnergySpent";

	private const string PP_MULTI_CATCHES = "AchStat_MultiCatches";

	private const string PP_TRIPLE_CATCHES = "AchStat_TripleCatches";

	private const string PP_ONE_SHOT_CATCHES = "AchStat_OneShotCatches";

	private const string PP_BEST_PERFECT_STREAK = "AchStat_BestPerfectStreak";

	private const string PP_BEST_MULTI_STREAK = "AchStat_BestMultiCatchStreak";

	public static AchievementManager Instance { get; private set; }

	public event Action<Achievement> OnAchievementCompleted;

	public event Action<Achievement> OnAchievementClaimed;

	public Sprite GetRewardIcon(SkillBonusType type)
	{
		foreach (RewardCategoryIcon rewardCategoryIcon in rewardCategoryIcons)
		{
			if (rewardCategoryIcon.bonusTypes != null && rewardCategoryIcon.bonusTypes.Contains(type))
			{
				return rewardCategoryIcon.icon;
			}
		}
		return null;
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadAllAchievementsFromResources();
		LoadAchievementData();
	}

	private void LoadAllAchievementsFromResources()
	{
		allAchievements.Clear();
		Achievement[] array = Resources.LoadAll<Achievement>("Achievements");
		foreach (Achievement achievement in array)
		{
			if (string.IsNullOrEmpty(achievement.ID))
			{
				Debug.LogWarning("[AchievementManager] Achievement '" + achievement.name + "' has no ID — skipped.");
			}
			else
			{
				allAchievements.Add(achievement);
			}
		}
		Debug.Log($"[AchievementManager] Loaded {allAchievements.Count} achievements from Resources.");
	}

	public void SaveAchievementData()
	{
		foreach (KeyValuePair<string, bool> item in completedState)
		{
			PlayerPrefs.SetInt("Ach_" + item.Key + "_Completed", item.Value ? 1 : 0);
		}
		foreach (KeyValuePair<string, bool> item2 in claimedState)
		{
			PlayerPrefs.SetInt("Ach_" + item2.Key + "_Claimed", item2.Value ? 1 : 0);
		}
		PlayerPrefs.SetString("AchStat_MoneyEarnedDbl", totalMoneyEarned.ToString("R"));
		PlayerPrefs.SetInt("AchStat_XpEarned", totalXpEarned);
		PlayerPrefs.SetInt("AchStat_PerfectCatches", perfectCatches);
		PlayerPrefs.SetInt("AchStat_CritClicks", criticalClicks);
		PlayerPrefs.SetInt("AchStat_PassiveIncome", passiveIncomeEarned);
		PlayerPrefs.SetInt("AchStat_PassiveFish", passiveFishCaught);
		PlayerPrefs.SetInt("AchStat_EnergySpent", energyExpended);
		PlayerPrefs.SetInt("AchStat_MultiCatches", multiCatches);
		PlayerPrefs.SetInt("AchStat_TripleCatches", tripleCatches);
		PlayerPrefs.SetInt("AchStat_OneShotCatches", oneShotCatches);
		PlayerPrefs.SetInt("AchStat_BestPerfectStreak", bestPerfectStreak);
		PlayerPrefs.SetInt("AchStat_BestMultiCatchStreak", bestMultiCatchStreak);
		PlayerPrefs.Save();
	}

	public void LoadAchievementData()
	{
		if (PlayerPrefs.HasKey("AchStat_MoneyEarnedDbl"))
		{
			double.TryParse(PlayerPrefs.GetString("AchStat_MoneyEarnedDbl", "0"), out totalMoneyEarned);
		}
		else
		{
			totalMoneyEarned = PlayerPrefs.GetInt("AchStat_MoneyEarned", 0);
		}
		totalXpEarned = PlayerPrefs.GetInt("AchStat_XpEarned", 0);
		perfectCatches = PlayerPrefs.GetInt("AchStat_PerfectCatches", 0);
		criticalClicks = PlayerPrefs.GetInt("AchStat_CritClicks", 0);
		passiveIncomeEarned = PlayerPrefs.GetInt("AchStat_PassiveIncome", 0);
		passiveFishCaught = PlayerPrefs.GetInt("AchStat_PassiveFish", 0);
		energyExpended = PlayerPrefs.GetInt("AchStat_EnergySpent", 0);
		multiCatches = PlayerPrefs.GetInt("AchStat_MultiCatches", 0);
		tripleCatches = PlayerPrefs.GetInt("AchStat_TripleCatches", 0);
		oneShotCatches = PlayerPrefs.GetInt("AchStat_OneShotCatches", 0);
		bestPerfectStreak = PlayerPrefs.GetInt("AchStat_BestPerfectStreak", 0);
		bestMultiCatchStreak = PlayerPrefs.GetInt("AchStat_BestMultiCatchStreak", 0);
		currentPerfectStreak = 0;
		currentMultiCatchStreak = 0;
		completedState.Clear();
		claimedState.Clear();
		foreach (Achievement allAchievement in allAchievements)
		{
			bool flag = PlayerPrefs.GetInt("Ach_" + allAchievement.ID + "_Completed", 0) == 1;
			bool value = PlayerPrefs.GetInt("Ach_" + allAchievement.ID + "_Claimed", 0) == 1;
			if (PlayerPrefs.GetInt("Ach_" + allAchievement.ID + "_Unlocked", 0) == 1)
			{
				flag = true;
				value = true;
			}
			if (!flag && allAchievement.requirementValue > 0 && FishLogManager.Instance != null && GetCurrentValue(allAchievement) >= allAchievement.requirementValue)
			{
				flag = true;
				PlayerPrefs.SetInt("Ach_" + allAchievement.ID + "_Completed", 1);
			}
			completedState[allAchievement.ID] = flag;
			claimedState[allAchievement.ID] = value;
		}
		PlayerPrefs.Save();
	}

	public bool IsAchievementCompleted(string id)
	{
		bool value;
		return completedState.TryGetValue(id, out value) && value;
	}

	public bool IsAchievementClaimed(string id)
	{
		bool value;
		return claimedState.TryGetValue(id, out value) && value;
	}

	public bool HasUnclaimedAchievements()
	{
		foreach (Achievement allAchievement in allAchievements)
		{
			if (IsAchievementCompleted(allAchievement.ID) && !IsAchievementClaimed(allAchievement.ID))
			{
				return true;
			}
		}
		return false;
	}

	public float GetProgress(Achievement ach)
	{
		if (IsAchievementCompleted(ach.ID))
		{
			return 1f;
		}
		if (ach.requirementValue <= 0)
		{
			return 0f;
		}
		return Mathf.Clamp01((float)GetCurrentValue(ach) / (float)ach.requirementValue);
	}

	public void RefreshCompletionStatus()
	{
		foreach (Achievement allAchievement in allAchievements)
		{
			if (!IsAchievementCompleted(allAchievement.ID) && allAchievement.requirementValue > 0)
			{
				int currentValue = GetCurrentValue(allAchievement);
				if (currentValue >= allAchievement.requirementValue)
				{
					completedState[allAchievement.ID] = true;
					PlayerPrefs.SetInt("Ach_" + allAchievement.ID + "_Completed", 1);
					Debug.Log($"[AchievementManager] Auto-completed: {allAchievement.achievementName} ({currentValue}/{allAchievement.requirementValue})");
				}
			}
		}
		PlayerPrefs.Save();
	}

	private int GetCurrentValue(Achievement ach)
	{
		switch (ach.requirementType)
		{
		case AchievementRequirementType.total_fish_caught:
			if (!(FishLogManager.Instance != null))
			{
				return 0;
			}
			return FishLogManager.Instance.TotalGlobalFishCaught;
		case AchievementRequirementType.catch_specific_fish:
			if (!(FishLogManager.Instance != null))
			{
				return 0;
			}
			return FishLogManager.Instance.GetTotalCatchCountForSpecies(ach.requirementTarget);
		case AchievementRequirementType.catch_rarity:
		{
			if (FishLogManager.Instance == null)
			{
				return 0;
			}
			int num = 0;
			{
				foreach (Fish item in FishLogManager.Instance.allFish)
				{
					num += FishLogManager.Instance.GetCatchCount(item.speciesName, ach.requirementTarget);
				}
				return num;
			}
		}
		case AchievementRequirementType.total_money_earned:
			return (int)Math.Min(totalMoneyEarned, 2147483647.0);
		case AchievementRequirementType.total_xp_earned:
			return totalXpEarned;
		case AchievementRequirementType.perfect_catches:
			return perfectCatches;
		case AchievementRequirementType.critical_clicks:
			return criticalClicks;
		case AchievementRequirementType.passive_income_earned:
			return passiveIncomeEarned;
		case AchievementRequirementType.passive_fish_caught:
			return passiveFishCaught;
		case AchievementRequirementType.skills_unlocked:
			if (!(SkillManager.Instance != null))
			{
				return 0;
			}
			return SkillManager.Instance.GetTotalSkillsPurchased();
		case AchievementRequirementType.energy_expended:
			return energyExpended;
		case AchievementRequirementType.days_completed:
			if (!(GameManager.Instance != null))
			{
				return 0;
			}
			return Mathf.Max(0, GameManager.Instance.CurrentDay - 1);
		case AchievementRequirementType.multi_catches:
			return multiCatches;
		case AchievementRequirementType.catch_all_zone_species:
		{
			if (GameManager.Instance == null || FishLogManager.Instance == null)
			{
				return 0;
			}
			ZoneData zoneData = null;
			foreach (ZoneData allZone in GameManager.Instance.allZones)
			{
				if (string.Equals(allZone.zoneName, ach.requirementTarget, StringComparison.OrdinalIgnoreCase))
				{
					zoneData = allZone;
					break;
				}
			}
			if (zoneData == null || zoneData.possibleCatches == null || zoneData.possibleCatches.Count == 0)
			{
				return 0;
			}
			foreach (FishEncounterData possibleCatch in zoneData.possibleCatches)
			{
				if (!(possibleCatch.fishSpecies == null) && !FishLogManager.Instance.HasCaughtSpecies(possibleCatch.fishSpecies.speciesName))
				{
					return 0;
				}
			}
			return 1;
		}
		case AchievementRequirementType.legendary_all_species:
			if (FishLogManager.Instance == null)
			{
				return 0;
			}
			foreach (Fish item2 in FishLogManager.Instance.allFish)
			{
				if (FishLogManager.Instance.GetCatchCount(item2.speciesName, "Legendary") < 1)
				{
					return 0;
				}
			}
			return 1;
		case AchievementRequirementType.all_skills_maxed:
			if (SkillManager.Instance == null)
			{
				return 0;
			}
			foreach (KeyValuePair<string, Skill> allSkill in SkillManager.Instance.allSkills)
			{
				if (SkillManager.Instance.GetSkillLevel(allSkill.Key) < allSkill.Value.MaxLevel)
				{
					return 0;
				}
			}
			return 1;
		case AchievementRequirementType.perfect_catch_streak:
			return bestPerfectStreak;
		case AchievementRequirementType.multi_catch_streak:
			return bestMultiCatchStreak;
		case AchievementRequirementType.triple_catches:
			return tripleCatches;
		case AchievementRequirementType.one_shot_catch:
			return oneShotCatches;
		default:
			return 0;
		}
	}

	private void CheckAllAchievements()
	{
		foreach (Achievement allAchievement in allAchievements)
		{
			if (!IsAchievementCompleted(allAchievement.ID) && GetCurrentValue(allAchievement) >= allAchievement.requirementValue)
			{
				CompleteAchievement(allAchievement);
			}
		}
	}

	public void OnFishCaught(CaughtFish fish)
	{
		CheckAllAchievements();
	}

	public void NotifyMoneyEarned(double amount)
	{
		if (!(amount <= 0.0))
		{
			totalMoneyEarned += amount;
			CheckAllAchievements();
		}
	}

	public void NotifyXpEarned(int amount)
	{
		if (amount > 0)
		{
			totalXpEarned += amount;
			CheckAllAchievements();
		}
	}

	public void NotifyPerfectCatch()
	{
		perfectCatches++;
		currentPerfectStreak++;
		if (currentPerfectStreak > bestPerfectStreak)
		{
			bestPerfectStreak = currentPerfectStreak;
		}
		CheckAllAchievements();
	}

	public void NotifyNonPerfectCatch()
	{
		currentPerfectStreak = 0;
	}

	public void NotifyCriticalClick()
	{
		criticalClicks++;
		CheckAllAchievements();
	}

	public void NotifyPassiveIncomeEarned(int amount)
	{
		if (amount > 0)
		{
			passiveIncomeEarned += amount;
			CheckAllAchievements();
		}
	}

	public void NotifyPassiveFishCaught()
	{
		passiveFishCaught++;
		CheckAllAchievements();
	}

	public void NotifyEnergyExpended(int amount)
	{
		if (amount > 0)
		{
			energyExpended += amount;
			CheckAllAchievements();
		}
	}

	public void NotifyMultiCatch()
	{
		multiCatches++;
		currentMultiCatchStreak++;
		if (currentMultiCatchStreak > bestMultiCatchStreak)
		{
			bestMultiCatchStreak = currentMultiCatchStreak;
		}
		CheckAllAchievements();
	}

	public void NotifyNonMultiCatch()
	{
		currentMultiCatchStreak = 0;
	}

	public void NotifyTripleCatch()
	{
		tripleCatches++;
		CheckAllAchievements();
	}

	public void NotifyOneShotCatch()
	{
		oneShotCatches++;
		CheckAllAchievements();
	}

	public void NotifyDayCompleted()
	{
		CheckAllAchievements();
	}

	public void NotifySkillUnlocked()
	{
		CheckAllAchievements();
	}

	public void ResetAchievementData()
	{
		completedState.Clear();
		claimedState.Clear();
		totalMoneyEarned = 0.0;
		totalXpEarned = 0;
		perfectCatches = 0;
		criticalClicks = 0;
		passiveIncomeEarned = 0;
		passiveFishCaught = 0;
		energyExpended = 0;
		multiCatches = 0;
		tripleCatches = 0;
		oneShotCatches = 0;
		currentPerfectStreak = 0;
		bestPerfectStreak = 0;
		currentMultiCatchStreak = 0;
		bestMultiCatchStreak = 0;
		foreach (Achievement allAchievement in allAchievements)
		{
			completedState[allAchievement.ID] = false;
			claimedState[allAchievement.ID] = false;
		}
		SaveAchievementData();
		Debug.Log("[AchievementManager] All achievement data reset for new game.");
	}

	private void CompleteAchievement(Achievement ach)
	{
		completedState[ach.ID] = true;
		PlayerPrefs.SetInt("Ach_" + ach.ID + "_Completed", 1);
		PlayerPrefs.Save();
		Debug.Log("[AchievementManager] Achievement completed (awaiting claim): " + ach.achievementName);
		this.OnAchievementCompleted?.Invoke(ach);
	}

	public void ClaimAchievement(string id)
	{
		if (IsAchievementClaimed(id))
		{
			return;
		}
		if (!IsAchievementCompleted(id))
		{
			Debug.LogWarning("[AchievementManager] Tried to claim '" + id + "' but requirement not yet met.");
			return;
		}
		Achievement achievement = allAchievements.Find((Achievement a) => a.ID == id);
		if (!(achievement == null))
		{
			claimedState[id] = true;
			PlayerPrefs.SetInt("Ach_" + id + "_Claimed", 1);
			PlayerPrefs.Save();
			if (GameManager.Instance != null && achievement.rewardValue > 0f && achievement.rewardBonusType == SkillBonusType.None)
			{
				GameManager.Instance.AddEarnings(Mathf.RoundToInt(achievement.rewardValue), "Achievement_" + id);
			}
			PlayerStats.Instance?.RecalculateAllStats();
			Debug.Log("[AchievementManager] Achievement claimed: " + achievement.achievementName);
			this.OnAchievementClaimed?.Invoke(achievement);
		}
	}

	[ContextMenu("Debug: Complete Specific Achievement")]
	public void DebugCompleteSpecificAchievement()
	{
		if (!string.IsNullOrWhiteSpace(debugAchievementIDToComplete))
		{
			Achievement achievement = allAchievements.Find((Achievement a) => a.ID == debugAchievementIDToComplete);
			if (achievement != null && !IsAchievementCompleted(achievement.ID))
			{
				completedState[achievement.ID] = true;
				PlayerPrefs.SetInt("Ach_" + achievement.ID + "_Completed", 1);
				PlayerPrefs.Save();
				this.OnAchievementCompleted?.Invoke(achievement);
				Debug.Log("Forced achievement '" + achievement.ID + "' to be ready to claim!");
			}
			else
			{
				Debug.LogWarning("Achievement '" + debugAchievementIDToComplete + "' not found or already completed!");
			}
		}
	}

	[ContextMenu("Debug: Complete All Achievements")]
	public void DebugCompleteAllAchievements()
	{
		foreach (Achievement allAchievement in allAchievements)
		{
			if (!IsAchievementCompleted(allAchievement.ID))
			{
				completedState[allAchievement.ID] = true;
				PlayerPrefs.SetInt("Ach_" + allAchievement.ID + "_Completed", 1);
				PlayerPrefs.Save();
				this.OnAchievementCompleted?.Invoke(allAchievement);
			}
		}
		Debug.Log("Forced all achievements to be ready to claim!");
	}
}
