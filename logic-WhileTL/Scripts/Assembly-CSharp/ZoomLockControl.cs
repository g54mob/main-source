using System;
using UnityEngine;
using UnityEngine.UI;

public class ZoomLockControl : ActiveComponent
{
	[SceneBind("ZoomLockSlider")]
	public Slider ZoomLockSlider;

	[SceneBind("Disable")]
	public Toggle DisableToggle;

	[SceneBind("MinValue")]
	public Text MinValue;

	[SceneBind("MaxValue")]
	public Text MaxValue;

	private void ZoomLockChange(float val)
	{
		ActiveComponent.Model.globalSaves.maxLockedZoom = val;
		MinValue.text = Logic.ColorTransform("GREEN", 100.0 * Math.Round(ActiveComponent.Model.globalSaves.maxLockedZoom, 2) + "%");
		if (Mathf.Abs(val - ZoomLockSlider.minValue) < 0.001f)
		{
			DisableToggle.isOn = false;
		}
	}

	private void DisableClick(bool click)
	{
		ActiveComponent.Model.globalSaves.enableLockZoom = click;
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		Logic.UpdateGlobalSaves();
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		MinValue.text = Logic.ColorTransform("GREEN", 100.0 * Math.Round(ActiveComponent.Model.globalSaves.maxLockedZoom, 2) + "%");
		ZoomLockSlider.minValue = ActiveComponent._staticData.Settings.MinZoom;
		ZoomLockSlider.maxValue = ActiveComponent._staticData.Settings.MaxLockInterractZoom;
		ZoomLockSlider.value = ActiveComponent.Model.globalSaves.maxLockedZoom;
		ZoomLockSlider.onValueChanged.AddListener(ZoomLockChange);
		DisableToggle.isOn = ActiveComponent.Model.globalSaves.enableLockZoom;
		DisableToggle.onValueChanged.AddListener(DisableClick);
	}

	private void Update()
	{
		if (ActiveComponent._staticData != null && ActiveComponent.Model.globalSaves != null && !base.IsInited)
		{
			Init();
		}
		if (ActiveComponent.Model != null && ActiveComponent.Model.globalSaves != null)
		{
			if (ActiveComponent.Model.globalSaves.enableLockZoom != DisableToggle.isOn)
			{
				DisableToggle.isOn = ActiveComponent.Model.globalSaves.enableLockZoom;
			}
			if (Mathf.Abs(ActiveComponent.Model.globalSaves.maxLockedZoom - ZoomLockSlider.value) > 0.01f)
			{
				ZoomLockSlider.value = ActiveComponent.Model.globalSaves.maxLockedZoom;
			}
		}
	}

	private void LateUpdate()
	{
		if (ActiveComponent._staticData != null && ActiveComponent.Model.globalSaves != null && !base.IsInited)
		{
			Init();
		}
		if (ActiveComponent.Model != null && ActiveComponent.Model.globalSaves != null)
		{
			if (ActiveComponent.Model.globalSaves.enableLockZoom != DisableToggle.isOn)
			{
				DisableToggle.isOn = ActiveComponent.Model.globalSaves.enableLockZoom;
			}
			if (Mathf.Abs(ActiveComponent.Model.globalSaves.maxLockedZoom - ZoomLockSlider.value) > 0.01f)
			{
				ZoomLockSlider.value = ActiveComponent.Model.globalSaves.maxLockedZoom;
			}
		}
	}
}
