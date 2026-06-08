using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnReSubscriberArgs : EventArgs
	{
		public ReSubscriber ReSubscriber;

		public string Channel;
	}
}
