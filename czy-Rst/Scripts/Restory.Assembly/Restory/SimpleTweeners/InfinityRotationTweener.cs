using DG.Tweening;
using UnityEngine;

namespace Restory.SimpleTweeners
{
	public class InfinityRotationTweener : MonoBehaviour
	{
		[SerializeField]
		private Vector3 degrees = Vector3.zero;

		[SerializeField]
		[Min(0f)]
		private float duration = 0.5f;

		private float timeScale = 1f;

		private Tween tween;

		public float TimeScale
		{
			get
			{
				return timeScale;
			}
			set
			{
				timeScale = value;
				if (tween != null)
				{
					tween.timeScale = timeScale;
				}
			}
		}

		public void Play()
		{
			Stop();
			tween = base.transform.DOLocalRotate(degrees, duration, RotateMode.FastBeyond360).SetRelative().SetLoops(-1, LoopType.Incremental)
				.SetEase(Ease.Linear);
			tween.timeScale = timeScale;
		}

		public void PlayImmediately()
		{
			base.transform.localEulerAngles = degrees;
		}

		public void PlayBackwards()
		{
			Stop();
			tween = base.transform.DOLocalRotate(-degrees, duration, RotateMode.FastBeyond360).SetRelative().SetLoops(-1, LoopType.Incremental)
				.SetEase(Ease.Linear);
			tween.timeScale = timeScale;
		}

		public void PlayBackwardsImmediately()
		{
			base.transform.localEulerAngles = -degrees;
		}

		public void Stop()
		{
			tween?.Kill();
		}
	}
}
