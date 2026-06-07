using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/DiscoverRewardAssetData", order = 1)]
public class DiscoverRewardAssetData : ScriptableObject
{
	[SerializeField]
	protected List<DiscoverRewardEntry> rewardEntries;

	public virtual List<DiscoverRewardData> GetWeightedRandomReward(int count, float multiplier, bool preventSameType)
	{
		return null;
	}

	private List<DiscoverRewardData> DiscoverRewardEntryToRewardData(List<DiscoverRewardEntry> list_DiscoverRewardEntry)
	{
		return null;
	}
}
