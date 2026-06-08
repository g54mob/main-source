using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChatModeratorActions : MessageData
	{
		public string Type { get; }

		public string ModerationAction { get; }

		public List<string> Args { get; } = new List<string>();

		public string CreatedBy { get; }

		public string CreatedByUserId { get; }

		public string TargetUserId { get; }

		public ChatModeratorActions(string jsonStr)
		{
			JToken jToken = JObject.Parse(jsonStr).SelectToken("data");
			Type = jToken.SelectToken("type")?.ToString();
			ModerationAction = jToken.SelectToken("moderation_action")?.ToString();
			if (jToken.SelectToken("args") != null)
			{
				foreach (JToken item in (IEnumerable<JToken>)jToken.SelectToken("args"))
				{
					Args.Add(item.ToString());
				}
			}
			CreatedBy = jToken.SelectToken("created_by").ToString();
			CreatedByUserId = jToken.SelectToken("created_by_user_id").ToString();
			TargetUserId = jToken.SelectToken("target_user_id").ToString();
		}
	}
}
