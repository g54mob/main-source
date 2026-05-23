using UnityEngine.Events;

namespace UI
{
	public class MessageDialogParam
	{
		public eMessageId messageId;

		public string title;

		public UnityAction onClickAction;

		public bool enableEscape;

		public bool enableFrontButton;

		public bool playCloseSound;

		public MessageDialogParam(string title, UnityAction action, bool enableEscape = false, bool enableFrontButton = false, bool playCloseSound = true)
		{
		}

		public MessageDialogParam(eMessageId messageId, UnityAction action, bool enableEscape = false, bool enableFrontButton = false, bool playCloseSound = true)
		{
		}
	}
}
