using System;
using UnityEngine;

namespace Febucci.Numbers
{
	public struct Color32 : IEquatable<Color32>
	{
		public byte R;

		public byte G;

		public byte B;

		public byte A;

		public static readonly Color32 White = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public static readonly Color32 Black = new Color32(0, 0, 0);

		public static readonly Color32 Red = new Color32(byte.MaxValue, 0, 0);

		public static readonly Color32 Green = new Color32(0, byte.MaxValue, 0);

		public static readonly Color32 Blue = new Color32(0, 0, byte.MaxValue);

		public static readonly Color32 Clear = new Color32(0, 0, 0, 0);

		public Color32(byte r, byte g, byte b, byte a = byte.MaxValue)
		{
			R = r;
			G = g;
			B = b;
			A = a;
		}

		public Color32(float r, float g, float b, float a = 1f)
		{
			R = (byte)(Mathf.Clamp01(r) * 255f);
			G = (byte)(Mathf.Clamp01(g) * 255f);
			B = (byte)(Mathf.Clamp01(b) * 255f);
			A = (byte)(Mathf.Clamp01(a) * 255f);
		}

		public static explicit operator Color32(Color color)
		{
			return new Color32(color.R, color.G, color.B, color.A);
		}

		public static implicit operator Color(Color32 color32)
		{
			return new Color((float)(int)color32.R / 255f, (float)(int)color32.G / 255f, (float)(int)color32.B / 255f, (float)(int)color32.A / 255f);
		}

		public static bool operator ==(Color32 a, Color32 b)
		{
			if (a.R == b.R && a.G == b.G && a.B == b.B)
			{
				return a.A == b.A;
			}
			return false;
		}

		public static bool operator !=(Color32 a, Color32 b)
		{
			return !(a == b);
		}

		public override bool Equals(object obj)
		{
			if (obj is Color32 color)
			{
				return this == color;
			}
			return false;
		}

		public bool Equals(Color32 other)
		{
			if (R == other.R && G == other.G && B == other.B)
			{
				return A == other.A;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (R, G, B, A).GetHashCode();
		}

		public override string ToString()
		{
			return $"RGBA({R}, {G}, {B}, {A})";
		}

		public static Color32 LerpUnclamped(Color32 a, Color32 b, float t)
		{
			return new Color32((byte)((float)(int)a.R + (float)(b.R - a.R) * t), (byte)((float)(int)a.G + (float)(b.G - a.G) * t), (byte)((float)(int)a.B + (float)(b.B - a.B) * t), (byte)((float)(int)a.A + (float)(b.A - a.A) * t));
		}

		public static implicit operator UnityEngine.Color32(Color32 v)
		{
			return new UnityEngine.Color32(v.R, v.G, v.B, v.A);
		}

		public static implicit operator Color32(UnityEngine.Color32 v)
		{
			return new Color32(v.r, v.g, v.b, v.a);
		}

		public static implicit operator Color32(UnityEngine.Color v)
		{
			return new Color32((byte)(Mathf.Clamp01(v.r) * 255f), (byte)(Mathf.Clamp01(v.g) * 255f), (byte)(Mathf.Clamp01(v.b) * 255f), (byte)(Mathf.Clamp01(v.a) * 255f));
		}

		public static bool operator ==(in Color32 a, in UnityEngine.Color32 b)
		{
			return a == (Color32)b;
		}

		public static bool operator ==(in UnityEngine.Color32 a, in Color32 b)
		{
			return (Color32)a == b;
		}

		public static bool operator !=(in Color32 a, in UnityEngine.Color32 b)
		{
			return a != (Color32)b;
		}

		public static bool operator !=(in UnityEngine.Color32 a, in Color32 b)
		{
			return (Color32)a != b;
		}
	}
}
