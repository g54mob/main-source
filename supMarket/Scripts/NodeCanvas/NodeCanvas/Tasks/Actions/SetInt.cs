using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Integer", 0)]
	[Category("✫ Blackboard")]
	[Description("Set a blackboard integer variable")]
	public class SetInt : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<int> valueA;

		public OperationMethod Operation;

		public BBParameter<int> valueB;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
