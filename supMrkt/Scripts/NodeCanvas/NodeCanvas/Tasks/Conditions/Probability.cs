using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Conditions
{
	[Category("✫ Utility")]
	[Description("Return true or false based on the probability settings. The chance is rolled for once whenever the condition is enabled.")]
	public class Probability : ConditionTask
	{
		public BBParameter<float> probability;

		public BBParameter<float> maxValue;

		private bool success;

		protected override string info => null;

		protected override void OnEnable()
		{
		}

		protected override bool OnCheck()
		{
			return false;
		}
	}
}
