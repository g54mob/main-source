using System;
using System.Runtime.InteropServices;

namespace BCnEncoder.Shared
{
	internal static class RgbBoundingBox
	{
		public static void Create565(ReadOnlySpan<ColorRgba32> colors, out ColorRgb565 min, out ColorRgb565 max)
		{
			int num = 255;
			int num2 = 255;
			int num3 = 255;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < colors.Length; i++)
			{
				ColorRgba32 colorRgba = colors[i];
				if (colorRgba.r < num)
				{
					num = colorRgba.r;
				}
				if (colorRgba.g < num2)
				{
					num2 = colorRgba.g;
				}
				if (colorRgba.b < num3)
				{
					num3 = colorRgba.b;
				}
				if (colorRgba.r > num4)
				{
					num4 = colorRgba.r;
				}
				if (colorRgba.g > num5)
				{
					num5 = colorRgba.g;
				}
				if (colorRgba.b > num6)
				{
					num6 = colorRgba.b;
				}
			}
			int num7 = num4 - num >> 4;
			int num8 = num5 - num2 >> 4;
			int num9 = num6 - num3 >> 4;
			num = (num << 4) + num7 >> 4;
			num2 = (num2 << 4) + num8 >> 4;
			num3 = (num3 << 4) + num9 >> 4;
			num4 = (num4 << 4) - num7 >> 4;
			num5 = (num5 << 4) - num8 >> 4;
			num6 = (num6 << 4) - num9 >> 4;
			num = ((num >= 0) ? num : 0);
			num2 = ((num2 >= 0) ? num2 : 0);
			num3 = ((num3 >= 0) ? num3 : 0);
			num4 = ((num4 <= 255) ? num4 : 255);
			num5 = ((num5 <= 255) ? num5 : 255);
			num6 = ((num6 <= 255) ? num6 : 255);
			num = (num & 0xF8) | (num >> 5);
			num2 = (num2 & 0xFC) | (num2 >> 6);
			num3 = (num3 & 0xF8) | (num3 >> 5);
			num4 = (num4 & 0xF8) | (num4 >> 5);
			num5 = (num5 & 0xFC) | (num5 >> 6);
			num6 = (num6 & 0xF8) | (num6 >> 5);
			min = new ColorRgb565((byte)num, (byte)num2, (byte)num3);
			max = new ColorRgb565((byte)num4, (byte)num5, (byte)num6);
		}

		public static void Create565AlphaCutoff(ReadOnlySpan<ColorRgba32> colors, out ColorRgb565 min, out ColorRgb565 max, int alphaCutoff = 128)
		{
			int num = 255;
			int num2 = 255;
			int num3 = 255;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			for (int i = 0; i < colors.Length; i++)
			{
				ColorRgba32 colorRgba = colors[i];
				if (colorRgba.a >= alphaCutoff)
				{
					if (colorRgba.r < num)
					{
						num = colorRgba.r;
					}
					if (colorRgba.g < num2)
					{
						num2 = colorRgba.g;
					}
					if (colorRgba.b < num3)
					{
						num3 = colorRgba.b;
					}
					if (colorRgba.r > num4)
					{
						num4 = colorRgba.r;
					}
					if (colorRgba.g > num5)
					{
						num5 = colorRgba.g;
					}
					if (colorRgba.b > num6)
					{
						num6 = colorRgba.b;
					}
				}
			}
			int num7 = num4 - num >> 4;
			int num8 = num5 - num2 >> 4;
			int num9 = num6 - num3 >> 4;
			num = (num << 4) + num7 >> 4;
			num2 = (num2 << 4) + num8 >> 4;
			num3 = (num3 << 4) + num9 >> 4;
			num4 = (num4 << 4) - num7 >> 4;
			num5 = (num5 << 4) - num8 >> 4;
			num6 = (num6 << 4) - num9 >> 4;
			num = ((num >= 0) ? num : 0);
			num2 = ((num2 >= 0) ? num2 : 0);
			num3 = ((num3 >= 0) ? num3 : 0);
			num4 = ((num4 <= 255) ? num4 : 255);
			num5 = ((num5 <= 255) ? num5 : 255);
			num6 = ((num6 <= 255) ? num6 : 255);
			num = (num & 0xF8) | (num >> 5);
			num2 = (num2 & 0xFC) | (num2 >> 6);
			num3 = (num3 & 0xF8) | (num3 >> 5);
			num4 = (num4 & 0xF8) | (num4 >> 5);
			num5 = (num5 & 0xFC) | (num5 >> 6);
			num6 = (num6 & 0xF8) | (num6 >> 5);
			min = new ColorRgb565((byte)num, (byte)num2, (byte)num3);
			max = new ColorRgb565((byte)num4, (byte)num5, (byte)num6);
		}

		public static void Create565A(ReadOnlySpan<ColorRgba32> colors, out ColorRgb565 min, out ColorRgb565 max, out byte minAlpha, out byte maxAlpha)
		{
			int num = 255;
			int num2 = 255;
			int num3 = 255;
			int num4 = 255;
			int num5 = 0;
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			for (int i = 0; i < colors.Length; i++)
			{
				ColorRgba32 colorRgba = colors[i];
				if (colorRgba.r < num)
				{
					num = colorRgba.r;
				}
				if (colorRgba.g < num2)
				{
					num2 = colorRgba.g;
				}
				if (colorRgba.b < num3)
				{
					num3 = colorRgba.b;
				}
				if (colorRgba.a < num4)
				{
					num4 = colorRgba.a;
				}
				if (colorRgba.r > num5)
				{
					num5 = colorRgba.r;
				}
				if (colorRgba.g > num6)
				{
					num6 = colorRgba.g;
				}
				if (colorRgba.b > num7)
				{
					num7 = colorRgba.b;
				}
				if (colorRgba.a > num8)
				{
					num8 = colorRgba.a;
				}
			}
			int num9 = num5 - num >> 4;
			int num10 = num6 - num2 >> 4;
			int num11 = num7 - num3 >> 4;
			int num12 = num8 - num4 >> 5;
			num = (num << 4) + num9 >> 4;
			num2 = (num2 << 4) + num10 >> 4;
			num3 = (num3 << 4) + num11 >> 4;
			num4 = (num4 << 5) + num12 >> 5;
			num5 = (num5 << 4) - num9 >> 4;
			num6 = (num6 << 4) - num10 >> 4;
			num7 = (num7 << 4) - num11 >> 4;
			num8 = (num8 << 5) - num12 >> 5;
			num = ((num >= 0) ? num : 0);
			num2 = ((num2 >= 0) ? num2 : 0);
			num3 = ((num3 >= 0) ? num3 : 0);
			num4 = ((num4 >= 0) ? num4 : 0);
			num5 = ((num5 <= 255) ? num5 : 255);
			num6 = ((num6 <= 255) ? num6 : 255);
			num7 = ((num7 <= 255) ? num7 : 255);
			num8 = ((num8 <= 255) ? num8 : 255);
			num = (num & 0xF8) | (num >> 5);
			num2 = (num2 & 0xFC) | (num2 >> 6);
			num3 = (num3 & 0xF8) | (num3 >> 5);
			num5 = (num5 & 0xF8) | (num5 >> 5);
			num6 = (num6 & 0xFC) | (num6 >> 6);
			num7 = (num7 & 0xF8) | (num7 >> 5);
			min = new ColorRgb565((byte)num, (byte)num2, (byte)num3);
			max = new ColorRgb565((byte)num5, (byte)num6, (byte)num7);
			minAlpha = (byte)num4;
			maxAlpha = (byte)num8;
		}

		private static void InsetHdrChannel(ReadOnlySpan<ColorRgbFloat> colors, int channel, ref float blockMax, ref float blockMin)
		{
			float offset = 0f;
			if (blockMin < 0f)
			{
				offset = 0f - blockMin;
				blockMin += offset;
				blockMax += offset;
			}
			ReadOnlySpan<float> span = MemoryMarshal.Cast<ColorRgbFloat, float>(colors);
			float num = blockMax;
			float num2 = blockMin;
			for (int i = 0; i < 16; i++)
			{
				num = MathF.Min(num, (Select(span, i) == blockMin) ? num : Select(span, i));
				num2 = MathF.Max(num2, (Select(span, i) == blockMax) ? num2 : Select(span, i));
			}
			float num3 = MathF.Log(num2 + 1f, 2f);
			float num4 = MathF.Log(num + 1f, 2f);
			float num5 = MathF.Log(blockMax + 1f, 2f);
			float num6 = MathF.Log(blockMin + 1f, 2f);
			float y = (num5 - num6) * (1f / 32f);
			num6 += MathF.Min(num4 - num6, y);
			num5 -= MathF.Min(num5 - num3, y);
			blockMin = MathF.Pow(2f, num6) - 1f - offset;
			blockMax = MathF.Pow(2f, num5) - 1f - offset;
			float Select(ReadOnlySpan<float> readOnlySpan, int num7)
			{
				return readOnlySpan[num7 * 3 + channel] + offset;
			}
		}

		public static void CreateFloat(ReadOnlySpan<ColorRgbFloat> colors, out ColorRgbFloat min, out ColorRgbFloat max)
		{
			float blockMin = float.MaxValue;
			float blockMin2 = float.MaxValue;
			float blockMin3 = float.MaxValue;
			float blockMax = float.MinValue;
			float blockMax2 = float.MinValue;
			float blockMax3 = float.MinValue;
			for (int i = 0; i < colors.Length; i++)
			{
				ColorRgbFloat colorRgbFloat = colors[i];
				if (colorRgbFloat.r < blockMin)
				{
					blockMin = colorRgbFloat.r;
				}
				if (colorRgbFloat.g < blockMin2)
				{
					blockMin2 = colorRgbFloat.g;
				}
				if (colorRgbFloat.b < blockMin3)
				{
					blockMin3 = colorRgbFloat.b;
				}
				if (colorRgbFloat.r > blockMax)
				{
					blockMax = colorRgbFloat.r;
				}
				if (colorRgbFloat.g > blockMax2)
				{
					blockMax2 = colorRgbFloat.g;
				}
				if (colorRgbFloat.b > blockMax3)
				{
					blockMax3 = colorRgbFloat.b;
				}
			}
			InsetHdrChannel(colors, 0, ref blockMax, ref blockMin);
			InsetHdrChannel(colors, 1, ref blockMax2, ref blockMin2);
			InsetHdrChannel(colors, 2, ref blockMax3, ref blockMin3);
			min = new ColorRgbFloat(blockMin, blockMin2, blockMin3);
			max = new ColorRgbFloat(blockMax, blockMax2, blockMax3);
		}
	}
}
