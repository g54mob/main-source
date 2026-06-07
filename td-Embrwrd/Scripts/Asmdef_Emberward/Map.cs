using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class Map : MonoBehaviour
{
	[Serializable]
	public class WorldSplineData
	{
		public eWorldType worldType;

		public List<SplineContainer> splines;

		public Vector3 startNodeOffset;
	}

	[SerializeField]
	private MapNodePrefabData mapNodePrefabData;

	public GameObject mapStampPrefab;

	[SerializeField]
	private List<WorldSplineData> List_SplineLists;

	[SerializeField]
	private Transform anchor_MapElementSpawn;

	public float stepHorizontalOffset;

	public float iconRange;

	public float randNodeOffset_X;

	public float randNodeOffset_Y;

	public Vector3 startNodeOffset;

	public Vector3 endNodeBorderPadding;

	private List<MapNode> list_MapNodes;

	private SplineContainer spline;

	private int nodeCooldown_Shop;

	private int nodeCooldown_Workshop;

	private int nodeCooldown_SpecialEvent;

	private int nodeCooldown_CorruptedBattle;

	private int nodeCooldown_AnomalyBattle;

	private int nodeCooldown_DarknessBattle;

	private int nodeCooldown_Altar;

	private int nodeCooldown_Quest;

	private int nodeCooldown_Campsite;

	public List<MapNode> GetMapNodes()
	{
		return null;
	}

	public MapNode GetMapNode(int index)
	{
		return null;
	}

	public List<MapNode> GetPreviousConnectedStepMapNodes(int startIndex, int targetIndex)
	{
		return null;
	}

	public List<MapNode> GetPreviousConnectedStepMapNodes(MapNode startNode, MapNode targetNode)
	{
		return null;
	}

	private bool GetPreviousConnectedMapNodeRecursive(ref List<MapNode> nodes, MapNode startNode, MapNode targetNode)
	{
		return false;
	}

	public List<MapNode> GetNextStepMapNodes(MapNode node)
	{
		return null;
	}

	public List<MapNode> GetNextStepMapNodes(int index)
	{
		return null;
	}

	public List<MapNode> GetMapNodes(List<int> selectedIndex)
	{
		return null;
	}

	public List<MapNode> GetMapNodes(params int[] selectedIndex)
	{
		return null;
	}

	public void ClearMap()
	{
	}

	public void AddAnomalyToMapNode(MapNodeData nodeData)
	{
	}

	public MapData GenerateMapData(MapGenerateSetting setting)
	{
		return null;
	}

	public StageRewardData CreateStageRewardData(eStageType stageType, int step)
	{
		return null;
	}

	private StageRewardData RollStageReward(eStageType stageType, int step)
	{
		return null;
	}

	public void VisualizeMap(MapGenerateSetting setting, MapData mapData)
	{
	}

	private MapNode CreateMapNode(MapGenerateSetting setting, MapData mapData, eStageType mapNodeType, MapNodeData mapNodeData)
	{
		return null;
	}

	private Vector3 RotatePointAroundCenter(Vector3 pointToRotate, Vector3 centerPoint, float angle)
	{
		return default(Vector3);
	}

	private eStageType RollMapNodeType(MapGenerateSetting setting, int step)
	{
		return default(eStageType);
	}

	private GameObject GetPrefabForElement(eStageType nodeType)
	{
		return null;
	}

	private int GetRandomNumberOfConnections()
	{
		return 0;
	}

	private void SetNodeRandomOffset(MapData mapData)
	{
	}

	private bool IsWorldMapVertical(eWorldType worldType)
	{
		return false;
	}

	private void CreateMapObjects()
	{
	}
}
