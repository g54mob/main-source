using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Vector3 : IEquatable<Vector3>
	{
		private const float TOLERANCE = 1E-06f;

		public float X;

		public float Y;

		public float Z;

		public static readonly Vector3 Zero = new Vector3(0f, 0f, 0f);

		public static readonly Vector3 Up = new Vector3(0f, 1f, 0f);

		public static readonly Vector3 Down = new Vector3(0f, -1f, 0f);

		public static readonly Vector3 One = new Vector3(1f, 1f, 1f);

		public static readonly Vector3 Right = new Vector3(1f, 0f, 0f);

		public static readonly Vector3 Left = new Vector3(-1f, 0f, 0f);

		public float magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z);

		public Vector3 normalized
		{
			get
			{
				float num = magnitude;
				if (num < 1E-06f)
				{
					return Zero;
				}
				return new Vector3(X / num, Y / num, Z / num);
			}
		}

		public Vector3(float x, float y, float z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public static Vector3 operator +(in Vector3 a, in Vector3 b)
		{
			return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
		}

		public static Vector3 operator -(in Vector3 a, in Vector3 b)
		{
			return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
		}

		public static Vector3 operator *(in Vector3 a, int d)
		{
			return new Vector3(a.X * (float)d, a.Y * (float)d, a.Z * (float)d);
		}

		public static Vector3 operator *(int d, in Vector3 a)
		{
			return new Vector3((float)d * a.X, (float)d * a.Y, (float)d * a.Z);
		}

		public static Vector3 operator /(in Vector3 a, int d)
		{
			return new Vector3(a.X / (float)d, a.Y / (float)d, a.Z / (float)d);
		}

		public static Vector3 operator *(in Vector3 a, float d)
		{
			return new Vector3(a.X * d, a.Y * d, a.Z * d);
		}

		public static Vector3 operator *(float d, in Vector3 a)
		{
			return new Vector3(d * a.X, d * a.Y, d * a.Z);
		}

		public static Vector3 operator /(in Vector3 a, float d)
		{
			return new Vector3(a.X / d, a.Y / d, a.Z / d);
		}

		public static bool operator ==(in Vector3 a, in Vector3 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f)
			{
				return Math.Abs(a.Z - b.Z) < 1E-06f;
			}
			return false;
		}

		public static bool operator !=(in Vector3 a, in Vector3 b)
		{
			return !(a == b);
		}

		public static implicit operator Vector3(in Vector2 v)
		{
			return new Vector3(v.X, v.Y, 0f);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector3 b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector3 other)
		{
			if (Math.Abs(X - other.X) < 1E-06f && Math.Abs(Y - other.Y) < 1E-06f)
			{
				return Math.Abs(Z - other.Z) < 1E-06f;
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

		public static implicit operator UnityEngine.Vector3(Vector3 v)
		{
			return new UnityEngine.Vector3(v.X, v.Y, v.Z);
		}

		public static implicit operator Vector3(UnityEngine.Vector3 v)
		{
			return new Vector3(v.x, v.y, v.z);
		}

		public static Vector3 operator +(in Vector3 a, in UnityEngine.Vector3 b)
		{
			return a + (Vector3)b;
		}

		public static Vector3 operator +(in UnityEngine.Vector3 a, in Vector3 b)
		{
			return (Vector3)a + b;
		}

		public static Vector3 operator -(in Vector3 a, in UnityEngine.Vector3 b)
		{
			return a - (Vector3)b;
		}

		public static Vector3 operator -(in UnityEngine.Vector3 a, in Vector3 b)
		{
			return (Vector3)a - b;
		}

		public static bool operator ==(in Vector3 a, in UnityEngine.Vector3 b)
		{
			return a == (Vector3)b;
		}

		public static bool operator ==(in UnityEngine.Vector3 a, in Vector3 b)
		{
			return (Vector3)a == b;
		}

		public static bool operator !=(in Vector3 a, in UnityEngine.Vector3 b)
		{
			return a != (Vector3)b;
		}

		public static bool operator !=(in UnityEngine.Vector3 a, in Vector3 b)
		{
			return (Vector3)a != b;
		}
	}
}
