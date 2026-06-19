using Pug.UnityExtensions;
using UnityEngine;

namespace PugTilemap.Grid
{
	public struct CellEnumerator<CellType>
	{
		private readonly BaseGrid<CellType> map;

		private int x;

		private int y;

		private readonly int xMin;

		private readonly int xMax;

		private readonly int yMax;

		private readonly int lineGap;

		public int index { get; private set; }

		public Vector2Int pos => new Vector2Int(x, y);

		public CellType item => map.cells[index];

		public CellEnumerator<CellType> Current => this;

		public void Set(CellType newItem)
		{
			map.cells[index] = newItem;
		}

		public CellEnumerator(BaseGrid<CellType> map, RectInt rect)
		{
			this.map = map;
			rect = rect.Intersection(map.bounds);
			if (rect.size == Vector2Int.zero)
			{
				int num = (index = 0);
				lineGap = num;
				xMin = (xMax = (x = (yMax = (y = 0))));
				return;
			}
			xMin = rect.xMin;
			xMax = rect.xMax;
			yMax = rect.yMax;
			int num3 = (rect.yMin - map.bounds.yMin) * map.bounds.width + (xMin - map.bounds.xMin);
			lineGap = map.bounds.xMax - xMax + (xMin - map.bounds.xMin);
			index = num3 - 1;
			x = xMin - 1;
			y = rect.yMin;
		}

		public bool MoveNext()
		{
			if (y >= yMax)
			{
				return false;
			}
			x++;
			index++;
			if (x >= xMax)
			{
				y++;
				if (y >= yMax)
				{
					return false;
				}
				x = xMin;
				index += lineGap;
			}
			return true;
		}

		public CellEnumerator<CellType> GetEnumerator()
		{
			return this;
		}
	}
}
