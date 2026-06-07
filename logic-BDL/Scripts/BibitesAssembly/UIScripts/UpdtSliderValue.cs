using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class UpdtSliderValue : MonoBehaviour
	{
		public string prefix;

		public string sufix;

		public int precision = 1;

		public Slider slider;

		private TextMeshProUGUI SliderValue;

		private void Start()
		{
			SliderValue = GetComponent<TextMeshProUGUI>();
			TextUpdate(slider.value);
		}

		public void TextUpdate(float value)
		{
			if (SliderValue == null)
			{
				SliderValue = GetComponent<TextMeshProUGUI>();
			}
			SliderValue.text = prefix + Mathf.Round(value * Mathf.Pow(10f, precision)) / Mathf.Pow(10f, precision) + sufix;
		}
	}
}
