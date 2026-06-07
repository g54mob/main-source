using UnityEngine;
using UnityEngine.UI;
using VRTK.Controllables;
using VRTK.Controllables.ArtificialBased;

namespace VRTK.Examples
{
	public class ToggleGameObjectSlider : MonoBehaviour
	{
		public VRTK_ArtificialSlider slider;

		public Text descriptionText;

		public ToggleGameObjectSliderOptions[] options;

		protected virtual void OnEnable()
		{
			if (slider != null)
			{
				slider.ValueChanged += ValueChanged;
			}
			ToggleOption(0);
		}

		protected virtual void OnDisable()
		{
			if (slider != null)
			{
				slider.ValueChanged -= ValueChanged;
			}
		}

		protected virtual void ValueChanged(object sender, ControllableEventArgs e)
		{
			ToggleOption(Mathf.RoundToInt(e.value));
		}

		protected virtual void ToggleOption(int index)
		{
			ToggleGameObjectSliderOptions[] array = options;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].option.SetActive(value: false);
			}
			ToggleGameObjectSliderOptions toggleGameObjectSliderOptions = options[index];
			toggleGameObjectSliderOptions.option.SetActive(value: true);
			descriptionText.text = toggleGameObjectSliderOptions.description;
		}
	}
}
