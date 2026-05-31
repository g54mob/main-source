using System.Collections.Generic;
using UnityEngine;

public class TaskRCP : MonoBehaviour
{
	public RandomTasksRCP randomTasksRCP;

	public SunController sunController;

	[HideInInspector]
	public List<string> nonPTSFields;

	private void OnValidate()
	{
	}

	private void ClearPTSFields(TaskManagerRCPBase rcpBase)
	{
	}

	private bool TaskExistInRCPDevice(int idRCP, string Task)
	{
		return false;
	}

	[ContextMenu("RandomTask")]
	public void RandomTask(int selectTask = -1, TaskDataType _taskLevel = TaskDataType.Null)
	{
	}
}
