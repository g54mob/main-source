using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct CreatedPipe
{
	public ulong roomIDEnd;

	public ulong roomIDStart;

	public WallDirection endingWall;

	public WallDirection startingWall;

	public ConnectorLabel endingLabel;

	public ConnectorLabel startingLabel;

	public GameObject focusNodeEnd;

	public GameObject focusNodeStart;

	public GameObject pipeRef;

	public GameObject pipeLineRef;

	public List<Vector3> pipePath;

	public List<Vector3Int> markedGridCells;

	public CreatedPipe(ulong startID, ulong endID, WallDirection startWall, WallDirection endWall, ConnectorLabel startLabel, ConnectorLabel endLabel, GameObject pipe, List<Vector3> path, List<Vector3Int> gridCells, GameObject pipeLine, GameObject nodeStart, GameObject nodeEnd)
	{
		roomIDEnd = endID;
		roomIDStart = startID;
		endingWall = endWall;
		startingWall = startWall;
		endingLabel = endLabel;
		startingLabel = startLabel;
		pipeRef = pipe;
		pipeLineRef = pipeLine;
		focusNodeEnd = nodeEnd;
		focusNodeStart = nodeStart;
		pipePath = path;
		markedGridCells = gridCells;
	}
}
