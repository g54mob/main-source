using System;

namespace TwitchLib.PubSub.Events
{
	public class OnChannelCommerceReceivedArgs : EventArgs
	{
		public string Username;

		public string DisplayName;

		public string ChannelName;

		public string UserId;

		public string ChannelId;

		public string Time;

		public string ItemImageURL;

		public string ItemDescription;

		public bool SupportsChannel;

		public string PurchaseMessage;
	}
}
