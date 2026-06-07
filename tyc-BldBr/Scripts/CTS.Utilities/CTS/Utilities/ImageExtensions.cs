using UnityEngine.UI;

namespace CTS.Utilities
{
	public static class ImageExtensions
	{
		public static float GetSpriteAspectRatio(this Image image)
		{
			bool num = image.sprite;
			bool flag = image.overrideSprite;
			if (!num && !flag)
			{
				return 1f;
			}
			if (flag)
			{
				return image.overrideSprite.GetAspectRatio();
			}
			return image.sprite.GetAspectRatio();
		}
	}
}
