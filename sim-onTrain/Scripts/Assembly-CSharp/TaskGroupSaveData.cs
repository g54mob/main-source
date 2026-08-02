using System;
using System.Collections.Generic;

[Serializable]
public class TaskGroupSaveData
{
	public int groupIndex;

	public List<TaskSaveData> tasksProgress;
}
