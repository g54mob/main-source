using NodeCanvas.Framework;
using NodeCanvas.StateMachines;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.Actions
{
	public class SwitchFSM : ActionTask<FSMOwner>
	{
		[RequiredField]
		public BBParameter<FSM> fsm;

		protected override string info => null;

		protected override void OnExecute()
		{
		}
	}
}
