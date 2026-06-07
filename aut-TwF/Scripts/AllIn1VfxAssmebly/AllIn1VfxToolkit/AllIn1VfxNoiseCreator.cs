using UnityEngine;

namespace AllIn1VfxToolkit
{
	public static class AllIn1VfxNoiseCreator
	{
		public static Texture2D PerlinNoise(Texture2D tex, float scale, int randomSeed, bool tileable)
		{
			int width = tex.width;
			int height = tex.height;
			Random.InitState(randomSeed);
			float offset = Random.Range(-100f, 100f);
			for (int i = 0; i < height; i++)
			{
				for (int j = 0; j < width; j++)
				{
					tex.SetPixel(j, i, CalculatePerlinColor(j, i, scale, offset, width, height));
				}
			}
			tex.Apply();
			Texture2D texture2D = new Texture2D(height, width);
			texture2D.SetPixels(tex.GetPixels());
			if (tileable)
			{
				for (int k = 0; k < height; k++)
				{
					for (int l = 0; l < width; l++)
					{
						texture2D.SetPixel(l, k, PerlinBorderless(l, k, scale, offset, width, height, tex));
					}
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		private static Color CalculatePerlinColor(int x, int y, float scale, float offset, int width, int height)
		{
			float x2 = ((float)x + offset) / (float)width * scale;
			float y2 = ((float)y + offset) / (float)height * scale;
			float num = Mathf.PerlinNoise(x2, y2);
			return new Color(num, num, num, 1f);
		}

		private static Color PerlinBorderless(int x, int y, float scale, float offset, int width, int height, Texture2D previousPerlin)
		{
			int x2 = x;
			int y2 = y;
			float num = (float)x / (float)width;
			float num2 = (float)y / (float)height;
			if (num > 0.5f)
			{
				x = width - x;
			}
			if (num2 > 0.5f)
			{
				y = height - y;
			}
			offset += 23.43f;
			float x3 = ((float)x + offset) / (float)width * scale;
			float y3 = ((float)y + offset) / (float)height * scale;
			float num3 = Mathf.PerlinNoise(x3, y3);
			Color b = new Color(num3, num3, num3, 1f);
			float a = Mathf.Max(num, num2);
			a = Mathf.Max(a, Mathf.Max(1f - num, 1f - num2));
			a = Mathf.Pow(a, 10f);
			return Color.Lerp(previousPerlin.GetPixel(x2, y2), b, a);
		}
	}
}
