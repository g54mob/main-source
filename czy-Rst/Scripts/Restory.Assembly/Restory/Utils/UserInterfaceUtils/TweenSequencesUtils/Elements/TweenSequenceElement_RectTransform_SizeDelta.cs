using System;
using DG.Tweening;
using UnityEngine;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_RectTransform_SizeDelta : TweenSequenceElement_RectTransform
	{
		private static class TransformSizeStyle
		{
			public const string TransformSizeSettings = "Rect Transform Width&Height Settings";
		}

		[SerializeField]
		private RectTransform transformToResize;

		[SerializeField]
		private Vector2 targetSizeValue;

		public override Tween Tween => SetUpTween(transformToResize.DOSizeDelta(targetSizeValue, base.sequenceElementDuration));
	}
}
