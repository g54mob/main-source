using System;
using DG.Tweening;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_CanvasGroup_Fade : TweenSequenceElement_Tween
	{
		protected static class CanvasGroupFadeStyle
		{
			public const string CanvasGroupFadeSettings = "CanvasGroup Fade Settings";
		}

		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private float endValue;

		public override Tween Tween => SetUpTween(canvasGroup.DOFade(endValue, base.sequenceElementDuration));
	}
}
