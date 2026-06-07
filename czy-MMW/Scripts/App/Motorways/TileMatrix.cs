using System.Collections.Generic;
using Factory.Pools;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Motorways
{
	public class TileMatrix<T> : IReusable
	{
		public delegate T GenerateDataFromCoordinates(Vector2Int tileCoordinates);

		public delegate T GenerateDataFromTile(TileBase tile);

		public delegate T GetAdjacentFloodFillColor(T color);

		public delegate bool CanFloodFillEnterTile(Vector2Int tileCoordinates, int stepCount, T existingColor, T replacementColor);

		private struct FloodFillFringeNode
		{
			public Vector2Int coordinates;

			public int stepCount;

			public T color;
		}

		private RectInt _dimensions;

		private List<T> _data = new List<T>();

		private T _defaultValue;

		private static readonly Vector2Int[] FloodFillAdjacencyOffsets = new Vector2Int[4]
		{
			Vector2Int.up,
			Vector2Int.right,
			Vector2Int.down,
			Vector2Int.left
		};

		public RectInt Dimensions => _dimensions;

		public T this[Vector2Int tileCoordinates]
		{
			get
			{
				if (_dimensions.Contains(tileCoordinates))
				{
					int index = ConvertCoordinatesToArrayIndex(tileCoordinates);
					return _data[index];
				}
				return _defaultValue;
			}
			set
			{
				if (_dimensions.Contains(tileCoordinates))
				{
					int index = ConvertCoordinatesToArrayIndex(tileCoordinates);
					_data[index] = value;
				}
			}
		}

		public void Initialize(RectInt dimensions, T defaultValue)
		{
			_dimensions = dimensions;
			_defaultValue = defaultValue;
			int num = _dimensions.width * _dimensions.height;
			int num2 = Mathf.Min(num, _data.Count);
			for (int i = 0; i < num2; i++)
			{
				_data[i] = _defaultValue;
			}
			if (num > _data.Count)
			{
				_data.Capacity = num;
				for (int j = _data.Count; j < num; j++)
				{
					_data.Add(defaultValue);
				}
			}
		}

		public void Reset()
		{
			_dimensions = new RectInt(Vector2Int.zero, Vector2Int.zero);
			_defaultValue = default(T);
		}

		public void FillFromTilemap(Tilemap tilemap, GenerateDataFromTile generator)
		{
			int num = 0;
			for (int i = 0; i < _dimensions.height; i++)
			{
				for (int j = 0; j < _dimensions.width; j++)
				{
					_data[num] = generator(tilemap.GetTile(new Vector3Int(_dimensions.xMin + j, _dimensions.yMin + i, 0)));
					num++;
				}
			}
		}

		public void FillFromCoordinates(GenerateDataFromCoordinates generator)
		{
			int num = 0;
			for (int i = 0; i < _dimensions.height; i++)
			{
				for (int j = 0; j < _dimensions.width; j++)
				{
					_data[num] = generator(new Vector2Int(_dimensions.xMin + j, _dimensions.yMin + i));
					num++;
				}
			}
		}

		public void FloodFill(List<Vector2Int> startCoordinates, T startColor, GetAdjacentFloodFillColor getAdjacentColor, CanFloodFillEnterTile canEnterTile)
		{
			HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
			Queue<FloodFillFringeNode> queue = new Queue<FloodFillFringeNode>();
			foreach (Vector2Int startCoordinate in startCoordinates)
			{
				if (_dimensions.Contains(startCoordinate))
				{
					queue.Enqueue(new FloodFillFringeNode
					{
						coordinates = startCoordinate,
						stepCount = 0,
						color = startColor
					});
					hashSet.Add(startCoordinate);
				}
			}
			while (queue.Count > 0)
			{
				FloodFillFringeNode floodFillFringeNode = queue.Dequeue();
				Vector2Int coordinates = floodFillFringeNode.coordinates;
				int index = ConvertCoordinatesToArrayIndex(coordinates);
				_data[index] = floodFillFringeNode.color;
				int stepCount = floodFillFringeNode.stepCount + 1;
				T val = getAdjacentColor(floodFillFringeNode.color);
				Vector2Int[] floodFillAdjacencyOffsets = FloodFillAdjacencyOffsets;
				foreach (Vector2Int vector2Int in floodFillAdjacencyOffsets)
				{
					Vector2Int vector2Int2 = coordinates + vector2Int;
					if (_dimensions.Contains(vector2Int2) && !hashSet.Contains(vector2Int2) && canEnterTile(vector2Int2, stepCount, this[vector2Int2], val))
					{
						queue.Enqueue(new FloodFillFringeNode
						{
							coordinates = vector2Int2,
							stepCount = stepCount,
							color = val
						});
						hashSet.Add(vector2Int2);
					}
				}
			}
		}

		private int ConvertCoordinatesToArrayIndex(Vector2Int coordinates)
		{
			return (coordinates.y - _dimensions.yMin) * _dimensions.width + (coordinates.x - _dimensions.xMin);
		}
	}
}
