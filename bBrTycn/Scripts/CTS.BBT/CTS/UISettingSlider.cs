using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public abstract class UISettingSlider<T> : UISetting<T>
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		protected Slider _slider;

		[SerializeField]
		protected TMP_Text _valueText;

		[SerializeField]
		private string _toStringFormat = "N0";

		[SerializeField]
		private string _textFormat = "{0}";

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_slider.onValueChanged.AddListener(OnSliderValueChanged);
			_setting.ValueChanged += OnSettingValueChanged;
			OnSettingValueChanged(_setting.GetValue());
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_slider.onValueChanged.RemoveListener(OnSliderValueChanged);
			_setting.ValueChanged -= OnSettingValueChanged;
		}

		public void SetRange(Vector2 range)
		{
			_slider.maxValue = range.y;
			_slider.minValue = range.x;
		}

		private void OnSettingValueChanged(T value)
		{
			_slider.value = GetValueForSlider(value);
			UpdateText();
		}

		protected abstract float GetValueForSlider(T settingValue);

		protected abstract T GetValueForSetting(float sliderValue);

		private void OnSliderValueChanged(float value)
		{
			_setting.SetValue(GetValueForSetting(value));
		}

		protected virtual void UpdateText()
		{
			if ((bool)_valueText)
			{
				_valueText.text = string.Format(_textFormat, _slider.value.ToString(_toStringFormat));
			}
		}
	}
}
