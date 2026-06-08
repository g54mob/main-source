using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class Following : MessageData
	{
		public string DisplayName { get; }

		public string Username { get; }

		public string UserId { get; }

		public string FollowedChannelId { get; internal set; }

		public Following(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			DisplayName = jObject["display_name"].ToString();
			Username = jObject["username"].ToString();
			UserId = jObject["user_id"].ToString();
		}
	}
}
