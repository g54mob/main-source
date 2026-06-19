using System;
using UnityEngine;

namespace PugTilemap.Grid
{
	[Serializable]
	public class BitGrid : BaseGrid<bool>
	{
		public BitGrid()
		{
		}

		public BitGrid(RectInt initBounds)
			: base(initBounds)
		{
		}

		public void Or(Vector2Int pos, bool bit)
		{
			if (bit)
			{
				Set(pos, c: true);
			}
		}

		public override bool IsTypeEmpty(bool c)
		{
			return !c;
		}

		public int Blit<Z>(BaseGrid<Z> dest, RectInt rect, Z t)
		{
			int result = -1;
			if (rect.size == Vector2Int.zero)
			{
				return result;
			}
			CellEnumerator<bool> cellEnumerator = Enumerate(rect);
			CellEnumerator<Z> cellEnumerator2 = dest.Enumerate(rect);
			while (cellEnumerator.MoveNext() && cellEnumerator2.MoveNext())
			{
				if (cellEnumerator.item)
				{
					cellEnumerator2.Set(t);
				}
			}
			return result;
		}
	}
}
