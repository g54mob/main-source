using UnityEngine;

namespace Presentation.Locators
{
	[CreateAssetMenu(menuName = "Locators/GridLocator", fileName = "GridLocator", order = 0)]
	public class GridLocator : ScriptableObject
	{
		public class CustomGridLayout
		{
			public Vector3 cellSize = new Vector3(1f, 1f, 1f);

			public Vector3 cellGap = Vector3.zero;

			public Vector3 cellAnchor = Vector3.zero;

			public Vector3 CellToWorld(Vector3Int cellPosition)
			{
				return Vector3.Scale(cellPosition, cellSize + cellGap) + Vector3.Scale(cellSize, cellAnchor);
			}

			public Vector3Int WorldToCell(Vector3 worldPosition)
			{
				Vector3 vector = cellSize + cellGap;
				Vector3 vector2 = new Vector3(worldPosition.x / vector.x, worldPosition.y / vector.y, worldPosition.z / vector.z);
				return new Vector3Int(Mathf.FloorToInt(vector2.x), Mathf.FloorToInt(vector2.y), Mathf.FloorToInt(vector2.z));
			}

			public Vector3 SnapToGrid(Vector3 worldPosition)
			{
				Vector3Int cellPosition = WorldToCell(worldPosition);
				return CellToWorld(cellPosition);
			}
		}

		private readonly CustomGridLayout _grid = new CustomGridLayout();

		private Vector3 _halfCellSize;

		public void SetGrid(Grid grid)
		{
			_grid.cellSize = grid.cellSize;
			_grid.cellGap = grid.cellGap;
			_halfCellSize = _grid.cellSize / 2f;
		}

		public Vector3Int GetCellPosition(Vector3 worldPosition)
		{
			return _grid.WorldToCell(worldPosition);
		}

		public Vector3 GetWorldPosition(Vector3Int cellPosition)
		{
			return _grid.CellToWorld(cellPosition) + _halfCellSize;
		}

		public Vector3 GetRelativePosition(Vector3Int cellPosition)
		{
			return _grid.CellToWorld(cellPosition);
		}

		public Vector3 GetCellSize()
		{
			return _grid.cellSize;
		}
	}
}
