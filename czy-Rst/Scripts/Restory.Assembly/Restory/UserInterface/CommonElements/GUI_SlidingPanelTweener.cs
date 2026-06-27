using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_SlidingPanelTweener : MonoBehaviour
	{
		[Serializable]
		private class SlidingAnimationSettings
		{
			[Range(0f, 2f)]
			public float Duration = 0.5f;

			public Ease Ease = Ease.OutCubic;
		}

		[Header("General settings")]
		[SerializeField]
		private RectTransform rectTransform;

		[SerializeField]
		private SlidingPanelState initialState;

		[Space]
		[Header("Position settings")]
		[SerializeField]
		private Vector2 hiddenPosition;

		[SerializeField]
		private Vector2 peekingPosition;

		[SerializeField]
		private Vector2 openPosition;

		[Space]
		[Header("Animation settings")]
		[SerializeField]
		private SlidingAnimationSettings hiddenToPeekingSettings;

		[SerializeField]
		private SlidingAnimationSettings hiddenToOpenSettings;

		[SerializeField]
		private SlidingAnimationSettings peekingToHiddenSettings;

		[SerializeField]
		private SlidingAnimationSettings peekingToOpenSettings;

		[SerializeField]
		private SlidingAnimationSettings openToHiddenSettings;

		[SerializeField]
		private SlidingAnimationSettings openToPeekingSettings;

		private TweenSequencesService tweenSequences;

		private SlidingPanelState currentState;

		private Sequence transitionSequence;

		public SlidingPanelState State => currentState;

		public event Action OnTransitionStarted;

		public event Action OnTransitionComplete;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
			SetState(initialState);
		}

		public void SetState(SlidingPanelState state)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				transitionSequence = null;
			}
			switch (state)
			{
			case SlidingPanelState.Hidden:
				rectTransform.anchoredPosition = hiddenPosition;
				break;
			case SlidingPanelState.Peeking:
				rectTransform.anchoredPosition = peekingPosition;
				break;
			case SlidingPanelState.Open:
				rectTransform.anchoredPosition = openPosition;
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
			currentState = state;
		}

		public void TransitionToState(SlidingPanelState state)
		{
			if (state == currentState)
			{
				CompleteTransition();
				return;
			}
			switch (state)
			{
			case SlidingPanelState.Hidden:
				TransitionToHiddenState();
				break;
			case SlidingPanelState.Peeking:
				TransitionToPeekingState();
				break;
			case SlidingPanelState.Open:
				TransitionToOpenState();
				break;
			default:
				throw new ArgumentOutOfRangeException("state", state, null);
			}
			currentState = state;
			this.OnTransitionStarted?.Invoke();
		}

		private void TransitionToHiddenState()
		{
			switch (currentState)
			{
			case SlidingPanelState.Peeking:
				PlayTransitionSequence(hiddenPosition, peekingToHiddenSettings);
				break;
			case SlidingPanelState.Open:
				PlayTransitionSequence(hiddenPosition, openToHiddenSettings);
				break;
			}
		}

		private void TransitionToPeekingState()
		{
			switch (currentState)
			{
			case SlidingPanelState.Hidden:
				PlayTransitionSequence(peekingPosition, hiddenToPeekingSettings);
				break;
			case SlidingPanelState.Open:
				PlayTransitionSequence(peekingPosition, openToPeekingSettings);
				break;
			}
		}

		private void TransitionToOpenState()
		{
			switch (currentState)
			{
			case SlidingPanelState.Hidden:
				PlayTransitionSequence(openPosition, hiddenToOpenSettings);
				break;
			case SlidingPanelState.Peeking:
				PlayTransitionSequence(openPosition, peekingToOpenSettings);
				break;
			}
		}

		private void PlayTransitionSequence(Vector2 targetPosition, SlidingAnimationSettings transitionSettings)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(rectTransform.DOAnchorPos(targetPosition, transitionSettings.Duration).SetEase(transitionSettings.Ease)).OnComplete(CompleteTransition);
		}

		private void CompleteTransition()
		{
			this.OnTransitionComplete?.Invoke();
		}

		private bool IsInvalidInitialState()
		{
			return initialState == SlidingPanelState.None;
		}
	}
}
