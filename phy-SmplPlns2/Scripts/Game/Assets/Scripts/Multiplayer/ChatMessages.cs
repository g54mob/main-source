using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class ChatMessages
	{
		public class ChatMessage
		{
			public string MessageText { get; set; }

			public int OwnerId { get; set; }

			public string PlayerName { get; set; }

			public float TimeStamp { get; internal set; }
		}

		public class ChatMessageEventArgs : EventArgs
		{
			public ChatMessage Message { get; set; }
		}

		private List<ChatMessage> _messages = new List<ChatMessage>();

		public IReadOnlyList<ChatMessage> Messages => _messages;

		public event EventHandler<ChatMessageEventArgs> ChatMessageReceived;

		public void RaiseMessageReceived(int? ownerId, string messageText)
		{
			NetworkPlayerScript networkPlayerScript = Game.Instance.NetworkGameManager.Players.FirstOrDefault((NetworkPlayerScript x) => x.OwnerId == ownerId);
			ChatMessage chatMessage = new ChatMessage
			{
				OwnerId = (ownerId ?? (-1)),
				PlayerName = networkPlayerScript?.Name,
				MessageText = messageText,
				TimeStamp = Time.unscaledTime
			};
			_messages.Add(chatMessage);
			this.ChatMessageReceived?.Invoke(this, new ChatMessageEventArgs
			{
				Message = chatMessage
			});
		}
	}
}
