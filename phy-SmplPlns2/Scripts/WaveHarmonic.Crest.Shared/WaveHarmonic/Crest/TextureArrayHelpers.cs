using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal static class TextureArrayHelpers
	{
		internal const int k_SmallTextureSize = 4;

		public static Texture2D CreateTexture2D(Color color, TextureFormat format)
		{
			Texture2D texture2D = new Texture2D(4, 4, format, mipChain: false, linear: false);
			Color[] array = new Color[texture2D.height * texture2D.width];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = color;
			}
			texture2D.SetPixels(array);
			texture2D.Apply();
			return texture2D;
		}

		public static Texture2DArray CreateTexture2DArray(Texture2D texture, int depth)
		{
			Texture2DArray texture2DArray = new Texture2DArray(4, 4, depth, texture.format, mipChain: false, linear: false);
			for (int i = 0; i < texture2DArray.depth; i++)
			{
				Graphics.CopyTexture(texture, 0, 0, texture2DArray, i, 0);
			}
			texture2DArray.Apply();
			return texture2DArray;
		}
	}
}
