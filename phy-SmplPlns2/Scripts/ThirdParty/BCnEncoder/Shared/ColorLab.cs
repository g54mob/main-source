using System;

namespace BCnEncoder.Shared
{
	internal struct ColorLab
	{
		public float l;

		public float a;

		public float b;

		public ColorLab(float l, float a, float b)
		{
			this.l = l;
			this.a = a;
			this.b = b;
		}

		public ColorLab(ColorRgb24 color)
		{
			this = ColorToLab(color);
		}

		public ColorLab(ColorRgba32 color)
		{
			this = ColorToLab(new ColorRgb24(color.r, color.g, color.b));
		}

		public ColorLab(ColorRgbFloat color)
		{
			this = XyzToLab(new ColorXyz(color));
		}

		public static ColorLab ColorToLab(ColorRgb24 color)
		{
			return XyzToLab(new ColorXyz(color));
		}

		public static ColorLab XyzToLab(ColorXyz xyz)
		{
			float num = 95.047f;
			float num2 = 100f;
			float num3 = 108.883f;
			float num4 = PivotXyz(xyz.x / num);
			float num5 = PivotXyz(xyz.y / num2);
			float num6 = PivotXyz(xyz.z / num3);
			return new ColorLab(116f * num5 - 16f, 500f * (num4 - num5), 200f * (num5 - num6));
		}

		private static float PivotXyz(float n)
		{
			float result = MathF.Cbrt(n);
			if (!(n > 0.008856f))
			{
				return 7.787f * n + 0.13793103f;
			}
			return result;
		}
	}
}
