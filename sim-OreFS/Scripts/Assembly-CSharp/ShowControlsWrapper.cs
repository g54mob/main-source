using System.Collections;
using GameCreator.Runtime.Variables;
using Kamgam.SettingsGenerator;
using UnityEngine;
using UnityEngine.UI;

public class ShowControlsWrapper : MonoBehaviour
{
	public GlobalNameVariables settingsVariables;

	private void OnEnable()
	{
		StartCoroutine(DetectCurrentValue());
	}

	private IEnumerator DetectCurrentValue()
	{
		yield return new WaitForSeconds(0.5f);
		bool currentValue = ShowControlsConnection.CurrentValue;
		SetSettingsVariables("ST-Show-Controls", currentValue);
	}

	public void SetSettingsVariables(string key, object value)
	{
		settingsVariables.Set(key, value);
	}

	public void SetShowControls(Toggle toggle)
	{
		SetSettingsVariables("ST-Show-Controls", toggle.isOn);
	}
}
