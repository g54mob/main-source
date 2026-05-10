using System;

namespace Pathfinding
{
	public struct Int2 : IEquatable<Int2>
	{
		public int x;

		public int y;

		public long sqrMagnitudeLong => 0L;

		public Int2(int x, int y)
		{
			this.x = 0;
			this.y = 0;
		}

		public static Int2 operator -(Int2 lhs)
		{
			return default(Int2);
		}

		public static Int2 operator +(Int2 a, Int2 b)
		{
			return default(Int2);
		}

		public static Int2 operator -(Int2 a, Int2 b)
		{
			return default(Int2);
		}

		public static bool operator ==(Int2 a, Int2 b)
		{
			return false;
		}

		public static bool operator !=(Int2 a, Int2 b)
		{
			return false;
		}

		public static long DotLong(Int2 a, Int2 b)
		{
			return 0L;
		}

		public override bool Equals(object o)
		{
			return false;
		}

		public bool Equals(Int2 other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public static Int2 Min(Int2 a, Int2 b)
		{
			return default(Int2);
		}

		public static Int2 Max(Int2 a, Int2 b)
		{
			return default(Int2);
		}

		public static Int2 FromInt3XZ(Int3 o)
		{
			return default(Int2);
		}

		public static Int3 ToInt3XZ(Int2 o)
		{
			return default(Int3);
		}

		public override string ToString()
		{
			return null;
		}
	}
}
