using System;
using UnityEngine;

namespace PugTilemap.Workshop
{
	public struct Bresenham
	{
		private int x0;

		private int y0;

		private int err;

		private readonly int dx;

		private readonly int dy;

		private readonly int sx;

		private readonly int sy;

		private readonly int x1;

		private readonly int y1;

		public Vector2Int Current => new Vector2Int(x0, y0);

		public Bresenham(Vector2Int from, Vector2Int to)
		{
			x0 = from.x;
			y0 = from.y;
			x1 = to.x;
			y1 = to.y;
			dx = Math.Abs(x1 - x0);
			dy = Math.Abs(y1 - y0);
			sx = ((x0 < x1) ? 1 : (-1));
			sy = ((y0 < y1) ? 1 : (-1));
			err = dx - dy;
		}

		public bool MoveNext()
		{
			if (x0 == x1 && y0 == y1)
			{
				return false;
			}
			int num = 2 * err;
			if (num > -dy)
			{
				err -= dy;
				x0 += sx;
			}
			if (num < dx)
			{
				err += dx;
				y0 += sy;
			}
			return true;
		}

		public Bresenham GetEnumerator()
		{
			return this;
		}
	}
}
