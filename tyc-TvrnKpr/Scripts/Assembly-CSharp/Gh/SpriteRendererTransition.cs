using System;
using DG.Tweening;
using UnityEngine;

namespace Gh
{
	public class SpriteRendererTransition : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _renderer;

		[SerializeField]
		private float _transitionInTime;

		[SerializeField]
		private float _transitionOutTime;

		[SerializeField]
		private Ease _transitionEase;

		[SerializeField]
		private Color _baseColor;

		private Color _clearColor => default(Color);

		public void PlayFadeIn(bool skipTransition = false, Action onComplete = null, float time = -1f, Ease easeOverride = Ease.INTERNAL_Zero)
		{
		}

		public void PlayFadeOut(bool skipTransition = false, Action onComplete = null, float time = -1f, Ease easeOverride = Ease.INTERNAL_Zero)
		{
		}

		public void PlayFadeInWithCurve(bool skipTransition = false, Action onComplete = null, float time = -1f, AnimationCurve easeCurve = null)
		{
		}

		public void PlayFadeOutWithCurve(bool skipTransition = false, Action onComplete = null, float time = -1f, AnimationCurve easeCurve = null)
		{
		}

		private void PlayTransition(Color startColor, Color endColor, float time, Action<Tween> setEase, Action onComplete, bool skipTransition)
		{
		}
	}
}
