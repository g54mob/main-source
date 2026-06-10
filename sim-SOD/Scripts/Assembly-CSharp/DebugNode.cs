using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class DebugNode : MonoBehaviour
{
	public NewNode node;

	public Vector3 coordinate;

	public Vector3 tileCoordinate;

	public Vector2Int localTileCoordinate;

	public bool isConnected;

	public List<NewNode.NodeAccess> accessToOtherNodes;

	public bool upperStairwellLink;

	public bool lowerStairwellLink;

	public bool isTileStairwell;

	public bool isTileInvertedStairwell;

	public NewNode.FloorTileType floorType;

	private bool displaySpawnedConnections;

	public List<GameObject> spawnedConnections;

	public void Setup(NewNode newNode)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void RefreshData()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void ToggleDisplayConnections()
	{
	}
}
