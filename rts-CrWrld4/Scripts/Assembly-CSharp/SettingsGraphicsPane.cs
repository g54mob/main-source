using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SettingsGraphicsPane : MonoBehaviour
{
	[Serializable]
	public class OnValueChanged : UnityEvent<float>
	{
	}

	public Toggle windowToggle;

	public Toggle fullScreenToggle;

	public Toggle fullScreenExclusiveToggle;

	public Dropdown windowResolutionComboBox;

	public Dropdown fullScreenResolutionComboBox;

	public Dropdown monitorComboBox;

	public Slider uiscaleSlider;

	public Toggle uiAutoScale;

	public TextMeshProUGUI currentRes;

	public Text hiResInstructions;

	public OnValueChanged onUIScaleChanged;

	private int lastWidth;

	private int lastHeight;

	public void OnEnable()
	{
	}

	private void Start()
	{
	}

	private void Refresh()
	{
	}

	public void Update()
	{
	}

	private void SetMonitorControls()
	{
	}

	private void SetWindowResolutionsInControls()
	{
	}

	public void ApplySettings()
	{
	}

	public static void SetFullScreen(bool fullScreen, int w, int h, bool exclusive, bool forceUpdate = false)
	{
	}

	public void UIScaleChange(float val)
	{
	}

	public void OnUIAutoScaleChange(bool val)
	{
	}
}
