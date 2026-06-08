using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnContinuedGiftedSubscriptionArgs : EventArgs
	{
		public ContinuedGiftedSubscription ContinuedGiftedSubscription;

		public string Channel;
	}
}
