using System;
using System.Numerics;

namespace BCnEncoder.Shared
{
	public struct ColorRgbFloat : IEquatable<ColorRgbFloat>
	{
		public float r;

		public float g;

		public float b;

		public ColorRgbFloat(float r, float g, float b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
		}

		public ColorRgbFloat(ColorRgba32 other)
		{
			r = (float)(int)other.r / 255f;
			g = (float)(int)other.g / 255f;
			b = (float)(int)other.b / 255f;
		}

		public ColorRgbFloat(Vector3 vector)
		{
			r = vector.X;
			g = vector.Y;
			b = vector.Z;
		}

		public bool Equals(ColorRgbFloat other)
		{
			if (r == other.r && g == other.g)
			{
				return b == other.b;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgbFloat other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((r.GetHashCode() * 397) ^ g.GetHashCode()) * 397) ^ b.GetHashCode();
		}

		public static bool operator ==(ColorRgbFloat left, ColorRgbFloat right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgbFloat left, ColorRgbFloat right)
		{
			return !left.Equals(right);
		}

		public static ColorRgbFloat operator +(ColorRgbFloat left, ColorRgbFloat right)
		{
			return new ColorRgbFloat(left.r + right.r, left.g + right.g, left.b + right.b);
		}

		public static ColorRgbFloat operator -(ColorRgbFloat left, ColorRgbFloat right)
		{
			return new ColorRgbFloat(left.r - right.r, left.g - right.g, left.b - right.b);
		}

		public static ColorRgbFloat operator /(ColorRgbFloat left, float right)
		{
			return new ColorRgbFloat(left.r / right, left.g / right, left.b / right);
		}

		public static ColorRgbFloat operator *(ColorRgbFloat left, float right)
		{
			return new ColorRgbFloat(left.r * right, left.g * right, left.b * right);
		}

		public static ColorRgbFloat operator *(float left, ColorRgbFloat right)
		{
			return new ColorRgbFloat(right.r * left, right.g * left, right.b * left);
		}

		public override string ToString()
		{
			return $"r : {r:0.00} g : {g:0.00} b : {b:0.00}";
		}

		public ColorRgba32 ToRgba32()
		{
			return new ColorRgba32(ByteHelper.ClampToByte(r * 255f), ByteHelper.ClampToByte(g * 255f), ByteHelper.ClampToByte(b * 255f), byte.MaxValue);
		}

		public Vector3 ToVector3()
		{
			return new Vector3(r, g, b);
		}

		internal float CalcLogDist(ColorRgbFloat other)
		{
			float num = (float)Math.Sign(other.r) * MathF.Log(1f + MathF.Abs(other.r)) - (float)Math.Sign(r) * MathF.Log(1f + MathF.Abs(r));
			float num2 = (float)Math.Sign(other.g) * MathF.Log(1f + MathF.Abs(other.g)) - (float)Math.Sign(g) * MathF.Log(1f + MathF.Abs(g));
			float num3 = (float)Math.Sign(other.b) * MathF.Log(1f + MathF.Abs(other.b)) - (float)Math.Sign(b) * MathF.Log(1f + MathF.Abs(b));
			return MathF.Sqrt(num * num + num2 * num2 + num3 * num3);
		}

		internal float CalcDist(ColorRgbFloat other)
		{
			float num = other.r - r;
			float num2 = other.g - g;
			float num3 = other.b - b;
			return MathF.Sqrt(num * num + num2 * num2 + num3 * num3);
		}

		internal void ClampToPositive()
		{
			if (r < 0f)
			{
				r = 0f;
			}
			if (g < 0f)
			{
				g = 0f;
			}
			if (b < 0f)
			{
				b = 0f;
			}
		}

		internal void ClampToHalf()
		{
			if (r < (float)Half.MinValue)
			{
				r = Half.MinValue;
			}
			else if (g > (float)Half.MaxValue)
			{
				g = Half.MaxValue;
			}
			if (b < (float)Half.MinValue)
			{
				b = Half.MinValue;
			}
			else if (r > (float)Half.MaxValue)
			{
				r = Half.MaxValue;
			}
			if (g < (float)Half.MinValue)
			{
				g = Half.MinValue;
			}
			else if (b > (float)Half.MaxValue)
			{
				b = Half.MaxValue;
			}
		}
	}
}
