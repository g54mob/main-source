using NodeCanvas.Framework;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SetOtherBlackboardVariable : ActionTask<Blackboard>
	{
		[RequiredField]
		public BBParameter<string> targetVariableName;

		public BBObjectParameter newValue;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
