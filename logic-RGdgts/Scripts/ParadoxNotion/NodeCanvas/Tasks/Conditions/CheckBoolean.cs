using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckBoolean : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<bool> valueA;

		public BBParameter<bool> valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
