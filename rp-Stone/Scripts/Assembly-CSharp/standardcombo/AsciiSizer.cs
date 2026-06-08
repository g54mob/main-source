using System;

namespace standardcombo
{
	public class AsciiSizer
	{
		public struct Result
		{
			public int fontIndex;

			public Size fontSize;

			public Size idealFontSize;

			public Size gridSize;

			public Size padding;

			public float errorX;

			public float errorY;

			public string message;

			public bool warning;
		}

		public struct Size
		{
			public int width;

			public int height;

			public Size(int width, int height)
			{
				this.width = width;
				this.height = height;
			}
		}

		private struct Attempt
		{
			public int fontSize;

			public int gridSize;

			public int padding;

			public float error;
		}

		private const float paddedErrorLimit = 0.5f;

		public static Result FindBestSizes(Size[] availableFontSizes, int screenWidth, int screenHeight, int minColumnCount, int maxColumnCount, int minRowCount, int maxRowCount, float maxClipPixelPercentX = 0.2f, float maxClipPixelPercentY = 0.2f)
		{
			if (availableFontSizes == null || availableFontSizes.Length == 0)
			{
				throw new ArgumentException("AsciiSizer::FindBestSizes() requires a list of available font sizes.");
			}
			Result result = new Result
			{
				errorX = 999f,
				errorY = 999f
			};
			for (int i = 0; i < availableFontSizes.Length; i++)
			{
				Result result2 = FitFont(availableFontSizes[i], screenWidth, screenHeight, maxColumnCount, maxRowCount, maxClipPixelPercentX, maxClipPixelPercentY);
				if ((result.errorX + result.errorY > result2.errorX + result2.errorY && result2.gridSize.width >= minColumnCount && result2.gridSize.height >= minRowCount) || (result.gridSize.width < minColumnCount && minColumnCount - result.gridSize.width > minColumnCount - result2.gridSize.width) || (result.gridSize.height < minRowCount && minRowCount - result.gridSize.height > minRowCount - result2.gridSize.height))
				{
					result = result2;
					result.fontIndex = i;
				}
			}
			if (Math.Abs(result.padding.width) > result.fontSize.width || Math.Abs(result.padding.height) > result.fontSize.height)
			{
				result.warning = true;
			}
			result.message = "Selecting font " + result.fontSize.width + "x" + result.fontSize.height;
			ref string message = ref result.message;
			message = message + ". Grid size = " + result.gridSize.width + "x" + result.gridSize.height;
			message = ref result.message;
			message = message + ". Padding = " + result.padding.width + "," + result.padding.height;
			return result;
		}

		public static Result FitFont(Size fontSize, int screenWidth, int screenHeight, int maxColumnCount, int maxRowCount, float maxClipPixelPercentX = 0.2f, float maxClipPixelPercentY = 0.2f)
		{
			Attempt attempt = FitDimension(fontSize.width, screenWidth, maxColumnCount, maxClipPixelPercentX);
			Attempt attempt2 = FitDimension(fontSize.height, screenHeight, maxRowCount, maxClipPixelPercentY);
			return new Result
			{
				fontIndex = -1,
				fontSize = fontSize,
				idealFontSize = fontSize,
				gridSize = 
				{
					width = attempt.gridSize,
					height = attempt2.gridSize
				},
				padding = 
				{
					width = attempt.padding,
					height = attempt2.padding
				},
				errorX = attempt.error,
				errorY = attempt2.error
			};
		}

		private static Attempt FitDimension(int fontSize, int screenSize, int maxGrid, float maxClipPixelPercent)
		{
			Attempt result = default(Attempt);
			float num = (float)screenSize / (float)fontSize;
			int value = (int)Math.Floor(num);
			value = Clamp(value, 1, maxGrid);
			int num2 = screenSize - fontSize * value;
			int value2 = (int)Math.Ceiling(num);
			value2 = Clamp(value2, 1, maxGrid);
			int num3 = fontSize * value2 - screenSize;
			float num4 = (float)num3 / (float)fontSize;
			float num5 = num4 * 0.5f / maxClipPixelPercent;
			float num6 = (float)num2 / (float)fontSize;
			if (num6 < 0f || (num4 >= 0f && num4 <= maxClipPixelPercent && num5 < num6))
			{
				result.fontSize = fontSize;
				result.gridSize = value2;
				result.padding = -num3;
				result.error = num5;
			}
			else
			{
				result.fontSize = fontSize;
				result.gridSize = value;
				result.padding = num2;
				result.error = num6;
			}
			return result;
		}

		public static Result FindIdealSizes(int screenWidth, int screenHeight, int preferredRowCount, int minRowCount, int maxRowCount, int maxColumnCount, float idealFontWidthDividedByHeight = 1f, float maxClipPixelPercentX = 0.2f, float maxClipPixelPercentY = 0.2f)
		{
			Result result = new Result
			{
				fontIndex = -1
			};
			int num = maxRowCount - minRowCount + 1;
			if (num <= 0 || preferredRowCount <= 0 || minRowCount <= 0 || preferredRowCount < minRowCount || preferredRowCount > maxRowCount)
			{
				throw new ArgumentException("invalid preferredRowCount, minRowCount and maxRowCount arguments.");
			}
			Attempt[] array = new Attempt[num];
			array[0].gridSize = preferredRowCount;
			int num2 = preferredRowCount;
			int num3 = preferredRowCount;
			for (int i = 1; i < num; i++)
			{
				if (num2 + 1 > maxRowCount || (i % 2 != 1 && num3 - 1 >= minRowCount))
				{
					num3 = (array[i].gridSize = num3 - 1);
				}
				else
				{
					num2 = (array[i].gridSize = num2 + 1);
				}
			}
			for (int j = 0; j < num; j++)
			{
				int gridSize = array[j].gridSize;
				float num4 = (float)screenHeight / (float)gridSize;
				int num5 = (int)Math.Floor(num4);
				int num6 = screenHeight - num5 * gridSize;
				int num7 = (int)Math.Ceiling(num4);
				int num8 = num7 * gridSize - screenHeight;
				float num9 = (float)num8 / (float)num7;
				float num10 = num9 * 0.5f / maxClipPixelPercentY;
				float num11 = (float)num6 / (float)num5;
				if (num9 <= maxClipPixelPercentY && num10 < num11)
				{
					array[j].fontSize = num7;
					array[j].error = num10;
					array[j].padding = -num8;
				}
				else
				{
					array[j].fontSize = num5;
					array[j].error = num11;
					array[j].padding = num6;
				}
			}
			Attempt attempt = default(Attempt);
			float num12 = 999f;
			for (int k = 0; k < num; k++)
			{
				float error = array[k].error;
				if (num12 > error)
				{
					num12 = error;
					attempt = array[k];
				}
			}
			int fontSize = attempt.fontSize;
			result.idealFontSize.height = fontSize;
			result.gridSize.height = attempt.gridSize;
			result.errorY = num12;
			float num13 = idealFontWidthDividedByHeight * (float)fontSize;
			int num14 = (int)Math.Round(num13);
			int num15 = (int)Math.Floor(num13);
			float num16 = 999f;
			for (int l = num15; l <= num15 + 1; l++)
			{
				if (l != num14 && Math.Abs((float)l - num13) >= 0.65f)
				{
					continue;
				}
				float num17 = (float)screenWidth / (float)l;
				int num18 = (int)Math.Floor(num17);
				int num19 = screenWidth - num18 * l;
				int num20 = (int)Math.Ceiling(num17);
				float num21 = (float)(num20 * l - screenWidth) / (float)l;
				float num22 = num21 * 0.5f / maxClipPixelPercentX;
				float num23 = (float)num19 / (float)l;
				if (num21 <= maxClipPixelPercentX && num22 < num23)
				{
					if (num16 > num22)
					{
						num16 = num22;
						result.idealFontSize.width = l;
						result.gridSize.width = num20;
					}
				}
				else if (num16 > num23)
				{
					num16 = num23;
					result.idealFontSize.width = l;
					result.gridSize.width = num18;
				}
			}
			result.fontSize = result.idealFontSize;
			result.gridSize.width = Math.Min(maxColumnCount, result.gridSize.width);
			result.errorX = num16;
			result.padding.width = screenWidth - result.gridSize.width * result.fontSize.width;
			result.padding.height = screenHeight - result.gridSize.height * result.fontSize.height;
			ref string message = ref result.message;
			message = message + ". Grid size = " + result.gridSize.width + "x" + result.gridSize.height;
			message = ref result.message;
			message = message + ". Padding = " + result.padding.width + "," + result.padding.height;
			return result;
		}

		private static int Clamp(int value, int min, int max)
		{
			if (value < min)
			{
				return min;
			}
			if (value > max)
			{
				return max;
			}
			return value;
		}
	}
}
