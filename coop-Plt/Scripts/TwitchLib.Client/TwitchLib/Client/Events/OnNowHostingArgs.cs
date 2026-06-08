using System;

namespace TwitchLib.Client.Events
{
	public class OnNowHostingArgs : EventArgs
	{
		public string Channel;

		public string HostedChannel;
	}
}
