using NodeCanvas.Framework;
using ParadoxNotion;

namespace NodeCanvas.Tasks.Actions
{
	public class SetFloat : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<float> valueA;

		public OperationMethod Operation;

		public BBParameter<float> valueB;

		public bool perSecond;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
