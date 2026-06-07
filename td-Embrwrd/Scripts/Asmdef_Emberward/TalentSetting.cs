using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class TalentSetting
{
	[SerializeField]
	private eTalentType talentType;

	[SerializeField]
	private int maxLevel;

	[FormerlySerializedAs("expCost")]
	[SerializeField]
	[Obsolete]
	private int expCost_Deprecated;

	[SerializeField]
	private bool hasParam;

	[SerializeField]
	private int cost_LV1;

	[SerializeField]
	private int cost_LV2;

	[SerializeField]
	private int cost_LV3;

	[SerializeField]
	private int param_1;

	[SerializeField]
	private int param_2;

	[SerializeField]
	private int param_3;

	[SerializeField]
	private bool isPercentage;

	[SerializeField]
	private Sprite icon;

	[SerializeField]
	private bool lockInDemoVersion;

	[SerializeField]
	private bool lockInEAVersion;

	public eTalentType TalentType => default(eTalentType);

	public int MaxLevel => 0;

	public int ExpCost_Deprecated => 0;

	public bool HasParam => false;

	public int Param_1 => 0;

	public int Param_2 => 0;

	public int Param_3 => 0;

	public bool IsPercentage => false;

	public Sprite Icon => null;

	public bool LockInDemoVersion => false;

	public bool LockInEAVersion => false;

	public int GetParamByLevel(int level)
	{
		return 0;
	}

	public string GetLocFormatString(int curLevel)
	{
		return null;
	}

	private void OnValidate()
	{
	}

	private Color GetParamGuiColor(int value)
	{
		return default(Color);
	}

	private Color GetLevelGuiColor()
	{
		return default(Color);
	}

	private Color GetExpCostGuiColor(int value)
	{
		return default(Color);
	}

	public void SetTalentType(eTalentType type)
	{
	}

	public void SetIcon(Sprite sprite)
	{
	}

	public int GetCurrentLevelCost(int level)
	{
		return 0;
	}

	public int GetNextLevelCost(int level)
	{
		return 0;
	}

	public int GetFullLearnCost()
	{
		return 0;
	}

	public void SetLockInDemoVersion(bool isLock)
	{
	}

	private void CopyTalentTypeToClip()
	{
	}
}
