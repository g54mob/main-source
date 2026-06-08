using System;

namespace TwitchLib.PubSub.Events
{
	public class OnFollowArgs : EventArgs
	{
		public string FollowedChannelId;

		public string DisplayName;

		public string Username;

		public string UserId;
	}
}
