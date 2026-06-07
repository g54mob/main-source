using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Vector2 : IEquatable<Vector2>
	{
		private const float TOLERANCE = 1E-06f;

		public float X;

		public float Y;

		public static readonly Vector2 Zero = new Vector2(0f, 0f);

		public static readonly Vector2 One = new Vector2(1f, 1f);

		public static readonly Vector2 Right = new Vector2(1f, 0f);

		public static readonly Vector2 Left = new Vector2(-1f, 0f);

		public float magnitude => (float)Math.Sqrt(X * X + Y * Y);

		public Vector2 normalized
		{
			get
			{
				float num = magnitude;
				if (num < 1E-06f)
				{
					return Zero;
				}
				return new Vector2(X / num, Y / num);
			}
		}

		public Vector2(float x, float y)
		{
			X = x;
			Y = y;
		}

		public static Vector2 operator +(in Vector2 a, in Vector2 b)
		{
			return new Vector2(a.X + b.X, a.Y + b.Y);
		}

		public static Vector2 operator -(in Vector2 a, in Vector2 b)
		{
			return new Vector2(a.X - b.X, a.Y - b.Y);
		}

		public static Vector2 operator *(in Vector2 a, int d)
		{
			return new Vector2(a.X * (float)d, a.Y * (float)d);
		}

		public static Vector2 operator /(in Vector2 a, int d)
		{
			return new Vector2(a.X / (float)d, a.Y / (float)d);
		}

		public static Vector2 operator *(in Vector2 a, float d)
		{
			return new Vector2(a.X * d, a.Y * d);
		}

		public static Vector2 operator *(float d, in Vector2 a)
		{
			return new Vector2(d * a.X, d * a.Y);
		}

		public static Vector2 operator /(in Vector2 a, float d)
		{
			return new Vector2(a.X / d, a.Y / d);
		}

		public static bool operator ==(in Vector2 a, in Vector2 b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f)
			{
				return Math.Abs(a.Y - b.Y) < 1E-06f;
			}
			return false;
		}

		public static bool operator !=(in Vector2 a, in Vector2 b)
		{
			return !(a == b);
		}

		public static implicit operator Vector2(in Vector3 v)
		{
			return new Vector2(v.X, v.Y);
		}

		public override bool Equals(object obj)
		{
			if (obj is Vector2 b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Vector2 other)
		{
			if (Math.Abs(X - other.X) < 1E-06f)
			{
				return Math.Abs(Y - other.Y) < 1E-06f;
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

		public static implicit operator UnityEngine.Vector2(Vector2 v)
		{
			return new UnityEngine.Vector2(v.X, v.Y);
		}

		public static implicit operator Vector2(UnityEngine.Vector2 v)
		{
			return new Vector2(v.x, v.y);
		}

		public static Vector2 operator +(in Vector2 a, in UnityEngine.Vector2 b)
		{
			return a + (Vector2)b;
		}

		public static Vector2 operator +(in UnityEngine.Vector2 a, in Vector2 b)
		{
			return (Vector2)a + b;
		}

		public static Vector2 operator -(in Vector2 a, in UnityEngine.Vector2 b)
		{
			return a - (Vector2)b;
		}

		public static Vector2 operator -(in UnityEngine.Vector2 a, in Vector2 b)
		{
			return (Vector2)a - b;
		}

		public static bool operator ==(in Vector2 a, in UnityEngine.Vector2 b)
		{
			return a == (Vector2)b;
		}

		public static bool operator ==(in UnityEngine.Vector2 a, in Vector2 b)
		{
			return (Vector2)a == b;
		}

		public static bool operator !=(in Vector2 a, in UnityEngine.Vector2 b)
		{
			return a != (Vector2)b;
		}

		public static bool operator !=(in UnityEngine.Vector2 a, in Vector2 b)
		{
			return (Vector2)a != b;
		}
	}
}
