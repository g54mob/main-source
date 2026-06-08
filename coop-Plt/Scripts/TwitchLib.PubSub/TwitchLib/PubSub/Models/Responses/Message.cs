using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwitchLib.PubSub.Models.Responses.Messages;

namespace TwitchLib.PubSub.Models.Responses
{
	public class Message
	{
		public readonly MessageData MessageData;

		public string Topic { get; }

		public Message(string jsonStr)
		{
			JToken jToken = JObject.Parse(jsonStr).SelectToken("data");
			Topic = jToken.SelectToken("topic")?.ToString();
			string text = jToken.SelectToken("message").ToString();
			string topic = Topic;
			switch ((topic != null) ? topic.Split('.')[0] : null)
			{
			case "chat_moderator_actions":
				MessageData = new ChatModeratorActions(text);
				break;
			case "channel-bits-events-v1":
				MessageData = new ChannelBitsEvents(text);
				break;
			case "channel-bits-events-v2":
			{
				text = text.Replace("\\", "");
				string value = JObject.Parse(text)["data"].ToString();
				MessageData = JsonConvert.DeserializeObject<ChannelBitsEventsV2>(value);
				break;
			}
			case "video-playback-by-id":
				MessageData = new VideoPlayback(text);
				break;
			case "whispers":
				MessageData = new Whisper(text);
				break;
			case "channel-subscribe-events-v1":
				MessageData = new ChannelSubscription(text);
				break;
			case "channel-ext-v1":
				MessageData = new ChannelExtensionBroadcast(text);
				break;
			case "following":
				MessageData = new Following(text);
				break;
			case "community-points-channel-v1":
				MessageData = new CommunityPointsChannel(text);
				break;
			case "channel-points-channel-v1":
				MessageData = new ChannelPointsChannel(text);
				break;
			case "leaderboard-events-v1":
				MessageData = new LeaderboardEvents(text);
				break;
			case "raid":
				MessageData = new RaidEvents(text);
				break;
			case "predictions-channel-v1":
				MessageData = new PredictionEvents(text);
				break;
			}
		}
	}
}
