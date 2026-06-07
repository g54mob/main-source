using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class SetIntRandom : ActionTask
	{
		public BBParameter<int> minValue;

		public BBParameter<int> maxValue;

		[BlackboardOnly]
		public BBParameter<int> intVariable;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
