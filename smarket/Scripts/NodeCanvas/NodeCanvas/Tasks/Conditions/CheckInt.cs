using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
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
