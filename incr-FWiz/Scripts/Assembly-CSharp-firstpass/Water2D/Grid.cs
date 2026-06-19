using UnityEngine;

namespace Water2D
{
	public class Grid
	{
		public int cellsX { get; private set; }

		public int cellsY { get; private set; }

		public int cellsTotal => 0;

		public float width { get; private set; }

		public float height { get; private set; }

		public float cellWidth { get; private set; }

		public float cellHeight { get; private set; }

		public Vector2 bl { get; private set; }

		public Vector2 tr { get; private set; }

		public Grid(int cellsX, int cellsY, float width, float height, Vector2 bl)
		{
		}

		public void UpdatePosition(Vector2 bottomLeft)
		{
		}

		public void UpdateCellCount(int cellsX, int cellsY)
		{
		}

		public bool RectInCell(Rect rect, int cellIdx)
		{
			return false;
		}

		public bool RectInGrid(Rect rect, int cellIdx)
		{
			return false;
		}

		public void DrawGizmos()
		{
		}

		public Vector2Int GetGridCellCoords(Vector2 pos)
		{
			return default(Vector2Int);
		}

		public int GetGridCellIndex(Vector2 pos)
		{
			return 0;
		}

		private int toIdx(int x, int y)
		{
			return 0;
		}

		private Vector2Int to2D(int idx)
		{
			return default(Vector2Int);
		}
	}
}
