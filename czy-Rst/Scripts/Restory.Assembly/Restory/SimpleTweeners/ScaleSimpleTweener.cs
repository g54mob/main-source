using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class ScaleSimpleTweener : SimpleTweenerBase
	{
		[SerializeField]
		private Vector3 localScale = Vector3.one;

		private Vector3 finalLocalScale;

		private Vector3 cachedLocalScale = Vector3.zero;

		public override float Progress
		{
			get
			{
				return (base.transform.localRotation.eulerAngles - cachedLocalScale).magnitude / (finalLocalScale - cachedLocalScale).magnitude;
			}
			set
			{
				base.transform.localPosition = Vector3.Lerp(cachedLocalScale, finalLocalScale, value);
			}
		}

		protected override void CacheInitialState()
		{
			cachedLocalScale = base.transform.localScale;
			finalLocalScale = cachedLocalScale + localScale;
		}

		public override void Play()
		{
			Sequence sequence = InitSequence();
			sequence.Append(base.transform.DOScale(localScale, duration).SetEase(ease));
			sequence.Play();
		}

		public override void PlayImmediately()
		{
			base.transform.localScale = localScale;
		}

		public override void RevertState()
		{
			base.transform.localScale = cachedLocalScale;
		}
	}
}
