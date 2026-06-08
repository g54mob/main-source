using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnBeingHostedArgs : EventArgs
	{
		public BeingHostedNotification BeingHostedNotification;
	}
}
