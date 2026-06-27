using System;

namespace Moq
{
	internal sealed class Condition
	{
		private Func<bool> condition;

		private Action success;

		public bool IsTrue => condition?.Invoke() ?? false;

		public Condition(Func<bool> condition, Action success = null)
		{
			this.condition = condition;
			this.success = success;
		}

		public void SetupEvaluatedSuccessfully()
		{
			success?.Invoke();
		}
	}
}
