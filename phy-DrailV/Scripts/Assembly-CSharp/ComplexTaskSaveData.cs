using System;
using DV.Logic.Job;

[Serializable]
public class ComplexTaskSaveData : TaskSaveData
{
	public TaskSaveData[] tasksData;

	public ComplexTaskSaveData(TaskState state, TaskType type, float taskStartTime, float taskFinishedTime, TaskSaveData[] tasksData)
		: base(state, type, taskStartTime, taskFinishedTime)
	{
		this.tasksData = tasksData;
	}
}
