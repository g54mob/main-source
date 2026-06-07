using System;
using UnityEngine;

namespace CTS
{
	public class ConversationPanelEvents : MonoBehaviour
	{
		public static event Action ConversationPanelOpening;

		public static event Action ConversationPanelClosing;

		public void InvokeConversationPanelOpening()
		{
			ConversationPanelEvents.ConversationPanelOpening?.Invoke();
		}

		public void InvokeConversationPanelClosing()
		{
			ConversationPanelEvents.ConversationPanelClosing?.Invoke();
		}
	}
}
