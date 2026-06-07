using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UIScripts
{
	public class UpdtSpeedSlider : MonoBehaviour
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
			SliderValue.text = prefix + Mathf.Round(Mathf.Pow(5f, value) * Mathf.Pow(10f, precision)) / Mathf.Pow(10f, precision) + sufix;
		}
	}
}
