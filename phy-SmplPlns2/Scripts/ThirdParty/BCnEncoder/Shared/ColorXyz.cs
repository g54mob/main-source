using System;

namespace BCnEncoder.Shared
{
	internal struct ColorXyz
	{
		public float x;

		public float y;

		public float z;

		public ColorXyz(float x, float y, float z)
		{
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public ColorXyz(ColorRgb24 color)
		{
			this = ColorToXyz(color);
		}

		public ColorXyz(ColorRgbFloat color)
		{
			this = ColorToXyz(color);
		}

		public ColorRgbFloat ToColorRgbFloat()
		{
			return new ColorRgbFloat(3.2404542f * x - 1.5371385f * y - 0.4985314f * z, -0.969266f * x + 1.8760108f * y + 0.041556f * z, 0.0556434f * x - 0.2040259f * y + 1.0572252f * z);
		}

		public static ColorXyz ColorToXyz(ColorRgb24 color)
		{
			float num = PivotRgb((float)(int)color.r / 255f);
			float num2 = PivotRgb((float)(int)color.g / 255f);
			float num3 = PivotRgb((float)(int)color.b / 255f);
			return new ColorXyz(num * 0.4124f + num2 * 0.3576f + num3 * 0.1805f, num * 0.2126f + num2 * 0.7152f + num3 * 0.0722f, num * 0.0193f + num2 * 0.1192f + num3 * 0.9505f);
		}

		public static ColorXyz ColorToXyz(ColorRgbFloat color)
		{
			float num = PivotRgb(color.r);
			float num2 = PivotRgb(color.g);
			float num3 = PivotRgb(color.b);
			return new ColorXyz(num * 0.4124f + num2 * 0.3576f + num3 * 0.1805f, num * 0.2126f + num2 * 0.7152f + num3 * 0.0722f, num * 0.0193f + num2 * 0.1192f + num3 * 0.9505f);
		}

		private static float PivotRgb(float n)
		{
			return ((n > 0.04045f) ? MathF.Pow((n + 0.055f) / 1.055f, 2.4f) : (n / 12.92f)) * 100f;
		}
	}
}
