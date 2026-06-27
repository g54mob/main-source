using System;
using Mandragora.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates
{
	[Serializable]
	public class TextFinalState
	{
		[SerializeField]
		private Text text;

		[SerializeField]
		private TextMeshProUGUI textMeshPro;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setColor;

		[SerializeField]
		private Color finalColor = Color.grey;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setAlpha;

		[SerializeField]
		private float finalAlphaValue = 1f;

		public void ApplySettings()
		{
			if (textMeshPro != null)
			{
				if (setColor)
				{
					textMeshPro.color = finalColor;
				}
				if (setAlpha)
				{
					textMeshPro.alpha = finalAlphaValue;
				}
			}
			else if (text != null)
			{
				if (setColor)
				{
					text.color = finalColor;
				}
				if (setAlpha)
				{
					text.color = new Color(text.color.r, text.color.g, text.color.b, finalAlphaValue);
				}
			}
			else
			{
				Debug.LogError("[TextFinalState] has no text component set!");
			}
		}
	}
}
