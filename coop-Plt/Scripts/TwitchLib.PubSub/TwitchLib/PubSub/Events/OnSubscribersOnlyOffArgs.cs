using System;

namespace TwitchLib.PubSub.Events
{
	public class OnSubscribersOnlyOffArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
