using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathCover : MonoBehaviour
	{
		[SerializeField]
		private Transform openedPoint;

		[SerializeField]
		private Transform closedPoint;

		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		[Range(0f, 2f)]
		private float animationDuration = 0.8f;

		[SerializeField]
		private Ease animationEase = Ease.Linear;

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		private bool isOpen;

		public bool IsAnimationActive
		{
			get
			{
				if (transitionSequence != null)
				{
					return transitionSequence.IsActive();
				}
				return false;
			}
		}

		public bool IsOpen => isOpen;

		public event Action OnAnimationCompleted;

		public event Action OnStartedOpeningAnimation;

		public event Action OnStartedClosingAnimation;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void SetOpenedPosition()
		{
			isOpen = true;
			targetTransform.position = openedPoint.position;
		}

		public void SetClosedPosition()
		{
			isOpen = false;
			targetTransform.position = closedPoint.position;
		}

		public void Open()
		{
			if (!isOpen)
			{
				isOpen = true;
				PlayTransitionToPoint(openedPoint.localPosition);
				this.OnStartedOpeningAnimation?.Invoke();
			}
		}

		public void Close()
		{
			if (isOpen)
			{
				isOpen = false;
				PlayTransitionToPoint(closedPoint.localPosition);
				this.OnStartedClosingAnimation?.Invoke();
			}
		}

		private void PlayTransitionToPoint(Vector3 targetPosition)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(targetTransform.DOLocalMove(targetPosition, animationDuration)).SetEase(animationEase).OnComplete(ResolveTransitionCompleted);
		}

		private void ResolveTransitionCompleted()
		{
			this.OnAnimationCompleted?.Invoke();
		}
	}
}
