using System;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D
{
	public struct GridKey : IEquatable<GridKey>
	{
		public int X;

		public int Y;

		public GridKey(int x, int y)
		{
			X = x;
			Y = y;
		}

		public bool Equals(GridKey key)
		{
			if (X == key.X)
			{
				return Y == key.Y;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return X.GetHashCode() * 17 + Y.GetHashCode();
		}
	}
}
