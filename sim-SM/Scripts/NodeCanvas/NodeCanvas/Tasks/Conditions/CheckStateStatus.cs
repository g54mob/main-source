using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Check the parent state status. This condition is only meant to be used along with an FSM system.")]
	public class CheckStateStatus : ConditionTask
	{
		public CompactStatus status;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
