using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnNewSubscriberArgs : EventArgs
	{
		public Subscriber Subscriber;

		public string Channel;
	}
}
