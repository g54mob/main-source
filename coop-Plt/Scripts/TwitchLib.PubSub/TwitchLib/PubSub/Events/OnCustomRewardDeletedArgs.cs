using System;

namespace TwitchLib.PubSub.Events
{
	public class OnCustomRewardDeletedArgs
	{
		public DateTime TimeStamp;

		public string ChannelId;

		public Guid RewardId;

		public string RewardTitle;

		public string RewardPrompt;
	}
}
