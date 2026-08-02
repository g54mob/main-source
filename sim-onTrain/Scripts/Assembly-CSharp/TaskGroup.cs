using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class TaskGroup
{
	public string groupName = "Task Group";

	[Tooltip("Localization table'dan group name key'i seç")]
	public LocalizedString groupNameLocalized;

	public List<TaskData> tasks = new List<TaskData>();

	public string GetLocalizedGroupName()
	{
		if (groupNameLocalized != null && !groupNameLocalized.IsEmpty)
		{
			string localizedString = groupNameLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString) && !localizedString.Contains("No translation") && !localizedString.Contains("No localization") && !localizedString.Contains("Missing Translation") && !localizedString.Contains("MISSING"))
			{
				return localizedString;
			}
		}
		return groupName;
	}
}
