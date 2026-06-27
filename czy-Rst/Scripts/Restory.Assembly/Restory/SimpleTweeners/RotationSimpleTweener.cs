using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class RotationSimpleTweener : SimpleTweenerBase
	{
		[SerializeField]
		private Vector3 eulerAngleRotationOffset = Vector3.zero;

		private Vector3 finalEulerRotation;

		private Vector3 cachedLocalEulerAngles = Vector3.zero;

		public override float Progress
		{
			get
			{
				return (base.transform.localRotation.eulerAngles - cachedLocalEulerAngles).magnitude / (finalEulerRotation - cachedLocalEulerAngles).magnitude;
			}
			set
			{
				base.transform.localPosition = Vector3.Lerp(cachedLocalEulerAngles, finalEulerRotation, value);
			}
		}

		protected override void CacheInitialState()
		{
			cachedLocalEulerAngles = base.transform.localEulerAngles;
			finalEulerRotation = cachedLocalEulerAngles + eulerAngleRotationOffset;
		}

		public override void Play()
		{
			Sequence sequence = InitSequence();
			sequence.Append(base.transform.DOLocalRotate(finalEulerRotation, duration).SetEase(ease));
			sequence.Play();
		}

		public override void PlayImmediately()
		{
			base.transform.eulerAngles = finalEulerRotation;
		}

		public override void RevertState()
		{
			base.transform.localEulerAngles = cachedLocalEulerAngles;
		}
	}
}
