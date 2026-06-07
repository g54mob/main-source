using UnityEngine.Events;

namespace UI
{
	public class PutMachineDialogParam
	{
		public string title;

		public UnityAction yesAction;

		public UnityAction noAction;

		public bool enableEscape;

		public bool enableFlontButton;

		public PutMachineDialogParam(eMachine machine, UnityAction yesAction, UnityAction noAction = null)
		{
		}
	}
}
