using System;

namespace TwitchLib.PubSub.Events
{
	public class OnClearArgs : EventArgs
	{
		public string Moderator;

		public string ChannelId;
	}
}
