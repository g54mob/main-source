using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class SetFloatRandom : ActionTask
	{
		public BBParameter<float> minValue;

		public BBParameter<float> maxValue;

		[BlackboardOnly]
		public BBParameter<float> floatVariable;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
