using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_BlinkingImage : MonoBehaviour
	{
		[SerializeField]
		private Image targetImage;

		[SerializeField]
		private Color activeColor;

		[SerializeField]
		private Color inactiveColor;

		[SerializeField]
		[Range(0.1f, 5f)]
		private float oneColorShowTime = 1f;

		private Coroutine blinkingCoroutine;

		private void OnEnable()
		{
			targetImage.color = inactiveColor;
		}

		private void OnDisable()
		{
			KillBlinkingCoroutine();
		}

		public void TurnBlinkingOff(BlinkingImageStoppedModeColorOptions colorToSet = BlinkingImageStoppedModeColorOptions.UseInactiveColor)
		{
			if (blinkingCoroutine != null)
			{
				StopCoroutine(blinkingCoroutine);
				blinkingCoroutine = null;
			}
			switch (colorToSet)
			{
			case BlinkingImageStoppedModeColorOptions.UseInactiveColor:
				targetImage.color = inactiveColor;
				break;
			case BlinkingImageStoppedModeColorOptions.UseActiveColor:
				targetImage.color = activeColor;
				break;
			default:
				throw new NotImplementedException();
			case BlinkingImageStoppedModeColorOptions.UseLastColor:
				break;
			}
		}

		public void TurnBlinkingOn()
		{
			if (base.isActiveAndEnabled && blinkingCoroutine == null)
			{
				blinkingCoroutine = StartCoroutine(BlinkingCoroutine());
			}
		}

		private IEnumerator BlinkingCoroutine()
		{
			while (true)
			{
				targetImage.color = ((targetImage.color == activeColor) ? inactiveColor : activeColor);
				yield return new WaitForSeconds(oneColorShowTime);
			}
		}

		private void KillBlinkingCoroutine()
		{
			if (blinkingCoroutine != null)
			{
				StopCoroutine(blinkingCoroutine);
				blinkingCoroutine = null;
			}
		}
	}
}
