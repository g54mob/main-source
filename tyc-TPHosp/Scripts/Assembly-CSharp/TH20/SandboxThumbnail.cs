using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public static class SandboxThumbnail
	{
		[UsedImplicitly(ImplicitUseTargetFlags.Members)]
		public class Style
		{
			[SerializeField]
			private int _width = 256;

			[SerializeField]
			private int _height = 128;

			[SerializeField]
			private int _border = 4;

			[SerializeField]
			private Color _tileColor1 = Color.white;

			[SerializeField]
			private Color _tileColor2 = Color.grey;

			[SerializeField]
			private Color _landscapeColor;

			[SerializeField]
			private float _landscapePerlinScale = 0.1f;

			[SerializeField]
			private float _landscapePerlinRange = 0.25f;

			public int Border => _border;

			public Color GetLandscapeColor(int x, int y)
			{
				float num = Mathf.PerlinNoise((float)x * _landscapePerlinScale, (float)y * _landscapePerlinScale) * _landscapePerlinRange;
				return _landscapeColor * (1f - num);
			}

			public Color GetTileColor(int x, int y)
			{
				if ((((x >> 2) + (y >> 2)) & 1) != 0)
				{
					return _tileColor2;
				}
				return _tileColor1;
			}

			public Texture2D CreateTexture()
			{
				return new Texture2D(_width, _height, TextureFormat.ARGB32, mipChain: true);
			}
		}

		private static Color32[] Rotate90(Color32[] data, int w, int h)
		{
			Color32[] array = new Color32[w * h];
			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < w; j++)
				{
					array[i + (w - j - 1) * h] = data[j + i * w];
				}
			}
			return array;
		}

		private static Color32[] Crop(Color32[] data, int width, int cropX, int cropY, int cropWidth, int cropHeight)
		{
			Color32[] array = new Color32[cropWidth * cropHeight];
			for (int i = 0; i < cropHeight; i++)
			{
				for (int j = 0; j < cropWidth; j++)
				{
					int num = j + cropX;
					int num2 = i + cropY;
					array[j + i * cropWidth] = data[num + num2 * width];
				}
			}
			return array;
		}

		private static Color32[] Scale(Color32[] source, int srcWidth, int srcHeight, int dstWidth, int dstHeight)
		{
			int num = 0;
			int num2 = 0;
			int num3 = dstWidth;
			int num4 = dstHeight;
			float num5 = (float)dstWidth / (float)srcWidth;
			float num6 = (float)dstHeight / (float)srcHeight;
			Color32[] array = new Color32[dstWidth * dstHeight];
			if (num5 > num6)
			{
				float num7 = (float)srcWidth * num6;
				num = (int)Mathf.Max(((float)dstWidth - num7) / 2f, 0f);
				num3 = dstWidth - num * 2;
			}
			else if (num5 < num6)
			{
				float num8 = (float)srcHeight * num5;
				num2 = (int)Mathf.Max(((float)dstHeight - num8) / 2f, 0f);
				num4 = dstHeight - num2 * 2;
			}
			float num9 = 0f;
			float num10 = 0f;
			float num11 = (float)srcWidth / (float)num3;
			float num12 = (float)srcHeight / (float)num4;
			for (int i = num2; i < num2 + num4; i++)
			{
				for (int j = num; j < num + num3; j++)
				{
					array[j + i * dstWidth] = source[(int)num9 + (int)num10 * srcWidth];
					num9 += num11;
				}
				num9 = 0f;
				num10 += num12;
			}
			return array;
		}

		public static Texture2D Generate(LevelConfig levelConfig, Style style)
		{
			int num = 0;
			int num2 = 0;
			Color32[] array = null;
			Texture2D texture2D = style.CreateTexture();
			foreach (SharedInstance<HospitalPlotDefinition> hospitalPlot in levelConfig.GetWorldStateConfig().HospitalPlots)
			{
				Texture2D floorImage = hospitalPlot.Instance.FloorImage;
				Color[] pixels = floorImage.GetPixels();
				int width = floorImage.width;
				int height = floorImage.height;
				if (array == null)
				{
					num = width;
					num2 = height;
					array = new Color32[width * height];
					ArrayUtils.Populate<Color32>(array, Color.clear);
				}
				for (int i = 0; i < height; i++)
				{
					for (int j = 0; j < width; j++)
					{
						if (HospitalMapTile.IsHospitalFloor(pixels[j + i * width]))
						{
							array[j + i * width] = Color.white;
						}
					}
				}
			}
			array = Rotate90(array, num, num2);
			int num3 = int.MaxValue;
			int num4 = int.MaxValue;
			int num5 = 0;
			int num6 = 0;
			for (int k = 0; k < num2; k++)
			{
				for (int l = 0; l < num; l++)
				{
					if (array[l + k * num].r != 0)
					{
						if (l < num3)
						{
							num3 = l;
						}
						if (l > num5)
						{
							num5 = l;
						}
						if (k < num4)
						{
							num4 = k;
						}
						if (k > num6)
						{
							num6 = k;
						}
					}
				}
			}
			num3 = Mathf.Max(num3 - style.Border, 0);
			num4 = Mathf.Max(num4 - style.Border, 0);
			num5 = Mathf.Min(num5 + style.Border, num);
			num6 = Mathf.Min(num6 + style.Border, num2);
			array = Crop(array, num, num3, num4, num5 - num3, num6 - num4);
			num = num5 - num3;
			num2 = num6 - num4;
			array = Scale(array, num, num2, texture2D.width, texture2D.height);
			num = texture2D.width;
			num2 = texture2D.height;
			for (int m = 0; m < num2; m++)
			{
				for (int n = 0; n < num; n++)
				{
					bool flag = array[n + m * num].r != 0;
					array[n + m * num] = (flag ? style.GetTileColor(n, m) : style.GetLandscapeColor(n, m));
				}
			}
			texture2D.SetPixels32(array);
			texture2D.Apply();
			return texture2D;
		}
	}
}
