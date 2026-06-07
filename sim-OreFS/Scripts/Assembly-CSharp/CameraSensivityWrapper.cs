using System.Collections;
using GameCreator.Runtime.Variables;
using Kamgam.SettingsGenerator;
using Kamgam.UGUIComponentsForSettings;
using UnityEngine;

public class CameraSensivityWrapper : MonoBehaviour
{
	public GlobalNameVariables settingsVariables;

	private void OnEnable()
	{
		StartCoroutine(DetectCurrentSensivity());
	}

	public void CheckCameraSensivity()
	{
		StartCoroutine(DetectCurrentSensivity(0.5f));
	}

	private IEnumerator DetectCurrentSensivity(float waitTime = 1.5f)
	{
		yield return new WaitForSeconds(1.5f);
		Vector3 currentValue = CameraSensivityConnection.CurrentValue;
		SetSettingsVariables("Camera-Sensivity", currentValue);
	}

	public void SetSettingsVariables(string key, object value)
	{
		settingsVariables.Set(key, value);
	}

	public void SetCameraSensivity(SliderWithEventOverridesUGUI slider)
	{
		Vector3 vector = new Vector3(slider.value, slider.value, slider.value);
		SetSettingsVariables("ST-Camera-Sensivity", vector);
	}
}
