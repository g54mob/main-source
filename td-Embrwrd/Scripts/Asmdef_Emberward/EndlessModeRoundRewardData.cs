using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/EndlessModeRoundRewardData", order = 1)]
public class EndlessModeRoundRewardData : ScriptableObject
{
	[Header("每一波次的獎勵類型")]
	[SerializeField]
	private List<EndlessModeRoundReward> list_RewardTypes;

	[SerializeField]
	[Header("基本波數用完後，不斷重複的獎勵類型")]
	private List<EndlessModeRoundReward> list_RepeatRewardTypes;

	public EndlessModeRoundReward GetRewardForRound(int round)
	{
		return null;
	}
}
