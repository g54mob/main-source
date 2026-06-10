using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class MultiTargetButton : Button
	{
		public ColorScheme scheme;

		public List<Target> extraTargets;

		public List<MultiTargetButton> childButtons;

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
		}

		private void UseSchemeColorTint(Target target, SelectionState state, ColorScheme scheme, bool instant)
		{
		}

		private void ToggleActiveState(Target target, SelectionState state)
		{
		}

		private void StartColorTween(Graphic target, Color targetColor, float fadeDuration, bool instant)
		{
		}

		private void DoSpriteSwap(Graphic target, Sprite newSprite)
		{
		}

		private void TriggerAnimation(Animator targetAnimator, AnimationTriggers trigger, string triggerName)
		{
		}
	}
}
