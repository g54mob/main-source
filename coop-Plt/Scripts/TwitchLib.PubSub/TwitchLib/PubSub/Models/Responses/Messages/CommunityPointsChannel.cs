using System;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class CommunityPointsChannel : MessageData
	{
		public CommunityPointsChannelType Type { get; protected set; }

		public DateTime TimeStamp { get; protected set; }

		public string ChannelId { get; protected set; }

		public string Login { get; protected set; }

		public string DisplayName { get; protected set; }

		public string Message { get; protected set; }

		public Guid RewardId { get; protected set; }

		public string RewardTitle { get; protected set; }

		public string RewardPrompt { get; protected set; }

		public int RewardCost { get; protected set; }

		public string Status { get; protected set; }

		public Guid RedemptionId { get; protected set; }

		public CommunityPointsChannel(string jsonStr)
		{
			JToken jToken = JObject.Parse(jsonStr);
			switch (jToken.SelectToken("type").ToString())
			{
			case "reward-redeemed":
			case "redemption-status-update":
				Type = CommunityPointsChannelType.RewardRedeemed;
				break;
			case "custom-reward-created":
				Type = CommunityPointsChannelType.CustomRewardCreated;
				break;
			case "custom-reward-updated":
				Type = CommunityPointsChannelType.CustomRewardUpdated;
				break;
			case "custom-reward-deleted":
				Type = CommunityPointsChannelType.CustomRewardDeleted;
				break;
			default:
				Type = (CommunityPointsChannelType)(-1);
				break;
			}
			TimeStamp = DateTime.Parse(jToken.SelectToken("data.timestamp").ToString());
			switch (Type)
			{
			case CommunityPointsChannelType.RewardRedeemed:
				ChannelId = jToken.SelectToken("data.redemption.channel_id").ToString();
				Login = jToken.SelectToken("data.redemption.user.login").ToString();
				DisplayName = jToken.SelectToken("data.redemption.user.display_name").ToString();
				RewardId = Guid.Parse(jToken.SelectToken("data.redemption.reward.id").ToString());
				RewardTitle = jToken.SelectToken("data.redemption.reward.title").ToString();
				RewardPrompt = jToken.SelectToken("data.redemption.reward.prompt").ToString();
				RewardCost = int.Parse(jToken.SelectToken("data.redemption.reward.cost").ToString());
				Message = jToken.SelectToken("data.redemption.user_input")?.ToString();
				Status = jToken.SelectToken("data.redemption.status").ToString();
				RedemptionId = Guid.Parse(jToken.SelectToken("data.redemption.id").ToString());
				break;
			case CommunityPointsChannelType.CustomRewardUpdated:
				ChannelId = jToken.SelectToken("data.updated_reward.channel_id").ToString();
				RewardId = Guid.Parse(jToken.SelectToken("data.updated_reward.id").ToString());
				RewardTitle = jToken.SelectToken("data.updated_reward.title").ToString();
				RewardPrompt = jToken.SelectToken("data.updated_reward.prompt").ToString();
				RewardCost = int.Parse(jToken.SelectToken("data.updated_reward.cost").ToString());
				break;
			case CommunityPointsChannelType.CustomRewardCreated:
				ChannelId = jToken.SelectToken("data.new_reward.channel_id").ToString();
				RewardId = Guid.Parse(jToken.SelectToken("data.new_reward.id").ToString());
				RewardTitle = jToken.SelectToken("data.new_reward.title").ToString();
				RewardPrompt = jToken.SelectToken("data.new_reward.prompt").ToString();
				RewardCost = int.Parse(jToken.SelectToken("data.new_reward.cost").ToString());
				break;
			case CommunityPointsChannelType.CustomRewardDeleted:
				ChannelId = jToken.SelectToken("data.deleted_reward.channel_id").ToString();
				RewardId = Guid.Parse(jToken.SelectToken("data.deleted_reward.id").ToString());
				RewardTitle = jToken.SelectToken("data.deleted_reward.title").ToString();
				RewardPrompt = jToken.SelectToken("data.deleted_reward.prompt").ToString();
				break;
			}
		}
	}
}
