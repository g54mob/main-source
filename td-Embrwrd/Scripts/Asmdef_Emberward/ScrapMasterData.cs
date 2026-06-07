using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ScrapMasterData
{
	[Serializable]
	public class ScrapMasterSkillLevelData
	{
		public eScrapMasterSkillType skillType;

		public int level;

		public bool IsMaxLevel()
		{
			return false;
		}

		public void IncreaseLevel()
		{
		}

		public ScrapMasterSkillLevelData Clone()
		{
			return null;
		}
	}

	[SerializeField]
	private bool isFirstSkillLearned;

	private List<int> list_ExpRequirement;

	public int exp;

	public int level;

	public List<ScrapMasterSkillLevelData> list_SkillLevelData;

	public int lastSavedExp;

	public int lastSavedLevel;

	private bool lastSavedIsFirstSkillLearned;

	public List<ScrapMasterSkillLevelData> list_LastSavedSkillLevelData;

	public bool IsFirstSkillLearned => false;

	private void Initialize()
	{
	}

	public void SetFirstSkillLearned()
	{
	}

	public void LoadFromSavedLevelAndExp()
	{
	}

	public void RecordSavedLevelAndExp()
	{
	}

	public void AddExp(int amount)
	{
	}

	public int GetExpRequirementForLevel(int targetLevel)
	{
		return 0;
	}

	public int GetNextExpRequirement()
	{
		return 0;
	}

	public int GetTotalSkillLevel()
	{
		return 0;
	}

	public bool IsMaxLevel()
	{
		return false;
	}

	public bool IsSkillMaxLevel(eScrapMasterSkillType skillType)
	{
		return false;
	}

	public bool IsLearnedAnyPlatformSkill()
	{
		return false;
	}

	public int GetSkillLevel(eScrapMasterSkillType skillType)
	{
		return 0;
	}

	public int GetNextSkillLevel(eScrapMasterSkillType skillType)
	{
		return 0;
	}

	public void IncreaseSkillLevel(eScrapMasterSkillType skillType)
	{
	}
}
