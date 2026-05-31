using System.Collections.Generic;
using UnityEngine;

public class TasksPrinters : MonoBehaviour
{
	public RandomTasksPrinters randomTasksPrinters;

	public SunController sunController;

	[HideInInspector]
	public List<string> nonPTSFields;

	private void OnValidate()
	{
	}

	private void ClearPTSFields(TaskManagerPrintersBase rcpBase)
	{
	}

	private bool TaskExistInPrinterDevice(int idPrinter, string Task)
	{
		return false;
	}

	[ContextMenu("RandomTask")]
	public void RandomTask(int selectTask = -1, TaskDataType _taskLevel = TaskDataType.Null)
	{
	}
}
