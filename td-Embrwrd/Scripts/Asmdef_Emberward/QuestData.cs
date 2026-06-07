using System;
using UnityEngine;

[Serializable]
public class QuestData
{
	[Header("任務類型")]
	public eQuestType questType;

	[Header("任務難度")]
	public eQuestDifficulty difficulty;

	[Header("獎勵類型")]
	public eQuestRewardType RewardType;

	[Header("獎勵道具")]
	public eItemType ItemType;

	[Header("獎勵數量")]
	public int RewardAmount;

	[Range(0f, 3f)]
	public int RequireItemCount;

	public eItemType Requirement_item_1;

	public eItemType Requirement_item_2;

	public eItemType Requirement_item_3;

	[Range(0f, 3f)]
	public int RequireValueCount;

	public int Requirement_value_1;

	public int Requirement_value_2;

	public int Requirement_value_3;

	public string GetLocDescription()
	{
		return null;
	}
}
