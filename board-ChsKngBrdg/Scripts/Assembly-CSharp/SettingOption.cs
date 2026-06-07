using System;
using System.Collections.Generic;
using UnityEngine.Localization;

[Serializable]
public class SettingOption
{
	public string displayText;

	public LocalizedString localizedString;

	public List<float> settingValue;

	public SettingOption(string displayText, List<float> settingValue)
	{
		this.displayText = displayText;
		this.settingValue = settingValue;
	}
}
