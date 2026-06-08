using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnChannelStateChangedArgs : EventArgs
	{
		public ChannelState ChannelState;

		public string Channel;
	}
}
