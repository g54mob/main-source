using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.Elements
{
	[Serializable]
	public class TweenSequenceElement_Text_Color : TweenSequenceElement_Tween
	{
		protected static class TextColorStyle
		{
			public const string TextColorSettings = "Text Color Settings";
		}

		[SerializeField]
		private Text text;

		[SerializeField]
		private TextMeshProUGUI textMeshPro;

		[SerializeField]
		private Color endColor = Color.grey;

		public override Tween Tween
		{
			get
			{
				if (textMeshPro != null)
				{
					return SetUpTween(textMeshPro.DOColor(endColor, base.sequenceElementDuration));
				}
				if (text != null)
				{
					return SetUpTween(text.DOColor(endColor, base.sequenceElementDuration));
				}
				Debug.LogError("[TweenSequenceElement_Text_Color] has no text component set!");
				return null;
			}
		}
	}
}
