using System;

namespace NSEipix.TaskManager
{
	public class StepAction : Step
	{
		private Action action;

		public StepAction(Action action)
		{
			this.action = action;
		}

		public override bool IsCompleted()
		{
			action?.Invoke();
			return true;
		}
	}
}
