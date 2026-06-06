using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Vector4 : IEquatable<Vector4>
	{
		private const float TOLERANCE = 1E-06f;

		public float X;

		public float Y;

		public float Z;

		public float W;

		public static readonly Vector4 Zero = new Vector4(0f, 0f, 0f, 0f);

		public static readonly Vector4 One = new Vector4(1f, 1f, 1f, 1f);

		public float magnitude => (float)Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

		public Vector4 normalized
		{
			get
			{
				float num = magnitude;
				if (num < 1E-06f)
				{
					return Zero;
				}
				return new Vector4(X / num, Y / num, Z / num, W / num);
			}
		}

		public Vector4(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public static Vector4 operator +(in Vector4 a, in Vector4 b)
		{
			return new Vector4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		public static Vector4 operator -(in Vector4 a, in Vector4 b)
		{
			return new Vector4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		public static Vector4 operator *(in Vector4 a, int d)
		{
			return new Vector4(a.X * (float)d, a.Y * (float)d, a.Z * (float)d, a.W * (float)d);
		}

		public static Vector4 operator *(int d, in Vector4 a)
		{
			return new Vector4((float)d * a.X, (float)d * a.Y, (float)d * a.Z, (float)d * a.W);
		}

		public static Vector4 operator /(in Vector4 a, int d)
		{
			return new Vector4(a.X / (float)d, a.Y / (float)d, a.Z / (float)d, a.W / (float)d);
		}

		public static Vector4 operator *(in Vector4 a, float d)
		{
			return new Vector4(a.X * d, a.Y * d, a.Z * d, a.W * d);
		}

		public static Vector4 operator *(float d, in Vector4 a)
		{
			return new Vector4(d * a.X, d * a.Y, d * a.Z, d * a.W);
		}

		public static Vector4 operator /(in Vector4 a, float d)
		{
			return new Vector4(a.X / d, a.Y / d, a.Z / d, a.W / d);
		}

		public static bool operator ==(in Vector4 a, in Vector4 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f && Math.Abs(a.Z - b.Z) < 1E-06f)
			{
				return Math.Abs(a.W - b.W) < 1E-06f;
			}
			return false;
		}

		public static bool operator !=(in Vector4 a, in Vector4 b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector4 b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector4 other)
		{
			if (Math.Abs(X - other.X) < 1E-06f && Math.Abs(Y - other.Y) < 1E-06f && Math.Abs(Z - other.Z) < 1E-06f)
			{
				return Math.Abs(W - other.W) < 1E-06f;
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

		public static implicit operator UnityEngine.Vector4(Vector4 v)
		{
			return new UnityEngine.Vector4(v.X, v.Y, v.Z, v.W);
		}

		public static implicit operator Vector4(UnityEngine.Vector4 v)
		{
			return new Vector4(v.x, v.y, v.z, v.w);
		}

		public static Vector4 operator +(in Vector4 a, in UnityEngine.Vector4 b)
		{
			return a + (Vector4)b;
		}

		public static Vector4 operator +(in UnityEngine.Vector4 a, in Vector4 b)
		{
			return (Vector4)a + b;
		}

		public static Vector4 operator -(in Vector4 a, in UnityEngine.Vector4 b)
		{
			return a - (Vector4)b;
		}

		public static Vector4 operator -(in UnityEngine.Vector4 a, in Vector4 b)
		{
			return (Vector4)a - b;
		}

		public static bool operator ==(in Vector4 a, in UnityEngine.Vector4 b)
		{
			return a == (Vector4)b;
		}

		public static bool operator ==(in UnityEngine.Vector4 a, in Vector4 b)
		{
			return (Vector4)a == b;
		}

		public static bool operator !=(in Vector4 a, in UnityEngine.Vector4 b)
		{
			return a != (Vector4)b;
		}

		public static bool operator !=(in UnityEngine.Vector4 a, in Vector4 b)
		{
			return (Vector4)a != b;
		}
	}
}
