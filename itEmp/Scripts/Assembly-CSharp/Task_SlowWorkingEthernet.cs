using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Task_SlowWorkingEthernet : ITask
{
	public TaskDataOrderData orderData;

	public UnityEngine.Object[] parameters;

	public bool[] isChapterCompleted;

	public string TaskID;

	public TaskVariables variables;

	public List<ChapterTask> chapterCompletedNames;

	public void SetTaskID(string _taskID)
	{
	}

	public string GetTitle()
	{
		return null;
	}

	public string GetDescription()
	{
		return null;
	}

	public string GetTip()
	{
		return null;
	}

	public void PrepareChapterTask()
	{
	}

	public List<ChapterTask> GetChapterCompletedName()
	{
		return null;
	}

	public bool[] GetChapterCompleted()
	{
		return null;
	}

	public string[] GetAwardsName()
	{
		return null;
	}

	public string[] GetPenaltiesName()
	{
		return null;
	}

	public TaskDataOrderData GetOrderData()
	{
		return null;
	}

	public void SetOrderData(TaskDataOrderData _orderData)
	{
	}

	public void SetParameters(UnityEngine.Object[] _parameters)
	{
	}

	public void BeforeTask()
	{
	}

	public bool Verify()
	{
		return false;
	}

	public void TaskComplet(bool timeExpired)
	{
	}

	public void TaskPenaltie()
	{
	}

	public void SetFirstShift()
	{
	}

	public string SaveTask()
	{
		return null;
	}

	public void LoadTask(string json)
	{
	}
}
