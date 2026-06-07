using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckVariable<T> : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<T> valueA;

		public BBParameter<T> valueB;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
