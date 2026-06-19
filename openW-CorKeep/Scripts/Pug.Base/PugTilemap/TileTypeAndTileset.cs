using System;
using Unity.Mathematics;

namespace PugTilemap
{
	[Serializable]
	public struct TileTypeAndTileset : IEquatable<TileTypeAndTileset>
	{
		public TileType TileType;

		public Tileset Tileset;

		public TileTypeAndTileset(TileType tileType, Tileset tileset)
		{
			TileType = tileType;
			Tileset = tileset;
		}

		public bool Equals(TileTypeAndTileset other)
		{
			if (TileType == other.TileType)
			{
				return Tileset == other.Tileset;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is TileTypeAndTileset other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)math.hash(new int2((int)TileType, (int)Tileset));
		}

		public override string ToString()
		{
			return $"{{{TileType}, {Tileset}}}";
		}
	}
}
