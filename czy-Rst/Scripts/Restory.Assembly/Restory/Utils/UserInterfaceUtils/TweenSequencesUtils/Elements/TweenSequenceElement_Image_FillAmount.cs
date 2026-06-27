using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Image_FillAmount : TweenSequenceElement_Tween
	{
		protected static class ImageFillAmountStyle
		{
			public const string ImageFillAmountSettings = "Image Fill Amount Settings";
		}

		[SerializeField]
		private Image image;

		[SerializeField]
		private float endValue;

		public override Tween Tween => SetUpTween(image.DOFillAmount(endValue, base.sequenceElementDuration));
	}
}
