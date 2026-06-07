using System;
using System.Collections.Generic;
using DV.PointSet;
using UnityEngine;

public class TrackChunkSpatialHash
{
	public readonly float cellSize;

	private readonly Dictionary<Vector2Int, Dictionary<EquiPointSet, TrackChunk>> addingCells;

	private readonly Dictionary<Vector2Int, List<TrackChunk>> lookupCells;

	private bool doneAdding;

	public TrackChunkSpatialHash(float cellSize)
	{
		this.cellSize = cellSize;
		addingCells = new Dictionary<Vector2Int, Dictionary<EquiPointSet, TrackChunk>>();
		lookupCells = new Dictionary<Vector2Int, List<TrackChunk>>();
	}

	public static Vector2Int GetCellID(Vector3 worldPosition, float cellSize)
	{
		return new Vector2Int(Mathf.FloorToInt(worldPosition.x / cellSize), Mathf.FloorToInt(worldPosition.z / cellSize));
	}

	public Vector2Int GetCellID(Vector3 worldPosition)
	{
		return GetCellID(worldPosition, cellSize);
	}

	public void DoneAdding()
	{
		doneAdding = true;
		foreach (KeyValuePair<Vector2Int, Dictionary<EquiPointSet, TrackChunk>> addingCell in addingCells)
		{
			Vector2Int key = addingCell.Key;
			Dictionary<EquiPointSet, TrackChunk> value = addingCell.Value;
			if (!lookupCells.TryGetValue(key, out var value2))
			{
				value2 = new List<TrackChunk>();
				lookupCells[addingCell.Key] = value2;
			}
			foreach (KeyValuePair<EquiPointSet, TrackChunk> item in value)
			{
				TrackChunk value3 = item.Value;
				value2.Add(value3);
			}
		}
		addingCells.Clear();
	}

	public TrackChunk Add(EquiPointSet pointSet, EquiPointSet.Point point)
	{
		if (doneAdding)
		{
			throw new InvalidOperationException("Can't add anymore");
		}
		Vector2Int cellID = GetCellID((Vector3)point.position);
		if (!addingCells.TryGetValue(cellID, out var value))
		{
			value = new Dictionary<EquiPointSet, TrackChunk>();
			addingCells.Add(cellID, value);
		}
		if (!value.TryGetValue(pointSet, out var value2))
		{
			value2 = (value[pointSet] = new TrackChunk(pointSet, cellID));
		}
		value2.Include(point);
		return value2;
	}

	public void FindInRange(Vector3 position, float extent, Dictionary<Vector2Int, List<TrackChunk>> results)
	{
		if (!doneAdding)
		{
			throw new InvalidOperationException("Must call DoneAdding first");
		}
		Vector2Int cellID = GetCellID(position - Vector3.one * extent);
		Vector2Int cellID2 = GetCellID(position + Vector3.one * extent);
		results.Clear();
		for (int i = cellID.x; i <= cellID2.x; i++)
		{
			for (int j = cellID.y; j <= cellID2.y; j++)
			{
				Vector2Int key = new Vector2Int(i, j);
				if (lookupCells.TryGetValue(key, out var value))
				{
					results[key] = value;
				}
			}
		}
	}
}
