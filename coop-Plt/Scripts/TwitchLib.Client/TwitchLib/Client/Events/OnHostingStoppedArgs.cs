using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnHostingStoppedArgs : EventArgs
	{
		public HostingStopped HostingStopped;
	}
}
