using DG.Tweening;
using UnityEngine;

namespace Dorfromantik.UI.Components
{
	public class UiIconButtonIngame : UiIconButton
	{
		[SerializeField]
		private float punchScaleFactor = 0.25f;

		[SerializeField]
		private float punchDuration = 0.25f;

		internal override void SetVisualStateActivated(bool shouldSetActivated, bool shouldIgnoreCurrentState = false)
		{
			if ((base.IsActivated != shouldSetActivated || shouldIgnoreCurrentState) && base.UiVisualStateInfoActivated.isAvailable)
			{
				onActivatedSequence = ResetInteractionSequence(onActivatedSequence);
				RectTransform component = base.UiVisualStateInfoActivated.canvasGroup.GetComponent<RectTransform>();
				TweenSettingsExtensions.Insert(onActivatedSequence, 0f, ShortcutExtensions.DOPunchScale(component, new Vector2(punchScaleFactor, punchScaleFactor), punchDuration));
				if (shouldSetActivated)
				{
					TweenSettingsExtensions.Insert(onActivatedSequence, 0f, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, groupAlphaVisible, 0f));
				}
				else
				{
					TweenSettingsExtensions.Append(onActivatedSequence, DOTweenModuleUI.DOFade(base.UiVisualStateInfoActivated.canvasGroup, 0f, 0f));
				}
				TweenSettingsExtensions.Insert(onInteractionSequence, 0f, onActivatedSequence);
				SetState(UiState.Activated, shouldSetActivated);
			}
		}
	}
}
