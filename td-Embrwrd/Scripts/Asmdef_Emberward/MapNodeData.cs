using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapNodeData
{
	public int Index;

	public int Step;

	public int IndexInStep;

	public eStageType MapNodeType;

	public eMapNodeState State;

	public StageRewardData stageReward;

	public int randomSeed;

	public List<int> connectedIndex;

	public int connectedFromCount;

	public int difficulty;

	public string stageEnvSceneName;

	public eItemType anomalyPerkType;

	public eItemType extraAnomalyPerkType;

	public eItemType buffAnomalyPerkType;

	[SerializeField]
	protected bool isCleared;

	public List<int> List_ExtraData;

	public bool IsCleared => false;

	public MapNodeData(int index, int step, int indexInStep, eStageType mapNodeType, eMapNodeState state)
	{
	}

	public void SetRandomSeed(int seed)
	{
	}

	public void SetStageReward(StageRewardData rewardData)
	{
	}

	public void SetEnvSceneName(string name, int difficulty)
	{
	}

	public void AddConnection(int index)
	{
	}

	public bool HasStageReward()
	{
		return false;
	}

	public void SetCleared()
	{
	}
}
