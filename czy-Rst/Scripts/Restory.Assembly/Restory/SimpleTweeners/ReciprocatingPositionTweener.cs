using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class ReciprocatingPositionTweener : SimpleTweenerBase
	{
		[SerializeField]
		private Vector3 localPositionOffset = Vector3.zero;

		[SerializeField]
		[Min(0f)]
		private float holdDuration;

		[SerializeField]
		[Min(0f)]
		private float returnDuration = 0.2f;

		[SerializeField]
		private Ease returnEase = Ease.Linear;

		private Vector3 initialPosition = Vector3.zero;

		private Vector3 targetPosition = Vector3.zero;

		public override float Progress { get; set; }

		protected override void CacheInitialState()
		{
			initialPosition = base.transform.localPosition;
			targetPosition = initialPosition + localPositionOffset;
		}

		public override void RevertState()
		{
		}

		public override void Play()
		{
			Sequence sequence = InitSequence();
			sequence.Append(base.transform.DOLocalMove(targetPosition, duration).SetEase(ease));
			sequence.AppendInterval(holdDuration);
			sequence.Append(base.transform.DOLocalMove(initialPosition, returnDuration).SetEase(returnEase));
			sequence.Play();
		}

		public override void PlayImmediately()
		{
		}
	}
}
