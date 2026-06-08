using System;

namespace TwitchLib.PubSub.Events
{
	public class OnViewCountArgs : EventArgs
	{
		public string ServerTime;

		public int Viewers;

		public string ChannelId;
	}
}
