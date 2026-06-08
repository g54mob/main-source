using System;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Events
{
	public class OnChannelSubscriptionArgs : EventArgs
	{
		public ChannelSubscription Subscription;

		public string ChannelId;
	}
}
