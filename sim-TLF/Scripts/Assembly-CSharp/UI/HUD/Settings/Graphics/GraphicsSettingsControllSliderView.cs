using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI.HUD.Settings.Graphics
{
	public class GraphicsSettingsControllSliderView : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider;

		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _sliderValue;

		public void Init(string name, UnityAction<float> onToggleChanged, float defaultValue = 60f)
		{
			_slider.onValueChanged.AddListener(onToggleChanged);
			_slider.onValueChanged.AddListener(SetValueText);
			_titleText.text = name;
			_slider.value = defaultValue;
		}

		private void SetValueText(float value)
		{
			_sliderValue.text = ((int)value).ToString();
		}
	}
}
