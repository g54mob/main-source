using System.Collections;
using GameCreator.Runtime.Variables;
using Kamgam.SettingsGenerator;
using UnityEngine;
using UnityEngine.UI;

public class CameraShakeWrapper : MonoBehaviour
{
	public GlobalNameVariables settingsVariables;

	private void OnEnable()
	{
		StartCoroutine(DetectCurrentValue());
	}

	private IEnumerator DetectCurrentValue()
	{
		yield return new WaitForSeconds(0.5f);
		bool currentValue = CameraShakeConnection.CurrentValue;
		SetSettingsVariables("ST-Camera-Shake", currentValue);
	}

	public void SetSettingsVariables(string key, object value)
	{
		settingsVariables.Set(key, value);
	}

	public void SetCameraShake(Toggle toggle)
	{
		SetSettingsVariables("ST-Camera-Shake", toggle.isOn);
	}
}
