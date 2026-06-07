using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckInt : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<int> valueA;

		public CompareMethod checkType;

		public BBParameter<int> valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
