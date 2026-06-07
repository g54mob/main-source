using System;

namespace Digger.Modules.Core.Sources
{
	[Serializable]
	public struct Vector2i
	{
		public int x;

		public int y;

		public static readonly Vector2i zero = new Vector2i(0, 0);

		public static readonly Vector2i one = new Vector2i(1, 1);

		public Vector2i(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public static int DistanceSquared(Vector2i a, Vector2i b)
		{
			int num = b.x - a.x;
			int num2 = b.y - a.y;
			return num * num + num2 * num2;
		}

		public int DistanceSquared(Vector2i v)
		{
			return DistanceSquared(this, v);
		}

		public override int GetHashCode()
		{
			return x ^ (y << 2);
		}

		public override bool Equals(object other)
		{
			if (!(other is Vector2i vector2i))
			{
				return false;
			}
			if (x == vector2i.x)
			{
				return y == vector2i.y;
			}
			return false;
		}

		public bool Equals(Vector2i vector)
		{
			if (x == vector.x)
			{
				return y == vector.y;
			}
			return false;
		}

		public override string ToString()
		{
			return "Vector2i(" + x + " " + y + ")";
		}

		public static bool operator ==(Vector2i a, Vector2i b)
		{
			if (a.x == b.x)
			{
				return a.y == b.y;
			}
			return false;
		}

		public static bool operator !=(Vector2i a, Vector2i b)
		{
			if (a.x == b.x)
			{
				return a.y != b.y;
			}
			return true;
		}

		public static Vector2i operator -(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.x - b.x, a.y - b.y);
		}

		public static Vector2i operator -(Vector2i a)
		{
			return new Vector2i(-a.x, -a.y);
		}

		public static Vector2i operator +(Vector2i a, Vector2i b)
		{
			return new Vector2i(a.x + b.x, a.y + b.y);
		}

		public static Vector2i operator *(Vector2i a, int b)
		{
			return new Vector2i(a.x * b, a.y * b);
		}

		public static Vector2i operator *(int b, Vector2i a)
		{
			return new Vector2i(a.x * b, a.y * b);
		}

		public static Vector2i operator /(Vector2i a, int b)
		{
			return new Vector2i(a.x / b, a.y / b);
		}
	}
}
