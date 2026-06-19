using System;
using System.Collections.Generic;
using UnityEngine;

namespace Michsky.DreamOS
{
	[CreateAssetMenu(fileName = "New Chat", menuName = "DreamOS/New Messaging Chat")]
	public class MessagingChat : ScriptableObject
	{
		public enum DynamicMessageReplyBehavior
		{
			DoNothing = 0,
			DisableReply = 1
		}

		[Serializable]
		public class ChatMessage
		{
			[TextArea(3, 6)]
			public string messageContent = "My message";

			public ObjectType objectType;

			public MessageAuthor messageAuthor;

			public string sentTime = "00:00";

			public AudioClip audioMessage;

			public Sprite imageMessage;

			[Header("Localization")]
			public string messageKey;
		}

		[Serializable]
		public class DynamicMessages
		{
			public string messageID = "MESSAGE_0";

			[TextArea(3, 6)]
			public string messageContent = "My message";

			[TextArea(3, 6)]
			public string replyContent = "Reply message";

			[Header("Settings")]
			[Range(0.1f, 25f)]
			public float replyLatency = 1f;

			[Range(0.1f, 25f)]
			public float replyTimer = 1.5f;

			public DynamicMessageReplyBehavior replyBehavior;

			public bool enableReply = true;

			[Header("Storyteller")]
			public string runStoryteller;

			[Header("Localization")]
			public string replyKey;
		}

		[Serializable]
		public class StoryTeller
		{
			public string itemID = "ITEM_0";

			public MessageAuthor messageAuthor;

			[TextArea(3, 6)]
			public string messageContent = "My message";

			[Range(0f, 25f)]
			public float messageLatency = 1f;

			[Range(0f, 25f)]
			public float messageTimer = 1.5f;

			public List<StoryTellerItem> replies = new List<StoryTellerItem>();

			[Header("Localization")]
			public string messageKey;
		}

		[Serializable]
		public class StoryTellerItem
		{
			public string replyID;

			[TextArea]
			public string replyBrief = "Reply brief";

			[TextArea]
			public string replyContent = "Reply content";

			[TextArea]
			public string replyFeedback = "Reply feedback";

			[Range(0.1f, 25f)]
			public float feedbackLatency = 1f;

			[Range(0.1f, 25f)]
			public float feedbackTimer = 1.5f;

			public string callAfter;

			[Header("Localization")]
			public string briefKey;

			public string contentKey;

			public string feedbackKey;
		}

		public enum MessageAuthor
		{
			Self = 0,
			Individual = 1
		}

		public enum ObjectType
		{
			Message = 0,
			Date = 1,
			AudioMessage = 2,
			ImageMessage = 3
		}

		public bool saveConversation;

		public bool useDynamicMessages;

		public bool useStoryTeller;

		public List<ChatMessage> messageList = new List<ChatMessage>();

		public List<DynamicMessages> dynamicMessages = new List<DynamicMessages>();

		public List<StoryTeller> storyTeller = new List<StoryTeller>();
	}
}
