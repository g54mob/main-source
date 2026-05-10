using System;
using UnityEngine;

namespace CTS.GridSystem
{
	[Serializable]
	public class GridGeneric<T>
	{
		private readonly int _width;

		private readonly int _height;

		private readonly float _cellSize;

		private readonly Vector3 _originPosition;

		private T[,] _gridArray;

		public GridGeneric(int p_width, int p_height, float p_cellSize, Vector3 p_originPosition, Func<GridGeneric<T>, int, int, T> p_createGridCell, bool p_debug = false)
		{
			_width = p_width;
			_height = p_height;
			_cellSize = p_cellSize;
			_originPosition = p_originPosition;
			_gridArray = new T[_width, _height];
			for (int i = 0; i < _gridArray.GetLength(0); i++)
			{
				for (int j = 0; j < _gridArray.GetLength(1); j++)
				{
					_gridArray[i, j] = p_createGridCell(this, i, j);
				}
			}
		}

		public Vector3 GetWorldPosition(float p_x, float p_y, float p_z)
		{
			return new Vector3(p_x, p_y, p_z) * _cellSize + _originPosition;
		}

		public int GetX(Vector3 p_worldPosition)
		{
			return Mathf.FloorToInt((p_worldPosition - _originPosition).x / _cellSize);
		}

		public int GetY(Vector3 p_worldPosition)
		{
			return Mathf.FloorToInt((p_worldPosition - _originPosition).y / _cellSize);
		}

		public int GetZ(Vector3 p_worldPosition)
		{
			return Mathf.FloorToInt((p_worldPosition - _originPosition).z / _cellSize);
		}

		private void SetGridCell(int p_w, int p_h, T p_value)
		{
			if (p_w >= 0 && p_h >= 0 && p_w < _width && p_h < _height)
			{
				_gridArray[p_w, p_h] = p_value;
			}
		}

		public void SetGridCellXY(Vector3 p_worldPos, T p_value)
		{
			SetGridCell(GetX(p_worldPos), GetY(p_worldPos), p_value);
		}

		public void SetGridCellXZ(Vector3 p_worldPos, T p_value)
		{
			SetGridCell(GetX(p_worldPos), GetZ(p_worldPos), p_value);
		}

		private T GetGridCell(int p_w, int p_h)
		{
			if (p_w >= 0 && p_h >= 0 && p_w < _width && p_h < _height)
			{
				return _gridArray[p_w, p_h];
			}
			return default(T);
		}

		public T GetGridCell(Vector2Int p_position)
		{
			return GetGridCell(p_position.x, p_position.y);
		}
	}
}
