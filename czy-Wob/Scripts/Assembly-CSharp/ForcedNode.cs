using System;
using UnityEngine;

[Serializable]
public struct ForcedNode
{
	public Vector3Int endingCoords;

	public Vector3Int startingCoords;

	public ulong requiredRoomID;

	public ConnectorLabel requiredLabel;

	public WallDirection requiredWallDirection;

	public ForcedNode(Vector3Int startingCoords, Vector3Int endingCoords, ulong requiredRoomID, WallDirection requiredWallDirection, ConnectorLabel requiredLabel)
	{
		this.endingCoords = endingCoords;
		this.requiredLabel = requiredLabel;
		this.startingCoords = startingCoords;
		this.requiredRoomID = requiredRoomID;
		this.requiredWallDirection = requiredWallDirection;
	}
}
