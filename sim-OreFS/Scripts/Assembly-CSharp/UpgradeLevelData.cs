using System;
using System.Collections.Generic;
using I2.Loc;
using UnityEngine;

[Serializable]
public class UpgradeLevelData
{
	[Header("Localization Keys")]
	public string titleKey;

	public string descriptionKey;

	public List<UpgradeChangeEntry> changes;

	[Header("Requirements")]
	public int requiredFactoryLevel;

	public int cost;

	[Header("Version")]
	public bool availableInDemo;

	[Header("Visual")]
	public Sprite levelIcon;

	public string Title
	{
		get
		{
			if (string.IsNullOrEmpty(titleKey))
			{
				return "";
			}
			string translation = LocalizationManager.GetTranslation(titleKey);
			if (!string.IsNullOrEmpty(translation))
			{
				return translation;
			}
			return "NL/" + titleKey;
		}
	}

	public string Description
	{
		get
		{
			if (string.IsNullOrEmpty(descriptionKey))
			{
				return "";
			}
			string translation = LocalizationManager.GetTranslation(descriptionKey);
			if (!string.IsNullOrEmpty(translation))
			{
				return translation;
			}
			return "NL/" + descriptionKey;
		}
	}

	public List<string> GetLocalizedChanges()
	{
		if (changes == null || changes.Count == 0)
		{
			return new List<string>();
		}
		List<string> list = new List<string>(changes.Count);
		foreach (UpgradeChangeEntry change in changes)
		{
			if (!string.IsNullOrEmpty(change.textKey))
			{
				string text = LocalizationManager.GetTranslation(change.textKey);
				if (string.IsNullOrEmpty(text))
				{
					text = "NL/" + change.textKey;
				}
				bool flag = !string.IsNullOrEmpty(change.oldValue);
				bool flag2 = !string.IsNullOrEmpty(change.newValue);
				if (flag && flag2)
				{
					text = text + " (" + change.oldValue + " > " + change.newValue + ")";
				}
				else if (flag2)
				{
					text = text + " (" + change.newValue + ")";
				}
				else if (flag)
				{
					text = text + " (" + change.oldValue + ")";
				}
				list.Add(text);
			}
		}
		return list;
	}
}
