using CommunityToolkit.HighPerformance;

namespace BCnEncoder.Shared
{
	internal static class ImageToBlocks
	{
		internal static ColorRgba32[] ColorsFromRawBlocks(RawBlock4X4Rgba32[,] blocks, int pixelWidth, int pixelHeight)
		{
			ColorRgba32[] array = new ColorRgba32[pixelWidth * pixelHeight];
			for (int i = 0; i < pixelHeight; i++)
			{
				for (int j = 0; j < pixelWidth; j++)
				{
					int num = j >> 2;
					int num2 = i >> 2;
					int x = j & 3;
					int y = i & 3;
					array[j + i * pixelWidth] = blocks[num, num2][x, y];
				}
			}
			return array;
		}

		internal static ColorRgba32[] ColorsFromRawBlocks(RawBlock4X4Rgba32[] blocks, int pixelWidth, int pixelHeight)
		{
			int num = ((pixelWidth + 3) & -4) >> 2;
			ColorRgba32[] array = new ColorRgba32[pixelWidth * pixelHeight];
			for (int i = 0; i < pixelHeight; i++)
			{
				for (int j = 0; j < pixelWidth; j++)
				{
					int num2 = j >> 2;
					int num3 = i >> 2;
					int x = j & 3;
					int y = i & 3;
					int num4 = num2 + num3 * num;
					array[j + i * pixelWidth] = blocks[num4][x, y];
				}
			}
			return array;
		}

		internal static ColorRgbFloat[] ColorsFromRawBlocks(RawBlock4X4RgbFloat[] blocks, int pixelWidth, int pixelHeight)
		{
			int num = ((pixelWidth + 3) & -4) >> 2;
			ColorRgbFloat[] array = new ColorRgbFloat[pixelWidth * pixelHeight];
			for (int i = 0; i < pixelHeight; i++)
			{
				for (int j = 0; j < pixelWidth; j++)
				{
					int num2 = j >> 2;
					int num3 = i >> 2;
					int x = j & 3;
					int y = i & 3;
					int num4 = num2 + num3 * num;
					array[j + i * pixelWidth] = blocks[num4][x, y];
				}
			}
			return array;
		}

		internal static RawBlock4X4Rgba32[] ImageTo4X4(ReadOnlyMemory2D<ColorRgba32> image, out int blocksWidth, out int blocksHeight)
		{
			blocksWidth = ((image.Width + 3) & -4) >> 2;
			blocksHeight = ((image.Height + 3) & -4) >> 2;
			RawBlock4X4Rgba32[] array = new RawBlock4X4Rgba32[blocksWidth * blocksHeight];
			ReadOnlySpan2D<ColorRgba32> span = image.Span;
			for (int i = 0; i < image.Height; i++)
			{
				for (int j = 0; j < image.Width; j++)
				{
					ColorRgba32 value = span[i, j];
					int num = j >> 2;
					int num2 = i >> 2;
					int x = j & 3;
					int y = i & 3;
					array[num + num2 * blocksWidth][x, y] = value;
				}
			}
			if ((image.Height & 3) != 0)
			{
				int num3 = image.Height & 3;
				for (int k = 0; k < blocksWidth; k++)
				{
					RawBlock4X4Rgba32 rawBlock4X4Rgba = array[k + blocksWidth * (blocksHeight - 1)];
					for (int l = num3; l < 4; l++)
					{
						for (int m = 0; m < 4; m++)
						{
							rawBlock4X4Rgba[m, l] = rawBlock4X4Rgba[m, l - 1];
						}
					}
					array[k + blocksWidth * (blocksHeight - 1)] = rawBlock4X4Rgba;
				}
			}
			if ((image.Width & 3) != 0)
			{
				int num4 = image.Width & 3;
				for (int n = 0; n < blocksHeight; n++)
				{
					RawBlock4X4Rgba32 rawBlock4X4Rgba2 = array[blocksWidth - 1 + n * blocksWidth];
					for (int num5 = num4; num5 < 4; num5++)
					{
						for (int num6 = 0; num6 < 4; num6++)
						{
							rawBlock4X4Rgba2[num5, num6] = rawBlock4X4Rgba2[num5 - 1, num6];
						}
					}
					array[blocksWidth - 1 + n * blocksWidth] = rawBlock4X4Rgba2;
				}
			}
			return array;
		}

		internal static RawBlock4X4RgbFloat[] ImageTo4X4(ReadOnlyMemory2D<ColorRgbFloat> image, out int blocksWidth, out int blocksHeight)
		{
			blocksWidth = ((image.Width + 3) & -4) >> 2;
			blocksHeight = ((image.Height + 3) & -4) >> 2;
			RawBlock4X4RgbFloat[] array = new RawBlock4X4RgbFloat[blocksWidth * blocksHeight];
			ReadOnlySpan2D<ColorRgbFloat> span = image.Span;
			for (int i = 0; i < image.Height; i++)
			{
				for (int j = 0; j < image.Width; j++)
				{
					ColorRgbFloat value = span[i, j];
					int num = j >> 2;
					int num2 = i >> 2;
					int x = j & 3;
					int y = i & 3;
					array[num + num2 * blocksWidth][x, y] = value;
				}
			}
			if ((image.Height & 3) != 0)
			{
				int num3 = image.Height & 3;
				for (int k = 0; k < blocksWidth; k++)
				{
					RawBlock4X4RgbFloat rawBlock4X4RgbFloat = array[k + blocksWidth * (blocksHeight - 1)];
					for (int l = num3; l < 4; l++)
					{
						for (int m = 0; m < 4; m++)
						{
							rawBlock4X4RgbFloat[m, l] = rawBlock4X4RgbFloat[m, l - 1];
						}
					}
					array[k + blocksWidth * (blocksHeight - 1)] = rawBlock4X4RgbFloat;
				}
			}
			if ((image.Width & 3) != 0)
			{
				int num4 = image.Width & 3;
				for (int n = 0; n < blocksHeight; n++)
				{
					RawBlock4X4RgbFloat rawBlock4X4RgbFloat2 = array[blocksWidth - 1 + n * blocksWidth];
					for (int num5 = num4; num5 < 4; num5++)
					{
						for (int num6 = 0; num6 < 4; num6++)
						{
							rawBlock4X4RgbFloat2[num5, num6] = rawBlock4X4RgbFloat2[num5 - 1, num6];
						}
					}
					array[blocksWidth - 1 + n * blocksWidth] = rawBlock4X4RgbFloat2;
				}
			}
			return array;
		}

		public static int CalculateNumOfBlocks(int pixelWidth, int pixelHeight)
		{
			int num = ((pixelWidth + 3) & -4) >> 2;
			int num2 = ((pixelHeight + 3) & -4) >> 2;
			return num * num2;
		}

		public static void CalculateNumOfBlocks(int pixelWidth, int pixelHeight, out int blocksWidth, out int blocksHeight)
		{
			blocksWidth = ((pixelWidth + 3) & -4) >> 2;
			blocksHeight = ((pixelHeight + 3) & -4) >> 2;
		}
	}
}
