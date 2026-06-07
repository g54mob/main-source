using System;
using System.Collections.Generic;
using System.Linq;

namespace DV.Logic.Job
{
	public class SequentialTasks : Task
	{
		private LinkedList<Task> tasks;

		private LinkedListNode<Task> currentTask;

		public override TaskType InstanceTaskType => TaskType.Sequential;

		public SequentialTasks(Task task, long timelimit = 0L, bool isLastTask = false)
			: base(timelimit, isLastTask)
		{
			tasks = new LinkedList<Task>();
			AddTask(task);
			currentTask = tasks.First;
		}

		public SequentialTasks(List<Task> sequentalTasks, long timelimit = 0L)
			: base(timelimit)
		{
			tasks = new LinkedList<Task>();
			AddTask(sequentalTasks);
			currentTask = tasks.First;
		}

		public LinkedListNode<Task> AddTask(Task task)
		{
			return tasks.AddLast(task);
		}

		public LinkedListNode<Task> AddTask(List<Task> sequentalTasks)
		{
			foreach (Task sequentalTask in sequentalTasks)
			{
				AddTask(sequentalTask);
			}
			return tasks.Last;
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
			return new TaskData(TaskType.Sequential, state, taskStartTime, taskFinishTime, null, null, null, WarehouseTaskType.None, null, 0f, tasks.ToList());
		}

		public override TaskState UpdateTaskState()
		{
			while (currentTask.Value.UpdateTaskState() == TaskState.Done)
			{
				if (currentTask == tasks.Last)
				{
					SetState(TaskState.Done);
					return state;
				}
				currentTask = currentTask.Next;
			}
			SetState(currentTask.Value.state);
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
			int num = 0;
			for (LinkedListNode<Task> linkedListNode = tasks.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				array[num] = linkedListNode.Value.GetTaskSaveData();
				num++;
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
			int num = 0;
			for (LinkedListNode<Task> linkedListNode = tasks.First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				linkedListNode.Value.OverrideTaskState(complexTaskSaveData.tasksData[num]);
				if (complexTaskSaveData.tasksData[num].state == TaskState.Done && linkedListNode != tasks.Last)
				{
					currentTask = linkedListNode.Next;
				}
				num++;
			}
		}
	}
}
