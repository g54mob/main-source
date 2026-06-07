using System.Collections.Generic;
using UnityEngine;

namespace DV.PointSet
{
	public class SpatialHash2D<T>
	{
		public readonly float cellSize;

		public readonly Dictionary<Vector2Int, List<T>> cells;

		public SpatialHash2D(float cellSize)
		{
			this.cellSize = cellSize;
			cells = new Dictionary<Vector2Int, List<T>>();
		}

		public Vector2Int GetCellID(Vector3 worldPosition)
		{
			return new Vector2Int((int)(worldPosition.x / cellSize), (int)(worldPosition.z / cellSize));
		}

		public void Add(T obj, Vector3 worldPosition)
		{
			Vector2Int cellID = GetCellID(worldPosition);
			if (!cells.TryGetValue(cellID, out var value))
			{
				value = new List<T>();
				cells.Add(cellID, value);
			}
			value.Add(obj);
		}

		public void FindInRange(Vector3 position, float extent, ref List<T> results)
		{
			Vector2Int cellID = GetCellID(position - Vector3.one * extent);
			Vector2Int cellID2 = GetCellID(position + Vector3.one * extent);
			results.Clear();
			for (int i = cellID.x; i <= cellID2.x; i++)
			{
				for (int j = cellID.y; j <= cellID2.y; j++)
				{
					if (!cells.TryGetValue(new Vector2Int(i, j), out var value))
					{
						continue;
					}
					foreach (T item in value)
					{
						results.Add(item);
					}
				}
			}
		}
	}
}
