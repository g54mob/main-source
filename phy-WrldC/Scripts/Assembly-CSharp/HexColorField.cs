using TMPro;
using UnityEngine;

public class HexColorField : MonoBehaviour
{
	public ColorPicker hsvpicker;

	public bool displayAlpha;

	private TMP_InputField hexInputField;

	public bool IsHexInputFieldFocused => hexInputField.isFocused;

	private void Awake()
	{
		hexInputField = GetComponent<TMP_InputField>();
		hexInputField.onEndEdit.AddListener(UpdateColor);
		hsvpicker.onValueChanged.AddListener(UpdateHex);
	}

	private void OnDestroy()
	{
		hexInputField.onValueChanged.RemoveListener(UpdateColor);
		hsvpicker.onValueChanged.RemoveListener(UpdateHex);
	}

	private void UpdateHex(Color newColor)
	{
		hexInputField.text = ColorToHex(newColor);
	}

	private void UpdateColor(string newHex)
	{
		if (!newHex.StartsWith("#"))
		{
			newHex = "#" + newHex;
		}
		if (ColorUtility.TryParseHtmlString(newHex, out var color))
		{
			Color currentColor = hsvpicker.CurrentColor;
			hsvpicker.CurrentColor = color;
			hsvpicker?.OnValueDiscretChanged(currentColor, color);
		}
		else
		{
			UpdateHex(hsvpicker.CurrentColor);
			Debug.Log("hex value is in the wrong format, valid formats are: #RGB, #RGBA, #RRGGBB and #RRGGBBAA (# is optional)");
		}
	}

	private string ColorToHex(Color32 color)
	{
		if (!displayAlpha)
		{
			return $"#{color.r:X2}{color.g:X2}{color.b:X2}";
		}
		return $"#{color.r:X2}{color.g:X2}{color.b:X2}{color.a:X2}";
	}
}
