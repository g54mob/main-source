using System;
using System.Collections.Generic;
using Data.SaveData;

[Serializable]
public class TechTreeSaveData : AbstractSaveData
{
	public const int CurrentVersion = 2;

	public string TechTreeGuid;

	public int FocusedNodeID;

	public List<TechTreeSaveDataNode> UnlockedNodes = new List<TechTreeSaveDataNode>();

	public TechTreeSaveData(string techTreeGuid, List<TechTreeSaveDataNode> unlockedNodes, int focusedNodeID)
		: base(2)
	{
		TechTreeGuid = techTreeGuid;
		UnlockedNodes = unlockedNodes;
		FocusedNodeID = focusedNodeID;
	}
}
