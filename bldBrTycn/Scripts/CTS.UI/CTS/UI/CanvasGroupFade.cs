using DG.Tweening;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupFade : CanvasGroupTweenEffect
	{
		[SerializeField]
		[Header("Canvas Group Alpha")]
		private float _shownAlpha = 1f;

		[SerializeField]
		private float _hiddenAlpha;

		protected override Tween ShowEffect()
		{
			return Alpha(_shownAlpha, _showDuration, _showEase);
		}

		protected override Tween HideEffect()
		{
			return Alpha(_hiddenAlpha, _hideDuration, _hideEase);
		}

		private Tween Alpha(float targetAlpha, float duration, Ease ease)
		{
			return base.CanvasGroup.DOFade(targetAlpha, duration).SetEase(ease).SetUpdate(isIndependentUpdate: true);
		}

		protected override void SetShowResult()
		{
			base.CanvasGroup.alpha = _shownAlpha;
		}

		protected override void SetHideResult()
		{
			base.CanvasGroup.alpha = _hiddenAlpha;
		}
	}
}
