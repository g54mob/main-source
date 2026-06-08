using System;

namespace TwitchLib.PubSub.Events
{
	public class OnStreamUpArgs : EventArgs
	{
		public string ServerTime;

		public int PlayDelay;

		public string ChannelId;
	}
}
