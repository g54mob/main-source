using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kitchen.NetworkSupport;
using UnityEngine;

namespace Kitchen
{
	public class PostLoadingInstructionManager
	{
		private static List<LoadingInstruction> PostLoadingTasks = new List<LoadingInstruction>();

		private static bool HasCompletedTaskList;

		private int FinishedTaskCount;

		public static void RegisterPostLoadingTasks(InstructionGroup instruction_group, params (Func<Task>, string)[] tasks)
		{
			if (HasCompletedTaskList)
			{
				PostLoadingTasks.Clear();
				HasCompletedTaskList = false;
			}
			for (int i = 0; i < tasks.Length; i++)
			{
				(Func<Task>, string) tuple = tasks[i];
				PostLoadingTasks.Add(new LoadingInstruction(instruction_group, tuple.Item1, tuple.Item2));
			}
		}

		private bool IsFinished((Task task, LoadingInstruction instruction) instruction)
		{
			if (!instruction.task.IsCompleted && !instruction.task.IsFaulted)
			{
				return instruction.task.IsCanceled;
			}
			return true;
		}

		public List<(Task, LoadingInstruction)> BeginGroupTasks(InstructionGroup instruction_group)
		{
			List<(Task, LoadingInstruction)> list = new List<(Task, LoadingInstruction)>();
			foreach (LoadingInstruction postLoadingTask in PostLoadingTasks)
			{
				if (postLoadingTask.Group == instruction_group)
				{
					list.Add((postLoadingTask.Initialise(), postLoadingTask));
				}
			}
			return list;
		}

		public IEnumerator BeginProcessing()
		{
			FinishedTaskCount = 0;
			int finished_in_previous_groups = 0;
			foreach (InstructionGroup item in Enum.GetValues(typeof(InstructionGroup)).Cast<InstructionGroup>())
			{
				List<(Task, LoadingInstruction)> tasks = BeginGroupTasks(item);
				int completion_count = 0;
				while (completion_count < tasks.Count)
				{
					completion_count = tasks.Count(IsFinished);
					FinishedTaskCount = completion_count + finished_in_previous_groups;
					yield return new WaitForEndOfFrame();
				}
				foreach (var item2 in tasks)
				{
					if (item2.Item1.IsFaulted)
					{
						EventLog.Platform.Report(PlatformEvent.InitialiseTaskFailure, item2.Item2.DebuggingIdentifier);
						EventLog.Platform.Report(PlatformEvent.InitialiseTaskFailure, item2.Item1.Exception);
						Debug.LogException(item2.Item1.Exception);
					}
				}
				finished_in_previous_groups += completion_count;
			}
			HasCompletedTaskList = true;
		}

		public bool IsComplete()
		{
			return FinishedTaskCount == PostLoadingTasks.Count;
		}

		public float GetProgress()
		{
			return (float)FinishedTaskCount / (float)PostLoadingTasks.Count;
		}
	}
}
