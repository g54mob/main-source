using System;
using UnityEngine;

[Serializable]
public class GridPoint
{
	public Vector3Int Index;

	public Vector3 Position;

	public bool IsOccupied;

	public GridPoint(Vector3Int index, Vector3 position, bool isOccupied)
	{
	}
}
