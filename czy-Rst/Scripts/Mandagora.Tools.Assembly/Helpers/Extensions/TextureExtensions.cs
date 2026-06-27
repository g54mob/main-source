using System.Collections.Generic;
using UnityEngine;

namespace Helpers.Extensions
{
	public static class TextureExtensions
	{
		private static Dictionary<Texture2D, Texture2D> cashedTextures = new Dictionary<Texture2D, Texture2D>();

		public static Texture2D ScaledTexture(this Texture2D source, int targetWidth, int targetHeight)
		{
			if (cashedTextures.TryGetValue(source, out var value) && targetWidth == value.width)
			{
				return value;
			}
			value = new Texture2D(targetWidth, targetHeight, TextureFormat.RGBA32, mipChain: false);
			Color[] pixels = value.GetPixels(0);
			float num = 1f / (float)targetWidth;
			float num2 = 1f / (float)targetHeight;
			for (int i = 0; i < pixels.Length; i++)
			{
				pixels[i] = source.GetPixelBilinear(num * ((float)i % (float)targetWidth), num2 * Mathf.Floor((float)i / (float)targetWidth));
			}
			value.SetPixels(pixels, 0);
			value.Apply();
			cashedTextures[source] = value;
			return value;
		}

		public static Vector2Int SizeProportionalToScreen(this Texture2D source, float targetScreenWidth, float targetScreenHeight)
		{
			float num = (float)Screen.width / targetScreenWidth;
			float num2 = (float)Screen.height / targetScreenHeight;
			float num3 = ((num > num2) ? num2 : num);
			return new Vector2Int((int)((float)source.width * num3), (int)((float)source.height * num3));
		}
	}
}
