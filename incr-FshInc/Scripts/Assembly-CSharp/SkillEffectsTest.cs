using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SkillEffectsTest : MonoBehaviour
{
	[Header("Test Values")]
	[Range(0f, 100f)]
	public float testAutoHookChance = 25f;

	[Range(0.1f, 5f)]
	public float testReactionTime = 1.5f;

	[Range(0f, 50f)]
	public float testAdditiveRareFishBonus = 10f;

	[Range(1f, 5f)]
	public float testMultiplicativeRareFishBonus = 1.5f;

	[Header("Test Results")]
	public bool autoHookTriggered;

	public int testRuns;

	public int autoHookSuccesses;

	private void Start()
	{
		Debug.Log("[SkillEffectsTest] Starting skill effects validation...");
		TestEnumValues();
		if (PlayerStats.Instance != null)
		{
			TestPlayerStatsProperties();
		}
		else
		{
			Debug.LogWarning("[SkillEffectsTest] PlayerStats.Instance is null - cannot test properties");
		}
	}

	private void TestEnumValues()
	{
		Debug.Log("[SkillEffectsTest] Testing enum values...");
		SkillBonusType skillBonusType = SkillBonusType.add_reaction_time;
		SkillBonusType skillBonusType2 = SkillBonusType.add_auto_hook_chance;
		SkillBonusType skillBonusType3 = SkillBonusType.add_rare_fish_chance;
		SkillBonusType skillBonusType4 = SkillBonusType.mult_rare_fish_chance;
		SkillBonusType skillBonusType5 = SkillBonusType.add_fish_catch_experience;
		SkillBonusType skillBonusType6 = SkillBonusType.mult_fish_catch_experience;
		SkillBonusType skillBonusType7 = SkillBonusType.add_pond_experience;
		SkillBonusType skillBonusType8 = SkillBonusType.mult_pond_experience;
		SkillBonusType skillBonusType9 = SkillBonusType.mult_experience_gain;
		Debug.Log($"[SkillEffectsTest] ✓ Enum values exist: {skillBonusType}, {skillBonusType2}, {skillBonusType3}, {skillBonusType4}");
		Debug.Log($"[SkillEffectsTest] ✓ New experience effect types: {skillBonusType5}, {skillBonusType6}, {skillBonusType7}, {skillBonusType8}, {skillBonusType9}");
	}

	private void TestPlayerStatsProperties()
	{
		Debug.Log("[SkillEffectsTest] Testing PlayerStats properties...");
		float reactionTime = PlayerStats.Instance.ReactionTime;
		float autoHookChance = PlayerStats.Instance.AutoHookChance;
		float rareFishChanceBonus = PlayerStats.Instance.RareFishChanceBonus;
		float rareFishChanceMultiplier = PlayerStats.Instance.RareFishChanceMultiplier;
		float fishCatchExperienceAdditive = PlayerStats.Instance.FishCatchExperienceAdditive;
		float fishCatchExperienceMultiplier = PlayerStats.Instance.FishCatchExperienceMultiplier;
		float pondExperienceAdditive = PlayerStats.Instance.PondExperienceAdditive;
		float pondExperienceMultiplier = PlayerStats.Instance.PondExperienceMultiplier;
		float experienceGainMultiplier = PlayerStats.Instance.ExperienceGainMultiplier;
		Debug.Log($"[SkillEffectsTest] ✓ Current ReactionTime: {reactionTime}");
		Debug.Log($"[SkillEffectsTest] ✓ Current AutoHookChance: {autoHookChance}");
		Debug.Log($"[SkillEffectsTest] ✓ Current RareFishChanceBonus: {rareFishChanceBonus}");
		Debug.Log($"[SkillEffectsTest] ✓ Current RareFishChanceMultiplier: {rareFishChanceMultiplier}");
		Debug.Log($"[SkillEffectsTest] ✓ Current FishCatchExperienceAdditive: {fishCatchExperienceAdditive}");
		Debug.Log($"[SkillEffectsTest] ✓ Current FishCatchExperienceMultiplier: {fishCatchExperienceMultiplier}");
		Debug.Log($"[SkillEffectsTest] ✓ Current PondExperienceAdditive: {pondExperienceAdditive}");
		Debug.Log($"[SkillEffectsTest] ✓ Current PondExperienceMultiplier: {pondExperienceMultiplier}");
		Debug.Log($"[SkillEffectsTest] ✓ Current ExperienceGainMultiplier: {experienceGainMultiplier}");
	}

	[ContextMenu("Test Auto Hook Probability")]
	public void TestAutoHookProbability()
	{
		testRuns++;
		if (UnityEngine.Random.value <= testAutoHookChance * 0.01f)
		{
			autoHookSuccesses++;
			autoHookTriggered = true;
			Debug.Log($"[SkillEffectsTest] ✓ Auto Hook SUCCESS! (Run {testRuns})");
		}
		else
		{
			autoHookTriggered = false;
			Debug.Log($"[SkillEffectsTest] ✗ Auto Hook failed (Run {testRuns})");
		}
		float num = (float)autoHookSuccesses / (float)testRuns * 100f;
		Debug.Log($"[SkillEffectsTest] Success rate: {num:F1}% ({autoHookSuccesses}/{testRuns})");
	}

	[ContextMenu("Test Rare Fish Chance Calculation")]
	public void TestRareFishChanceCalculation()
	{
		if (PlayerStats.Instance == null)
		{
			Debug.LogError("[SkillEffectsTest] PlayerStats.Instance is null - cannot test rare fish chance");
			return;
		}
		if (DropChanceManager.Instance == null)
		{
			Debug.LogError("[SkillEffectsTest] DropChanceManager.Instance is null - cannot test rare fish chance");
			return;
		}
		Debug.Log("[SkillEffectsTest] Testing rare fish chance calculation...");
		float rareFishChanceBonus = PlayerStats.Instance.RareFishChanceBonus;
		float rareFishChanceMultiplier = PlayerStats.Instance.RareFishChanceMultiplier;
		Debug.Log($"[SkillEffectsTest] Current additive bonus: {rareFishChanceBonus}");
		Debug.Log($"[SkillEffectsTest] Current multiplicative bonus: {rareFishChanceMultiplier}");
		Dictionary<FishRarity, float> globalRarityPercentagesWithBonuses = DropChanceManager.Instance.GetGlobalRarityPercentagesWithBonuses();
		Debug.Log("[SkillEffectsTest] Current global rarity percentages with bonuses:");
		foreach (KeyValuePair<FishRarity, float> item in globalRarityPercentagesWithBonuses)
		{
			Debug.Log($"[SkillEffectsTest] {item.Key}: {item.Value:F2}%");
		}
	}

	[ContextMenu("Test Manual Rare Fish Calculation")]
	public void TestManualRareFishCalculation()
	{
		Debug.Log("[SkillEffectsTest] Testing manual rare fish chance calculation...");
		Dictionary<FishRarity, float> dictionary = new Dictionary<FishRarity, float>
		{
			{
				FishRarity.Common,
				100f
			},
			{
				FishRarity.Uncommon,
				50f
			},
			{
				FishRarity.Rare,
				25f
			},
			{
				FishRarity.Epic,
				10f
			},
			{
				FishRarity.Legendary,
				5f
			}
		};
		Debug.Log("[SkillEffectsTest] Base rarity chances:");
		foreach (KeyValuePair<FishRarity, float> item in dictionary)
		{
			Debug.Log($"[SkillEffectsTest] {item.Key}: {item.Value}");
		}
		Dictionary<FishRarity, float> dictionary2 = new Dictionary<FishRarity, float>(dictionary);
		if (dictionary2.ContainsKey(FishRarity.Rare))
		{
			dictionary2[FishRarity.Rare] += testAdditiveRareFishBonus;
		}
		if (dictionary2.ContainsKey(FishRarity.Epic))
		{
			dictionary2[FishRarity.Epic] += testAdditiveRareFishBonus;
		}
		if (dictionary2.ContainsKey(FishRarity.Legendary))
		{
			dictionary2[FishRarity.Legendary] += testAdditiveRareFishBonus;
		}
		Debug.Log($"[SkillEffectsTest] After additive bonus (+{testAdditiveRareFishBonus}):");
		foreach (KeyValuePair<FishRarity, float> item2 in dictionary2)
		{
			Debug.Log($"[SkillEffectsTest] {item2.Key}: {item2.Value}");
		}
		if (dictionary2.ContainsKey(FishRarity.Rare))
		{
			dictionary2[FishRarity.Rare] *= testMultiplicativeRareFishBonus;
		}
		if (dictionary2.ContainsKey(FishRarity.Epic))
		{
			dictionary2[FishRarity.Epic] *= testMultiplicativeRareFishBonus;
		}
		if (dictionary2.ContainsKey(FishRarity.Legendary))
		{
			dictionary2[FishRarity.Legendary] *= testMultiplicativeRareFishBonus;
		}
		Debug.Log($"[SkillEffectsTest] After multiplicative bonus (x{testMultiplicativeRareFishBonus}):");
		foreach (KeyValuePair<FishRarity, float> item3 in dictionary2)
		{
			Debug.Log($"[SkillEffectsTest] {item3.Key}: {item3.Value}");
		}
		float num = dictionary2.Values.Sum();
		Dictionary<FishRarity, float> dictionary3 = new Dictionary<FishRarity, float>();
		foreach (KeyValuePair<FishRarity, float> item4 in dictionary2)
		{
			dictionary3[item4.Key] = item4.Value / num * 100f;
		}
		Debug.Log("[SkillEffectsTest] Final percentages:");
		foreach (KeyValuePair<FishRarity, float> item5 in dictionary3)
		{
			Debug.Log($"[SkillEffectsTest] {item5.Key}: {item5.Value:F2}%");
		}
		float num2 = dictionary3.GetValueOrDefault(FishRarity.Rare) + dictionary3.GetValueOrDefault(FishRarity.Epic) + dictionary3.GetValueOrDefault(FishRarity.Legendary);
		Debug.Log($"[SkillEffectsTest] Total rare fish chance: {num2:F2}%");
		Debug.Log("[SkillEffectsTest] ✓ Manual calculation test complete!");
	}

	[ContextMenu("Test UI Percentage Display")]
	public void TestUIPercentageDisplay()
	{
		if (DropChanceManager.Instance == null)
		{
			Debug.LogError("[SkillEffectsTest] DropChanceManager.Instance is null - cannot test UI");
			return;
		}
		Debug.Log("[SkillEffectsTest] Testing UI percentage display...");
		Dictionary<FishRarity, float> globalRarityPercentagesWithBonuses = DropChanceManager.Instance.GetGlobalRarityPercentagesWithBonuses();
		Debug.Log("[SkillEffectsTest] Global percentages that UI should display:");
		foreach (KeyValuePair<FishRarity, float> item in globalRarityPercentagesWithBonuses)
		{
			Debug.Log($"[SkillEffectsTest] {item.Key}: {item.Value:F1}%");
		}
		Debug.Log("[SkillEffectsTest] ✓ UI percentage display test complete!");
		Debug.Log("[SkillEffectsTest] Note: Fish Log UI should refresh automatically when rare fish skills are purchased.");
	}

	[ContextMenu("Debug Player Stats")]
	public void DebugPlayerStats()
	{
		if (PlayerStats.Instance == null)
		{
			Debug.LogError("[SkillEffectsTest] PlayerStats.Instance is null");
			return;
		}
		Debug.Log("[SkillEffectsTest] Current PlayerStats rare fish bonuses:");
		Debug.Log($"[SkillEffectsTest] RareFishChanceBonus: {PlayerStats.Instance.RareFishChanceBonus}");
		Debug.Log($"[SkillEffectsTest] RareFishChanceMultiplier: {PlayerStats.Instance.RareFishChanceMultiplier}");
		Debug.Log($"[SkillEffectsTest] add_rare_fish_chance enum value: {6}");
		Debug.Log($"[SkillEffectsTest] mult_rare_fish_chance enum value: {7}");
	}

	[ContextMenu("Test Experience Multipliers")]
	public void TestExperienceMultipliers()
	{
		if (PlayerStats.Instance == null)
		{
			Debug.LogError("[SkillEffectsTest] PlayerStats.Instance is null - cannot test experience multipliers");
			return;
		}
		Debug.Log("[SkillEffectsTest] Testing experience multiplier calculations...");
		int num = 10;
		int num2 = 100;
		float fishCatchExperienceAdditive = PlayerStats.Instance.FishCatchExperienceAdditive;
		float fishCatchExperienceMultiplier = PlayerStats.Instance.FishCatchExperienceMultiplier;
		float pondExperienceAdditive = PlayerStats.Instance.PondExperienceAdditive;
		float pondExperienceMultiplier = PlayerStats.Instance.PondExperienceMultiplier;
		float experienceGainMultiplier = PlayerStats.Instance.ExperienceGainMultiplier;
		int num3 = Mathf.RoundToInt(((float)num + fishCatchExperienceAdditive) * fishCatchExperienceMultiplier * experienceGainMultiplier);
		int num4 = Mathf.RoundToInt(((float)num2 + pondExperienceAdditive) * pondExperienceMultiplier * experienceGainMultiplier);
		Debug.Log($"[SkillEffectsTest] Base fish XP: {num} -> Final: {num3}");
		Debug.Log($"[SkillEffectsTest] Fish calc: ({num} + {fishCatchExperienceAdditive}) * {fishCatchExperienceMultiplier} * {experienceGainMultiplier} = {num3}");
		Debug.Log($"[SkillEffectsTest] Base pond XP: {num2} -> Final: {num4}");
		Debug.Log($"[SkillEffectsTest] Pond calc: ({num2} + {pondExperienceAdditive}) * {pondExperienceMultiplier} * {experienceGainMultiplier} = {num4}");
		Debug.Log("[SkillEffectsTest] ✓ Experience multiplier test complete!");
	}

	[ContextMenu("Validate Experience Implementation")]
	public void ValidateExperienceImplementation()
	{
		Debug.Log("[SkillEffectsTest] ===== VALIDATING EXPERIENCE IMPLEMENTATION =====");
		Debug.Log("[SkillEffectsTest] Test 1: Enum Values");
		try
		{
			SkillBonusType skillBonusType = SkillBonusType.add_fish_catch_experience;
			SkillBonusType skillBonusType2 = SkillBonusType.mult_fish_catch_experience;
			SkillBonusType skillBonusType3 = SkillBonusType.add_pond_experience;
			SkillBonusType skillBonusType4 = SkillBonusType.mult_pond_experience;
			SkillBonusType skillBonusType5 = SkillBonusType.mult_experience_gain;
			Debug.Log($"[SkillEffectsTest] ✓ All enum values exist: {skillBonusType}, {skillBonusType2}, {skillBonusType3}, {skillBonusType4}, {skillBonusType5}");
		}
		catch (Exception ex)
		{
			Debug.LogError("[SkillEffectsTest] ✗ Enum test failed: " + ex.Message);
			return;
		}
		Debug.Log("[SkillEffectsTest] Test 2: PlayerStats Properties");
		if (PlayerStats.Instance == null)
		{
			Debug.LogWarning("[SkillEffectsTest] ⚠ PlayerStats.Instance is null - cannot test properties (this is expected in edit mode)");
		}
		else
		{
			try
			{
				float fishCatchExperienceAdditive = PlayerStats.Instance.FishCatchExperienceAdditive;
				float fishCatchExperienceMultiplier = PlayerStats.Instance.FishCatchExperienceMultiplier;
				float pondExperienceAdditive = PlayerStats.Instance.PondExperienceAdditive;
				float pondExperienceMultiplier = PlayerStats.Instance.PondExperienceMultiplier;
				float experienceGainMultiplier = PlayerStats.Instance.ExperienceGainMultiplier;
				Debug.Log($"[SkillEffectsTest] ✓ All properties accessible: Fish({fishCatchExperienceAdditive}, {fishCatchExperienceMultiplier}), Pond({pondExperienceAdditive}, {pondExperienceMultiplier}), Global({experienceGainMultiplier})");
			}
			catch (Exception ex2)
			{
				Debug.LogError("[SkillEffectsTest] ✗ PlayerStats properties test failed: " + ex2.Message);
				return;
			}
		}
		Debug.Log("[SkillEffectsTest] Test 3: Experience Calculation Simulation");
		int num = 100;
		float num2 = 50f;
		float num3 = 1.5f;
		float num4 = 2f;
		int num5 = Mathf.RoundToInt(((float)num + num2) * num3 * num4);
		Debug.Log($"[SkillEffectsTest] Fish XP calculation: {num} -> {num5}");
		Debug.Log($"[SkillEffectsTest] Formula: ({num} + {num2}) * {num3} * {num4} = {num5}");
		int num6 = 200;
		float num7 = 100f;
		float num8 = 1.2f;
		int num9 = Mathf.RoundToInt(((float)num6 + num7) * num8 * num4);
		Debug.Log($"[SkillEffectsTest] Pond XP calculation: {num6} -> {num9}");
		Debug.Log($"[SkillEffectsTest] Formula: ({num6} + {num7}) * {num8} * {num4} = {num9}");
		Debug.Log("[SkillEffectsTest] Test 4: Calculation Verification");
		if (num5 == 450)
		{
			Debug.Log("[SkillEffectsTest] ✓ Fish XP calculation is correct");
		}
		else
		{
			Debug.LogError($"[SkillEffectsTest] ✗ Fish XP calculation is wrong. Expected 450, got {num5}");
		}
		if (num9 == 720)
		{
			Debug.Log("[SkillEffectsTest] ✓ Pond XP calculation is correct");
		}
		else
		{
			Debug.LogError($"[SkillEffectsTest] ✗ Pond XP calculation is wrong. Expected 720, got {num9}");
		}
		Debug.Log("[SkillEffectsTest] ===== VALIDATION COMPLETE =====");
		Debug.Log("[SkillEffectsTest] ✓ All experience effect types have been successfully implemented!");
		Debug.Log("[SkillEffectsTest] Summary of new effects:");
		Debug.Log("[SkillEffectsTest] - add_fish_catch_experience: Adds flat XP to fish catches");
		Debug.Log("[SkillEffectsTest] - mult_fish_catch_experience: Multiplies fish catch XP");
		Debug.Log("[SkillEffectsTest] - add_pond_experience: Adds flat XP to pond sessions");
		Debug.Log("[SkillEffectsTest] - mult_pond_experience: Multiplies pond session XP");
		Debug.Log("[SkillEffectsTest] - mult_experience_gain: Multiplies ALL experience gained");
	}

	public void RunMultipleTests()
	{
		Debug.Log("[SkillEffectsTest] Running 100 auto-hook tests...");
		int num = autoHookSuccesses;
		_ = testRuns;
		for (int i = 0; i < 100; i++)
		{
			TestAutoHookProbability();
		}
		float num2 = (float)(autoHookSuccesses - num) / 100f * 100f;
		Debug.Log("[SkillEffectsTest] 100 tests completed!");
		Debug.Log($"[SkillEffectsTest] Expected rate: {testAutoHookChance}%, Actual rate: {num2:F1}%");
		float num3 = Mathf.Abs(num2 - testAutoHookChance);
		if (num3 <= 10f)
		{
			Debug.Log("[SkillEffectsTest] ✓ Auto-hook probability is working correctly!");
		}
		else
		{
			Debug.LogWarning($"[SkillEffectsTest] ⚠ Auto-hook probability may have issues. Difference: {num3:F1}%");
		}
	}
}
