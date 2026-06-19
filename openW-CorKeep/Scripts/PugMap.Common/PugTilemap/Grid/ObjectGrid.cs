using UnityEngine;

namespace PugTilemap.Grid
{
	public class ObjectGrid<CellType> : BaseGrid<CellType> where CellType : class
	{
		public ObjectGrid()
			: this(default(RectInt))
		{
		}

		public ObjectGrid(RectInt bounds)
			: base(bounds)
		{
		}

		public override bool IsTypeEmpty(CellType c)
		{
			return c == null;
		}
	}
}
