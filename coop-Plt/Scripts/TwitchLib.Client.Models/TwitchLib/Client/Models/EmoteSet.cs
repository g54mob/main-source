using System.Collections.Generic;
using System.Linq;
using TwitchLib.Client.Models.Extractors;

namespace TwitchLib.Client.Models
{
	public class EmoteSet
	{
		public List<Emote> Emotes { get; }

		public string RawEmoteSetString { get; }

		public EmoteSet(string rawEmoteSetString, string message)
		{
			RawEmoteSetString = rawEmoteSetString;
			EmoteExtractor emoteExtractor = new EmoteExtractor();
			Emotes = emoteExtractor.Extract(rawEmoteSetString, message).ToList();
		}

		public EmoteSet(IEnumerable<Emote> emotes, string emoteSetData)
		{
			RawEmoteSetString = emoteSetData;
			Emotes = emotes.ToList();
		}
	}
}
