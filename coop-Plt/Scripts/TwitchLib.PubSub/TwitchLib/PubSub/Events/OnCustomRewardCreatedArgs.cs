using System;

namespace TwitchLib.PubSub.Events
{
	public class OnCustomRewardCreatedArgs : EventArgs
	{
		public DateTime TimeStamp;

		public string ChannelId;

		public Guid RewardId;

		public string RewardTitle;

		public string RewardPrompt;

		public int RewardCost;
	}
}
