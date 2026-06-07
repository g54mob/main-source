using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SaveBlackboard : ActionTask<Blackboard>
	{
		[RequiredField]
		public BBParameter<string> saveKey;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
