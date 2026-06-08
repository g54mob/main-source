using System.Collections.Generic;
using Newtonsoft.Json;

namespace TwitchLib.Api.V5.Models.Chat
{
	public class EmoteSet
	{
		[JsonProperty(PropertyName = "emoticon_sets")]
		public Dictionary<string, Emote[]> EmoticonSets { get; protected set; }

		[JsonProperty(PropertyName = "emoticons")]
		public Emote[] Emoticons { get; protected set; }
	}
}
