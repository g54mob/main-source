using System;

namespace BCnEncoder.Shared
{
	public struct ColorRgba32 : IEquatable<ColorRgba32>
	{
		public byte r;

		public byte g;

		public byte b;

		public byte a;

		public ColorRgba32(byte r, byte g, byte b, byte a)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.a = a;
		}

		public ColorRgba32(byte r, byte g, byte b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			a = byte.MaxValue;
		}

		public bool Equals(ColorRgba32 other)
		{
			if (r == other.r && g == other.g && b == other.b)
			{
				return a == other.a;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgba32 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((r.GetHashCode() * 397) ^ g.GetHashCode()) * 397) ^ b.GetHashCode()) * 397) ^ a.GetHashCode();
		}

		public static bool operator ==(ColorRgba32 left, ColorRgba32 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgba32 left, ColorRgba32 right)
		{
			return !left.Equals(right);
		}

		public static ColorRgba32 operator +(ColorRgba32 left, ColorRgba32 right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r + right.r), ByteHelper.ClampToByte(left.g + right.g), ByteHelper.ClampToByte(left.b + right.b), ByteHelper.ClampToByte(left.a + right.a));
		}

		public static ColorRgba32 operator -(ColorRgba32 left, ColorRgba32 right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r - right.r), ByteHelper.ClampToByte(left.g - right.g), ByteHelper.ClampToByte(left.b - right.b), ByteHelper.ClampToByte(left.a - right.a));
		}

		public static ColorRgba32 operator /(ColorRgba32 left, double right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte((int)((double)(int)left.r / right)), ByteHelper.ClampToByte((int)((double)(int)left.g / right)), ByteHelper.ClampToByte((int)((double)(int)left.b / right)), ByteHelper.ClampToByte((int)((double)(int)left.a / right)));
		}

		public static ColorRgba32 operator *(ColorRgba32 left, double right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte((int)((double)(int)left.r * right)), ByteHelper.ClampToByte((int)((double)(int)left.g * right)), ByteHelper.ClampToByte((int)((double)(int)left.b * right)), ByteHelper.ClampToByte((int)((double)(int)left.a * right)));
		}

		public static ColorRgba32 operator <<(ColorRgba32 left, int right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r << right), ByteHelper.ClampToByte(left.g << right), ByteHelper.ClampToByte(left.b << right), ByteHelper.ClampToByte(left.a << right));
		}

		public static ColorRgba32 operator >>(ColorRgba32 left, int right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r >> right), ByteHelper.ClampToByte(left.g >> right), ByteHelper.ClampToByte(left.b >> right), ByteHelper.ClampToByte(left.a >> right));
		}

		public static ColorRgba32 operator |(ColorRgba32 left, ColorRgba32 right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r | right.r), ByteHelper.ClampToByte(left.g | right.g), ByteHelper.ClampToByte(left.b | right.b), ByteHelper.ClampToByte(left.a | right.a));
		}

		public static ColorRgba32 operator |(ColorRgba32 left, int right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r | right), ByteHelper.ClampToByte(left.g | right), ByteHelper.ClampToByte(left.b | right), ByteHelper.ClampToByte(left.a | right));
		}

		public static ColorRgba32 operator &(ColorRgba32 left, ColorRgba32 right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r & right.r), ByteHelper.ClampToByte(left.g & right.g), ByteHelper.ClampToByte(left.b & right.b), ByteHelper.ClampToByte(left.a & right.a));
		}

		public static ColorRgba32 operator &(ColorRgba32 left, int right)
		{
			return new ColorRgba32(ByteHelper.ClampToByte(left.r & right), ByteHelper.ClampToByte(left.g & right), ByteHelper.ClampToByte(left.b & right), ByteHelper.ClampToByte(left.a & right));
		}

		public override string ToString()
		{
			return $"r : {r} g : {g} b : {b} a : {a}";
		}

		internal readonly ColorRgbaFloat ToFloat()
		{
			return new ColorRgbaFloat(this);
		}

		public readonly ColorRgbFloat ToRgbFloat()
		{
			return new ColorRgbFloat(this);
		}
	}
}
