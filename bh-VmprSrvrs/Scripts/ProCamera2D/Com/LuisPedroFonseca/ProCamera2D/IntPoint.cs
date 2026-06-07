using System;

namespace Com.LuisPedroFonseca.ProCamera2D
{
	internal struct IntPoint : IEquatable<IntPoint>
	{
		public static IntPoint MaxValue;

		public int X;

		public int Y;

		public IntPoint(int x, int y)
		{
			X = 0;
			Y = 0;
		}

		public bool IsEqual(IntPoint other)
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public bool Equals(IntPoint other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
