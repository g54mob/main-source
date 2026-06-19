using UnityEngine;

namespace Pug.UnityExtensions
{
	public class MimicSprite : MonoBehaviour
	{
		public SpriteRenderer spriteRenderer;

		public SpriteRenderer spriteRendererToMimic;

		private void Update()
		{
			if (spriteRendererToMimic.sprite != spriteRenderer.sprite)
			{
				spriteRenderer.sprite = spriteRendererToMimic.sprite;
			}
		}
	}
}
