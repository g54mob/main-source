using UnityEngine;
using UnityEngine.Events;

namespace Michsky.DreamOS
{
	[AddComponentMenu("DreamOS/Apps/Messaging/Storyteller Reply Event")]
	public class StorytellerReplyEvent : MonoBehaviour
	{
		[Header("Settings")]
		[SerializeField]
		private MessagingManager messagingManager;

		[SerializeField]
		private string replyID;

		[Header("Events")]
		public UnityEvent onReplySelect = new UnityEvent();

		private void Start()
		{
			if (messagingManager == null)
			{
				Debug.LogError("<b>[Storyteller Reply Event]</b> Messaging Manager is missing.", this);
				return;
			}
			MessagingManager.StorytellerReplyEvent storytellerReplyEvent = new MessagingManager.StorytellerReplyEvent();
			storytellerReplyEvent.replyID = replyID;
			storytellerReplyEvent.onReplySelect.AddListener(delegate
			{
				onReplySelect.Invoke();
			});
			messagingManager.storytellerReplyEvents.Add(storytellerReplyEvent);
		}
	}
}
