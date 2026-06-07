using System;

namespace Febucci.Numbers
{
	public struct Vector4Int : IEquatable<Vector4Int>
	{
		public int X;

		public int Y;

		public int Z;

		public int W;

		public Vector4Int(int x, int y, int z, int w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public static Vector4Int operator +(in Vector4Int a, in Vector4Int b)
		{
			return new Vector4Int(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		public static Vector4Int operator -(in Vector4Int a, in Vector4Int b)
		{
			return new Vector4Int(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		public static Vector4Int operator *(in Vector4Int a, int d)
		{
			return new Vector4Int(a.X * d, a.Y * d, a.Z * d, a.W * d);
		}

		public static Vector4Int operator *(int d, in Vector4Int a)
		{
			return new Vector4Int(d * a.X, d * a.Y, d * a.Z, d * a.W);
		}

		public static Vector4Int operator /(in Vector4Int a, int d)
		{
			return new Vector4Int(a.X / d, a.Y / d, a.Z / d, a.W / d);
		}

		public static bool operator ==(in Vector4Int a, in Vector4Int b)
		{
			if (a.X == b.X && a.Y == b.Y && a.Z == b.Z)
			{
				return a.W == b.W;
			}
			return false;
		}

		public static bool operator !=(in Vector4Int a, in Vector4Int b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4Int b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector4Int other)
		{
			if (X == other.X && Y == other.Y && Z == other.Z)
			{
				return W == other.W;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (X, Y, Z, W).GetHashCode();
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z}, {W})";
		}
	}
}
