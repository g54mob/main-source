using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Set a blackboard float variable")]
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
