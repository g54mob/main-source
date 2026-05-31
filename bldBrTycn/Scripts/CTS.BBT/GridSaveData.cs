using System;
using UnityEngine;
using UnityEngine.Serialization;

[Serializable]
public struct GridSaveData
{
	public Vector2Int gridSize;

	public CellSaveData[] cells;

	[FormerlySerializedAs("roomAssingation")]
	public int[] assignationData;
}
