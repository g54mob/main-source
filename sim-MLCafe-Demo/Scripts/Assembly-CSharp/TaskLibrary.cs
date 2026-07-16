using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task Library", menuName = "Libraries/Task Library", order = 1)]
public class TaskLibrary : ScriptableObject
{
	public List<WorkerTask> tasks = new List<WorkerTask>();

	public List<string> TaskNames()
	{
		List<string> result = new List<string>();
		tasks.ForEach(delegate(WorkerTask task)
		{
			result.Add(task.name);
		});
		return result;
	}

	public bool IsTask(string taskName, int compareId)
	{
		for (int i = 0; i < tasks.Count; i++)
		{
			if (tasks[i].name.ToLower() == taskName.ToLower() && i == compareId)
			{
				return true;
			}
		}
		return false;
	}

	public string GetTransportTarget(int id)
	{
		string result = "";
		switch (id)
		{
		case 0:
			result = "Delivered Goods";
			break;
		case 1:
			result = "Products to Depot";
			break;
		case 2:
			result = "Output to Storage";
			break;
		}
		return result;
	}
}
