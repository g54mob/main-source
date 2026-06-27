using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UI.Presenters
{
	public class GUI_SliderTextValue : MonoBehaviour
	{
		[SerializeField]
		private Slider slider;

		[SerializeField]
		private TextMeshProUGUI text;

		[SerializeField]
		private string format = "P0";

		private void Reset()
		{
			slider = GetComponent<Slider>();
			text = GetComponentInChildren<TextMeshProUGUI>();
		}

		private void OnEnable()
		{
			UpdateValue();
			slider.onValueChanged.AddListener(ResolveOnSliderValueChanged);
		}

		private void OnDisable()
		{
			slider.onValueChanged.RemoveListener(ResolveOnSliderValueChanged);
		}

		private void UpdateValue()
		{
			text.text = slider.value.ToString(format);
		}

		private void ResolveOnSliderValueChanged(float value)
		{
			UpdateValue();
		}
	}
}
