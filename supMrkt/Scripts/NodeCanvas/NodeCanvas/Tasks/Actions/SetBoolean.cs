using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Category("✫ Blackboard")]
	[Description("Set a blackboard boolean variable")]
	public class SetBoolean : ActionTask
	{
		public enum BoolSetModes
		{
			False = 0,
			True = 1,
			Toggle = 2
		}

		[RequiredField]
		[BlackboardOnly]
		public BBParameter<bool> boolVariable;

		public BoolSetModes setTo;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
