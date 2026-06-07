using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class InteractableSlider
{
	[Tooltip("Slider component.")]
	[SerializeField]
	private Slider _slider;

	[Tooltip("Text component for this slider.")]
	[SerializeField]
	private TextMeshProUGUI _valueText;

	[Tooltip("Format for the value text.")]
	[SerializeField]
	private string _textFormat = "F0";

	public void SetValue(float value)
	{
		_slider.value = value;
		if (_valueText != null)
		{
			_valueText.text = _slider.value.ToString(_textFormat, CultureInfo.InvariantCulture);
		}
	}

	public void SetValueNormalized(float value)
	{
		_slider.normalizedValue = value;
		if (_valueText != null)
		{
			_valueText.text = _slider.value.ToString(_textFormat, CultureInfo.InvariantCulture);
		}
	}

	public float ReturnValue(bool updateTextValue = false)
	{
		if (updateTextValue && _valueText != null)
		{
			_valueText.text = _slider.value.ToString(_textFormat, CultureInfo.InvariantCulture);
		}
		return _slider.value;
	}

	public float ReturnValueNormalized(bool updateTextValue = false)
	{
		if (updateTextValue && _valueText != null)
		{
			_valueText.text = _slider.value.ToString(_textFormat, CultureInfo.InvariantCulture);
		}
		return _slider.normalizedValue;
	}
}
