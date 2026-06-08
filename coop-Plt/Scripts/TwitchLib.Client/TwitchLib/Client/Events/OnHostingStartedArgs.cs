using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnHostingStartedArgs : EventArgs
	{
		public HostingStarted HostingStarted;
	}
}
