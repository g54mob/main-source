using DG.Tweening.Timeline;
using UnityEngine;

namespace DG.Tweening.TimelineExamples
{
	public class AgnosticDOTweenClip : MonoBehaviour
	{
		public DOTweenClip anthonyClip;

		public GameObject anthonyGO;

		public GameObject camilleGO;

		public GameObject skaterGO;

		private DOTweenClip _camilleClip;

		private DOTweenClip _skaterClip;

		private Tween _camilleTween;

		private Tween _skaterTween;

		public void PlayOriginalClip()
		{
		}

		public void ApplyToAllViaCloneAndReplace(float startupDelay)
		{
		}

		public void ApplyToAllViaGenerateIndependentTween(float startupDelay)
		{
		}
	}
}
