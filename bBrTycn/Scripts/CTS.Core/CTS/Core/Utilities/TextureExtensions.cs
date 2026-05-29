using UnityEngine;

namespace CTS.Core.Utilities
{
	public static class TextureExtensions
	{
		public static Rect GetRect(this Texture2D texture, float x = 0f, float y = 0f, float scale = 1f)
		{
			return new Rect(x, y, (float)texture.width * scale, (float)texture.height * scale);
		}
	}
}
