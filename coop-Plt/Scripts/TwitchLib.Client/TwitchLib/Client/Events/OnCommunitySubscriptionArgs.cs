using System;
using TwitchLib.Client.Models;

namespace TwitchLib.Client.Events
{
	public class OnCommunitySubscriptionArgs : EventArgs
	{
		public CommunitySubscription GiftedSubscription;

		public string Channel;
	}
}
