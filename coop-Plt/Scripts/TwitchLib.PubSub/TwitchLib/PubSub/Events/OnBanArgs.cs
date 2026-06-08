using System;

namespace TwitchLib.PubSub.Events
{
	public class OnBanArgs : EventArgs
	{
		public string BannedUserId;

		public string BannedUser;

		public string BanReason;

		public string BannedBy;

		public string BannedByUserId;

		public string ChannelId;
	}
}
