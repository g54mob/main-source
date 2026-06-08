using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class ChannelExtensionBroadcast : MessageData
	{
		public List<string> Messages { get; } = new List<string>();

		public ChannelExtensionBroadcast(string jsonStr)
		{
			JObject jObject = JObject.Parse(jsonStr);
			foreach (JToken item in (IEnumerable<JToken>)jObject["content"])
			{
				Messages.Add(item.ToString());
			}
		}
	}
}
