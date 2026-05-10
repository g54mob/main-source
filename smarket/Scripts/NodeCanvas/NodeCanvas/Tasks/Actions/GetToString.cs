using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	[Name("Get Variable To String", 0)]
	[Category("✫ Blackboard")]
	public class GetToString : ActionTask
	{
		[BlackboardOnly]
		public BBParameter<object> variable;

		[BlackboardOnly]
		public BBParameter<string> toString;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
