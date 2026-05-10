using DG.Tweening;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupScale : CanvasGroupTweenEffect
	{
		[SerializeField]
		[Header("Canvas Group Scale")]
		private Vector3 _shownLocalScale = new Vector3(1f, 1f, 1f);

		[SerializeField]
		private Vector3 _hiddenLocalScale = Vector3.zero;

		protected override Tween HideEffect()
		{
			return Scale(_hiddenLocalScale, _hideDuration, _hideEase);
		}

		protected override void SetHideResult()
		{
			base.RectTransform.localScale = _hiddenLocalScale;
		}

		protected override void SetShowResult()
		{
			base.RectTransform.localScale = _shownLocalScale;
		}

		protected override Tween ShowEffect()
		{
			return Scale(_shownLocalScale, _showDuration, _showEase);
		}

		private Tween Scale(Vector3 targetScale, float duration, Ease ease)
		{
			return base.RectTransform.DOScale(targetScale, duration).SetEase(ease).SetUpdate(isIndependentUpdate: true);
		}
	}
}
