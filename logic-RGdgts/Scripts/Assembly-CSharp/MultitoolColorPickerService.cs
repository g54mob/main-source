using System;
using TMPro;
using UI.Apps;
using UnityEngine;
using UnityEngine.UI;

public class MultitoolColorPickerService : MultitoolService
{
	public enum ColorMode
	{
		RGB = 0,
		HSV = 1
	}

	public TMP_InputField hexInput;

	public Slider[] sliders;

	public Image[] slidersBackground;

	public TMP_InputField[] inputs;

	public TextMeshProUGUI[] labels;

	public Toggle rgbToggle;

	public Toggle hsvToggle;

	public Image oldColorImage;

	public Image colorImage;

	protected Color32 oldColor;

	protected Color32 color;

	private Action<Color32> onColorChange;

	protected ColorMode colorMode;

	private Material[] materials;

	private Action OnClose;

	private bool settingColor;

	public void Show(Color oldColor, Action<Color32> onColorChange, Action OnClose = null)
	{
	}

	public override void OnMultitoolAppStart(MultiToolAppInfo appInfo)
	{
	}

	public void OnCloseButtonDown()
	{
	}

	public void OnOldColorClick()
	{
	}

	private void RefreshColor()
	{
	}

	private void SetColor(Color32 color)
	{
	}

	public void OnEndInput(int i)
	{
	}

	public void OnSliderChange(int i)
	{
	}

	public void OnHexInput()
	{
	}

	public void SetRGB()
	{
	}

	public void SetHSV()
	{
	}

	public void OnRGBToggle(bool value)
	{
	}

	public void OnHSVToggle(bool value)
	{
	}
}
