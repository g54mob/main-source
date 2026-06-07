using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Vector2Int : IEquatable<Vector2Int>
	{
		public int X;

		public int Y;

		public Vector2Int(int x, int y)
		{
			X = x;
			Y = y;
		}

		public static Vector2Int operator +(in Vector2Int a, in Vector2Int b)
		{
			return new Vector2Int(a.X + b.X, a.Y + b.Y);
		}

		public static Vector2Int operator -(in Vector2Int a, in Vector2Int b)
		{
			return new Vector2Int(a.X - b.X, a.Y - b.Y);
		}

		public static Vector2Int operator *(in Vector2Int a, int d)
		{
			return new Vector2Int(a.X * d, a.Y * d);
		}

		public static Vector2Int operator *(int d, in Vector2Int a)
		{
			return new Vector2Int(d * a.X, d * a.Y);
		}

		public static Vector2Int operator /(in Vector2Int a, int d)
		{
			return new Vector2Int(a.X / d, a.Y / d);
		}

		public static bool operator ==(in Vector2Int a, in Vector2Int b)
		{
			if (a.X == b.X)
			{
				return a.Y == b.Y;
			}
			return false;
		}

		public static bool operator !=(in Vector2Int a, in Vector2Int b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2Int b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector2Int other)
		{
			if (X == other.X)
			{
				return Y == other.Y;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (X, Y).GetHashCode();
		}

		public override string ToString()
		{
			return $"({X}, {Y})";
		}

		public static implicit operator UnityEngine.Vector2Int(Vector2Int v)
		{
			return new UnityEngine.Vector2Int(v.X, v.Y);
		}

		public static implicit operator Vector2Int(UnityEngine.Vector2Int v)
		{
			return new Vector2Int(v.x, v.y);
		}

		public static Vector2Int operator +(in Vector2Int a, in UnityEngine.Vector2Int b)
		{
			return a + (Vector2Int)b;
		}

		public static Vector2Int operator +(in UnityEngine.Vector2Int a, in Vector2Int b)
		{
			return (Vector2Int)a + b;
		}

		public static Vector2Int operator -(in Vector2Int a, in UnityEngine.Vector2Int b)
		{
			return a - (Vector2Int)b;
		}

		public static Vector2Int operator -(in UnityEngine.Vector2Int a, in Vector2Int b)
		{
			return (Vector2Int)a - b;
		}

		public static bool operator ==(in Vector2Int a, in UnityEngine.Vector2Int b)
		{
			return a == (Vector2Int)b;
		}

		public static bool operator ==(in UnityEngine.Vector2Int a, in Vector2Int b)
		{
			return (Vector2Int)a == b;
		}

		public static bool operator !=(in Vector2Int a, in UnityEngine.Vector2Int b)
		{
			return a != (Vector2Int)b;
		}

		public static bool operator !=(in UnityEngine.Vector2Int a, in Vector2Int b)
		{
			return (Vector2Int)a != b;
		}
	}
}
