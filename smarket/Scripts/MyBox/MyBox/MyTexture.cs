using UnityEngine;

namespace MyBox
{
	public static class MyTexture
	{
		public static Sprite AsSprite(this Texture2D texture)
		{
			return null;
		}

		public static Texture2D Resample(this Texture2D source, int targetWidth, int targetHeight)
		{
			return null;
		}

		public static Texture2D Crop(this Texture2D original, int left, int right, int top, int down, float brightnessOffset = 0f)
		{
			return null;
		}

		public static Texture2D WithSolidColor(this Texture2D original, Color color)
		{
			return null;
		}
	}
}
