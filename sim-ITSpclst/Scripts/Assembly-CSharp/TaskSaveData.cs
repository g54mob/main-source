using System;

[Serializable]
public class TaskSaveData
{
	public string script;

	public string taskID;

	public string Title;

	public long expirationDate;

	public long taskTimeSec;

	public float progress;

	public float remainingSec;

	public bool viewTask;

	public string typeTask;

	public string[] parameters;

	public bool[] isChapterCompleted;

	public TaskDataOrderData orderData;

	public TaskVariables variables;
}
