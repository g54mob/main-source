using UnityEngine;

namespace CTS.Utilities
{
	public static class TextureExtensions
	{
		public static float GetAspectRatio(this Texture texture)
		{
			return (float)texture.width / (float)texture.height;
		}
	}
}
