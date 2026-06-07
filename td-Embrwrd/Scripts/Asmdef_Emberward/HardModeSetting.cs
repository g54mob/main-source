using System;
using System.Collections.Generic;

[Serializable]
public class HardModeSetting
{
	public List<HardModeSettingEntry> list_HardModeSettingEntry;

	public HardModeSetting()
	{
	}

	public HardModeSetting(List<int> levelSettings)
	{
	}

	public void ResetAllLevel()
	{
	}

	public void SetLevel(eHardModeShardType type, int level)
	{
	}

	public int GetShardLevel(eHardModeShardType type)
	{
		return 0;
	}

	public bool IsShardActivated(eHardModeShardType type, int level)
	{
		return false;
	}

	public void OverrideShardLevel(eHardModeShardType type, int level)
	{
	}

	public int GetDifficultyLevel()
	{
		return 0;
	}

	public int GetMaxDifficultyLevel()
	{
		return 0;
	}

	public int GetMonsterHPMultiplier()
	{
		return 0;
	}

	public int GetBossHPMultiplier()
	{
		return 0;
	}

	public List<int> GetShardLevelList()
	{
		return null;
	}

	public eItemType GetPerkTypeByShardType(eHardModeShardType type)
	{
		return default(eItemType);
	}

	public void SetShardLevels(List<int> list_SelectedShardLevel)
	{
	}
}
