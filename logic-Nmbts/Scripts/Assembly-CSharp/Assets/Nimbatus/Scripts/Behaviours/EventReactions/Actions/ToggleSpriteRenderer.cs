using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Actions
{
	public class ToggleSpriteRenderer : NimbatusAction
	{
		public SpriteRenderer TargetRenderer;

		public bool TargetState;

		public override void Execute()
		{
			if (TargetRenderer != null)
			{
				TargetRenderer.enabled = TargetState;
			}
		}
	}
}
