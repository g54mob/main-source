using System;
using UnityEngine;

public class ExperienceEffectsDebugger : MonoBehaviour
{
	[Header("Debug Tools")]
	public bool debugOnStart = true;

	[Header("Test Skill Creation")]
	public SkillBonusType testEffectType = SkillBonusType.add_fish_catch_experience;

	public float testBonusValue = 50f;

	private void Start()
	{
		if (debugOnStart)
		{
			DebugExperienceEffectsImplementation();
		}
	}

	[ContextMenu("Debug Experience Effects Implementation")]
	public void DebugExperienceEffectsImplementation()
	{
		Debug.Log("=== EXPERIENCE EFFECTS DEBUG ===");
		Debug.Log("Step 1: Checking enum values...");
		CheckEnumValues();
		Debug.Log("Step 2: Checking SkillManager...");
		CheckSkillManager();
		Debug.Log("Step 3: Checking PlayerStats...");
		CheckPlayerStats();
		Debug.Log("Step 4: Testing experience calculations...");
		TestExperienceCalculations();
		Debug.Log("=== DEBUG COMPLETE ===");
	}

	private void CheckEnumValues()
	{
		try
		{
			SkillBonusType[] obj = new SkillBonusType[5]
			{
				SkillBonusType.add_fish_catch_experience,
				SkillBonusType.mult_fish_catch_experience,
				SkillBonusType.add_pond_experience,
				SkillBonusType.mult_pond_experience,
				SkillBonusType.mult_experience_gain
			};
			Debug.Log("✓ All experience effect enum values are available:");
			SkillBonusType[] array = obj;
			foreach (SkillBonusType skillBonusType in array)
			{
				Debug.Log($"  - {skillBonusType} (value: {(int)skillBonusType})");
			}
		}
		catch (Exception ex)
		{
			Debug.LogError("✗ Enum values not available: " + ex.Message);
		}
	}

	private void CheckSkillManager()
	{
		if (SkillManager.Instance == null)
		{
			Debug.LogWarning("⚠ SkillManager.Instance is null - may be normal in edit mode");
			return;
		}
		Debug.Log($"✓ SkillManager found with {SkillManager.Instance.allSkills.Count} skills loaded");
		int num = 0;
		foreach (Skill value in SkillManager.Instance.allSkills.Values)
		{
			if (IsExperienceEffect(value.bonusType))
			{
				num++;
				Debug.Log($"  Found experience skill: {value.ID} ({value.bonusType} = {value.bonusValue})");
			}
		}
		if (num == 0)
		{
			Debug.LogWarning("⚠ No skills found with experience effects. You need to create skills with the new bonus types.");
			Debug.Log("To create skills with experience effects:");
			Debug.Log("1. Create new Skill ScriptableObjects in Resources/Skills/");
			Debug.Log("2. Set bonusType to one of: add_fish_catch_experience, mult_fish_catch_experience, etc.");
			Debug.Log("3. Set bonusValue appropriately (additive values or multiplier values)");
		}
		else
		{
			Debug.Log($"✓ Found {num} skills with experience effects");
		}
	}

	private void CheckPlayerStats()
	{
		if (PlayerStats.Instance == null)
		{
			Debug.LogWarning("⚠ PlayerStats.Instance is null - may be normal in edit mode");
			return;
		}
		Debug.Log("✓ PlayerStats found. Current experience multipliers:");
		Debug.Log($"  - FishCatchExperienceAdditive: {PlayerStats.Instance.FishCatchExperienceAdditive}");
		Debug.Log($"  - FishCatchExperienceMultiplier: {PlayerStats.Instance.FishCatchExperienceMultiplier}");
		Debug.Log($"  - PondExperienceAdditive: {PlayerStats.Instance.PondExperienceAdditive}");
		Debug.Log($"  - PondExperienceMultiplier: {PlayerStats.Instance.PondExperienceMultiplier}");
		Debug.Log($"  - ExperienceGainMultiplier: {PlayerStats.Instance.ExperienceGainMultiplier}");
		PlayerStats.Instance.RecalculateAllStats();
		Debug.Log("✓ Forced PlayerStats recalculation");
	}

	private void TestExperienceCalculations()
	{
		int num = 100;
		float num2 = CalculateFishExperience(num);
		Debug.Log($"Fish XP test: {num} base → {num2} final");
		int num3 = 500;
		float num4 = CalculatePondExperience(num3);
		Debug.Log($"Pond XP test: {num3} base → {num4} final");
		if (num2 != (float)num || num4 != (float)num3)
		{
			Debug.Log("✓ Experience multipliers are being applied");
		}
		else
		{
			Debug.Log("ℹ No experience multipliers currently active (all values = 1.0 or 0)");
		}
	}

	private float CalculateFishExperience(int baseXP)
	{
		if (PlayerStats.Instance == null)
		{
			return baseXP;
		}
		return ((float)baseXP + PlayerStats.Instance.FishCatchExperienceAdditive) * PlayerStats.Instance.FishCatchExperienceMultiplier * PlayerStats.Instance.ExperienceGainMultiplier;
	}

	private float CalculatePondExperience(int baseXP)
	{
		if (PlayerStats.Instance == null)
		{
			return baseXP;
		}
		return ((float)baseXP + PlayerStats.Instance.PondExperienceAdditive) * PlayerStats.Instance.PondExperienceMultiplier * PlayerStats.Instance.ExperienceGainMultiplier;
	}

	private bool IsExperienceEffect(SkillBonusType bonusType)
	{
		if (bonusType != SkillBonusType.add_fish_catch_experience && bonusType != SkillBonusType.mult_fish_catch_experience && bonusType != SkillBonusType.add_pond_experience && bonusType != SkillBonusType.mult_pond_experience)
		{
			return bonusType == SkillBonusType.mult_experience_gain;
		}
		return true;
	}

	[ContextMenu("Create Test Experience Skill")]
	public void CreateTestExperienceSkill()
	{
		if (SkillManager.Instance == null)
		{
			Debug.LogError("SkillManager.Instance is null - cannot create test skill");
			return;
		}
		Skill skill = ScriptableObject.CreateInstance<Skill>();
		skill.ID = "TEST_EXPERIENCE_SKILL";
		skill.skillName = "Test Experience Skill";
		skill.description = "Temporary test skill for debugging";
		skill.bonusType = testEffectType;
		skill.bonusValue = testBonusValue;
		skill.MaxLevel = 5;
		skill.CostFormula = "100";
		if (!SkillManager.Instance.allSkills.ContainsKey(skill.ID))
		{
			SkillManager.Instance.allSkills.Add(skill.ID, skill);
			SkillManager.Instance.skillLevels.Add(skill.ID, 0);
			Debug.Log($"✓ Created test skill: {skill.ID} ({skill.bonusType} = {skill.bonusValue})");
			SkillManager.Instance.LevelUpSkill(skill.ID);
			Debug.Log($"✓ Leveled up test skill to level {SkillManager.Instance.GetSkillLevel(skill.ID)}");
			if (PlayerStats.Instance != null)
			{
				PlayerStats.Instance.RecalculateAllStats();
				Debug.Log("✓ Recalculated PlayerStats with test skill");
				CheckPlayerStats();
			}
		}
		else
		{
			Debug.LogWarning("Test skill already exists");
		}
	}

	[ContextMenu("Remove Test Experience Skill")]
	public void RemoveTestExperienceSkill()
	{
		if (SkillManager.Instance == null)
		{
			return;
		}
		string key = "TEST_EXPERIENCE_SKILL";
		if (SkillManager.Instance.allSkills.ContainsKey(key))
		{
			SkillManager.Instance.allSkills.Remove(key);
			SkillManager.Instance.skillLevels.Remove(key);
			if (PlayerStats.Instance != null)
			{
				PlayerStats.Instance.RecalculateAllStats();
			}
			Debug.Log("✓ Removed test skill and recalculated stats");
		}
	}
}
