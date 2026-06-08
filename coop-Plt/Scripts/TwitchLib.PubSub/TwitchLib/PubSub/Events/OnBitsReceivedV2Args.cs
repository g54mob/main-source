using System;

namespace TwitchLib.PubSub.Events
{
	public class OnBitsReceivedV2Args
	{
		public string UserName { get; internal set; }

		public string ChannelName { get; internal set; }

		public string UserId { get; internal set; }

		public string ChannelId { get; internal set; }

		public DateTime Time { get; internal set; }

		public string ChatMessage { get; internal set; }

		public int BitsUsed { get; internal set; }

		public int TotalBitsUsed { get; internal set; }

		public bool IsAnonymous { get; internal set; }

		public string Context { get; internal set; }
	}
}
