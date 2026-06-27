using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Image_Color : TweenSequenceElement_Tween
	{
		protected static class ImageColorStyle
		{
			public const string ImageColorSettings = "Image Color Settings";
		}

		[SerializeField]
		private Image image;

		[SerializeField]
		private Color endValue = Color.white;

		public override Tween Tween => SetUpTween(image.DOColor(endValue, base.sequenceElementDuration));
	}
}
