using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "設定檔/PerkSettingData/煉獄裂片", order = 1)]
public class PerkSettingData_InfernoShards : PerkSettingData
{
	[SerializeField]
	private eHardModeShardType shardType;

	public eHardModeShardType ShardType => default(eHardModeShardType);

	public override string GetLocNameString(bool isPrefix = true)
	{
		return null;
	}

	public override string GetLocStatsString()
	{
		return null;
	}

	public string GetLocNameStringWithLevel(int level)
	{
		return null;
	}

	public string GetLocStatsStringWithLevel(int level)
	{
		return null;
	}

	public string CreateLocNameString(int level)
	{
		return null;
	}

	public string CreateLocStatString(int level)
	{
		return null;
	}

	private int GetShardLevelFromGameData()
	{
		return 0;
	}
}
