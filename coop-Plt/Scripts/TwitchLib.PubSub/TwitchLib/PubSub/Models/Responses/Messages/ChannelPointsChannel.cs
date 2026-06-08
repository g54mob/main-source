using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Enums;
using TwitchLib.PubSub.Models.Responses.Messages.Redemption;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChannelPointsChannel : MessageData
	{
		public ChannelPointsChannelType Type { get; private set; }

		public ChannelPointsData Data { get; private set; }

		public string RawData { get; private set; }

		public ChannelPointsChannel(string jsonStr)
		{
			RawData = jsonStr;
			JToken jToken = JObject.Parse(jsonStr);
			string text = jToken.SelectToken("type").ToString();
			string text2 = text;
			if (text2 == "reward-redeemed")
			{
				Type = ChannelPointsChannelType.RewardRedeemed;
				Data = JsonConvert.DeserializeObject<RewardRedeemed>(jToken.SelectToken("data").ToString());
			}
			else
			{
				Type = ChannelPointsChannelType.Unknown;
			}
		}
	}
}
