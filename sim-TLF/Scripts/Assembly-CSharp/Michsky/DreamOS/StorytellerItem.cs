using UnityEngine;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(ButtonManager))]
	public class StorytellerItem : MonoBehaviour
	{
		[HideInInspector]
		public int itemIndex;

		[HideInInspector]
		public int layoutIndex;

		[HideInInspector]
		public ChatLayoutPreset layout;

		[HideInInspector]
		public MessagingManager msgManager;

		[HideInInspector]
		public DynamicMessageHandler handler;

		[HideInInspector]
		public string replyLocKey;

		private void Start()
		{
			base.gameObject.GetComponent<ButtonManager>().onClick.AddListener(delegate
			{
				string text = null;
				text = (string.IsNullOrEmpty(replyLocKey) ? msgManager.chatList[layoutIndex].chatAsset.storyTeller[msgManager.storyTellerIndex].replies[itemIndex].replyContent : replyLocKey);
				msgManager.HideStorytellerPanel();
				msgManager.CreateMessage(layout, text);
				msgManager.stItemIndex = itemIndex;
				msgManager.isStoryTellerOpen = false;
				if (!string.IsNullOrEmpty(msgManager.chatList[layoutIndex].chatAsset.storyTeller[msgManager.storyTellerIndex].replies[itemIndex].replyFeedback))
				{
					handler.StartCoroutine(handler.HandleStoryTellerLatency(msgManager.chatList[layoutIndex].chatAsset.storyTeller[msgManager.storyTellerIndex].replies[itemIndex].feedbackLatency, layoutIndex, itemIndex));
				}
				for (int i = 0; i < msgManager.storytellerReplyEvents.Count; i++)
				{
					if (msgManager.storytellerReplyEvents[i].replyID == base.gameObject.name)
					{
						msgManager.storytellerReplyEvents[i].onReplySelect.Invoke();
						break;
					}
				}
			});
		}
	}
}
