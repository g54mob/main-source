using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class ElementPositionTweener : SimpleTweenerBase
	{
		[SerializeField]
		[Range(0f, 1f)]
		private float snapDuration = 0.5f;

		[SerializeField]
		[Range(0f, 1f)]
		private float reverseStartProgress = 0.8f;

		[SerializeField]
		private Vector3 localPositionOffset = Vector3.zero;

		private Vector3 cachedLocalPosition = Vector3.zero;

		private Vector3 finalLocalPosition;

		private Vector3 reverseStartLocalPosition;

		public bool IsPlaying
		{
			get
			{
				if (Sequence != null)
				{
					return Sequence.IsPlaying();
				}
				return false;
			}
		}

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

		public Vector3 ReverseStartLocalPosition => reverseStartLocalPosition;

		protected override void CacheInitialState()
		{
			cachedLocalPosition = base.transform.localPosition;
			finalLocalPosition = cachedLocalPosition + localPositionOffset;
			reverseStartLocalPosition = Vector3.Lerp(cachedLocalPosition, finalLocalPosition, reverseStartProgress);
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

		public void PlayBackwards()
		{
			InitSequence();
			Sequence.Append(base.transform.DOLocalMove(cachedLocalPosition, duration * Progress).SetEase(ease));
			Sequence.Play();
		}

		public void PlayBackwardsImmediately()
		{
			base.transform.localPosition = cachedLocalPosition;
		}

		public void PlaySnap(Vector3 targetPosition)
		{
			InitSequence();
			Sequence.Append(base.transform.DOLocalMove(targetPosition, snapDuration)).Join(base.transform.DOLocalRotate(Vector3.zero, snapDuration)).SetEase(ease);
			Sequence.Play();
		}

		public void AppendTighteningToSequence(Vector3 startPosition)
		{
			if (Sequence == null || !Sequence.IsPlaying())
			{
				Debug.LogError("Failed to append tightening animation to sequence, it is not playing");
				return;
			}
			float num = (startPosition - cachedLocalPosition).magnitude / (finalLocalPosition - cachedLocalPosition).magnitude;
			float num2 = duration * num;
			Vector3 endValue = new Vector3(0f, 0f, num2 * 360f);
			RotateMode mode = RotateMode.FastBeyond360;
			Sequence.Append(base.transform.DOLocalMove(cachedLocalPosition, num2)).Join(base.transform.DOLocalRotate(endValue, num2, mode)).SetEase(ease);
		}
	}
}
