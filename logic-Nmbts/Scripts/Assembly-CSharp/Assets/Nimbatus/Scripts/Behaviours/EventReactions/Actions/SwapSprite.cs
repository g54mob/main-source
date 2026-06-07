using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class SwapSprite : NimbatusAction
	{
		public SpriteRenderer TargetRenderer;

		public Sprite Sprite;

		public override void Execute()
		{
			if (TargetRenderer != null && Sprite != null)
			{
				TargetRenderer.sprite = Sprite;
			}
		}
	}
}
