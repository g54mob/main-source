using System;
using BCnEncoder.Shared;

namespace BCnEncoder.Encoder
{
	internal static class ColorChooser
	{
		public static int ChooseClosestColor4(ReadOnlySpan<ColorRgb24> colors, ColorRgba32 color, float rWeight, float gWeight, float bWeight, out float error)
		{
			ReadOnlySpan<float> readOnlySpan = stackalloc float[4]
			{
				MathF.Abs(colors[0].r - color.r) * rWeight + MathF.Abs(colors[0].g - color.g) * gWeight + MathF.Abs(colors[0].b - color.b) * bWeight,
				MathF.Abs(colors[1].r - color.r) * rWeight + MathF.Abs(colors[1].g - color.g) * gWeight + MathF.Abs(colors[1].b - color.b) * bWeight,
				MathF.Abs(colors[2].r - color.r) * rWeight + MathF.Abs(colors[2].g - color.g) * gWeight + MathF.Abs(colors[2].b - color.b) * bWeight,
				MathF.Abs(colors[3].r - color.r) * rWeight + MathF.Abs(colors[3].g - color.g) * gWeight + MathF.Abs(colors[3].b - color.b) * bWeight
			};
			int num = ((readOnlySpan[0] > readOnlySpan[3]) ? 1 : 0);
			int num2 = ((readOnlySpan[1] > readOnlySpan[2]) ? 1 : 0);
			int num3 = ((readOnlySpan[0] > readOnlySpan[2]) ? 1 : 0);
			int num4 = ((readOnlySpan[1] > readOnlySpan[3]) ? 1 : 0);
			int num5 = ((readOnlySpan[2] > readOnlySpan[3]) ? 1 : 0);
			int num6 = num2 & num3;
			int num7 = num & num4;
			int num8 = (num & num5) | ((num6 | num7) << 1);
			error = readOnlySpan[num8];
			return num8;
		}

		public static int ChooseClosestColor4AlphaCutoff(ReadOnlySpan<ColorRgb24> colors, ColorRgba32 color, float rWeight, float gWeight, float bWeight, int alphaCutoff, bool hasAlpha, out float error)
		{
			if (hasAlpha && color.a < alphaCutoff)
			{
				error = 0f;
				return 3;
			}
			ReadOnlySpan<float> readOnlySpan = stackalloc float[4]
			{
				MathF.Abs(colors[0].r - color.r) * rWeight + MathF.Abs(colors[0].g - color.g) * gWeight + MathF.Abs(colors[0].b - color.b) * bWeight,
				MathF.Abs(colors[1].r - color.r) * rWeight + MathF.Abs(colors[1].g - color.g) * gWeight + MathF.Abs(colors[1].b - color.b) * bWeight,
				MathF.Abs(colors[2].r - color.r) * rWeight + MathF.Abs(colors[2].g - color.g) * gWeight + MathF.Abs(colors[2].b - color.b) * bWeight,
				hasAlpha ? 999f : (MathF.Abs(colors[3].r - color.r) * rWeight + MathF.Abs(colors[3].g - color.g) * gWeight + MathF.Abs(colors[3].b - color.b) * bWeight)
			};
			int num = ((readOnlySpan[0] > readOnlySpan[2]) ? 1 : 0);
			int num2 = ((readOnlySpan[1] > readOnlySpan[3]) ? 1 : 0);
			int num3 = ((readOnlySpan[0] > readOnlySpan[3]) ? 1 : 0);
			int num4 = ((readOnlySpan[1] > readOnlySpan[2]) ? 1 : 0);
			bool num5 = !(readOnlySpan[1] > readOnlySpan[2]);
			int num6 = ((readOnlySpan[0] > readOnlySpan[1]) ? 1 : 0);
			int num7 = ((readOnlySpan[2] > readOnlySpan[3]) ? 1 : 0);
			int num8 = (int)(((num5 ? 1u : 0u) & (uint)num6) | (uint)(num3 & num7)) | (((num & num4) | (num2 & num3)) << 1);
			error = readOnlySpan[num8];
			return num8;
		}

		public static int ChooseClosestColor(Span<ColorRgb24> colors, ColorRgba32 color)
		{
			int result = 0;
			int num = Math.Abs(colors[0].r - color.r) + Math.Abs(colors[0].g - color.g) + Math.Abs(colors[0].b - color.b);
			for (int i = 1; i < colors.Length; i++)
			{
				int num2 = Math.Abs(colors[i].r - color.r) + Math.Abs(colors[i].g - color.g) + Math.Abs(colors[i].b - color.b);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public static int ChooseClosestColor(Span<ColorRgba32> colors, ColorRgba32 color)
		{
			int result = 0;
			int num = Math.Abs(colors[0].r - color.r) + Math.Abs(colors[0].g - color.g) + Math.Abs(colors[0].b - color.b) + Math.Abs(colors[0].a - color.a);
			for (int i = 1; i < colors.Length; i++)
			{
				int num2 = Math.Abs(colors[i].r - color.r) + Math.Abs(colors[i].g - color.g) + Math.Abs(colors[i].b - color.b) + Math.Abs(colors[i].a - color.a);
				if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public static int ChooseClosestColorAlphaCutOff(Span<ColorRgba32> colors, ColorRgba32 color, byte alphaCutOff = 127)
		{
			if (color.a <= alphaCutOff)
			{
				return 3;
			}
			int result = 0;
			int num = Math.Abs(colors[0].r - color.r) + Math.Abs(colors[0].g - color.g) + Math.Abs(colors[0].b - color.b);
			for (int i = 1; i < colors.Length; i++)
			{
				if (i != 3)
				{
					int num2 = Math.Abs(colors[i].r - color.r) + Math.Abs(colors[i].g - color.g) + Math.Abs(colors[i].b - color.b);
					if (num2 < num)
					{
						result = i;
						num = num2;
					}
				}
			}
			return result;
		}

		public static int ChooseClosestColor(Span<ColorYCbCr> colors, ColorYCbCr color, float luminanceMultiplier = 4f)
		{
			int result = 0;
			float num = 0f;
			bool flag = true;
			for (int i = 0; i < colors.Length; i++)
			{
				float num2 = MathF.Abs(colors[i].y - color.y) * luminanceMultiplier + MathF.Abs(colors[i].cb - color.cb) + MathF.Abs(colors[i].cr - color.cr);
				if (flag)
				{
					num = num2;
					flag = false;
				}
				else if (num2 < num)
				{
					result = i;
					num = num2;
				}
			}
			return result;
		}

		public static int ChooseClosestColor(Span<ColorYCbCr> colors, ColorRgba32 color, float luminanceMultiplier = 4f)
		{
			return ChooseClosestColor(colors, new ColorYCbCr(color), luminanceMultiplier);
		}
	}
}
