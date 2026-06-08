using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnPrimePaidSubscriberArgs : EventArgs
	{
		public PrimePaidSubscriber PrimePaidSubscriber;

		public string Channel;
	}
}
