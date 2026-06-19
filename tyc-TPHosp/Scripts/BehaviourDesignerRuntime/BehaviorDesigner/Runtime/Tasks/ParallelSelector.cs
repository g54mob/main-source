using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("Similar to the selector task, the parallel selector task will return success as soon as a child task returns success. The difference is that the parallel task will run all of its children tasks simultaneously versus running each task one at a time. If one tasks returns success the parallel selector task will end all of the child tasks and return success. If every child task returns failure then the parallel selector task will return failure.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=28")]
	[TaskIcon("{SkinColor}ParallelSelectorIcon.png")]
	public class ParallelSelector : Composite
	{
		public class SaveState : BaseSaveState
		{
			public int currentChildID;

			public Dictionary<int, TaskStatus> executionStatusMap;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private int currentChildIndex;

		private TaskStatus[] executionStatus;

		public override void OnAwake()
		{
			executionStatus = new TaskStatus[children.Count];
		}

		public override void OnChildStarted(int childIndex)
		{
			currentChildIndex++;
			executionStatus[childIndex] = TaskStatus.Running;
		}

		public override bool CanRunParallelChildren()
		{
			return true;
		}

		public override int CurrentChildIndex()
		{
			return currentChildIndex;
		}

		public override bool CanExecute()
		{
			return currentChildIndex < children.Count;
		}

		public override void OnChildExecuted(int childIndex, TaskStatus childStatus)
		{
			executionStatus[childIndex] = childStatus;
		}

		public override void OnConditionalAbort(int childIndex)
		{
			currentChildIndex = 0;
			for (int i = 0; i < executionStatus.Length; i++)
			{
				executionStatus[i] = TaskStatus.Inactive;
			}
		}

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			bool flag = true;
			for (int i = 0; i < executionStatus.Length; i++)
			{
				if (executionStatus[i] == TaskStatus.Running)
				{
					flag = false;
				}
				else if (executionStatus[i] == TaskStatus.Success)
				{
					return TaskStatus.Success;
				}
			}
			if (!flag)
			{
				return TaskStatus.Running;
			}
			return TaskStatus.Failure;
		}

		public override void OnEnd()
		{
			for (int i = 0; i < executionStatus.Length; i++)
			{
				executionStatus[i] = TaskStatus.Inactive;
			}
			currentChildIndex = 0;
		}

		public override BaseSaveState CreateSaveState()
		{
			Dictionary<int, TaskStatus> dictionary = new Dictionary<int, TaskStatus>();
			for (int i = 0; i < children.Count; i++)
			{
				dictionary.Add(children[i].ID, executionStatus[i]);
			}
			return new SaveState(this)
			{
				currentChildID = ((currentChildIndex < children.Count) ? children[currentChildIndex].ID : (-1)),
				executionStatusMap = dictionary
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			currentChildIndex = ((saveState.currentChildID >= 0) ? IndexOfChildWithID(saveState.currentChildID) : children.Count);
			foreach (KeyValuePair<int, TaskStatus> item in saveState.executionStatusMap)
			{
				executionStatus[IndexOfChildWithID(item.Key)] = item.Value;
			}
		}
	}
}
