using UnityEngine;

namespace ManagementScripts
{
	public static class Texture2DExtension
	{
		public static void SetPixelsWithAlpha(this Texture2D tex, int x, int y, int w, int h, Color[] pixels)
		{
			for (int i = 0; i < w; i++)
			{
				for (int j = 0; j < h; j++)
				{
					Color color = pixels[j * w + i];
					if (!Mathf.Approximately(color.a, 0f))
					{
						Color color2 = tex.GetPixel(i + x, j + y) * (1f - color.a) + color * color.a;
						color2.a = 1f;
						tex.SetPixel(i + x, j + y, color2);
					}
				}
			}
		}
	}
}
