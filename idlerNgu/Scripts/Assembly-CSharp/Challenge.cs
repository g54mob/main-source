using System;
using UnityEngine;

[Serializable]
public class Challenge
{
	public bool inChallenge;

	[NonSerialized]
	public int targetBoss;

	[NonSerialized]
	public int expReward;

	[NonSerialized]
	public int perkPointReward;

	public int curCompletions;

	public int curEvilCompletions;

	public int curSadisticCompletions;

	[NonSerialized]
	public int maxCompletions;

	public int bestTime;

	public challengeType challengeType;

	public PlayerTime challengeTime;

	public int highScore;

	public bool unlocked;

	public Challenge()
	{
		inChallenge = false;
		targetBoss = 0;
		challengeType = challengeType.Basic;
		challengeTime = new PlayerTime();
		bestTime = int.MaxValue;
		highScore = 0;
		unlocked = false;
	}

	public Challenge(bool highLow)
	{
		inChallenge = false;
		targetBoss = 0;
		challengeType = challengeType.Basic;
		challengeTime = new PlayerTime();
		if (highLow)
		{
			bestTime = int.MaxValue;
		}
		else
		{
			bestTime = 0;
		}
		highScore = 0;
		unlocked = false;
	}

	public void setChallengeStats(challengeType type, int boss, int reward, int preward, int maxComp)
	{
		targetBoss = boss;
		challengeType = type;
		expReward = reward;
		perkPointReward = preward;
		maxCompletions = maxComp;
		if (bestTime < 0)
		{
			if (type == challengeType.timeBased)
			{
				bestTime = 0;
			}
			else
			{
				bestTime = int.MaxValue;
			}
		}
		if (challengeTime == null)
		{
			challengeTime = new PlayerTime();
		}
	}

	public int getPoints()
	{
		if (maxCompletions == 0)
		{
			return curCompletions * perkPointReward;
		}
		return Mathf.Min(curCompletions, maxCompletions) * perkPointReward;
	}

	public void initializeEvilStuff()
	{
		curEvilCompletions = 0;
		curSadisticCompletions = 0;
	}
}
