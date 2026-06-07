using System.Collections.Generic;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

namespace Heathen.SteamworksIntegration.UI
{
	[HelpURL("https://kb.heathen.group/assets/steamworks/unity-engine/ui-components/chat-stream")]
	public class ChatStream : MonoBehaviour
	{
		[Tooltip("How many message entries will be retained at a time.\nOldest entries are removed as this count is exceeded")]
		[SerializeField]
		private uint historyLength = 200u;

		[Tooltip("The root object under which chat messages will be listed.")]
		[SerializeField]
		private Transform content;

		[SerializeField]
		private GameObject messageTemplate;

		private ScrollRect scrollRect;

		private Queue<GameObject> messages = new Queue<GameObject>();

		private void OnEnable()
		{
			scrollRect = GetComponentInChildren<ScrollRect>();
		}

		public void HandleClanMessage(ClanChatMsg message)
		{
			GameObject gameObject = Object.Instantiate(messageTemplate, content);
			gameObject.GetComponent<IChatMessage>().Initialize(message);
			messages.Enqueue(gameObject);
			if (messages.Count > historyLength)
			{
				Object.Destroy(messages.Dequeue());
			}
			scrollRect.verticalNormalizedPosition = 0f;
		}

		public void HandleLobbyMessage(LobbyChatMsg message)
		{
			GameObject gameObject = Object.Instantiate(messageTemplate, content);
			gameObject.GetComponent<IChatMessage>().Initialize(message);
			messages.Enqueue(gameObject);
			if (messages.Count > historyLength)
			{
				Object.Destroy(messages.Dequeue());
			}
			scrollRect.verticalNormalizedPosition = 0f;
		}

		public void HandleMessage(UserData sender, string message, EChatEntryType type)
		{
			GameObject gameObject = Object.Instantiate(messageTemplate, content);
			gameObject.GetComponent<IChatMessage>().Initialize(sender, message, type);
			messages.Enqueue(gameObject);
			if (messages.Count > historyLength)
			{
				Object.Destroy(messages.Dequeue());
			}
			scrollRect.verticalNormalizedPosition = 0f;
		}
	}
}
