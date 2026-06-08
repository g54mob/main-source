using System;

namespace TwitchLib.PubSub.Events
{
	public class OnHostArgs : EventArgs
	{
		public string Moderator;

		public string HostedChannel;

		public string ChannelId;
	}
}
