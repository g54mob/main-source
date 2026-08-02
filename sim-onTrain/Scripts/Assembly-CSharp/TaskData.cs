using System;
using UnityEngine;
using UnityEngine.Localization;

[Serializable]
public class TaskData
{
	public TaskType type;

	[Space(5f)]
	[TextArea(1, 2)]
	public string customTaskTitle;

	[Tooltip("Localization table'dan custom task title key'i seç")]
	public LocalizedString customTaskTitleLocalized;

	[Space(5f)]
	public string reachAdress;

	public CollectableItemData collectableItem;

	public CollectableItemData buildingData;

	public int zombiesCount;

	public int neededCount;

	public int currentProgress;

	public bool isCompleted;

	[Space(5f)]
	[Tooltip("If true, when one player completes this task, all players will have it marked as completed")]
	public bool isCommonTask;

	public string GetLocalizedCustomTaskTitle()
	{
		if (customTaskTitleLocalized != null && !customTaskTitleLocalized.IsEmpty)
		{
			string localizedString = customTaskTitleLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString) && !IsMissingTranslation(localizedString))
			{
				return localizedString;
			}
		}
		return customTaskTitle;
	}

	private bool IsMissingTranslation(string text)
	{
		if (!text.Contains("No translation") && !text.Contains("No localization") && !text.Contains("Missing Translation"))
		{
			return text.Contains("MISSING");
		}
		return true;
	}
}
