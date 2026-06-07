using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class ColorizedRendererSprite : ColorizedRenderer
	{
		private readonly SpriteRenderer _renderer;

		public ColorizedRendererSprite(SpriteRenderer renderer)
		{
			_renderer = renderer;
		}

		public override void SetColor(Color color)
		{
			_renderer.color = color;
		}
	}
}
