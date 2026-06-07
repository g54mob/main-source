using System;
using UnityEngine;

[Serializable]
public class Fruit
{
	[NonSerialized]
	public float targetTime;

	public float seconds;

	public bool activated;

	public long unlockCost;

	public long totalLevels;

	public long maxTier;

	public bool permCostPaid;

	public bool usePoop;

	public bool eatFruit;

	public int harvests;

	public Fruit()
	{
		targetTime = 1000f;
		activated = false;
		maxTier = 0L;
		permCostPaid = false;
		usePoop = false;
		eatFruit = true;
		harvests = 0;
	}

	public void reset()
	{
		activated = false;
		seconds = 0f;
		totalLevels = 0L;
		harvests = 0;
	}

	public void reset(float resetFactor)
	{
		if (resetFactor > 1f)
		{
			resetFactor = 1f;
		}
		activated = false;
		seconds *= Mathf.Floor(resetFactor);
		totalLevels = 0L;
		harvests = 0;
	}

	public void activate()
	{
		activated = true;
	}

	public void deactivate()
	{
		activated = false;
		seconds = 0f;
	}

	public int harvestTier()
	{
		return Mathf.Min(Mathf.FloorToInt(seconds / 3600f), (int)maxTier);
	}

	public void addTime()
	{
		seconds += 1f;
	}

	public void addTime(int toAdd)
	{
		seconds += toAdd;
	}

	public bool growing()
	{
		if (activated)
		{
			return maxTier != 0;
		}
		return false;
	}
}
