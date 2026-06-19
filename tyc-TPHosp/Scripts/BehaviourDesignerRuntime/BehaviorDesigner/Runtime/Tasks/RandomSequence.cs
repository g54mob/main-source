using System.Collections.Generic;
using UnityEngine;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("Similar to the sequence task, the random sequence task will return success as soon as every child task returns success.  The difference is that the random sequence class will run its children in a random order. The sequence task is deterministic in that it will always run the tasks from left to right within the tree. The random sequence task shuffles the child tasks up and then begins execution in a random order. Other than that the random sequence class is the same as the sequence class. It will stop running tasks as soon as a single task ends in failure. On a task failure it will stop executing all of the child tasks and return failure. If no child returns failure then it will return success.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=31")]
	[TaskIcon("{SkinColor}RandomSequenceIcon.png")]
	public class RandomSequence : Composite
	{
		public class SaveState : BaseSaveState
		{
			public List<int> childIDList;

			public List<int> childrenExecutionOrderIDs;

			public TaskStatus executionStatus;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("Seed the random number generator to make things easier to debug")]
		public int seed;

		[Tooltip("Do we want to use the seed?")]
		public bool useSeed;

		private List<int> childIndexList = new List<int>();

		private List<int> childrenExecutionOrder = new List<int>();

		private TaskStatus executionStatus;

		public override void OnAwake()
		{
			if (useSeed)
			{
				Random.InitState(seed);
			}
			childIndexList.Clear();
			for (int i = 0; i < children.Count; i++)
			{
				childIndexList.Add(i);
			}
		}

		public override void OnStart()
		{
			ShuffleChilden();
		}

		public override int CurrentChildIndex()
		{
			return childrenExecutionOrder[childrenExecutionOrder.Count - 1];
		}

		public override bool CanExecute()
		{
			if (childrenExecutionOrder.Count > 0)
			{
				return executionStatus != TaskStatus.Failure;
			}
			return false;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			if (childrenExecutionOrder.Count > 0)
			{
				childrenExecutionOrder.RemoveAt(childrenExecutionOrder.Count - 1);
			}
			executionStatus = childStatus;
		}

		public override void OnConditionalAbort(int childIndex)
		{
			childrenExecutionOrder.Clear();
			executionStatus = TaskStatus.Inactive;
			ShuffleChilden();
		}

		public override void OnEnd()
		{
			executionStatus = TaskStatus.Inactive;
			childrenExecutionOrder.Clear();
		}

		public override void OnReset()
		{
			seed = 0;
			useSeed = false;
		}

		private void ShuffleChilden()
		{
			for (int num = childIndexList.Count; num > 0; num--)
			{
				int index = Random.Range(0, num);
				int num2 = childIndexList[index];
				childrenExecutionOrder.Add(num2);
				childIndexList[index] = childIndexList[num - 1];
				childIndexList[num - 1] = num2;
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			List<int> list = new List<int>(childIndexList);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = children[i].ID;
			}
			List<int> list2 = new List<int>(childrenExecutionOrder);
			for (int j = 0; j < list2.Count; j++)
			{
				list2[j] = children[j].ID;
			}
			return new SaveState(this)
			{
				childIDList = list,
				childrenExecutionOrderIDs = list2,
				executionStatus = executionStatus
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			executionStatus = saveState.executionStatus;
			childIndexList.Clear();
			foreach (int childID in saveState.childIDList)
			{
				childIndexList.Add(IndexOfChildWithID(childID));
			}
			childrenExecutionOrder.Clear();
			foreach (int childrenExecutionOrderID in saveState.childrenExecutionOrderIDs)
			{
				childrenExecutionOrder.Add(IndexOfChildWithID(childrenExecutionOrderID));
			}
		}
	}
}
