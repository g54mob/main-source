using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "New Tutorial Data", menuName = "TrainSurvival/Tutorial Data")]
public class TutorialData : ScriptableObject
{
	public string tutorialTitle = "Tutorial";

	[Tooltip("Localization table'dan tutorial title key'i seç")]
	public LocalizedString tutorialTitleLocalized;

	public TutorialAnimationType animationType;

	public float animationDuration = 0.5f;

	[Space(10f)]
	public List<TaskGroup> taskGroups = new List<TaskGroup>();

	public string GetLocalizedTutorialTitle()
	{
		if (tutorialTitleLocalized != null && !tutorialTitleLocalized.IsEmpty)
		{
			string localizedString = tutorialTitleLocalized.GetLocalizedString();
			if (!string.IsNullOrEmpty(localizedString) && !localizedString.Contains("No translation") && !localizedString.Contains("No localization") && !localizedString.Contains("Missing Translation") && !localizedString.Contains("MISSING"))
			{
				return localizedString;
			}
		}
		return tutorialTitle;
	}

	public void AddTaskGroup()
	{
		TaskGroup taskGroup = new TaskGroup();
		taskGroup.groupName = $"Group {taskGroups.Count + 1}";
		taskGroups.Add(taskGroup);
	}

	public void ClearTaskStats()
	{
		foreach (TaskGroup taskGroup in taskGroups)
		{
			foreach (TaskData task in taskGroup.tasks)
			{
				task.isCompleted = false;
				task.currentProgress = 0;
			}
		}
	}
}
