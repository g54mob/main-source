using System;
using DG.Tweening;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.UI
{
	public class CanvasGroupMove : CanvasGroupTweenEffect
	{
		[SerializeField]
		[Header("Canvas Group Position")]
		public Vector3 _shownLocalPosition;

		[SerializeField]
		public Vector3 _hiddenLocalPosition;

		[SerializeField]
		private bool _worldCanvas;

		public static event Action SlidingPanel;

		private void Reset()
		{
			_shownLocalPosition = GetComponent<RectTransform>().anchoredPosition;
		}

		[Button("Save LocalPosition On Showed", EButtonEnableMode.Editor)]
		private void SaveLocalPositionOnShowed()
		{
			_shownLocalPosition = GetComponent<RectTransform>().anchoredPosition;
		}

		[Button("Save LocalPosition On Hided", EButtonEnableMode.Editor)]
		private void SaveLocalPositionOnHided()
		{
			_hiddenLocalPosition = GetComponent<RectTransform>().anchoredPosition;
		}

		protected override Tween HideEffect()
		{
			Sequence sequence = DOTween.Sequence(base.RectTransform);
			sequence.Append(Move(_hiddenLocalPosition, _hideDuration, _hideEase));
			return sequence;
		}

		protected override void SetHideResult()
		{
			base.RectTransform.anchoredPosition = _hiddenLocalPosition;
		}

		protected override void SetShowResult()
		{
			base.RectTransform.anchoredPosition = _shownLocalPosition;
		}

		protected override Tween ShowEffect()
		{
			Sequence sequence = DOTween.Sequence(base.RectTransform);
			sequence.Append(Move(_shownLocalPosition, _showDuration, _showEase));
			return sequence;
		}

		private Tween Move(Vector3 targetLocalPosition, float duration, Ease ease)
		{
			Tweener obj = (_worldCanvas ? ((Tweener)base.RectTransform.DOLocalMove(targetLocalPosition, duration)) : ((Tweener)base.RectTransform.DOAnchorPos(targetLocalPosition, duration)));
			((Tween)obj).SetEase(ease).SetUpdate(isIndependentUpdate: true);
			return obj;
		}
	}
}
