using System;

namespace UI
{
	public class RemoveMachineDialogParam
	{
		public eMachine machine;

		public Action<bool> yesAction;

		public Action noAction;

		public bool enableEscape;

		public bool enableFlontButton;

		public RemoveMachineDialogParam(eMachine machine, Action<bool> yesAction, Action noAction = null)
		{
		}
	}
}
