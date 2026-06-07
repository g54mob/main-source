using System;

namespace Gh.Tk
{
	public readonly struct Neighbours : IEquatable<Neighbours>
	{
		public readonly NeighbourInfo left;

		public readonly NeighbourInfo top;

		public readonly NeighbourInfo right;

		public readonly NeighbourInfo bottom;

		public Neighbours(NeighbourInfo left, NeighbourInfo top, NeighbourInfo right, NeighbourInfo bottom)
		{
			this.left = default(NeighbourInfo);
			this.top = default(NeighbourInfo);
			this.right = default(NeighbourInfo);
			this.bottom = default(NeighbourInfo);
		}

		public bool Equals(Neighbours other)
		{
			return false;
		}
	}
}
