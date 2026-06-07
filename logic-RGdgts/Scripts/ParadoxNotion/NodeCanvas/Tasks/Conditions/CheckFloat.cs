using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Conditions
{
	public class CheckFloat : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<float> valueA;

		public CompareMethod checkType;

		public BBParameter<float> valueB;

		public float differenceThreshold;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
