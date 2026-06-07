using System;
using UnityEngine;

[Serializable]
public class IntermediateData
{
	[Header("世界類型")]
	public eWorldType worldType;

	public eMissionType missionType;

	public eStageType stageType;

	public eWaveMode waveMode;

	public eEndlessModeType endlessModeType;

	public int difficulty;

	public bool isCorrupted;

	public bool isAnomaly;

	public bool isTerritoryLevel;

	public string stageName;

	public StageSettingData stageData;

	public MapNodeData mapNodeData;

	public string leaderboardName;

	public string endlessModeRoundRewardDataPath;

	[NonSerialized]
	public EndlessModeRoundRewardData endlessModeRoundRewardData;

	public void LoadDataProcess()
	{
	}
}
