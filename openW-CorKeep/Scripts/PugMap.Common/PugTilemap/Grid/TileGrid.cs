using System;
using UnityEngine;

namespace PugTilemap.Grid
{
	[Serializable]
	public class TileGrid : BaseGrid<TileType>
	{
		public TileGrid()
		{
		}

		public TileGrid(RectInt initialBounds)
			: base(initialBounds)
		{
		}

		public override bool IsTypeEmpty(TileType t)
		{
			return t == TileType.none;
		}
	}
}
