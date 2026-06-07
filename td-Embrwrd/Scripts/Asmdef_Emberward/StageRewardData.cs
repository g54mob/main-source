using System;
using System.Collections.Generic;

[Serializable]
public class StageRewardData
{
	public Dictionary<eStageRewardType, StageRewardEntry> dic_RewardEntries;

	public int Exp;

	public int Gem;

	public bool isDisplayAsUnknown;

	public StageRewardData(int exp = 0, int gem = 0)
	{
	}

	public void AddRewardEntry(eStageRewardType rewardType, eItemType itemType, int count)
	{
	}

	public bool HasAnyExtraReward()
	{
		return false;
	}

	public int GetRewardCount()
	{
		return 0;
	}

	public bool HasRewardType(eStageRewardType type)
	{
		return false;
	}

	public StageRewardEntry GetRewardByType(eStageRewardType type)
	{
		return null;
	}

	public void OverrideReward(eStageRewardType type, eItemType itemType, int count)
	{
	}
}
