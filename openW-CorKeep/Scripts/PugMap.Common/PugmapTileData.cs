using System;
using PugTilemap;

[Serializable]
public struct PugmapTileData
{
	public TileType tileType;

	public ushort tilesetType;

	public byte state;

	public byte[] typeData;

	public static implicit operator TileInfo(PugmapTileData tileData)
	{
		return new TileInfo
		{
			tileset = tileData.tilesetType,
			tileType = tileData.tileType,
			state = tileData.state
		};
	}

	public static implicit operator PugmapTileData(TileInfo tileInfo)
	{
		return new PugmapTileData
		{
			tileType = tileInfo.tileType,
			tilesetType = (ushort)tileInfo.tileset,
			state = (byte)tileInfo.state
		};
	}
}
