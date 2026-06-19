namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("The until failure task will keep executing its child task until the child task returns failure.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=41")]
	[TaskIcon("{SkinColor}UntilFailureIcon.png")]
	public class UntilFailure : Decorator
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
			if (executionStatus != TaskStatus.Success)
			{
				return executionStatus == TaskStatus.Inactive;
			}
			return true;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			executionStatus = childStatus;
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
