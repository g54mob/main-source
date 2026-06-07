using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public class EndlessModeRoundReward
{
	[Header("$GetWaveInfo")]
	public int Index;

	[FormerlySerializedAs("RewardType")]
	public eEndlessModeRoundRewardType RewardType_1;

	[SerializeField]
	public int value_1;

	public eEndlessModeRoundRewardType RewardType_2;

	[SerializeField]
	public int value_2;

	public int GetRewardTypeCount()
	{
		return 0;
	}

	public bool IsHaveRewardType(eEndlessModeRoundRewardType type)
	{
		return false;
	}

	public int GetRewardValue(eEndlessModeRoundRewardType type)
	{
		return 0;
	}

	private Color GetRewardTypeColor_1()
	{
		return default(Color);
	}

	private Color GetRewardTypeColor_2()
	{
		return default(Color);
	}

	private Color GetRewardTypeColor(eEndlessModeRoundRewardType type)
	{
		return default(Color);
	}

	private string GetWaveInfo()
	{
		return null;
	}
}
