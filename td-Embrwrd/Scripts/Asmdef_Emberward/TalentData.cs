using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class TalentData
{
	[SerializeField]
	private bool isInitialized;

	[SerializeField]
	private List<TalentDataEntry> list_talentData;

	[NonSerialized]
	private TalentSettingData talentSettingCache;

	public bool IsInitialized => false;

	public List<TalentDataEntry> List_TalentData => null;

	public TalentSettingData TalentSettingCache => null;

	public void Initialize()
	{
	}

	public int GetLearnedTalentCount_AnyLevel()
	{
		return 0;
	}

	public int GetLearnedTalentCount_FullOnly()
	{
		return 0;
	}

	public bool IsTalentLearned_AnyLevel(eTalentType type)
	{
		return false;
	}

	public bool IsTalentLearned_FullLevel(eTalentType type)
	{
		return false;
	}

	public int GetTalentLevel(eTalentType type)
	{
		return 0;
	}

	public int GetTalentMaxLevel(eTalentType type)
	{
		return 0;
	}

	public bool IsFullLevel(eTalentType type)
	{
		return false;
	}

	public void LearnTalent(eTalentType type)
	{
	}

	public int GetNextLevelExpCost(eTalentType talentType)
	{
		return 0;
	}

	public int GetTotalSpentExp()
	{
		return 0;
	}

	public void ResetAllTalents()
	{
	}

	public float GetTalentParam(eTalentType type)
	{
		return 0f;
	}

	public float GetTalentParamAsPercentage(eTalentType type)
	{
		return 0f;
	}

	public int GetTalentParamInt(eTalentType type)
	{
		return 0;
	}

	private void LoadTalentSettingIfNull()
	{
	}
}
