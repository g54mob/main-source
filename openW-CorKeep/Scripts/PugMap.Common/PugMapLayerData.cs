using System;
using System.Collections.Generic;

[Serializable]
public class PugMapLayerData
{
	[Serializable]
	public class TileLayerChunk
	{
		public int s;

		public int e;

		public TileLayerChunk(int start, int end)
		{
			s = start;
			e = end;
		}
	}

	public PugmapTileData tileData;

	public List<TileLayerChunk> tileDataChunks = new List<TileLayerChunk>();
}
