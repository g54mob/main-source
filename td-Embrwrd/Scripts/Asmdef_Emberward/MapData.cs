using System;
using System.Collections.Generic;

[Serializable]
public class MapData
{
	public int randomSeed;

	public List<MapNodeData> list_MapNodeData;

	public List<int> list_NodeCountInEachStep;

	public bool IsGenerated;

	public MapNodeData AddNode(eStageType type, eMapNodeState state, int step, int indexInStep)
	{
		return null;
	}
}
