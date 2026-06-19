using System.Collections.Generic;

namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("The utility selector task evaluates the child tasks using Utility Theory AI. The child task can override the GetUtility method and return the utility value at that particular time. The task with the highest utility value will be selected and the existing running task will be aborted. The utility selector task reevaluates its children every tick.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=134")]
	[TaskIcon("{SkinColor}UtilitySelectorIcon.png")]
	public class UtilitySelector : Composite
	{
		public class SaveState : BaseSaveState
		{
			public int currentChildID;

			public TaskStatus executionStatus;

			public bool reevaluating;

			public List<int> availableChildrenIDs;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private int currentChildIndex;

		private float highestUtility;

		private TaskStatus executionStatus;

		private bool reevaluating;

		private List<int> availableChildren = new List<int>();

		public override void OnStart()
		{
			highestUtility = float.MinValue;
			availableChildren.Clear();
			for (int i = 0; i < children.Count; i++)
			{
				float utility = children[i].GetUtility();
				if (utility > highestUtility)
				{
					highestUtility = utility;
					currentChildIndex = i;
				}
				availableChildren.Add(i);
			}
		}

		public override int CurrentChildIndex()
		{
			return currentChildIndex;
		}

		public override void OnChildStarted(int childIndex)
		{
			executionStatus = TaskStatus.Running;
		}

		public override bool CanExecute()
		{
			if (executionStatus == TaskStatus.Success || executionStatus == TaskStatus.Running || reevaluating)
			{
				return false;
			}
			return availableChildren.Count > 0;
		}

		public override void OnChildExecuted(int childIndex, TaskStatus childStatus)
		{
			if (childStatus == TaskStatus.Inactive || childStatus == TaskStatus.Running)
			{
				return;
			}
			executionStatus = childStatus;
			if (executionStatus != TaskStatus.Failure)
			{
				return;
			}
			availableChildren.Remove(childIndex);
			highestUtility = float.MinValue;
			for (int i = 0; i < availableChildren.Count; i++)
			{
				float utility = children[availableChildren[i]].GetUtility();
				if (utility > highestUtility)
				{
					highestUtility = utility;
					currentChildIndex = availableChildren[i];
				}
			}
		}

		public override void OnConditionalAbort(int childIndex)
		{
			currentChildIndex = childIndex;
			executionStatus = TaskStatus.Inactive;
		}

		public override void OnEnd()
		{
			executionStatus = TaskStatus.Inactive;
			currentChildIndex = 0;
		}

		public override TaskStatus OverrideStatus(TaskStatus status)
		{
			return executionStatus;
		}

		public override bool CanRunParallelChildren()
		{
			return true;
		}

		public override bool CanReevaluate()
		{
			return true;
		}

		public override bool OnReevaluationStarted()
		{
			if (executionStatus == TaskStatus.Inactive)
			{
				return false;
			}
			reevaluating = true;
			return true;
		}

		public override void OnReevaluationEnded(TaskStatus status)
		{
			reevaluating = false;
			int num = currentChildIndex;
			highestUtility = float.MinValue;
			for (int i = 0; i < availableChildren.Count; i++)
			{
				float utility = children[availableChildren[i]].GetUtility();
				if (utility > highestUtility)
				{
					highestUtility = utility;
					currentChildIndex = availableChildren[i];
				}
			}
			if (num != currentChildIndex)
			{
				BehaviorManager.instance.Interrupt(base.Owner, children[num], this);
				executionStatus = TaskStatus.Inactive;
			}
		}

		public override BaseSaveState CreateSaveState()
		{
			List<int> list = new List<int>(availableChildren);
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = children[i].ID;
			}
			return new SaveState(this)
			{
				currentChildID = ((currentChildIndex < children.Count) ? children[currentChildIndex].ID : (-1)),
				executionStatus = executionStatus,
				reevaluating = reevaluating,
				availableChildrenIDs = list
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			currentChildIndex = ((saveState.currentChildID >= 0) ? IndexOfChildWithID(saveState.currentChildID) : children.Count);
			executionStatus = saveState.executionStatus;
			reevaluating = saveState.reevaluating;
			availableChildren.Clear();
			foreach (int availableChildrenID in saveState.availableChildrenIDs)
			{
				availableChildren.Add(IndexOfChildWithID(availableChildrenID));
			}
		}
	}
}
