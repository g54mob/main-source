using System;
using UnityEngine;

[Serializable]
public class DiscoverRewardEntry
{
	[Header("$GetQuantityInfo")]
	public eDiscoverRewardType rewardType;

	[Header("權重")]
	public int weight;

	[Header("每份有幾個")]
	public int quantityPerServe;

	[Header("最小數量")]
	public int minQuantityMultiplier;

	[Header("最大數量")]
	public int maxQuantityMultiplier;

	[HideInInspector]
	public int quantity;
}
