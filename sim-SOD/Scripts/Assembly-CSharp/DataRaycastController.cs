using System;
using System.Collections.Generic;
using UnityEngine;

public class DataRaycastController : MonoBehaviour
{
	[Serializable]
	public struct NodeRaycastHit
	{
		public Vector3Int coord;

		public List<int> conditionalDoors;
	}

	private static DataRaycastController _instance;

	public static DataRaycastController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public bool EntranceRaycast(NewNode.NodeAccess fromEntrance, NewNode.NodeAccess toEntrance, out List<NodeRaycastHit> path, bool debugMode = false)
	{
		path = null;
		return false;
	}

	public bool NodeRaycast(NewNode fromNode, NewNode toNode, out List<NodeRaycastHit> path, NewDoor startingDoor = null, bool debugMode = false)
	{
		path = null;
		return false;
	}

	private bool TestAdjacentForNoCeilingAdjBannister(NewNode n)
	{
		return false;
	}

	private bool TestAdjacentForNoFloorAdjBannister(NewNode n)
	{
		return false;
	}

	private bool TestAdjacentForNoWall(NewWall w)
	{
		return false;
	}
}
