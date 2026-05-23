using MPUIKIT;
using Rewired;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class TFUISlider : MonoBehaviour
{
	public float minValue;

	public float maxValue = 1f;

	public float value = 1f;

	public float increments = 0.1f;

	public int displayFPPrecision = 1;

	public ThronefallUIElement target;

	public ThronefallUIElement.NavigationDirection increase;

	public ThronefallUIElement.NavigationDirection decrease = ThronefallUIElement.NavigationDirection.Left;

	public TextMeshProUGUI display;

	public GameObject knob;

	public GameObject tooltip;

	public RectTransform backgroundRect;

	public RectTransform fillRect;

	public MPImageBasic fillImg;

	public MPImageBasic knobImg;

	public UnityEvent onChange;

	public UnityEvent onNavigate;

	public bool customLabelRemapping;

	public float minLabelValue = 50f;

	public float maxLabelValue = 150f;

	public string suffix = "%";

	private Player input;

	private void Start()
	{
		target.onEmptyNavigate.AddListener(Navigate);
		target.onSelectionStateChange.AddListener(ToggleSelectionUI);
		input = ReInput.players.GetPlayer(0);
	}

	private void OnEnable()
	{
		ToggleSelectionUI();
	}

	private void UpdateDisplay()
	{
		fillRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, backgroundRect.sizeDelta.x * Mathf.InverseLerp(minValue, maxValue, value));
		if (customLabelRemapping)
		{
			display.text = Mathf.Lerp(minLabelValue, maxLabelValue, Mathf.InverseLerp(minValue, maxValue, value)).ToString("F" + displayFPPrecision) + suffix;
		}
		else
		{
			display.text = value.ToString("F" + displayFPPrecision);
		}
	}

	public void Navigate(ThronefallUIElement.NavigationDirection direction)
	{
		onNavigate.Invoke();
		if (direction == increase)
		{
			value += increments;
		}
		else if (direction == decrease)
		{
			value -= increments;
		}
		if (value > maxValue)
		{
			value = maxValue;
		}
		if (value < minValue)
		{
			value = minValue;
		}
		UpdateDisplay();
		onChange.Invoke();
	}

	public void Increase()
	{
		Navigate(increase);
	}

	public void Decrease()
	{
		Navigate(decrease);
	}

	public void OnTFUIStateChange()
	{
	}

	public void SetValue(float v)
	{
		value = v;
		if (value > maxValue)
		{
			value = maxValue;
		}
		if (value < minValue)
		{
			value = minValue;
		}
		UpdateDisplay();
	}

	public void SetValueByScreenPoint(Vector2 point)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundRect, input.controllers.Mouse.screenPosition, null, out point);
		if (point.x < 0f)
		{
			point.x = 0f;
		}
		if (point.x > backgroundRect.sizeDelta.x)
		{
			point.x = backgroundRect.sizeDelta.x;
		}
		float t = Mathf.InverseLerp(0f, backgroundRect.sizeDelta.x, point.x);
		int num = Mathf.RoundToInt(Mathf.Lerp(minValue, maxValue, t) / increments);
		value = increments * (float)num;
		UpdateDisplay();
		onChange.Invoke();
	}

	private void ToggleSelectionUI()
	{
		bool active = target.CurrentState == ThronefallUIElement.SelectionState.FocussedAndSelected || target.CurrentState == ThronefallUIElement.SelectionState.Selected;
		knob.SetActive(active);
		if (tooltip != null)
		{
			tooltip.SetActive(active);
		}
	}
}
