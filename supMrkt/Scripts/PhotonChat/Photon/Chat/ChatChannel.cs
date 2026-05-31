using System.Collections.Generic;

namespace Photon.Chat
{
	public class ChatChannel
	{
		public readonly string Name;

		public readonly List<string> Senders;

		public readonly List<object> Messages;

		public int MessageLimit;

		public int ChannelID;

		private Dictionary<object, object> properties;

		public readonly HashSet<string> Subscribers;

		private Dictionary<string, Dictionary<object, object>> usersProperties;

		public bool IsPrivate { get; protected internal set; }

		public int MessageCount => 0;

		public int LastMsgId { get; protected set; }

		public bool PublishSubscribers { get; protected set; }

		public int MaxSubscribers { get; protected set; }

		public ChatChannel(string name)
		{
		}

		public void Add(string sender, object message, int msgId)
		{
		}

		public void Add(string[] senders, object[] messages, int lastMsgId)
		{
		}

		public void TruncateMessages()
		{
		}

		public void ClearMessages()
		{
		}

		public string ToStringMessages()
		{
			return null;
		}

		internal void ReadChannelProperties(Dictionary<object, object> newProperties)
		{
		}

		internal bool AddSubscribers(string[] users)
		{
			return false;
		}

		internal bool AddSubscriber(string userId)
		{
			return false;
		}

		internal bool RemoveSubscriber(string userId)
		{
			return false;
		}
	}
}
