using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Set Integer Random", 0)]
	[Category("✫ Blackboard")]
	[Description("Set a blackboard integer variable at random between min and max value")]
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
