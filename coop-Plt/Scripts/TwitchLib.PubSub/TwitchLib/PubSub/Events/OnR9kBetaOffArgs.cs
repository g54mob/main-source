using System;

namespace TwitchLib.PubSub.Events
{
	public class OnR9kBetaOffArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
