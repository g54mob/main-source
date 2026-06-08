using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class QuestTileOption : IWeightedRandomizable
{
	public GameObject questTile;

	public float probability = 1f;

	public List<Quest> questOptions;

	public SessionQuestReward unlockReward;

	public float Probability
	{
		get
		{
			if (!(unlockReward == null) && unlockReward.state != RewardState.Completed)
			{
				return 0f;
			}
			return probability;
		}
	}
}
