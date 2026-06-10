using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;

[CreateAssetMenu(fileName = "New Skill", menuName = "Game/Skill")]
public class Skill : ScriptableObject
{
	[Header("Static Data - From Google Sheets")]
	public string ID;

	public string skillName;

	[TextArea]
	public string description;

	public Sprite icon;

	public int MaxLevel = 1;

	public string CostFormula;

	public int tier;

	public int requiredPrerequisiteLevel = 1;

	public SkillBonusType bonusType;

	public float bonusValue;

	public List<Skill> prerequisites;

	public string LocalizedName
	{
		get
		{
			string key = "#ui.skill." + ID.ToLower().Replace(" ", "_") + ".title";
			StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
			if (stringTableEntry == null || string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
			{
				return skillName;
			}
			return stringTableEntry.GetLocalizedString();
		}
	}

	public string LocalizedDescription
	{
		get
		{
			string key = "#ui.skill." + ID.ToLower().Replace(" ", "_") + ".desc";
			StringTableEntry stringTableEntry = LocalizationSettings.StringDatabase.GetTable("Skills")?.GetEntry(key);
			if (stringTableEntry == null || string.IsNullOrEmpty(stringTableEntry.GetLocalizedString()))
			{
				return description;
			}
			return stringTableEntry.GetLocalizedString();
		}
	}
}
