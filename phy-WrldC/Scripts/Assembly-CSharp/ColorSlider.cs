using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ColorSlider : MonoBehaviour
{
	public ColorPicker hsvpicker;

	public ColorValues type;

	private Slider slider;

	private bool listen = true;

	private float preSliderValue;

	private Color lastColor = Color.white;

	private bool isNewColorBeingSelected;

	private void Awake()
	{
		slider = GetComponent<Slider>();
		hsvpicker.onValueChanged.AddListener(ColorChanged);
		hsvpicker.onHSVChanged.AddListener(HSVChanged);
		slider.onValueChanged.AddListener(SliderChanged);
		isNewColorBeingSelected = false;
		Util.AddMouseUIEvent(slider.gameObject, EventTriggerType.PointerDown, delegate(BaseEventData eventData)
		{
			if ((eventData as PointerEventData).button == PointerEventData.InputButton.Left)
			{
				isNewColorBeingSelected = true;
			}
		});
		Util.AddMouseUIEvent(slider.gameObject, EventTriggerType.PointerUp, delegate(BaseEventData eventData)
		{
			if ((eventData as PointerEventData).button == PointerEventData.InputButton.Left)
			{
				hsvpicker.OnValueDiscretChanged?.Invoke(lastColor, hsvpicker.CurrentColor);
				isNewColorBeingSelected = false;
			}
		});
	}

	private void LateUpdate()
	{
		if (!isNewColorBeingSelected)
		{
			lastColor = hsvpicker.CurrentColor;
		}
	}

	private void OnDestroy()
	{
		hsvpicker.onValueChanged.RemoveListener(ColorChanged);
		hsvpicker.onHSVChanged.RemoveListener(HSVChanged);
		slider.onValueChanged.RemoveListener(SliderChanged);
	}

	private void ColorChanged(Color newColor)
	{
		listen = false;
		switch (type)
		{
		case ColorValues.R:
			slider.normalizedValue = newColor.r;
			break;
		case ColorValues.G:
			slider.normalizedValue = newColor.g;
			break;
		case ColorValues.B:
			slider.normalizedValue = newColor.b;
			break;
		case ColorValues.A:
			slider.normalizedValue = newColor.a;
			break;
		}
	}

	private void HSVChanged(float hue, float saturation, float value)
	{
		listen = false;
		switch (type)
		{
		case ColorValues.Hue:
			slider.normalizedValue = hue;
			break;
		case ColorValues.Saturation:
			slider.normalizedValue = saturation;
			break;
		case ColorValues.Value:
			slider.normalizedValue = value;
			break;
		}
	}

	private void SliderChanged(float newValue)
	{
		newValue = slider.normalizedValue;
		hsvpicker.AssignColor(type, newValue);
		listen = true;
	}
}
