using System;

namespace Gh.Tk
{
	public readonly struct NeighbourInfo : IEquatable<NeighbourInfo>
	{
		public readonly int index;

		public readonly WallInfo wall;

		public static NeighbourInfo Empty;

		public NeighbourInfo(int index, WallInfo wall)
		{
			this.index = 0;
			this.wall = default(WallInfo);
		}

		public bool Equals(NeighbourInfo other)
		{
			return false;
		}
	}
}
