using System;
using UnityEngine.UI;

public class SensControl : ActiveComponent
{
	[SceneBind("SensSlider")]
	public Slider SensSlider;

	[SceneBind("MinValue")]
	public Text MinValue;

	[SceneBind("MaxValue")]
	public Text MaxValue;

	private void SensChange(float val)
	{
		ActiveComponent.Model.globalSaves.cursorJoyConSens = val;
		MinValue.text = Logic.ColorTransform("GREEN", Math.Round(ActiveComponent.Model.globalSaves.cursorJoyConSens, 2).ToString());
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		MinValue.text = Logic.ColorTransform("GREEN", Math.Round(ActiveComponent.Model.globalSaves.cursorJoyConSens, 2).ToString());
		SensSlider.minValue = ActiveComponent._staticData.Settings.MinSens;
		SensSlider.maxValue = 10f;
		SensSlider.value = ActiveComponent.Model.globalSaves.cursorJoyConSens;
		SensSlider.onValueChanged.AddListener(SensChange);
	}

	private void Update()
	{
		if (ActiveComponent._staticData != null && ActiveComponent.Model.globalSaves != null && !base.IsInited)
		{
			Init();
		}
	}
}
