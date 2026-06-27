using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class PositionSimpleTweener : SimpleTweenerBase
	{
		[SerializeField]
		private Vector3 localPositionOffset = Vector3.zero;

		private Vector3 cachedLocalPosition = Vector3.zero;

		private Vector3 finalLocalPosition;

		public override float Progress
		{
			get
			{
				return (base.transform.localPosition - cachedLocalPosition).magnitude / (finalLocalPosition - cachedLocalPosition).magnitude;
			}
			set
			{
				base.transform.localPosition = Vector3.Lerp(cachedLocalPosition, finalLocalPosition, value);
			}
		}

		protected override void CacheInitialState()
		{
			cachedLocalPosition = base.transform.localPosition;
			finalLocalPosition = cachedLocalPosition + localPositionOffset;
		}

		public override void RevertState()
		{
			base.transform.localPosition = cachedLocalPosition;
		}

		public override void Play()
		{
			InitSequence();
			Sequence.Append(base.transform.DOLocalMove(finalLocalPosition, duration * (1f - Progress)).SetEase(ease));
			Sequence.Play();
		}

		public override void PlayImmediately()
		{
			base.transform.localPosition = finalLocalPosition;
		}
	}
}
