using UnityEngine.Events;

namespace UI
{
	public class ConfirmDialogParam
	{
		public string title;

		public eMessageId yesMessageId;

		public eMessageId noMessageId;

		public UnityAction yesAction;

		public UnityAction noAction;

		public bool enableEscape;

		public bool enableFlontButton;

		public bool autoClose;

		public ConfirmDialogParam(string title, UnityAction yesAction, UnityAction noAction, bool enableEscape = false, bool enableFlontButton = false, bool autoClose = true, eMessageId yesMessageId = eMessageId.None, eMessageId noMessageId = eMessageId.None)
		{
		}

		public ConfirmDialogParam(eConfirmId id, UnityAction yesAction, UnityAction noAction, bool enableEscape = false, bool enableFlontButton = false, bool autoClose = true, eMessageId yesMessageId = eMessageId.None, eMessageId noMessageId = eMessageId.None)
		{
		}
	}
}
