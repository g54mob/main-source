using System;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.Effects
{
	public class BounceEffect : MonoBehaviour
	{
		[Serializable]
		public class BouncePhase
		{
			[Range(0f, 0.8f)]
			public float Duration;

			public Vector3 TargetScale;

			public Ease Ease;
		}

		[SerializeField]
		private Transform targetTransform;

		[SerializeField]
		private BouncePhase stretchPhase = new BouncePhase
		{
			Duration = 0.07f,
			TargetScale = new Vector3(0.9f, 1.1f, 0.9f),
			Ease = Ease.OutQuad
		};

		[SerializeField]
		private BouncePhase squashPhase = new BouncePhase
		{
			Duration = 0.16f,
			TargetScale = new Vector3(1.1f, 0.9f, 1.1f),
			Ease = Ease.InQuad
		};

		[SerializeField]
		private BouncePhase settlePhase = new BouncePhase
		{
			Duration = 0.16f,
			TargetScale = Vector3.one,
			Ease = Ease.OutBack
		};

		private TweenSequencesService tweenSequences;

		private Sequence transitionSequence;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		private void OnDisable()
		{
			if (transitionSequence != null)
			{
				tweenSequences.Kill(transitionSequence);
				targetTransform.localScale = settlePhase.TargetScale;
			}
		}

		public void PlayBounce()
		{
			if (transitionSequence.IsActive())
			{
				tweenSequences.Kill(transitionSequence);
			}
			transitionSequence = tweenSequences.Create();
			transitionSequence.Append(targetTransform.DOScale(stretchPhase.TargetScale, stretchPhase.Duration).SetEase(stretchPhase.Ease));
			transitionSequence.Append(targetTransform.DOScale(squashPhase.TargetScale, squashPhase.Duration).SetEase(squashPhase.Ease));
			transitionSequence.Append(targetTransform.DOScale(settlePhase.TargetScale, settlePhase.Duration).SetEase(settlePhase.Ease));
			transitionSequence.OnKill(delegate
			{
				targetTransform.localScale = Vector3.one;
			});
		}

		public void ForceStopAnimationAndRestoreSizeImmediately()
		{
			if (transitionSequence.IsActive())
			{
				tweenSequences.Kill(transitionSequence);
			}
		}
	}
}
