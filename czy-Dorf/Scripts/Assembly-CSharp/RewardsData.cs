using System;
using System.Collections.Generic;

[Serializable]
public class RewardsData
{
	public int unlockLevel;

	public List<RewardData> rewards;

	public RewardsData()
	{
		rewards = new List<RewardData>();
	}
}
