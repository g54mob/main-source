using System;
using Mandragora.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Utils.UserInterfaceUtils.TweenSequencesUtils.FinalStates
{
	[Serializable]
	public class TweenSequenceImageFinalState
	{
		[SerializeField]
		private Image imageToAffect;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setColor;

		[SerializeField]
		private Color finalColor = Color.white;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setAlpha;

		[SerializeField]
		private float finalAlphaValue = 1f;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool setFillAmount;

		[SerializeField]
		private float finalFillAmount = 1f;

		public void ApplySettings()
		{
			if (setColor)
			{
				imageToAffect.color = finalColor;
			}
			if (setAlpha)
			{
				imageToAffect.color = new Color(imageToAffect.color.r, imageToAffect.color.g, imageToAffect.color.b, finalAlphaValue);
			}
			if (setFillAmount)
			{
				imageToAffect.fillAmount = finalFillAmount;
			}
		}
	}
}
