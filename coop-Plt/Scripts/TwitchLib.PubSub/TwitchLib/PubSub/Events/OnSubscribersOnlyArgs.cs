using System;

namespace TwitchLib.PubSub.Events
{
	public class OnSubscribersOnlyArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
