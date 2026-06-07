using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Conditions
{
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
