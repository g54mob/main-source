using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChannelBitsEvents : MessageData
	{
		public string Username { get; }

		public string ChannelName { get; }

		public string UserId { get; }

		public string ChannelId { get; }

		public string Time { get; }

		public string ChatMessage { get; }

		public int BitsUsed { get; }

		public int TotalBitsUsed { get; }

		public string Context { get; }

		public ChannelBitsEvents(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			Username = jObject.SelectToken("data").SelectToken("user_name")?.ToString();
			ChannelName = jObject.SelectToken("data").SelectToken("channel_name")?.ToString();
			UserId = jObject.SelectToken("data").SelectToken("user_id")?.ToString();
			ChannelId = jObject.SelectToken("data").SelectToken("channel_id")?.ToString();
			Time = jObject.SelectToken("data").SelectToken("time")?.ToString();
			ChatMessage = jObject.SelectToken("data").SelectToken("chat_message")?.ToString();
			BitsUsed = int.Parse(jObject.SelectToken("data").SelectToken("bits_used").ToString());
			TotalBitsUsed = int.Parse(jObject.SelectToken("data").SelectToken("total_bits_used").ToString());
			Context = jObject.SelectToken("data").SelectToken("context")?.ToString();
		}
	}
}
