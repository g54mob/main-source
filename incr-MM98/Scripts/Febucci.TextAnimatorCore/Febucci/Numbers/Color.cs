using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Color : IEquatable<Color>
	{
		private const float TOLERANCE = 1E-06f;

		public float X;

		public float Y;

		public float Z;

		public float W;

		public float R => X;

		public float G => Y;

		public float B => Z;

		public float A => W;

		public Color(float x, float y, float z, float w)
		{
			X = x;
			Y = y;
			Z = z;
			W = w;
		}

		public static Color operator +(in Color a, in Color b)
		{
			return new Color(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
		}

		public static Color operator -(in Color a, in Color b)
		{
			return new Color(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
		}

		public static Color operator *(in Color a, int d)
		{
			return new Color(a.X * (float)d, a.Y * (float)d, a.Z * (float)d, a.W * (float)d);
		}

		public static Color operator *(int d, in Color a)
		{
			return new Color((float)d * a.X, (float)d * a.Y, (float)d * a.Z, (float)d * a.W);
		}

		public static Color operator /(in Color a, int d)
		{
			return new Color(a.X / (float)d, a.Y / (float)d, a.Z / (float)d, a.W / (float)d);
		}

		public static Color operator *(in Color a, float d)
		{
			return new Color(a.X * d, a.Y * d, a.Z * d, a.W * d);
		}

		public static Color operator *(float d, in Color a)
		{
			return new Color(d * a.X, d * a.Y, d * a.Z, d * a.W);
		}

		public static Color operator /(in Color a, float d)
		{
			return new Color(a.X / d, a.Y / d, a.Z / d, a.W / d);
		}

		public static bool operator ==(in Color a, in Color b)
		{
			if (Math.Abs(a.X - b.X) < 1E-06f && Math.Abs(a.Y - b.Y) < 1E-06f && Math.Abs(a.Z - b.Z) < 1E-06f)
			{
				return Math.Abs(a.W - b.W) < 1E-06f;
			}
			return false;
		}

		public static bool operator !=(in Color a, in Color b)
		{
			return !(a == b);
		}

		public static implicit operator Color32(Color color)
		{
			return new Color32(color.R, color.G, color.B, color.A);
		}

		public override bool Equals(object obj)
		{
			if (obj is Color b)
			{
				return this == b;
			}
			return false;
		}

		public bool Equals(Color other)
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

		public static Color LerpUnclamped(Color a, Color b, float t)
		{
			return new Color(a.R + (b.R - a.R) * t, a.G + (b.G - a.G) * t, a.B + (b.B - a.B) * t, a.A + (b.A - a.A) * t);
		}

		public static implicit operator UnityEngine.Color(Color v)
		{
			return new UnityEngine.Color(v.X, v.Y, v.Z, v.W);
		}

		public static implicit operator Color(UnityEngine.Color v)
		{
			return new Color(v.r, v.g, v.b, v.a);
		}

		public static implicit operator Color(UnityEngine.Color32 v)
		{
			return new Color((float)(int)v.r / 255f, (float)(int)v.g / 255f, (float)(int)v.b / 255f, (float)(int)v.a / 255f);
		}

		public static implicit operator UnityEngine.Color32(Color v)
		{
			return new UnityEngine.Color32((byte)(v.X * 255f), (byte)(v.Y * 255f), (byte)(v.Z * 255f), (byte)(v.W * 255f));
		}

		public static Color operator +(in Color a, in UnityEngine.Color b)
		{
			return a + (Color)b;
		}

		public static Color operator +(in UnityEngine.Color a, in Color b)
		{
			return (Color)a + b;
		}

		public static Color operator -(in Color a, in UnityEngine.Color b)
		{
			return a - (Color)b;
		}

		public static Color operator -(in UnityEngine.Color a, in Color b)
		{
			return (Color)a - b;
		}

		public static bool operator ==(in Color a, in UnityEngine.Color b)
		{
			return a == (Color)b;
		}

		public static bool operator ==(in UnityEngine.Color a, in Color b)
		{
			return (Color)a == b;
		}

		public static bool operator !=(in Color a, in UnityEngine.Color b)
		{
			return a != (Color)b;
		}

		public static bool operator !=(in UnityEngine.Color a, in Color b)
		{
			return (Color)a != b;
		}
	}
}
