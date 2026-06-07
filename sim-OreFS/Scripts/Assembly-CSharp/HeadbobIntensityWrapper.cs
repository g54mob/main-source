using System.Collections;
using GameCreator.Runtime.Variables;
using Kamgam.SettingsGenerator;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

public class HeadbobIntensityWrapper : MonoBehaviour
{
	public GlobalNameVariables settingsVariables;

	private void OnEnable()
	{
		StartCoroutine(DetectHeadbobIntensity());
	}

	public void CheckHeadbobIntensity()
	{
		StartCoroutine(DetectHeadbobIntensity(0.5f));
	}

	private IEnumerator DetectHeadbobIntensity(float waitTime = 1.5f)
	{
		yield return new WaitForSeconds(1.5f);
		float currentValue = HeadbobIntensityConnection.CurrentValue;
		SetSettingsVariables("ST-Camera-Bob", currentValue);
	}

	public void SetSettingsVariables(string key, object value)
	{
		settingsVariables.Set(key, value);
	}

	public void SetHeadbobIntensity(SliderWithEventOverridesUGUI slider)
	{
		float value = slider.value;
		SetSettingsVariables("ST-Camera-Bob", value);
	}
}
