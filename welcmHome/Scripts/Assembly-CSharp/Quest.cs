using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Quest
{
	public delegate void QuestAdvanced();

	public delegate void QuestFinished(List<DialogueNode> newDialogue);

	public QuestAdvanced OnQuestAdvanced;

	public QuestFinished OnQuestFinished;

	[SerializeField]
	private string description;

	[SerializeField]
	private int goalAmount;

	private int _currentAmount;

	[Space]
	[SerializeField]
	private List<DialogueNode> dialogueAfterQuestCompleted;

	[Space]
	[SerializeField]
	private bool notificationAfterQuestCompleted;

	[SerializeField]
	private int notificationDuration = 2;

	[SerializeField]
	[TextArea]
	private string notificationText;

	public bool Completed { get; private set; }

	public int currentAmount
	{
		get
		{
			return _currentAmount;
		}
		set
		{
			_currentAmount = value;
			Evaluate();
			OnQuestAdvanced();
		}
	}

	public string Description => description;

	public int GoalAmount => goalAmount;

	public bool ShouldNotify => notificationAfterQuestCompleted;

	public string NotificationText => notificationText;

	public int NotificationDuration => notificationDuration;

	public Quest(string description, int currentAmount, int goalAmount)
	{
		this.description = description;
		Completed = false;
		_currentAmount = currentAmount;
		this.goalAmount = goalAmount;
	}

	public void Evaluate()
	{
		if (currentAmount >= goalAmount)
		{
			Completed = true;
			Complete();
		}
	}

	private void Complete()
	{
		Debug.Log("Quest completed!");
		OnQuestFinished(dialogueAfterQuestCompleted);
	}
}
