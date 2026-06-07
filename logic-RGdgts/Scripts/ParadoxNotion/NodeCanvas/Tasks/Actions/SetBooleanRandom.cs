using NodeCanvas.Framework;

namespace NodeCanvas.Tasks.Actions
{
	public class SetBooleanRandom : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<bool> boolVariable;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
