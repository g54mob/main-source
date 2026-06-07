using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Conditions
{
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
