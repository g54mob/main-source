using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckBooleanTrigger : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<bool> trigger;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
