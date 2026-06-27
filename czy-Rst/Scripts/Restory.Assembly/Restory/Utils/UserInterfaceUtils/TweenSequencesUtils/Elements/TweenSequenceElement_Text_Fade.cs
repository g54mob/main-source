using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Text_Fade : TweenSequenceElement_Tween
	{
		protected static class TextFadeStyle
		{
			public const string TextFadeSettings = "Text Fade Settings";
		}

		[SerializeField]
		private Text text;

		[SerializeField]
		private TextMeshProUGUI textMeshPro;

		[SerializeField]
		private float endValue;

		public override Tween Tween
		{
			get
			{
				if (textMeshPro != null)
				{
					return SetUpTween(textMeshPro.DOFade(endValue, base.sequenceElementDuration));
				}
				if (text != null)
				{
					return SetUpTween(text.DOFade(endValue, base.sequenceElementDuration));
				}
				Debug.LogError("[TweenSequenceElement_Text_Fade] has no text component set!");
				return null;
			}
		}
	}
}
