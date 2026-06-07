using System;
using DV.Utils;

namespace DV.Logic.Job
{
	public abstract class Task
	{
		public TaskState state;

		protected float taskStartTime;

		protected float taskFinishTime;

		protected bool isLastTask;

		public abstract TaskType InstanceTaskType { get; }

		public Job Job { get; protected set; }

		public float TimeLimit { get; protected set; }

		public bool IsLastTask => isLastTask;

		public Task(float TimeLimit = 0f, bool isLastTask = false)
		{
			this.TimeLimit = TimeLimit;
			state = TaskState.InProgress;
			taskStartTime = 0f;
			taskFinishTime = 0f;
			this.isLastTask = isLastTask;
		}

		public virtual bool IsTaskCompleted()
		{
			return state == TaskState.Done;
		}

		public virtual void SetJobBelonging(Job Job)
		{
			if (this.Job != null)
			{
				throw new Exception("Trying to set Job belonging after it is already initialized!");
			}
			this.Job = Job;
		}

		public abstract TaskState UpdateTaskState();

		public abstract float GetTaskPrice();

		public abstract TaskData GetTaskData();

		public virtual TaskSaveData GetTaskSaveData()
		{
			return new TaskSaveData(state, InstanceTaskType, taskStartTime, taskFinishTime);
		}

		public virtual void OverrideTaskState(TaskSaveData data)
		{
			if (data.type != InstanceTaskType)
			{
				throw new Exception("Unmatching task type of TaskSaveData and task!");
			}
			state = data.state;
			taskStartTime = data.taskStartTime;
			taskFinishTime = data.taskFinishedTime;
		}

		public virtual void StartTask()
		{
			taskStartTime = SingletonBehaviour<JobsManager>.Instance.Time;
		}

		protected void SetState(TaskState newState)
		{
			if (state != newState)
			{
				switch (newState)
				{
				case TaskState.Done:
					taskFinishTime = SingletonBehaviour<JobsManager>.Instance.Time;
					break;
				case TaskState.InProgress:
					taskFinishTime = 0f;
					break;
				}
				state = newState;
			}
		}
	}
}
