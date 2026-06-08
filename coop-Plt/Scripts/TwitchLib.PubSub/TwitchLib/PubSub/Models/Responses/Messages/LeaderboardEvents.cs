using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class LeaderboardEvents : MessageData
	{
		public LeaderBoardType Type { get; private set; }

		public string ChannelId { get; private set; }

		public List<LeaderBoard> Top { get; private set; } = new List<LeaderBoard>();

		public LeaderboardEvents(string jsonStr)
		{
			JToken jToken = JObject.Parse(jsonStr);
			string text = jToken.SelectToken("identifier.domain").ToString();
			string text2 = text;
			if (!(text2 == "bits-usage-by-channel-v1"))
			{
				if (text2 == "sub-gift-sent")
				{
					Type = LeaderBoardType.SubGiftSent;
				}
			}
			else
			{
				Type = LeaderBoardType.BitsUsageByChannel;
			}
			switch (Type)
			{
			case LeaderBoardType.BitsUsageByChannel:
				ChannelId = jToken.SelectToken("identifier.grouping_key").ToString();
				{
					foreach (JToken item in jToken["top"].Children())
					{
						Top.Add(new LeaderBoard
						{
							Place = int.Parse(item.SelectToken("rank").ToString()),
							Score = int.Parse(item.SelectToken("score").ToString()),
							UserId = item.SelectToken("entry_key").ToString()
						});
					}
					break;
				}
			case LeaderBoardType.SubGiftSent:
				ChannelId = jToken.SelectToken("identifier.grouping_key").ToString();
				{
					foreach (JToken item2 in jToken["top"].Children())
					{
						Top.Add(new LeaderBoard
						{
							Place = int.Parse(item2.SelectToken("rank").ToString()),
							Score = int.Parse(item2.SelectToken("score").ToString()),
							UserId = item2.SelectToken("entry_key").ToString()
						});
					}
					break;
				}
			}
		}
	}
}
