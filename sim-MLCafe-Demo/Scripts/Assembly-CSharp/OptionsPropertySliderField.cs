using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class OptionsPropertySliderField : OptionsPropertyField<SliderField>
{
	[SerializeField]
	private UnityEvent<float> OnUpdateSetting = new UnityEvent<float>();

	private void OnEnable()
	{
		OnUpdateField(GetSliderField().GetSliderValue());
	}

	public SliderField GetSliderField()
	{
		return propertyField;
	}

	[ContextMenu("UpdateSetting")]
	public void UpdateSetting(float value)
	{
		OnUpdateSetting.Invoke(value);
	}

	public void OnUpdateField(float value)
	{
		GetSliderField().SetValueWithoutNotify(value);
	}
}
