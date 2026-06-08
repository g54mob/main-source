using System;

namespace TwitchLib.PubSub.Events
{
	public class OnPubSubServiceErrorArgs : EventArgs
	{
		public Exception Exception;
	}
}
