using System;
using UnityEngine.Localization;

[Serializable]
public class SettingsControlBindingReference
{
	public string ActionName;

	public string ActionMapName;

	public string OverrideStoryKey;

	public int BindingIndex;

	public LocalizedString ActionTitle;

	public bool Rebindable;
}
