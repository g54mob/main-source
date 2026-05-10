using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Blackboard")]
	public class CheckFloat : ConditionTask
	{
		[BlackboardOnly]
		public BBParameter<float> valueA;

		public CompareMethod checkType;

		public BBParameter<float> valueB;

		[SliderField(0f, 0.1f)]
		public float differenceThreshold;

		protected override string info => null;

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
