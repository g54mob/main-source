using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser
{
	public class MultiTargetDropdown : TMP_Dropdown
	{
		public ColorScheme scheme;

		public List<Target> extraTargets;

		public List<MultiTargetDropdown> childDropdowns;

		private GameObject border;

		public static MultiTargetDropdown currentMultiTargetDropdown;

		public override void OnSubmit(BaseEventData eventData)
		{
		}

		public override void OnCancel(BaseEventData eventData)
		{
		}

		public override void OnDeselect(BaseEventData eventData)
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

		protected override DropdownItem CreateItem(DropdownItem itemTemplate)
		{
			return null;
		}

		protected override GameObject CreateBlocker(Canvas rootCanvas)
		{
			return null;
		}
	}
}
