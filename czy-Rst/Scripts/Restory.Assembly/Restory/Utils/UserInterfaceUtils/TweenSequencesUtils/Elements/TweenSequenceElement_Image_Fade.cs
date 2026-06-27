using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Image_Fade : TweenSequenceElement_Tween
	{
		protected static class ImageFadeStyle
		{
			public const string ImageFadeSettings = "Image Fade Settings";
		}

		[SerializeField]
		private Image image;

		[SerializeField]
		private float endValue;

		public override Tween Tween => SetUpTween(image.DOFade(endValue, base.sequenceElementDuration));
	}
}
