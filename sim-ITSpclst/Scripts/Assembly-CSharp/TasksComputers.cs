using System.Collections.Generic;
using UnityEngine;

public class TasksComputers : MonoBehaviour
{
	public RandomTasksComputers randomTasksComputers;

	public SunController sunController;

	[HideInInspector]
	public List<string> nonPTSFields;

	private void OnValidate()
	{
	}

	private void RunValidate()
	{
	}

	private void ClearPTSFields(TaskManagerComputersBase computerBase)
	{
	}

	public ITask GetTaskScript(int id = -1)
	{
		return null;
	}

	private bool TaskExistInComputerDevice(int idComputer, string Task)
	{
		return false;
	}

	[ContextMenu("RandomTask")]
	public void RandomTask(int selectTask = -1, int device = -1, TaskDataType _taskLevel = TaskDataType.Null)
	{
	}
}
