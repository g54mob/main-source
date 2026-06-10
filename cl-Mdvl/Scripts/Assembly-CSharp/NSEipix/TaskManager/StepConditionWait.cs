namespace NSEipix.TaskManager
{
	public class StepConditionWait : Step
	{
		private UntilTaskPredicate condition;

		public StepConditionWait(UntilTaskPredicate condition)
		{
			this.condition = condition;
		}

		public override bool IsCompleted()
		{
			if (condition == null || condition(base.Timer))
			{
				return true;
			}
			return false;
		}
	}
}
