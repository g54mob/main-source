using System;
using System.Collections.Generic;

namespace TwitchLib.Client.Events
{
	public class OnVIPsReceivedArgs : EventArgs
	{
		public string Channel;

		public List<string> VIPs;
	}
}
