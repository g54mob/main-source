namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("The return success task will always return success except when the child task is running.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=39")]
	[TaskIcon("{SkinColor}ReturnSuccessIcon.png")]
	public class ReturnSuccess : Decorator
	{
		public class SaveState : BaseSaveState
		{
			public TaskStatus executionStatus;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			if (executionStatus != TaskStatus.Inactive)
			{
				return executionStatus == TaskStatus.Running;
			}
			return true;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			executionStatus = childStatus;
		}

		public override TaskStatus Decorate(TaskStatus status)
		{
			if (status == TaskStatus.Failure)
			{
				return TaskStatus.Success;
			}
			return status;
		}

		public override void OnEnd()
		{
			executionStatus = TaskStatus.Inactive;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				executionStatus = executionStatus
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			executionStatus = saveState.executionStatus;
		}
	}
}
