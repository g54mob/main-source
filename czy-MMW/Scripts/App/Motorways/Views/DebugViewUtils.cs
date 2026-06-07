using UnityEngine;

namespace Motorways.Views
{
	public static class DebugViewUtils
	{
		public static readonly Texture2D DebugWindowBackground;

		static DebugViewUtils()
		{
			DebugWindowBackground = Create2DTexture(2, 2, Color.Lerp(Color.gray, Color.clear, 0.2f));
		}

		public static Texture2D Create2DTexture(int width, int height, Color color)
		{
			Color[] array = new Color[width * height];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = color;
			}
			Texture2D texture2D = new Texture2D(width, height);
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}
	}
}
