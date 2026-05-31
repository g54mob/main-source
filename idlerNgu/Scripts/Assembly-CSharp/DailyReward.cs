using System;
using UnityEngine;

[Serializable]
public class DailyReward
{
	public long totalSpins;

	public PlayerTime spinTime = new PlayerTime();

	public UnityEngine.Random.State dailyRewardState;

	public long freeSpins;

	public DailyReward()
	{
		totalSpins = 0L;
		spinTime = new PlayerTime();
		spinTime.setTime(82800f);
		freeSpins = 0L;
	}
}
