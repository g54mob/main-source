using System;

namespace TwitchLib.PubSub.Events
{
	public class OnRaidGoArgs : EventArgs
	{
		public string ChannelId;

		public Guid Id;

		public string TargetChannelId;

		public string TargetLogin;

		public string TargetDisplayName;

		public string TargetProfileImage;

		public int ViewerCount;
	}
}
