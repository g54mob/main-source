using System;

namespace TwitchLib.PubSub.Events
{
	public class OnStreamDownArgs : EventArgs
	{
		public string ServerTime;

		public string ChannelId;
	}
}
