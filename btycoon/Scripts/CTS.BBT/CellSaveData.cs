using System;
using UnityEngine;

[Serializable]
public struct CellSaveData
{
	public Vector2Int position;

	public int roomID;

	public int[] paint;

	public string buildableName;

	public int buildableRotation;
}
