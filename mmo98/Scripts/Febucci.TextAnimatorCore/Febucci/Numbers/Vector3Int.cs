using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Vector3Int : IEquatable<Vector3Int>
	{
		public int X;

		public int Y;

		public int Z;

		public Vector3Int(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static Vector3Int operator +(in Vector3Int a, in Vector3Int b)
		{
			return new Vector3Int(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public static Vector3Int operator -(in Vector3Int a, in Vector3Int b)
		{
			return new Vector3Int(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		public static Vector3Int operator *(in Vector3Int a, int d)
		{
			return new Vector3Int(a.X * d, a.Y * d, a.Z * d);
		}

		public static Vector3Int operator *(int d, in Vector3Int a)
		{
			return new Vector3Int(d * a.X, d * a.Y, d * a.Z);
		}

		public static Vector3Int operator /(in Vector3Int a, int d)
		{
			return new Vector3Int(a.X / d, a.Y / d, a.Z / d);
		}

		public static bool operator ==(in Vector3Int a, in Vector3Int b)
		{
			if (a.X == b.X && a.Y == b.Y)
			{
				return a.Z == b.Z;
			}
			return false;
		}

		public static bool operator !=(in Vector3Int a, in Vector3Int b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3Int b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector3Int other)
		{
			if (X == other.X && Y == other.Y)
			{
				return Z == other.Z;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (X, Y, Z).GetHashCode();
		}

		public override string ToString()
		{
			return $"({X}, {Y}, {Z})";
		}

		public static implicit operator UnityEngine.Vector3Int(Vector3Int v)
		{
			return new UnityEngine.Vector3Int(v.X, v.Y, v.Z);
		}

		public static implicit operator Vector3Int(UnityEngine.Vector3Int v)
		{
			return new Vector3Int(v.x, v.y, v.z);
		}

		public static Vector3Int operator +(in Vector3Int a, in UnityEngine.Vector3Int b)
		{
			return a + (Vector3Int)b;
		}

		public static Vector3Int operator +(in UnityEngine.Vector3Int a, in Vector3Int b)
		{
			return (Vector3Int)a + b;
		}

		public static Vector3Int operator -(in Vector3Int a, in UnityEngine.Vector3Int b)
		{
			return a - (Vector3Int)b;
		}

		public static Vector3Int operator -(in UnityEngine.Vector3Int a, in Vector3Int b)
		{
			return (Vector3Int)a - b;
		}

		public static bool operator ==(in Vector3Int a, in UnityEngine.Vector3Int b)
		{
			return a == (Vector3Int)b;
		}

		public static bool operator ==(in UnityEngine.Vector3Int a, in Vector3Int b)
		{
			return (Vector3Int)a == b;
		}

		public static bool operator !=(in Vector3Int a, in UnityEngine.Vector3Int b)
		{
			return a != (Vector3Int)b;
		}

		public static bool operator !=(in UnityEngine.Vector3Int a, in Vector3Int b)
		{
			return (Vector3Int)a != b;
		}
	}
}
