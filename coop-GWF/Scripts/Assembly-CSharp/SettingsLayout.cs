using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Settings/Settings Layout", fileName = "SettingsLayout")]
public class SettingsLayout : ScriptableObject
{
	[Serializable]
	public class Tab
	{
		public string tabName = "General";

		public List<SettingItemBase> entries = new List<SettingItemBase>();
	}

	public List<Tab> tabs = new List<Tab>();

	public static event Action<SettingsLayout, SettingItemBase> SettingsChanged;

	public void NotifyChanged(SettingItemBase entry)
	{
		SettingsLayout.SettingsChanged?.Invoke(this, entry);
	}
}
