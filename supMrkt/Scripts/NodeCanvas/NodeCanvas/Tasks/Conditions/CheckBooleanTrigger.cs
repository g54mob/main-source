using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	[Description("Check if a boolean variable is true and if so, it is immediately reset to false.")]
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
