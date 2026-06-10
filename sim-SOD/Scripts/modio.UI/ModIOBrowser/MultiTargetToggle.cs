using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class MultiTargetToggle : Toggle
	{
		public ColorScheme scheme;

		public List<Target> extraTargets;

		public GameObject targetIsOnIndicator;

		public GameObject targetIsDisabledIndicator;

		public void DoStateTransition()
		{
		}

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
