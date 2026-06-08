using System;

namespace TwitchLib.PubSub.Events
{
	public class OnBitsReceivedArgs : EventArgs
	{
		public string Username;

		public string ChannelName;

		public string UserId;

		public string ChannelId;

		public string Time;

		public string ChatMessage;

		public int BitsUsed;

		public int TotalBitsUsed;

		public string Context;
	}
}
