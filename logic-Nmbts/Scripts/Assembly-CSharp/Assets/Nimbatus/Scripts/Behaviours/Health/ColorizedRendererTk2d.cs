using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Health
{
	public class ColorizedRendererTk2d : ColorizedRenderer
	{
		private readonly tk2dSprite _renderer;

		public ColorizedRendererTk2d(tk2dSprite renderer)
		{
			_renderer = renderer;
		}

		public override void SetColor(Color color)
		{
			_renderer.color = color;
		}
	}
}
