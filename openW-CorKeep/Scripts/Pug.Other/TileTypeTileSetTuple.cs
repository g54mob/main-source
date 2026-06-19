using System;
using PugTilemap;
using Unity.Mathematics;

public struct TileTypeTileSetTuple : IEquatable<TileTypeTileSetTuple>
{
	public TileType tileType;

	public Tileset tileset;

	public TileTypeTileSetTuple(TileType tileType, Tileset tileset)
	{
		this.tileType = tileType;
		this.tileset = tileset;
	}

	public bool Equals(TileTypeTileSetTuple other)
	{
		if (tileType == other.tileType)
		{
			return tileset == other.tileset;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is TileTypeTileSetTuple other)
		{
			return Equals(other);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return (int)math.hash(new int2((int)tileType, (int)tileset));
	}

	public static implicit operator TileTypeTileSetTuple((TileType, Tileset) tuple)
	{
		return new TileTypeTileSetTuple(tuple.Item1, tuple.Item2);
	}
}
