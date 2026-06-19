using System;
using UnityEngine;

namespace PugTilemap.Grid
{
	public class FloodFill_SolidTileGridSource<TCellDst> : FloodFill<TileType, TCellDst> where TCellDst : IEquatable<TCellDst>
	{
		public FloodFill_SolidTileGridSource(BaseGrid<TCellDst> dstGrid, TCellDst dstFillValue)
			: base(dstGrid, dstFillValue)
		{
		}

		protected override bool IsSrcCellFillable(Vector2Int p)
		{
			return !base.srcGrid.UnsafeGet(p).IsBlockingTile();
		}
	}
}
