using Restory.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_SliderSFX : GUI_SfxEventHandler
	{
		[SerializeField]
		private Slider slider;

		private void OnEnable()
		{
			slider.onValueChanged.AddListener(ResolveSliderValueChanged);
		}

		private void OnDisable()
		{
			if (slider.MonoShellExists())
			{
				slider.onValueChanged.RemoveListener(ResolveSliderValueChanged);
			}
		}

		private void ResolveSliderValueChanged(float newSliderValue)
		{
			TryToPlaySound(soundBank.OnSliderMoveSound);
		}
	}
}
