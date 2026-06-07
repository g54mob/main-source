using System;
using System.Collections.Generic;
using System.Linq;

namespace DV.Logic.Job
{
	public class ParallelTasks : Task
	{
		private List<Task> tasks;

		public override TaskType InstanceTaskType => TaskType.Parallel;

		public ParallelTasks(List<Task> parallelTasks, long timelimit = 0L, bool isLastTask = false)
			: base(timelimit, isLastTask)
		{
			tasks = new List<Task>(parallelTasks);
		}

		public override float GetTaskPrice()
		{
			float num = 0f;
			foreach (Task task in tasks)
			{
				num += task.GetTaskPrice();
			}
			return num;
		}

		public override TaskData GetTaskData()
		{
			return new TaskData(TaskType.Parallel, state, taskStartTime, taskFinishTime, null, null, null, WarehouseTaskType.None, null, 0f, tasks.ToList());
		}

		public override TaskState UpdateTaskState()
		{
			bool flag = true;
			foreach (Task task in tasks)
			{
				if (task.UpdateTaskState() != TaskState.Done)
				{
					flag = false;
				}
			}
			if (flag)
			{
				SetState(TaskState.Done);
			}
			else
			{
				SetState(TaskState.InProgress);
			}
			return state;
		}

		public override void StartTask()
		{
			base.StartTask();
			foreach (Task task in tasks)
			{
				task.StartTask();
			}
		}

		public override void SetJobBelonging(Job Job)
		{
			base.SetJobBelonging(Job);
			foreach (Task task in tasks)
			{
				task.SetJobBelonging(Job);
			}
		}

		public override TaskSaveData GetTaskSaveData()
		{
			TaskSaveData[] array = new TaskSaveData[tasks.Count];
			for (int i = 0; i < tasks.Count; i++)
			{
				array[i] = tasks[i].GetTaskSaveData();
			}
			return new ComplexTaskSaveData(state, InstanceTaskType, taskStartTime, taskFinishTime, array);
		}

		public override void OverrideTaskState(TaskSaveData data)
		{
			base.OverrideTaskState(data);
			if (!(data is ComplexTaskSaveData complexTaskSaveData))
			{
				throw new Exception("Conversion to ComplexTaskSaveData failed!");
			}
			if (complexTaskSaveData.tasksData.Length != tasks.Count)
			{
				throw new Exception("Unmatching number of tasks and taskData!");
			}
			for (int i = 0; i < complexTaskSaveData.tasksData.Length; i++)
			{
				tasks[i].OverrideTaskState(complexTaskSaveData.tasksData[i]);
			}
		}
	}
}
