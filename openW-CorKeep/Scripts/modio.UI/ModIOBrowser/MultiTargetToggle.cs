using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class MultiTargetToggle : Toggle
	{
		public ColorScheme scheme;

		public List<Target> extraTargets = new List<Target>();

		public GameObject targetIsOnIndicator;

		public GameObject targetIsDisabledIndicator;

		public void DoStateTransition()
		{
			DoStateTransition(base.currentSelectionState, instant: true);
		}

		protected override void DoStateTransition(SelectionState state, bool instant)
		{
			base.DoStateTransition(state, instant);
			if (targetIsOnIndicator != null)
			{
				targetIsOnIndicator.SetActive(base.isOn);
			}
			if (targetIsDisabledIndicator != null)
			{
				targetIsDisabledIndicator.SetActive(state == SelectionState.Disabled);
			}
			foreach (Target extraTarget in extraTargets)
			{
				Color color;
				Sprite newSprite;
				string triggerName;
				switch (state)
				{
				case SelectionState.Normal:
					color = extraTarget.colors.normalColor;
					newSprite = null;
					triggerName = extraTarget.animationTriggers.normalTrigger;
					break;
				case SelectionState.Highlighted:
					color = extraTarget.colors.highlightedColor;
					newSprite = extraTarget.spriteState.highlightedSprite;
					triggerName = extraTarget.animationTriggers.highlightedTrigger;
					break;
				case SelectionState.Selected:
					color = extraTarget.colors.highlightedColor;
					newSprite = extraTarget.spriteState.highlightedSprite;
					triggerName = extraTarget.animationTriggers.highlightedTrigger;
					break;
				case SelectionState.Pressed:
					color = extraTarget.colors.pressedColor;
					newSprite = extraTarget.spriteState.pressedSprite;
					triggerName = extraTarget.animationTriggers.pressedTrigger;
					break;
				case SelectionState.Disabled:
					color = extraTarget.colors.disabledColor;
					newSprite = extraTarget.spriteState.disabledSprite;
					triggerName = extraTarget.animationTriggers.disabledTrigger;
					break;
				default:
					color = Color.black;
					newSprite = null;
					triggerName = string.Empty;
					break;
				}
				if (!base.gameObject.activeInHierarchy)
				{
					break;
				}
				switch (extraTarget.transition)
				{
				case MultiTargetTransition.ColorTint:
					StartColorTween(extraTarget.target, color * extraTarget.colors.colorMultiplier, extraTarget.colors.fadeDuration, instant);
					break;
				case MultiTargetTransition.SpriteSwap:
					DoSpriteSwap(extraTarget.target, newSprite);
					break;
				case MultiTargetTransition.Animation:
					TriggerAnimation(extraTarget.animator, extraTarget.animationTriggers, triggerName);
					break;
				case MultiTargetTransition.DisableEnable:
					ToggleActiveState(extraTarget, state);
					break;
				case MultiTargetTransition.ColorScheme:
					UseSchemeColorTint(extraTarget, state, scheme, instant);
					break;
				}
			}
		}

		private void UseSchemeColorTint(Target target, SelectionState state, ColorScheme scheme, bool instant)
		{
			if (!(scheme == null))
			{
				Color color = default(Color);
				switch (state)
				{
				case SelectionState.Normal:
					color = scheme.GetSchemeColor(target.colorSchemeBlock.Normal);
					break;
				case SelectionState.Highlighted:
					color = scheme.GetSchemeColor(target.colorSchemeBlock.Highlighted);
					break;
				case SelectionState.Selected:
					color = scheme.GetSchemeColor(target.colorSchemeBlock.Highlighted);
					break;
				case SelectionState.Pressed:
					color = scheme.GetSchemeColor(target.colorSchemeBlock.Pressed);
					break;
				case SelectionState.Disabled:
					color = scheme.GetSchemeColor(target.colorSchemeBlock.Disabled);
					break;
				}
				StartColorTween(target.target, color * target.colorSchemeBlock.ColorMultiplier, target.colorSchemeBlock.FadeDuration, instant);
			}
		}

		private void ToggleActiveState(Target target, SelectionState state)
		{
			switch (state)
			{
			case SelectionState.Normal:
				target.target.gameObject.SetActive(target.enableOnNormal);
				break;
			case SelectionState.Highlighted:
				target.target.gameObject.SetActive(target.enableOnHighlight);
				break;
			case SelectionState.Selected:
				target.target.gameObject.SetActive(target.enableOnHighlight);
				break;
			case SelectionState.Pressed:
				target.target.gameObject.SetActive(target.enableOnPressed);
				break;
			case SelectionState.Disabled:
				target.target.gameObject.SetActive(target.enableOnDisabled);
				break;
			}
		}

		private void StartColorTween(Graphic target, Color targetColor, float fadeDuration, bool instant)
		{
			if (!(target == null))
			{
				target.CrossFadeColor(targetColor, (!instant) ? fadeDuration : 0f, ignoreTimeScale: true, useAlpha: true);
			}
		}

		private void DoSpriteSwap(Graphic target, Sprite newSprite)
		{
			if (!(target == null) && target is Image image)
			{
				image.overrideSprite = newSprite;
			}
		}

		private void TriggerAnimation(Animator targetAnimator, AnimationTriggers trigger, string triggerName)
		{
			if (base.transition == Transition.Animation && !(targetAnimator == null) && base.animator.isActiveAndEnabled && targetAnimator.hasBoundPlayables && !string.IsNullOrEmpty(triggerName))
			{
				base.animator.ResetTrigger(trigger.normalTrigger);
				base.animator.ResetTrigger(trigger.pressedTrigger);
				base.animator.ResetTrigger(trigger.highlightedTrigger);
				base.animator.ResetTrigger(trigger.disabledTrigger);
				base.animator.SetTrigger(triggerName);
			}
		}
	}
}
