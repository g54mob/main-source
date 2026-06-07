using UnityEngine;

namespace Doozy.Engine.Themes
{
	[AddComponentMenu("Doozy/Themes/Targets/Sprite Target SpriteRenderer", 13)]
	[DefaultExecutionOrder(-100)]
	public class SpriteTargetSpriteRenderer : ThemeTarget
	{
		public SpriteRenderer SpriteRenderer;

		public override void UpdateTarget(ThemeData theme)
		{
		}

		private void Reset()
		{
		}

		private void UpdateReference()
		{
		}
	}
}
