using UnityEngine;

namespace CTS.Utilities
{
	public static class SpriteExtensions
	{
		public static float GetAspectRatio(this Sprite sprite)
		{
			return sprite.texture.GetAspectRatio();
		}
	}
}
