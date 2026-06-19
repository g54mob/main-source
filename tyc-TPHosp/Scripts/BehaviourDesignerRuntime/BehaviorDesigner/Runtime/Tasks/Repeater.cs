namespace BehaviorDesigner.Runtime.Tasks
{
	[TaskDescription("The repeater task will repeat execution of its child task until the child task has been run a specified number of times. It has the option of continuing to execute the child task even if the child task returns a failure.")]
	[HelpURL("http://www.opsive.com/assets/BehaviorDesigner/documentation.php?id=37")]
	[TaskIcon("{SkinColor}RepeaterIcon.png")]
	public class Repeater : Decorator
	{
		public class SaveState : BaseSaveState
		{
			public int executionCount;

			public TaskStatus executionStatus;

			public SaveState()
			{
			}

			public SaveState(Task task)
				: base(task)
			{
			}
		}

		[Tooltip("The number of times to repeat the execution of its child task")]
		public SharedInt count = 1;

		[Tooltip("Allows the repeater to repeat forever")]
		public SharedBool repeatForever;

		[Tooltip("Should the task return if the child task returns a failure")]
		public SharedBool endOnFailure;

		private int executionCount;

		private TaskStatus executionStatus;

		public override bool CanExecute()
		{
			if (repeatForever.Value || executionCount < count.Value)
			{
				if (endOnFailure.Value)
				{
					if (endOnFailure.Value)
					{
						return executionStatus != TaskStatus.Failure;
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public override void OnChildExecuted(TaskStatus childStatus)
		{
			executionCount++;
			executionStatus = childStatus;
		}

		public override void OnEnd()
		{
			executionCount = 0;
			executionStatus = TaskStatus.Inactive;
		}

		public override void OnReset()
		{
			count = 0;
			endOnFailure = true;
		}

		public override BaseSaveState CreateSaveState()
		{
			return new SaveState(this)
			{
				executionCount = executionCount,
				executionStatus = executionStatus
			};
		}

		public override void RestoreFromSaveState(BaseSaveState baseSaveState)
		{
			base.RestoreFromSaveState(baseSaveState);
			SaveState saveState = (SaveState)baseSaveState;
			executionCount = saveState.executionCount;
			executionStatus = saveState.executionStatus;
		}
	}
}
