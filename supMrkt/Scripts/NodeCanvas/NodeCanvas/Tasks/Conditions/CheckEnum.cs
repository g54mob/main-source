using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckEnum : ConditionTask
	{
		[BlackboardOnly]
		public BBObjectParameter valueA;

		public BBObjectParameter valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
