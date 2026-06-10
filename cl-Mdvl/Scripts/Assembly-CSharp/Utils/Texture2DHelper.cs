using UnityEngine;

namespace Utils
{
	public static class Texture2DHelper
	{
		public static void TryCreateTexture(ref Texture2D result, int width, int height, bool linear = false)
		{
			if (result == null)
			{
				result = new Texture2D(width, height, TextureFormat.RGBA32, mipChain: false, linear);
			}
			else if (result.width != width || result.height != height)
			{
				result.Reinitialize(width, height);
			}
			result.filterMode = FilterMode.Bilinear;
		}
	}
}
