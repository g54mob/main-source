using System;
using UnityEngine;

[Serializable]
public class Pit
{
	public double totalGold;

	public int highestTier;

	public bool tossedGold;

	public UnityEngine.Random.State pitState;

	public PlayerTime pitTime;

	public bool tier1TRewarded;

	public bool tier2TRewarded;

	public bool tier3TRewarded;

	public bool tier4TRewarded;

	public bool tier5TRewarded;

	public int tossCount;

	public Pit()
	{
		tossedGold = false;
		highestTier = 0;
		totalGold = 0.0;
		pitState = default(UnityEngine.Random.State);
		pitTime = new PlayerTime();
		tossCount = 0;
	}
}
