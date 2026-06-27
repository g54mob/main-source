using System;
using Restory.Data.WorkshopStatus;
using Restory.UserInterface;
using Restory.UserInterface.CommonElements;
using UnityEngine;

namespace Restory.UI.Presenters.WorkshopStatus
{
	public sealed class GUI_WorkshopStatusNotification : MonoBehaviour
	{
		[SerializeField]
		private RectTransform panelTransform;

		[SerializeField]
		private GUI_LocalisedText nameText;

		[SerializeField]
		private GUI_SlidingPanelTweener slidingTweener;

		public event Action<GUI_WorkshopStatusNotification> OnAnimationFinished;

		private void OnEnable()
		{
			slidingTweener.OnTransitionComplete += ResolveOnTransitionComplete;
		}

		private void OnDisable()
		{
			slidingTweener.OnTransitionComplete -= ResolveOnTransitionComplete;
		}

		public void SetAnchoredPosition(Vector2 screenPosition)
		{
			panelTransform.anchoredPosition = screenPosition;
		}

		public void Show(StatusInfo statusInfo)
		{
			nameText.LocalizationID = statusInfo.NameLocalizationKey;
			slidingTweener.TransitionToState(SlidingPanelState.Open);
		}

		public void Hide()
		{
			slidingTweener.TransitionToState(SlidingPanelState.Hidden);
		}

		private void ResolveOnTransitionComplete()
		{
			this.OnAnimationFinished?.Invoke(this);
		}
	}
}
