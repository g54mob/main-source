using System;
using DV.Logic.Job;

[Serializable]
public class TaskSaveData
{
	public TaskState state;

	public TaskType type;

	public float taskStartTime;

	public float taskFinishedTime;

	public TaskSaveData(TaskState state, TaskType type, float taskStartTime, float taskFinishedTime)
	{
		this.state = state;
		this.type = type;
		this.taskStartTime = taskStartTime;
		this.taskFinishedTime = taskFinishedTime;
	}
}
