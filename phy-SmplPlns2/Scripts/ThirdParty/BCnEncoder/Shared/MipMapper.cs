using System;
using CommunityToolkit.HighPerformance;

namespace BCnEncoder.Shared
{
	internal static class MipMapper
	{
		public static ReadOnlyMemory2D<ColorRgba32>[] GenerateMipChain(ReadOnlyMemory<ColorRgba32> input, int width, int height, ref int numMipMaps)
		{
			return GenerateMipChain(input.AsMemory2D(height, width), ref numMipMaps);
		}

		public static ReadOnlyMemory2D<ColorRgba32>[] GenerateMipChain(ReadOnlyMemory2D<ColorRgba32> pixels, ref int numMipMaps)
		{
			int width = pixels.Width;
			int height = pixels.Height;
			ReadOnlyMemory2D<ColorRgba32>[] array = new ReadOnlyMemory2D<ColorRgba32>[CalculateMipChainLength(width, height, numMipMaps)];
			array[0] = pixels;
			if (numMipMaps == 1)
			{
				return array;
			}
			if (numMipMaps <= 0)
			{
				numMipMaps = int.MaxValue;
			}
			for (int i = 1; i < numMipMaps; i++)
			{
				int num = Math.Max(1, width >> i);
				int num2 = Math.Max(1, height >> i);
				ColorRgba32[,] array2 = ResizeToHalf(array[i - 1].Span);
				array[i] = array2;
				if (num == 1 && num2 == 1)
				{
					numMipMaps = i + 1;
					break;
				}
			}
			return array;
		}

		public static ReadOnlyMemory2D<ColorRgbFloat>[] GenerateMipChain(ReadOnlyMemory<ColorRgbFloat> input, int width, int height, ref int numMipMaps)
		{
			return GenerateMipChain(input.AsMemory2D(height, width), ref numMipMaps);
		}

		public static ReadOnlyMemory2D<ColorRgbFloat>[] GenerateMipChain(ReadOnlyMemory2D<ColorRgbFloat> pixels, ref int numMipMaps)
		{
			int width = pixels.Width;
			int height = pixels.Height;
			ReadOnlyMemory2D<ColorRgbFloat>[] array = new ReadOnlyMemory2D<ColorRgbFloat>[CalculateMipChainLength(width, height, numMipMaps)];
			array[0] = pixels;
			if (numMipMaps == 1)
			{
				return array;
			}
			if (numMipMaps <= 0)
			{
				numMipMaps = int.MaxValue;
			}
			for (int i = 1; i < numMipMaps; i++)
			{
				int num = Math.Max(1, width >> i);
				int num2 = Math.Max(1, height >> i);
				ColorRgbFloat[,] array2 = ResizeToHalf(array[i - 1].Span);
				array[i] = array2;
				if (num == 1 && num2 == 1)
				{
					numMipMaps = i + 1;
					break;
				}
			}
			return array;
		}

		public static int CalculateMipChainLength(int width, int height, int maxNumMipMaps)
		{
			if (maxNumMipMaps == 1)
			{
				return 1;
			}
			if (maxNumMipMaps <= 0)
			{
				maxNumMipMaps = int.MaxValue;
			}
			int result = 0;
			for (int i = 1; i <= maxNumMipMaps; i++)
			{
				int num = Math.Max(1, width >> i);
				int num2 = Math.Max(1, height >> i);
				if (i == maxNumMipMaps)
				{
					return maxNumMipMaps;
				}
				if (num == 1 && num2 == 1)
				{
					result = i + 1;
					break;
				}
			}
			return result;
		}

		public static void CalculateMipLevelSize(int width, int height, int mipIdx, out int mipWidth, out int mipHeight)
		{
			mipWidth = Math.Max(1, width >> mipIdx);
			mipHeight = Math.Max(1, height >> mipIdx);
		}

		private static ColorRgba32[,] ResizeToHalf(ReadOnlySpan2D<ColorRgba32> pixelsRgba)
		{
			int oldWidth = pixelsRgba.Width;
			int oldHeight = pixelsRgba.Height;
			int num = Math.Max(1, oldWidth >> 1);
			int num2 = Math.Max(1, oldHeight >> 1);
			ColorRgba32[,] array = new ColorRgba32[num2, num];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					ColorRgbaFloat colorRgbaFloat = pixelsRgba[ClampH(i * 2), ClampW(j * 2)].ToFloat();
					ColorRgbaFloat colorRgbaFloat2 = pixelsRgba[ClampH(i * 2), ClampW(j * 2 + 1)].ToFloat();
					ColorRgbaFloat colorRgbaFloat3 = pixelsRgba[ClampH(i * 2 + 1), ClampW(j * 2)].ToFloat();
					ColorRgbaFloat colorRgbaFloat4 = pixelsRgba[ClampH(i * 2 + 1), ClampW(j * 2 + 1)].ToFloat();
					array[i, j] = ((colorRgbaFloat + colorRgbaFloat2 + colorRgbaFloat3 + colorRgbaFloat4) / 4f).ToRgba32();
				}
			}
			return array;
			int ClampH(int y)
			{
				return Math.Max(0, Math.Min(oldHeight - 1, y));
			}
			int ClampW(int x)
			{
				return Math.Max(0, Math.Min(oldWidth - 1, x));
			}
		}

		private static ColorRgbFloat[,] ResizeToHalf(ReadOnlySpan2D<ColorRgbFloat> pixelsRgba)
		{
			int oldWidth = pixelsRgba.Width;
			int oldHeight = pixelsRgba.Height;
			int num = Math.Max(1, oldWidth >> 1);
			int num2 = Math.Max(1, oldHeight >> 1);
			ColorRgbFloat[,] array = new ColorRgbFloat[num2, num];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					ColorRgbFloat colorRgbFloat = pixelsRgba[ClampH(i * 2), ClampW(j * 2)];
					ColorRgbFloat colorRgbFloat2 = pixelsRgba[ClampH(i * 2), ClampW(j * 2 + 1)];
					ColorRgbFloat colorRgbFloat3 = pixelsRgba[ClampH(i * 2 + 1), ClampW(j * 2)];
					ColorRgbFloat colorRgbFloat4 = pixelsRgba[ClampH(i * 2 + 1), ClampW(j * 2 + 1)];
					array[i, j] = (colorRgbFloat + colorRgbFloat2 + colorRgbFloat3 + colorRgbFloat4) / 4f;
				}
			}
			return array;
			int ClampH(int y)
			{
				return Math.Max(0, Math.Min(oldHeight - 1, y));
			}
			int ClampW(int x)
			{
				return Math.Max(0, Math.Min(oldWidth - 1, x));
			}
		}
	}
}
