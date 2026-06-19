using Aggro.Core;
using UnityEngine;

public class CustomInputSetting : AggroSettingBase
{
	private string _default;

	public string value { get; private set; }

	public CustomInputSetting(string defaultValue)
	{
		_default = defaultValue;
	}

	public override void SetToDefault()
	{
		value = _default;
	}

	protected override void SaveToPrefs(string preferencesKey)
	{
		PlayerPrefs.SetString(preferencesKey, value);
	}

	protected override void LoadFromPrefs(string preferencesKey)
	{
		value = PlayerPrefs.GetString(preferencesKey, _default);
	}

	public void SetValue(string value)
	{
		this.value = value;
	}
}
