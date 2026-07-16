using UnityEngine;

namespace UtilityFunctions
{
	public class Utility
	{
		public static Texture2D MakeTexture(int width, int height, Color color)
		{
			Texture2D texture2D = new Texture2D(width, height);
			for (int i = 0; i < width; i++)
			{
				for (int j = 0; j < height; j++)
				{
					texture2D.SetPixel(i, j, color);
				}
			}
			texture2D.Apply();
			return texture2D;
		}
	}
}
