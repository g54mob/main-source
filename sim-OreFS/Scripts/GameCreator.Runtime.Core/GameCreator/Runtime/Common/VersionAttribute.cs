using System;

namespace GameCreator.Runtime.Common
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
	public class VersionAttribute : Attribute
	{
		public int X { get; }

		public int Y { get; }

		public int Z { get; }

		public VersionAttribute(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			return $"{X}.{Y}.{Z}";
		}

		public bool EqualTo(VersionAttribute other)
		{
			if (X == other.X && Y == other.Y)
			{
				return Z == other.Z;
			}
			return false;
		}

		public int CompareTo(VersionAttribute other)
		{
			if (X > other.X)
			{
				return 1;
			}
			if (X < other.X)
			{
				return -1;
			}
			if (Y > other.Y)
			{
				return 1;
			}
			if (Y < other.Y)
			{
				return -1;
			}
			if (Z > other.Z)
			{
				return 1;
			}
			if (Z < other.Z)
			{
				return -1;
			}
			return 0;
		}
	}
}
