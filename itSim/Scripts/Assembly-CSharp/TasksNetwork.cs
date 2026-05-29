using System.Collections.Generic;
using UnityEngine;

public class TasksNetwork : MonoBehaviour
{
	public RandomTasksSwitch randomTasksSwitch;

	public RandomTasksRouter randomTasksRouter;

	public SunController sunController;

	[HideInInspector]
	public List<string> nonPTSFieldsSwitch;

	[HideInInspector]
	public List<string> nonPTSFieldsRouter;

	private void OnValidate()
	{
	}

	private bool TaskExistInSwitchDevice(int idPrinter, string Task)
	{
		return false;
	}

	private bool TaskExistInRouterDevice(int idPrinter, string Task)
	{
		return false;
	}

	[ContextMenu("RandomTask Switch")]
	public void RandomTaskSwitch(int selectTask = -1, TaskDataType _taskLevel = TaskDataType.Null)
	{
	}

	[ContextMenu("RandomTask Router")]
	public void RandomTaskRouter(int selectTask = -1, TaskDataType _taskLevel = TaskDataType.Null)
	{
	}
}
