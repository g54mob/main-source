using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	[Header("Base Stats")]
	public int baseMaxEnergy = 10;

	public int absoluteMaxDailyCasts = 10;

	public int baseEnergyCostPerCast = 5;

	public int baseReelInClickPower = 1;

	public float baseReactionTime = 0.7f;

	public float baseClicksRequiredMultiplier = 1f;

	public float baseRareFishChance;

	public float baseFishValueMultiplier = 1f;

	public float baseAutoHookChance;

	public float baseCritClickChance;

	public float baseCritClickMultiplier = 2f;

	public int basePassiveClicks;

	public int basePassiveClickStrength = 1;

	public float basePassiveClickSpeed = 1f;

	public float baseSponsorshipBonus;

	public float baseSponsorshipBonusMult = 1f;

	public float baseFasterCatching;

	public float basePerfectCatchTime;

	public float basePerfectStartProgress = 0.1f;

	public float basePassiveIncomeAdditive;

	public float basePassiveIncomeMultiplier = 1f;

	public float baseReelInTimeLimit = 3f;

	public float baseHoldClickRate = 6f;

	public float baseTimePerCrit;

	public float baseMaxReelInDuration = 10f;

	public float baseTrackerPulseSpeed;

	public float perfectCatchBonusMultiplier = 1.25f;

	[Header("Debug / Verification")]
	[SerializeField]
	private float debugCurrentZoneSynergyMult = 1f;

	public int baseFishTrackerTier = 1;

	private List<Fish> allFish;

	private List<ZoneData> allZones;

	public static PlayerStats Instance { get; private set; }

	[Header("Live Calculated Stats")]
	public int EnergyCostPerCast { get; private set; }

	public int MaxEnergy { get; private set; }

	public float ReelInClickPower { get; private set; }

	public float ClickPowerMultiplier { get; private set; } = 1f;

	[field: SerializeField]
	public float ReactionTime { get; private set; }

	[field: SerializeField]
	public float ClicksRequiredMultiplier { get; private set; }

	[field: SerializeField]
	public float CritClickChance { get; private set; }

	[field: SerializeField]
	public float CritClickMultiplier { get; private set; }

	[field: SerializeField]
	public int PassiveClicks { get; private set; }

	[field: SerializeField]
	public int PassiveClickStrength { get; private set; }

	[field: SerializeField]
	public float PassiveClickSpeed { get; private set; }

	[field: SerializeField]
	public float RareFishChanceBonus { get; private set; }

	[field: SerializeField]
	public float RareFishChanceMultiplier { get; private set; }

	[field: SerializeField]
	public float FishValueMultiplier { get; private set; }

	[field: SerializeField]
	public float PondUnlockCostMultiplier { get; private set; } = 1f;

	[field: SerializeField]
	public float SkillCostMultiplier { get; private set; }

	[field: SerializeField]
	public float AutoHookChance { get; private set; }

	[field: SerializeField]
	public float DoubleCatchChance { get; private set; }

	[field: SerializeField]
	public float TripleCatchChance { get; private set; }

	[field: SerializeField]
	public float AllCostsMultiplier { get; private set; } = 1f;

	[field: SerializeField]
	public float FishValueZoneSynergyBonus { get; private set; }

	[field: SerializeField]
	public float RareChanceZoneSynergyBonus { get; private set; }

	public float FishCatchExperienceAdditive { get; private set; }

	public float FishCatchExperienceMultiplier { get; private set; } = 1f;

	public float PondExperienceAdditive { get; private set; }

	public float PondExperienceMultiplier { get; private set; } = 1f;

	public float ExperienceGainMultiplier { get; private set; } = 1f;

	public float FasterCatchingBonus { get; private set; }

	public float PerfectCatchTimeWindow { get; private set; }

	public float PerfectStartProgressBonus { get; private set; }

	public float SponsorShipBonus { get; private set; }

	public float SponsorshipAdditive { get; private set; }

	public float SponsorshipMultiplier { get; private set; } = 1f;

	public float PassiveIncomeAdditive { get; private set; }

	public float PassiveIncomeMultiplier { get; private set; } = 1f;

	public float ReelInTimeLimit { get; private set; }

	public float HoldClickRate { get; private set; }

	public float TimePerCrit { get; private set; }

	public float MaxReelInDuration { get; private set; }

	public float PerfectCatchTimeRefund { get; private set; }

	public float TrackerPulseSpeedBonus { get; private set; }

	[Header("Unlocked Unique Skills")]
	public bool IsFrenzyModeEnabled { get; private set; }

	public bool IsHoldToReelEnabled { get; private set; }

	public int FishTrackerTier { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		allFish = FishLogManager.Instance.allFish;
		allZones = GameManager.Instance.allZones;
		RecalculateAllStats();
	}

	public void RecalculateAllStats()
	{
		ResetStatsToDefault();
		if (SkillManager.Instance == null || SkillManager.Instance.allSkills == null)
		{
			return;
		}
		Dictionary<SkillBonusType, float> dictionary = new Dictionary<SkillBonusType, float>();
		Dictionary<SkillBonusType, float> dictionary2 = new Dictionary<SkillBonusType, float>();
		foreach (Skill value in SkillManager.Instance.allSkills.Values)
		{
			int skillLevel = SkillManager.Instance.GetSkillLevel(value.ID);
			if (skillLevel <= 0)
			{
				continue;
			}
			if (value.bonusType == SkillBonusType.add_bobber_synergy)
			{
				if (!dictionary.ContainsKey(SkillBonusType.add_auto_hook_chance))
				{
					dictionary[SkillBonusType.add_auto_hook_chance] = 0f;
				}
				dictionary[SkillBonusType.add_auto_hook_chance] += value.bonusValue * (float)skillLevel;
				if (!dictionary.ContainsKey(SkillBonusType.add_double_catch_chance))
				{
					dictionary[SkillBonusType.add_double_catch_chance] = 0f;
				}
				dictionary[SkillBonusType.add_double_catch_chance] += value.bonusValue * (float)skillLevel;
			}
			else if (value.bonusType.ToString().StartsWith("add_"))
			{
				if (!dictionary.ContainsKey(value.bonusType))
				{
					dictionary[value.bonusType] = 0f;
				}
				dictionary[value.bonusType] += value.bonusValue * (float)skillLevel;
			}
			else if (value.bonusType.ToString().StartsWith("mult_"))
			{
				if (!dictionary2.ContainsKey(value.bonusType))
				{
					dictionary2[value.bonusType] = 1f;
				}
				float num = value.bonusValue;
				bool flag = value.bonusType == SkillBonusType.mult_clicks_required || value.bonusType == SkillBonusType.mult_skill_cost || value.bonusType == SkillBonusType.mult_pond_unlock_cost || value.bonusType == SkillBonusType.mult_all_costs;
				if (num >= 1f || flag)
				{
					num -= 1f;
				}
				dictionary2[value.bonusType] += num * (float)skillLevel;
			}
			else if (value.bonusType.ToString().StartsWith("enable_"))
			{
				if (!dictionary.ContainsKey(value.bonusType))
				{
					dictionary[value.bonusType] = 0f;
				}
				dictionary[value.bonusType] = 1f;
				ApplyEnableBonus(value);
			}
		}
		if (AchievementManager.Instance != null && AchievementManager.Instance.allAchievements != null)
		{
			foreach (Achievement allAchievement in AchievementManager.Instance.allAchievements)
			{
				if (!AchievementManager.Instance.IsAchievementClaimed(allAchievement.ID) || allAchievement.rewardBonusType == SkillBonusType.None)
				{
					continue;
				}
				if (allAchievement.rewardBonusType.ToString().StartsWith("add_"))
				{
					if (!dictionary.ContainsKey(allAchievement.rewardBonusType))
					{
						dictionary[allAchievement.rewardBonusType] = 0f;
					}
					dictionary[allAchievement.rewardBonusType] += allAchievement.rewardValue;
				}
				else if (allAchievement.rewardBonusType.ToString().StartsWith("mult_"))
				{
					if (!dictionary2.ContainsKey(allAchievement.rewardBonusType))
					{
						dictionary2[allAchievement.rewardBonusType] = 1f;
					}
					float num2 = allAchievement.rewardValue;
					bool flag2 = allAchievement.rewardBonusType == SkillBonusType.mult_clicks_required || allAchievement.rewardBonusType == SkillBonusType.mult_skill_cost || allAchievement.rewardBonusType == SkillBonusType.mult_pond_unlock_cost || allAchievement.rewardBonusType == SkillBonusType.mult_all_costs;
					if (num2 >= 1f || flag2)
					{
						num2 -= 1f;
					}
					dictionary2[allAchievement.rewardBonusType] += num2;
				}
				else if (allAchievement.rewardBonusType.ToString().StartsWith("enable_"))
				{
					if (!dictionary.ContainsKey(allAchievement.rewardBonusType))
					{
						dictionary[allAchievement.rewardBonusType] = 0f;
					}
					dictionary[allAchievement.rewardBonusType] = 1f;
				}
			}
		}
		foreach (SkillBonusType item in new List<SkillBonusType>(dictionary2.Keys))
		{
			if (dictionary2[item] < 0.1f)
			{
				dictionary2[item] = 0.1f;
			}
		}
		CalculateFinalStats(dictionary, dictionary2);
	}

	private void CalculateFinalStats(Dictionary<SkillBonusType, float> additives, Dictionary<SkillBonusType, float> multiplicatives)
	{
		float num = (float)baseReelInClickPower + additives.GetValueOrDefault(SkillBonusType.add_click_power);
		ClickPowerMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_click_power, 1f);
		if (ClickPowerMultiplier < 0.1f)
		{
			ClickPowerMultiplier = 0.1f;
		}
		ReelInClickPower = num * ClickPowerMultiplier;
		ReactionTime = baseReactionTime + additives.GetValueOrDefault(SkillBonusType.add_reaction_time);
		ClicksRequiredMultiplier = baseClicksRequiredMultiplier * multiplicatives.GetValueOrDefault(SkillBonusType.mult_clicks_required, 1f);
		CritClickChance = baseCritClickChance + (float)(int)additives.GetValueOrDefault(SkillBonusType.add_crit_click_chance);
		CritClickMultiplier = baseCritClickMultiplier + additives.GetValueOrDefault(SkillBonusType.add_crit_click_mult);
		PassiveClicks = Mathf.Max(0, basePassiveClicks + (int)additives.GetValueOrDefault(SkillBonusType.add_passive_clicks));
		PassiveClickStrength = Mathf.Max(1, basePassiveClickStrength + (int)additives.GetValueOrDefault(SkillBonusType.add_passive_click_strength));
		PassiveClickStrength = Mathf.CeilToInt((float)PassiveClickStrength * multiplicatives.GetValueOrDefault(SkillBonusType.mult_passive_click_strength, 1f));
		PassiveClickSpeed = Mathf.Max(0.1f, basePassiveClickSpeed + additives.GetValueOrDefault(SkillBonusType.add_passive_click_speed));
		RareFishChanceBonus = baseRareFishChance + additives.GetValueOrDefault(SkillBonusType.add_rare_fish_chance);
		RareFishChanceMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_rare_fish_chance, 1f);
		AutoHookChance = baseAutoHookChance + additives.GetValueOrDefault(SkillBonusType.add_auto_hook_chance);
		DoubleCatchChance = additives.GetValueOrDefault(SkillBonusType.add_double_catch_chance);
		TripleCatchChance = additives.GetValueOrDefault(SkillBonusType.add_triple_catch_chance);
		FishValueMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_fish_value, 1f);
		FishValueZoneSynergyBonus = multiplicatives.GetValueOrDefault(SkillBonusType.mult_fish_value_based_on_zone_level, 1f) - 1f;
		RareChanceZoneSynergyBonus = multiplicatives.GetValueOrDefault(SkillBonusType.mult_rare_chance_based_on_zone_level, 1f) - 1f;
		AllCostsMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_all_costs, 1f);
		float valueOrDefault = multiplicatives.GetValueOrDefault(SkillBonusType.mult_pond_unlock_cost, 1f);
		float valueOrDefault2 = multiplicatives.GetValueOrDefault(SkillBonusType.mult_skill_cost, 1f);
		PondUnlockCostMultiplier = valueOrDefault * AllCostsMultiplier;
		SkillCostMultiplier = valueOrDefault2 * AllCostsMultiplier;
		FishCatchExperienceAdditive = additives.GetValueOrDefault(SkillBonusType.add_fish_catch_experience);
		FishCatchExperienceMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_fish_catch_experience, 1f);
		PondExperienceAdditive = additives.GetValueOrDefault(SkillBonusType.add_pond_experience);
		PondExperienceMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_pond_experience, 1f);
		ExperienceGainMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_experience_gain, 1f);
		FasterCatchingBonus = baseFasterCatching + additives.GetValueOrDefault(SkillBonusType.add_faster_catching);
		PerfectCatchTimeWindow = basePerfectCatchTime + additives.GetValueOrDefault(SkillBonusType.add_perfect_catch_time);
		PerfectStartProgressBonus = basePerfectStartProgress + additives.GetValueOrDefault(SkillBonusType.add_perfect_start_progress);
		SponsorshipAdditive = baseSponsorshipBonus + additives.GetValueOrDefault(SkillBonusType.add_sponsorship_bonus);
		SponsorshipMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_sponsorship_bonus, 1f);
		SponsorShipBonus = SponsorshipAdditive * SponsorshipMultiplier;
		PassiveIncomeAdditive = basePassiveIncomeAdditive + additives.GetValueOrDefault(SkillBonusType.add_passive_income);
		PassiveIncomeMultiplier = multiplicatives.GetValueOrDefault(SkillBonusType.mult_passive_income, 1f);
		float num2 = additives.GetValueOrDefault(SkillBonusType.add_clicking_time) + additives.GetValueOrDefault(SkillBonusType.add_catch_time);
		ReelInTimeLimit = baseReelInTimeLimit + num2;
		HoldClickRate = baseHoldClickRate + additives.GetValueOrDefault(SkillBonusType.add_hold_click_rate);
		TimePerCrit = baseTimePerCrit + additives.GetValueOrDefault(SkillBonusType.add_time_per_crit);
		MaxReelInDuration = baseMaxReelInDuration + num2;
		PerfectCatchTimeRefund = additives.GetValueOrDefault(SkillBonusType.add_time_refund_on_perfect_catch);
		TrackerPulseSpeedBonus = baseTrackerPulseSpeed + additives.GetValueOrDefault(SkillBonusType.add_tracker_pulse_speed);
		int num3 = baseFishTrackerTier + (int)additives.GetValueOrDefault(SkillBonusType.add_fish_tracker_tier);
		if (additives.ContainsKey(SkillBonusType.enable_tracker_tier2) || additives.GetValueOrDefault(SkillBonusType.enable_tracker_tier2) > 0f)
		{
			num3 = Mathf.Max(num3, 2);
		}
		if (additives.ContainsKey(SkillBonusType.enable_tracker_tier3) || additives.GetValueOrDefault(SkillBonusType.enable_tracker_tier3) > 0f)
		{
			num3 = Mathf.Max(num3, 3);
		}
		FishTrackerTier = num3;
		Debug.Log($"[PlayerStats] FishTrackerTier calculated: {FishTrackerTier} (Add: {additives.GetValueOrDefault(SkillBonusType.add_fish_tracker_tier)}, T2 Enable: {additives.GetValueOrDefault(SkillBonusType.enable_tracker_tier2)}, T3 Enable: {additives.GetValueOrDefault(SkillBonusType.enable_tracker_tier3)})");
	}

	private void ApplyEnableBonus(Skill skill)
	{
		SkillBonusType bonusType = skill.bonusType;
		if (bonusType <= SkillBonusType.enable_tracker_tier2)
		{
			if (bonusType != SkillBonusType.enable_frenzy_mode)
			{
				_ = 40;
			}
			else
			{
				IsFrenzyModeEnabled = true;
			}
		}
		else if (bonusType != SkillBonusType.enable_tracker_tier3 && bonusType == SkillBonusType.enable_hold_to_reel)
		{
			IsHoldToReelEnabled = true;
		}
	}

	private void ResetStatsToDefault()
	{
		MaxEnergy = baseMaxEnergy;
		ClickPowerMultiplier = 1f;
		EnergyCostPerCast = baseEnergyCostPerCast;
		ReelInClickPower = baseReelInClickPower;
		ClicksRequiredMultiplier = baseClicksRequiredMultiplier;
		ReactionTime = baseReactionTime;
		CritClickChance = baseCritClickChance;
		CritClickMultiplier = baseCritClickMultiplier;
		PassiveClicks = basePassiveClicks;
		PassiveClickStrength = basePassiveClickStrength;
		PassiveClickSpeed = basePassiveClickSpeed;
		RareFishChanceBonus = baseRareFishChance;
		RareFishChanceMultiplier = 1f;
		AutoHookChance = baseAutoHookChance;
		FishValueMultiplier = 1f;
		FishValueZoneSynergyBonus = 0f;
		RareChanceZoneSynergyBonus = 0f;
		PondUnlockCostMultiplier = 1f;
		SkillCostMultiplier = 1f;
		AllCostsMultiplier = 1f;
		DoubleCatchChance = 0f;
		TripleCatchChance = 0f;
		FishCatchExperienceAdditive = 0f;
		FishCatchExperienceMultiplier = 1f;
		PondExperienceAdditive = 0f;
		PondExperienceMultiplier = 1f;
		ExperienceGainMultiplier = 1f;
		FasterCatchingBonus = baseFasterCatching;
		PerfectCatchTimeWindow = basePerfectCatchTime;
		PerfectStartProgressBonus = basePerfectStartProgress;
		SponsorShipBonus = baseSponsorshipBonus;
		PassiveIncomeAdditive = basePassiveIncomeAdditive;
		PassiveIncomeMultiplier = basePassiveIncomeMultiplier;
		ReelInTimeLimit = baseReelInTimeLimit;
		HoldClickRate = baseHoldClickRate;
		TimePerCrit = baseTimePerCrit;
		MaxReelInDuration = baseMaxReelInDuration;
		PerfectCatchTimeRefund = 0f;
		FishTrackerTier = baseFishTrackerTier;
		TrackerPulseSpeedBonus = baseTrackerPulseSpeed;
		IsFrenzyModeEnabled = false;
		IsHoldToReelEnabled = false;
	}

	public void WipeAllFishProgress()
	{
		if (allFish == null || allFish.Count == 0)
		{
			Debug.LogError("'All Fish' list is not assigned in the DebugTools Inspector!");
			return;
		}
		foreach (Fish item in allFish)
		{
			PlayerPrefs.DeleteKey("FishLevel_" + item.speciesName);
			PlayerPrefs.DeleteKey("FishXP_" + item.speciesName);
			foreach (RarityData availableRarity in item.availableRarities)
			{
				string text = item.speciesName + "_" + availableRarity.rarity;
				PlayerPrefs.DeleteKey("FishLog_" + text);
			}
			item.currentLevel = 1;
			item.currentXp = 0;
		}
		PlayerPrefs.Save();
		Debug.Log("<color=orange>WIPED ALL FISH PROGRESS:</color> Levels, XP, and catch logs have been reset.");
	}

	public void WipeAllZoneProgress()
	{
		if (allZones == null || allZones.Count == 0)
		{
			Debug.LogError("'All Zones' list is not assigned in the DebugTools Inspector!");
			return;
		}
		foreach (ZoneData allZone in allZones)
		{
			PlayerPrefs.DeleteKey(allZone.zoneName + "_unlocked");
			PlayerPrefs.DeleteKey("Zone_" + allZone.zoneName + "_Level");
			PlayerPrefs.DeleteKey("Zone_" + allZone.zoneName + "_XP");
			allZone.isUnlocked = allZone.unlockCost == 0.0;
			allZone.currentLevel = 1;
			allZone.currentXp = 0;
		}
		PlayerPrefs.Save();
		Debug.Log("<color=orange>WIPED ALL ZONE PROGRESS:</color> Unlocks, levels, and XP have been reset.");
	}

	public float GetFishValueZoneSynergyMultiplier(int zoneLevel)
	{
		return debugCurrentZoneSynergyMult = 1f + FishValueZoneSynergyBonus * (float)zoneLevel;
	}

	public float GetRareChanceZoneSynergyMultiplier(int zoneLevel)
	{
		return 1f + RareChanceZoneSynergyBonus * (float)zoneLevel;
	}

	[ContextMenu("Debug: Log Value Breakdown (100G Base)")]
	public void DebugLogValueBreakdown()
	{
		float num = 100f;
		int num2 = ((!(GameManager.Instance.currentZone != null)) ? 1 : GameManager.Instance.currentZone.currentLevel);
		float fishValueZoneSynergyMultiplier = GetFishValueZoneSynergyMultiplier(num2);
		float rareChanceZoneSynergyMultiplier = GetRareChanceZoneSynergyMultiplier(num2);
		float f = num * FishValueMultiplier * fishValueZoneSynergyMultiplier;
		Debug.Log("<color=cyan>[Value Breakdown for 100G Fish]</color>\n" + $"- Base Value: {num}G\n" + $"- Skill Multiplier: x{FishValueMultiplier}\n" + $"- Zone Synergy: x{fishValueZoneSynergyMultiplier} (at Zone Lvl {num2}, {FishValueZoneSynergyBonus * 100f}% per Lvl)\n" + $"- Rarity Synergy: x{rareChanceZoneSynergyMultiplier} (at Zone Lvl {num2}, {RareChanceZoneSynergyBonus * 100f}% per Lvl)\n" + $"<color=yellow><b>- Final Value: {Mathf.RoundToInt(f)}G</b></color>");
	}
}
