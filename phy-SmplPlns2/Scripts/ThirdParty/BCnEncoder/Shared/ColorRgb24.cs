using System;

namespace BCnEncoder.Shared
{
	internal struct ColorRgb24 : IEquatable<ColorRgb24>
	{
		public byte r;

		public byte g;

		public byte b;

		public ColorRgb24(byte r, byte g, byte b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public ColorRgb24(ColorRgb565 color)
		{
			r = color.R;
			g = color.G;
			b = color.B;
		}

		public ColorRgb24(ColorRgba32 color)
		{
			r = color.r;
			g = color.g;
			b = color.b;
		}

		public bool Equals(ColorRgb24 other)
		{
			if (r == other.r && g == other.g)
			{
				return b == other.b;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgb24 other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((r.GetHashCode() * 397) ^ g.GetHashCode()) * 397) ^ b.GetHashCode();
		}

		public static bool operator ==(ColorRgb24 left, ColorRgb24 right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgb24 left, ColorRgb24 right)
		{
			return !left.Equals(right);
		}

		public static ColorRgb24 operator +(ColorRgb24 left, ColorRgb24 right)
		{
			return new ColorRgb24(ByteHelper.ClampToByte(left.r + right.r), ByteHelper.ClampToByte(left.g + right.g), ByteHelper.ClampToByte(left.b + right.b));
		}

		public static ColorRgb24 operator -(ColorRgb24 left, ColorRgb24 right)
		{
			return new ColorRgb24(ByteHelper.ClampToByte(left.r - right.r), ByteHelper.ClampToByte(left.g - right.g), ByteHelper.ClampToByte(left.b - right.b));
		}

		public static ColorRgb24 operator /(ColorRgb24 left, double right)
		{
			return new ColorRgb24(ByteHelper.ClampToByte((int)((double)(int)left.r / right)), ByteHelper.ClampToByte((int)((double)(int)left.g / right)), ByteHelper.ClampToByte((int)((double)(int)left.b / right)));
		}

		public static ColorRgb24 operator *(ColorRgb24 left, double right)
		{
			return new ColorRgb24(ByteHelper.ClampToByte((int)((double)(int)left.r * right)), ByteHelper.ClampToByte((int)((double)(int)left.g * right)), ByteHelper.ClampToByte((int)((double)(int)left.b * right)));
		}

		public override string ToString()
		{
			return $"r : {r} g : {g} b : {b}";
		}
	}
}
