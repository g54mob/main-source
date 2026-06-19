namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("The sequence task is similar to an \"and\" operation. It will return failure as soon as one of its child tasks return failure. If a child task returns success then it will sequentially run the next task. If all child tasks return success then it will return success.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=25")]
	[TaskIcon("{SkinColor}SequenceIcon.png")]
	public class Sequence : Composite
	{
		public class SaveState : BaseSaveState
		{
			public int currentChildID;

			public TaskStatus executionStatus;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private int currentChildIndex;

		private TaskStatus executionStatus;

		public override int CurrentChildIndex()
		{
			return currentChildIndex;
		}

		public override bool CanExecute()
		{
			if (currentChildIndex < children.Count)
			{
				return executionStatus != TaskStatus.Failure;
			}
			return false;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			currentChildIndex++;
			executionStatus = childStatus;
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

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				currentChildID = ((currentChildIndex < children.Count) ? children[currentChildIndex].ID : (-1)),
				executionStatus = executionStatus
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			currentChildIndex = ((saveState.currentChildID >= 0) ? IndexOfChildWithID(saveState.currentChildID) : children.Count);
			executionStatus = saveState.executionStatus;
		}
	}
}
