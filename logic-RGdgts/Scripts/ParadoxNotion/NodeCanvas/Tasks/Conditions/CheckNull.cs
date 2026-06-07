using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckNull : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<object> variable;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
