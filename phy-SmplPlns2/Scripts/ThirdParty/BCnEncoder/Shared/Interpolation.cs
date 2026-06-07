namespace BCnEncoder.Shared
{
	internal static class Interpolation
	{
		public static ColorRgb24 InterpolateHalf(this ColorRgb24 c0, ColorRgb24 c1)
		{
			return InterpolateColor(c0, c1, 1, 2);
		}

		public static ColorRgb24 InterpolateThird(this ColorRgb24 c0, ColorRgb24 c1, int num)
		{
			return InterpolateColor(c0, c1, num, 3);
		}

		public static ColorRgb24 InterpolateFourthAtc(this ColorRgb24 c0, ColorRgb24 c1, int num)
		{
			return InterpolateColorAtc(c0, c1, num, 4);
		}

		public static byte InterpolateFifth(this byte a0, byte a1, int num)
		{
			return (byte)Interpolate(a0, a1, num, 5, 2);
		}

		public static byte InterpolateSeventh(this byte a0, byte a1, int num)
		{
			return (byte)Interpolate(a0, a1, num, 7, 3);
		}

		private static ColorRgb24 InterpolateColor(ColorRgb24 c0, ColorRgb24 c1, int num, int den)
		{
			return new ColorRgb24((byte)Interpolate(c0.r, c1.r, num, den), (byte)Interpolate(c0.g, c1.g, num, den), (byte)Interpolate(c0.b, c1.b, num, den));
		}

		private static ColorRgb24 InterpolateColorAtc(ColorRgb24 c0, ColorRgb24 c1, int num, int den)
		{
			return new ColorRgb24((byte)InterpolateAtc(c0.r, c1.r, num, den), (byte)InterpolateAtc(c0.g, c1.g, num, den), (byte)InterpolateAtc(c0.b, c1.b, num, den));
		}

		private static int Interpolate(int a, int b, int num, int den, int correction = 0)
		{
			return (int)((float)((den - num) * a + num * b + correction) / (float)den);
		}

		private static int InterpolateAtc(int a, int b, int num, int den)
		{
			return (int)((float)a - (float)num / (float)den * (float)b);
		}
	}
}
