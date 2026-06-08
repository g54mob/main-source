using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TwitchLib.PubSub.Models.Responses.Messages
{
	public class SubMessage : MessageData
	{
		public class Emote
		{
			public int Start { get; }

			public int End { get; }

			public int Id { get; }

			public Emote(JToken json)
			{
				Start = int.Parse(json.SelectToken("start").ToString());
				End = int.Parse(json.SelectToken("end").ToString());
				Id = int.Parse(json.SelectToken("id").ToString());
			}
		}

		public string Message { get; }

		public List<Emote> Emotes { get; } = new List<Emote>();

		public SubMessage(JToken json)
		{
			Message = json.SelectToken("message")?.ToString();
			foreach (JToken item in (IEnumerable<JToken>)json.SelectToken("emotes"))
			{
				Emotes.Add(new Emote(item));
			}
		}
	}
}
