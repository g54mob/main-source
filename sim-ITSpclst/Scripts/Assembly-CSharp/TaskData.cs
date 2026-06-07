using System;
using UnityEngine;

[Serializable]
public class TaskData
{
	public TaskManager taskManager;

	public string taskID;

	public string title;

	public long expirationDate;

	public long taskTimeSec;

	public float progress;

	public float remainingSec;

	public ITask scriptTask;

	public TaskDataType typeTask;

	public bool viewTask;

	[Header("pause UI")]
	public RectTransform TaskViewInPause;

	public TaskData()
	{
	}

	public TaskData(TaskManager taskManager)
	{
	}

	public void SetExpirationDate(TimeGame time, DateGame date, int secound)
	{
	}

	public void CreateTask(TaskDataType typeTask, ITask task, UnityEngine.Object[] parameters, TaskDataOrderData taskDataOrderData, bool asLoad = false)
	{
	}

	private int GetPositionObject(string name)
	{
		return 0;
	}
}
