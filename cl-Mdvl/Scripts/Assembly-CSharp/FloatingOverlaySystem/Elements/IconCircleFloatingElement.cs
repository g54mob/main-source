using NSMedieval.FloatingOverlaySystem;
using UnityEngine;
using UnityEngine.UI;

namespace FloatingOverlaySystem.Elements
{
	public class IconCircleFloatingElement : FloatingElementBase
	{
		[SerializeField]
		private Image image;

		public void SetSprite(Sprite sprite)
		{
			if (!(image.sprite == sprite))
			{
				image.sprite = sprite;
			}
		}
	}
}
