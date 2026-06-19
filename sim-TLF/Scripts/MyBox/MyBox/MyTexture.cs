using UnityEngine;

namespace MyBox
{
	public static class MyTexture
	{
		public static Sprite AsSprite(this Texture2D texture)
		{
			Rect rect = new Rect(0f, 0f, texture.width, texture.height);
			Vector2 pivot = new Vector2(0.5f, 0.5f);
			return Sprite.Create(texture, rect, pivot);
		}

		public static Texture2D Resample(this Texture2D source, int targetWidth, int targetHeight)
		{
			int width = source.width;
			int height = source.height;
			float num = (float)width / (float)height;
			float num2 = (float)targetWidth / (float)targetHeight;
			int num3 = 0;
			int num4 = 0;
			float num5;
			if (num > num2)
			{
				num5 = (float)targetHeight / (float)height;
				num3 = (int)(((float)width - (float)height * num2) * 0.5f);
			}
			else
			{
				num5 = (float)targetWidth / (float)width;
				num4 = (int)(((float)height - (float)width / num2) * 0.5f);
			}
			Color32[] pixels = source.GetPixels32();
			Color32[] array = new Color32[targetWidth * targetHeight];
			for (int i = 0; i < targetHeight; i++)
			{
				for (int j = 0; j < targetWidth; j++)
				{
					Vector2 vector = new Vector2(Mathf.Clamp((float)num3 + (float)j / num5, 0f, width - 1), Mathf.Clamp((float)num4 + (float)i / num5, 0f, height - 1));
					Color32 color = pixels[Mathf.FloorToInt(vector.x) + width * Mathf.FloorToInt(vector.y)];
					Color32 color2 = pixels[Mathf.FloorToInt(vector.x) + width * Mathf.CeilToInt(vector.y)];
					Color32 color3 = pixels[Mathf.CeilToInt(vector.x) + width * Mathf.FloorToInt(vector.y)];
					Color32 color4 = pixels[Mathf.CeilToInt(vector.x) + width * Mathf.CeilToInt(vector.y)];
					array[j + i * targetWidth] = Color.Lerp(Color.Lerp(color, color2, vector.y), Color.Lerp(color3, color4, vector.y), vector.x);
				}
			}
			Texture2D texture2D = new Texture2D(targetWidth, targetHeight);
			texture2D.SetPixels32(array);
			texture2D.Apply(updateMipmaps: true);
			return texture2D;
		}

		public static Texture2D Crop(this Texture2D original, int left, int right, int top, int down, float brightnessOffset = 0f)
		{
			int num = left + right;
			int num2 = top + down;
			int num3 = original.width - num;
			int num4 = original.height - num2;
			Color[] pixels = original.GetPixels(left, down, num3, num4);
			if (!Mathf.Approximately(brightnessOffset, 0f))
			{
				for (int i = 0; i < pixels.Length; i++)
				{
					pixels[i] = pixels[i].BrightnessOffset(brightnessOffset);
				}
			}
			Texture2D texture2D = new Texture2D(num3, num4, TextureFormat.RGB24, mipChain: false);
			texture2D.SetPixels(pixels);
			texture2D.Apply();
			return texture2D;
		}

		public static Texture2D WithSolidColor(this Texture2D original, Color color)
		{
			Texture2D texture2D = new Texture2D(original.width, original.height);
			for (int i = 0; i < texture2D.width; i++)
			{
				for (int j = 0; j < texture2D.height; j++)
				{
					texture2D.SetPixel(i, j, color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}
	}
}
