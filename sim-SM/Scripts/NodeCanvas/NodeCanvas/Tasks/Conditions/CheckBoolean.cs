using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
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
