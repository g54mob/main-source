using System;
using UnityEngine;

namespace Jundroo.Common.Utils
{
	public static class TextureUtility
	{
		public static Texture2D CreateResizedTexture(Texture2D sourceTexture, int targetWidth, int targetHeight)
		{
			Texture2D texture2D = new Texture2D(targetWidth, targetHeight, sourceTexture.format, mipChain: false);
			for (int i = 0; i < targetWidth; i++)
			{
				for (int j = 0; j < targetHeight; j++)
				{
					float u = (float)i / (float)targetWidth;
					float v = (float)j / (float)targetHeight;
					Color pixelBilinear = sourceTexture.GetPixelBilinear(u, v);
					texture2D.SetPixel(i, j, pixelBilinear);
				}
			}
			texture2D.Apply();
			return texture2D;
		}

		public static Texture2D CreateSquareThumbnail(Texture2D sourceTexture, int size)
		{
			float num = Mathf.Max((float)size / (float)sourceTexture.width, (float)size / (float)sourceTexture.height);
			Texture2D texture2D = CreateResizedTexture(sourceTexture, (int)((float)sourceTexture.width * num), (int)((float)sourceTexture.height * num));
			Vector2i vector2i = new Vector2i(texture2D.width / 2, texture2D.height / 2);
			Vector2i min = vector2i - new Vector2i(size / 2, size / 2);
			Vector2i max = vector2i + new Vector2i(size / 2, size / 2);
			return CropTexture(texture2D, min, max);
		}

		public static Texture2D CropTexture(Texture2D sourceTexture, Vector2i min, Vector2i max)
		{
			if (min.x < 0 || min.y < 0 || min.x >= max.x || min.y >= max.y || min.x >= sourceTexture.width || min.y >= sourceTexture.height)
			{
				throw new ArgumentException($"Invalid crop region ({min})-({max}) for source texture of size {sourceTexture.width}x{sourceTexture.height}");
			}
			Texture2D texture2D = new Texture2D(max.x - min.x, max.y - min.y, sourceTexture.format, mipChain: false);
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					int x = min.x + i;
					int y = min.y + j;
					Color pixel = sourceTexture.GetPixel(x, y);
					texture2D.SetPixel(i, j, pixel);
				}
			}
			texture2D.Apply();
			return texture2D;
		}
	}
}
