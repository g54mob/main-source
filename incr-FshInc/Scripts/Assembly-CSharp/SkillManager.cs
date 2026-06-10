using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
	public Dictionary<string, Skill> allSkills = new Dictionary<string, Skill>();

	public Dictionary<string, int> skillLevels = new Dictionary<string, int>();

	private const string SAVE_KEY_PREFIX = "SkillLevel_";

	private const string TotalSkillsKey = "TotalSkillsPurchased";

	public static SkillManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
			return;
		}
		Instance = this;
		UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
		LoadAllSkillsFromResources();
		LoadSkillData();
	}

	private void OnApplicationQuit()
	{
		SaveSkillData();
	}

	private void LoadAllSkillsFromResources()
	{
		allSkills.Clear();
		Skill[] array = Resources.LoadAll<Skill>("Skills");
		foreach (Skill skill in array)
		{
			if (string.IsNullOrEmpty(skill.ID))
			{
				Debug.LogWarning("Found a Skill asset with a missing ID: " + skill.name + ". It will not be loaded.", skill);
			}
			else if (!allSkills.ContainsKey(skill.ID))
			{
				allSkills.Add(skill.ID, skill);
			}
		}
	}

	public void LevelUpSkill(string skillID)
	{
		if (skillLevels.ContainsKey(skillID))
		{
			skillLevels[skillID]++;
		}
		else
		{
			skillLevels.Add(skillID, 1);
			Debug.LogWarning("Skill '" + skillID + "' was not found in the levels dictionary. Initializing it to level 1.");
		}
		AchievementManager.Instance?.NotifySkillUnlocked();
	}

	public int GetSkillLevel(string skillID)
	{
		if (string.IsNullOrEmpty(skillID))
		{
			return 0;
		}
		if (!skillLevels.ContainsKey(skillID))
		{
			return 0;
		}
		return skillLevels[skillID];
	}

	public bool IsSkillUnlocked(string skillID)
	{
		return GetSkillLevel(skillID) > 0;
	}

	public bool ArePrerequisitesMet(Skill skill)
	{
		if (skill.prerequisites == null)
		{
			return true;
		}
		foreach (Skill prerequisite in skill.prerequisites)
		{
			int num = Mathf.Min(skill.requiredPrerequisiteLevel, prerequisite.MaxLevel);
			if (GetSkillLevel(prerequisite.ID) < num)
			{
				return false;
			}
		}
		return true;
	}

	public int GetTotalSkillsPurchased()
	{
		if (skillLevels == null || skillLevels.Count == 0)
		{
			return 0;
		}
		return skillLevels.Values.Sum();
	}

	public double CalculateUpgradeCost(Skill skill)
	{
		int skillLevel = GetSkillLevel(skill.ID);
		if (skillLevel >= skill.MaxLevel)
		{
			return double.MaxValue;
		}
		int num = skillLevel + 1;
		string costFormula = skill.CostFormula;
		double num2 = 0.0;
		if (string.IsNullOrEmpty(costFormula))
		{
			return 0.0;
		}
		try
		{
			costFormula = costFormula.Replace("level", num.ToString(CultureInfo.InvariantCulture));
			string pattern = "(\\d*\\.?\\d+)\\s*\\^\\s*(\\d*\\.?\\d+)";
			Match match = Regex.Match(costFormula, pattern);
			while (match.Success)
			{
				double x = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
				double y = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
				double num3 = Math.Pow(x, y);
				costFormula = costFormula.Replace(match.Value, num3.ToString(CultureInfo.InvariantCulture));
				match = Regex.Match(costFormula, pattern);
			}
			num2 = Convert.ToDouble(new DataTable().Compute(costFormula, ""));
		}
		catch
		{
			return double.MaxValue;
		}
		if (PlayerStats.Instance != null)
		{
			float num4 = Mathf.Clamp(PlayerStats.Instance.SkillCostMultiplier, 0.01f, 10f);
			num2 *= (double)num4;
		}
		return Math.Round(num2);
	}

	public void SaveSkillData()
	{
		foreach (KeyValuePair<string, int> skillLevel in skillLevels)
		{
			PlayerPrefs.SetInt("SkillLevel_" + skillLevel.Key, skillLevel.Value);
		}
		int value = skillLevels.Values.Sum();
		PlayerPrefs.SetInt("TotalSkillsPurchased", value);
		PlayerPrefs.Save();
	}

	public void LoadSkillData()
	{
		skillLevels.Clear();
		foreach (string key in allSkills.Keys)
		{
			skillLevels.Add(key, PlayerPrefs.GetInt("SkillLevel_" + key, 0));
		}
		if (PlayerStats.Instance != null)
		{
			PlayerStats.Instance.RecalculateAllStats();
		}
	}

	public void ResetSkillTree()
	{
		foreach (string item in new List<string>(skillLevels.Keys))
		{
			skillLevels[item] = 0;
		}
		SaveSkillData();
		if (PlayerStats.Instance != null)
		{
			PlayerStats.Instance.RecalculateAllStats();
		}
		SkillTreePanel skillTreePanel = UnityEngine.Object.FindObjectOfType<SkillTreePanel>();
		if (skillTreePanel != null)
		{
			skillTreePanel.UpdateTreeVisuals();
		}
		ZoneSelectionPanel zoneSelectionPanel = UnityEngine.Object.FindObjectOfType<ZoneSelectionPanel>();
		if (zoneSelectionPanel != null)
		{
			zoneSelectionPanel.RefreshUI();
		}
		FishLogPanel fishLogPanel = UnityEngine.Object.FindObjectOfType<FishLogPanel>();
		if (fishLogPanel != null)
		{
			fishLogPanel.RefreshUI();
		}
	}
}
