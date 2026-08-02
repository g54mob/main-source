using System;
using UnityEngine;

[Serializable]
public class TutorialTask
{
	public string taskText;

	public int maxProgress = 1;

	[HideInInspector]
	public int currentProgress;

	[HideInInspector]
	public bool isCompleted;

	[TextArea(2, 4)]
	public string description;

	public TutorialTriggerType triggerType;

	public int dependentTaskIndex = -1;

	public Vector3 targetPosition;

	public float triggerRadius = 2f;

	public string targetObjectTag;
}
