using System;

namespace Jobberwocky.GeometryAlgorithms.Source.Algorithms.Hull2D
{
	public struct EdgeKey : IEquatable<EdgeKey>
	{
		public int point1;

		public int point2;

		public bool Equals(EdgeKey key)
		{
			if (point2 == key.point2)
			{
				return point1 == key.point1;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return point1.GetHashCode() * 17 + point2.GetHashCode();
		}
	}
}
