using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckString : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<string> valueA;

		public BBParameter<string> valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
