using System;

namespace BCnEncoder.Shared
{
	internal struct ColorRgbe : IEquatable<ColorRgbe>
	{
		public byte r;

		public byte g;

		public byte b;

		public byte e;

		public ColorRgbe(byte r, byte g, byte b, byte e)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.e = e;
		}

		public ColorRgbe(ColorRgbFloat color)
		{
			float num = MathF.Max(color.b, MathF.Max(color.g, color.r));
			if (num <= 1E-32f)
			{
				r = (g = (b = (e = 0)));
				return;
			}
			MathHelper.FrExp(num, out var eptr);
			float num2 = MathHelper.LdExp(1f, -eptr + 8);
			r = (byte)(num2 * color.r);
			g = (byte)(num2 * color.g);
			b = (byte)(num2 * color.b);
			e = (byte)(eptr + 128);
		}

		public ColorRgbFloat ToColorRgbFloat(float exposure = 1f)
		{
			if (e == 0)
			{
				return new ColorRgbFloat(0f, 0f, 0f);
			}
			float num = MathHelper.LdExp(1f, e - 136) / exposure;
			return new ColorRgbFloat(((float)(int)r + 0.5f) * num, ((float)(int)g + 0.5f) * num, ((float)(int)b + 0.5f) * num);
		}

		public bool Equals(ColorRgbe other)
		{
			if (r == other.r && g == other.g && b == other.b)
			{
				return e == other.e;
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj is ColorRgbe other)
			{
				return Equals(other);
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (((((r.GetHashCode() * 397) ^ g.GetHashCode()) * 397) ^ b.GetHashCode()) * 397) ^ e.GetHashCode();
		}

		public static bool operator ==(ColorRgbe left, ColorRgbe right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(ColorRgbe left, ColorRgbe right)
		{
			return !left.Equals(right);
		}

		public override string ToString()
		{
			return string.Format("{0}: {1}, {2}: {3}, {4}: {5}, {6}: {7}", "r", r, "g", g, "b", b, "e", e);
		}
	}
}
