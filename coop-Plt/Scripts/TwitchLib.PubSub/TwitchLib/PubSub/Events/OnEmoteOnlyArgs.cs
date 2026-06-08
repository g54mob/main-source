using System;

namespace TwitchLib.PubSub.Events
{
	public class OnEmoteOnlyArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
