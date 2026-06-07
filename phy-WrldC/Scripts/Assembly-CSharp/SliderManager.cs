using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
	private Func<float, string> lastOnLabelChangedCallback;

	private TextMeshProUGUI sliderLabel;

	private TextMeshProUGUI sliderValue;

	private Slider slider;

	private float minValue;

	private float maxValue;

	private float stepValue;

	private float scaleValue;

	private string displayFormat;

	private Canvas parentCanvas;

	public string Label
	{
		get
		{
			return sliderLabel.text;
		}
		set
		{
			sliderLabel.text = value + ":";
		}
	}

	public float CurrentValue { get; private set; }

	public event Action<float> OnValueChangedEvent;

	private event Func<float, string> OnLabelChangedEvent;

	private void Awake()
	{
		scaleValue = 1f;
		GetSliderResources();
	}

	private void GetSliderResources()
	{
		if (sliderLabel == null)
		{
			sliderLabel = base.transform.FindComponent<TextMeshProUGUI>("Label");
		}
		if (sliderValue == null)
		{
			sliderValue = base.transform.FindComponent<TextMeshProUGUI>("Value");
		}
		if (slider == null)
		{
			slider = base.transform.FindComponent<Slider>("Slider", isRecursively: true);
		}
		if (parentCanvas == null)
		{
			parentCanvas = GetComponentInParent<Canvas>();
		}
	}

	public void ConfigureProperties(float currentValue, float minValue, float maxValue, float stepValue, string displayFormat = "{0}")
	{
		GetSliderResources();
		this.minValue = minValue;
		this.maxValue = maxValue;
		this.stepValue = stepValue;
		this.displayFormat = displayFormat;
		currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
		sliderValue.text = string.Format(displayFormat, currentValue * scaleValue);
		_ = (maxValue - minValue) / stepValue;
		slider.maxValue = maxValue / stepValue;
		slider.minValue = minValue / stepValue;
		slider.value = currentValue / stepValue;
		slider.onValueChanged.RemoveAllListeners();
		slider.onValueChanged.AddListener(delegate(float value)
		{
			if (parentCanvas.enabled)
			{
				value *= stepValue;
				if (this.OnLabelChangedEvent != null)
				{
					sliderValue.text = this.OnLabelChangedEvent(value);
				}
				else
				{
					sliderValue.text = string.Format(displayFormat, value * scaleValue);
				}
				CurrentValue = value;
				this.OnValueChangedEvent?.Invoke(value);
			}
		});
		CurrentValue = currentValue;
	}

	public void SetCurrentValue(float value, float scaleValue = 1f)
	{
		this.scaleValue = scaleValue;
		value = Mathf.Clamp(value, minValue, maxValue);
		slider.SetValue(value / stepValue);
		CurrentValue = value;
		if (this.OnLabelChangedEvent != null)
		{
			sliderValue.text = this.OnLabelChangedEvent(value);
		}
		else
		{
			sliderValue.text = string.Format(displayFormat, value * scaleValue);
		}
	}

	public void SetCustomLabelChangedCallback(Func<float, string> onLabelChangedCallback)
	{
		if (lastOnLabelChangedCallback != null)
		{
			OnLabelChangedEvent -= lastOnLabelChangedCallback;
		}
		OnLabelChangedEvent += onLabelChangedCallback;
		SetCurrentValue(CurrentValue, scaleValue);
		lastOnLabelChangedCallback = onLabelChangedCallback;
	}
}
