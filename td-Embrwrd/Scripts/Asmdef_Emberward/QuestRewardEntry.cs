using System;
using UnityEngine;

[Serializable]
public class QuestRewardEntry
{
	public eQuestRewardType RewardType;

	public eItemType ItemType;

	public int multiplier_Min;

	public int multiplier_Max;

	private bool IsRewardAItem()
	{
		return false;
	}

	private Color GetRewardTypeColor()
	{
		return default(Color);
	}

	public QuestRewardEntry Clone()
	{
		return null;
	}
}
