using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Equipment.Ultrasonic
{
	public class SonicBathDrawer : MonoBehaviour
	{
		[SerializeField]
		private Transform pushedPoint;

		[SerializeField]
		private Transform pulledPoint;

		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		[Range(0f, 2f)]
		private float animationDuration = 0.8f;

		[SerializeField]
		private Ease animationEase = Ease.Linear;

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		private bool isPulled;

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

		public bool IsPulled => isPulled;

		public event Action OnAnimationCompleted;

		public event Action OnPullingAnimationStarted;

		public event Action OnPushingAnimationStarted;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void SetPulledPosition()
		{
			isPulled = true;
			targetTransform.position = pulledPoint.position;
		}

		public void SetPushedPosition()
		{
			isPulled = false;
			targetTransform.position = pushedPoint.position;
		}

		public void Pull()
		{
			if (!isPulled)
			{
				isPulled = true;
				PlayTransitionToPoint(pulledPoint.position);
				this.OnPullingAnimationStarted?.Invoke();
			}
		}

		public void Push()
		{
			if (isPulled)
			{
				isPulled = false;
				PlayTransitionToPoint(pushedPoint.position);
				this.OnPushingAnimationStarted?.Invoke();
			}
		}

		private void PlayTransitionToPoint(Vector3 targetPosition)
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(targetTransform.DOMove(targetPosition, animationDuration)).SetEase(animationEase).SetUpdate(UpdateType.Fixed)
				.OnComplete(OnTransitionComplete);
		}

		private void OnTransitionComplete()
		{
			this.OnAnimationCompleted?.Invoke();
		}
	}
}
