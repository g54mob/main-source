using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class GetOtherBlackboardVariable : ActionTask<Blackboard>
	{
		[RequiredField]
		public BBParameter<string> targetVariableName;

		[BlackboardOnly]
		public BBObjectParameter saveAs;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
