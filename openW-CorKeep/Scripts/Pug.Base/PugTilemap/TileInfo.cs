using System;
using Unity.Mathematics;

namespace PugTilemap
{
	public struct TileInfo : IEquatable<TileInfo>
	{
		public int tileset;

		public TileType tileType;

		public int state;

		public TileInfo(int tileset, TileType tileType, int state)
		{
			this.tileset = tileset;
			this.tileType = tileType;
			this.state = state;
		}

		public bool Equals(TileInfo other)
		{
			if (other.tileset == tileset && other.tileType == tileType)
			{
				return other.state == state;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)math.hash(new int3(tileset, (int)tileType, state));
		}
	}
}
