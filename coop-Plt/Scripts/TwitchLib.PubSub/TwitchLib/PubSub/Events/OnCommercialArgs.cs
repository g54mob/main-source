using System;

namespace TwitchLib.PubSub.Events
{
	public class OnCommercialArgs : EventArgs
	{
		public int Length;

		public string ServerTime;

		public string ChannelId;
	}
}
