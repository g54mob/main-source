using System;
using System.Collections.Generic;

namespace TwitchLib.PubSub.Events
{
	public class OnChannelExtensionBroadcastArgs : EventArgs
	{
		public List<string> Messages;

		public string ChannelId;
	}
}
