using System;
using UnityEngine;
using UnityEngine.Localization.Components;
using UnityEngine.Localization.SmartFormat.PersistentVariables;

[Serializable]
public class SettingMenuItem : MenuItem
{
	public Setting setting;

	public LocalizeStringEvent localizeStringEvent;

	public bool immediateUpdate;

	private SettingsManager settingsManager;

	private void Start()
	{
		if (immediateUpdate)
		{
			settingsManager = UnityEngine.Object.FindObjectOfType<SettingsManager>();
		}
		UpdateDisplayText();
	}

	public override void OnClick()
	{
		if (!(base.transform.localScale.y < 0.2f))
		{
			setting.CycleSettingOption(Setting.CycleDirection.Right);
			if (immediateUpdate)
			{
				settingsManager.ApplySpeedrunModeSetting();
				settingsManager.ApplyAudioSettings();
			}
			UpdateDisplayText();
		}
	}

	public void UpdateDisplayText()
	{
		StringVariable stringVariable = null;
		if (!localizeStringEvent.StringReference.TryGetValue("selectedOption", out var value))
		{
			stringVariable = new StringVariable();
			localizeStringEvent.StringReference.Add("selectedOption", stringVariable);
		}
		else
		{
			stringVariable = value as StringVariable;
		}
		if (!setting.currentOption.localizedString.IsEmpty)
		{
			stringVariable.Value = setting.currentOption.localizedString.GetLocalizedString();
		}
		else
		{
			stringVariable.Value = setting.currentOption.displayText;
		}
	}
}
