using System;

namespace TwitchLib.PubSub.Events
{
	public class OnEmoteOnlyOffArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
