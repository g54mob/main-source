using System;

namespace NSEipix.TaskManager
{
	public class StepDoUntil : Step
	{
		private Action action;

		private Func<bool> condition;

		public StepDoUntil(Action action, Func<bool> condition)
		{
			this.action = action;
			this.condition = condition;
		}

		public override bool IsCompleted()
		{
			return !condition();
		}

		protected override void OnUpdate()
		{
			action?.Invoke();
		}
	}
}
