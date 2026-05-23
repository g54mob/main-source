using System;
using UnityEngine.Localization;

[Serializable]
public class QuestData
{
	public string questName;

	public LocalizedString descriptionTemp;

	public QuestType questType;

	public int pay;

	public bool isCompleted;
}
