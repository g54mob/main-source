using System;

namespace PugTilemap.Grid
{
	[Serializable]
	public class ByteGrid : BaseGrid<byte>
	{
		public override bool IsTypeEmpty(byte c)
		{
			return c == 0;
		}
	}
}
