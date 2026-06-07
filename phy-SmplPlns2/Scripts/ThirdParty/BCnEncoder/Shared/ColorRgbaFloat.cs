using System;

namespace BCnEncoder.Shared
{
	internal struct ColorRgbaFloat : IEquatable<ColorRgbaFloat>
	{
		public float r;

		public float g;

		public float b;

		public float a;

		public ColorRgbaFloat(float r, float g, float b, float a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public ColorRgbaFloat(ColorRgba32 other)
		{
			r = (float)(int)other.r / 255f;
			g = (float)(int)other.g / 255f;
			b = (float)(int)other.b / 255f;
			a = (float)(int)other.a / 255f;
		}

		public ColorRgbaFloat(float r, float g, float b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			a = 1f;
		}

		public bool Equals(ColorRgbaFloat other)
		{
			if (r == other.r && g == other.g && b == other.b)
			{
				return a == other.a;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgbaFloat other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((r.GetHashCode() * 397) ^ g.GetHashCode()) * 397) ^ b.GetHashCode()) * 397) ^ a.GetHashCode();
		}

		public static bool operator ==(ColorRgbaFloat left, ColorRgbaFloat right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgbaFloat left, ColorRgbaFloat right)
		{
			return !left.Equals(right);
		}

		public static ColorRgbaFloat operator +(ColorRgbaFloat left, ColorRgbaFloat right)
		{
			return new ColorRgbaFloat(left.r + right.r, left.g + right.g, left.b + right.b, left.a + right.a);
		}

		public static ColorRgbaFloat operator -(ColorRgbaFloat left, ColorRgbaFloat right)
		{
			return new ColorRgbaFloat(left.r - right.r, left.g - right.g, left.b - right.b, left.a - right.a);
		}

		public static ColorRgbaFloat operator /(ColorRgbaFloat left, float right)
		{
			return new ColorRgbaFloat(left.r / right, left.g / right, left.b / right, left.a / right);
		}

		public static ColorRgbaFloat operator *(ColorRgbaFloat left, float right)
		{
			return new ColorRgbaFloat(left.r * right, left.g * right, left.b * right, left.a * right);
		}

		public static ColorRgbaFloat operator *(float left, ColorRgbaFloat right)
		{
			return new ColorRgbaFloat(right.r * left, right.g * left, right.b * left, right.a * left);
		}

		public override string ToString()
		{
			return $"r : {r:0.00} g : {g:0.00} b : {b:0.00} a : {a:0.00}";
		}

		public ColorRgba32 ToRgba32()
		{
			return new ColorRgba32(ByteHelper.ClampToByte(r * 255f), ByteHelper.ClampToByte(g * 255f), ByteHelper.ClampToByte(b * 255f), ByteHelper.ClampToByte(a * 255f));
		}
	}
}
