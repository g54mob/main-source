using System;

namespace BCnEncoder.Shared
{
	public class ImageQuality
	{
		public static float PeakSignalToNoiseRatio(ReadOnlySpan<ColorRgba32> original, ReadOnlySpan<ColorRgba32> other, bool countAlpha = true)
		{
			if (original.Length != other.Length)
			{
				throw new ArgumentException("Both spans should be the same length");
			}
			float num = 0f;
			for (int i = 0; i < original.Length; i++)
			{
				ColorYCbCr colorYCbCr = new ColorYCbCr(original[i]);
				ColorYCbCr colorYCbCr2 = new ColorYCbCr(other[i]);
				num += (colorYCbCr.y - colorYCbCr2.y) * (colorYCbCr.y - colorYCbCr2.y);
				num += (colorYCbCr.cb - colorYCbCr2.cb) * (colorYCbCr.cb - colorYCbCr2.cb);
				num += (colorYCbCr.cr - colorYCbCr2.cr) * (colorYCbCr.cr - colorYCbCr2.cr);
				if (countAlpha)
				{
					num += (float)(original[i].a - other[i].a) / 255f * ((float)(original[i].a - other[i].a) / 255f);
				}
			}
			if (num < float.Epsilon)
			{
				return 100f;
			}
			num = ((!countAlpha) ? (num / (float)(original.Length * 3)) : (num / (float)(original.Length * 4)));
			return 20f * MathF.Log10(1f / MathF.Sqrt(num));
		}

		public static float CalculateLogRMSE(ReadOnlySpan<ColorRgbFloat> original, ReadOnlySpan<ColorRgbFloat> other)
		{
			if (original.Length != other.Length)
			{
				throw new ArgumentException("Both spans should be the same length");
			}
			float num = 0f;
			for (int i = 0; i < original.Length; i++)
			{
				float num2 = (float)Math.Sign(other[i].r) * MathF.Log(1f + MathF.Abs(other[i].r)) - (float)Math.Sign(original[i].r) * MathF.Log(1f + MathF.Abs(original[i].r));
				float num3 = (float)Math.Sign(other[i].g) * MathF.Log(1f + MathF.Abs(other[i].g)) - (float)Math.Sign(original[i].g) * MathF.Log(1f + MathF.Abs(original[i].g));
				float num4 = (float)Math.Sign(other[i].b) * MathF.Log(1f + MathF.Abs(other[i].b)) - (float)Math.Sign(original[i].b) * MathF.Log(1f + MathF.Abs(original[i].b));
				num += num2 * num2;
				num += num3 * num3;
				num += num4 * num4;
			}
			return MathF.Sqrt(num / (3f * (float)original.Length));
		}

		public static float PeakSignalToNoiseRatioLuminance(ReadOnlySpan<ColorRgba32> original, ReadOnlySpan<ColorRgba32> other, bool countAlpha = true)
		{
			if (original.Length != other.Length)
			{
				throw new ArgumentException("Both spans should be the same length");
			}
			float num = 0f;
			for (int i = 0; i < original.Length; i++)
			{
				ColorYCbCr colorYCbCr = new ColorYCbCr(original[i]);
				ColorYCbCr colorYCbCr2 = new ColorYCbCr(other[i]);
				num += (colorYCbCr.y - colorYCbCr2.y) * (colorYCbCr.y - colorYCbCr2.y);
				if (countAlpha)
				{
					num += (float)(original[i].a - other[i].a) / 255f * ((float)(original[i].a - other[i].a) / 255f);
				}
			}
			if (num < float.Epsilon)
			{
				return 100f;
			}
			num = ((!countAlpha) ? (num / (float)original.Length) : (num / (float)(original.Length * 2)));
			return 20f * MathF.Log10(1f / MathF.Sqrt(num));
		}
	}
}
