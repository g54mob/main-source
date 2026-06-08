using System.Collections.Generic;
using TwitchLib.Client.Models.Builders;

namespace TwitchLib.Client.Models.Extractors
{
	public class EmoteExtractor
	{
		public IEnumerable<Emote> Extract(string rawEmoteSetString, string message)
		{
			if (string.IsNullOrEmpty(rawEmoteSetString) || string.IsNullOrEmpty(message))
			{
				yield break;
			}
			if (rawEmoteSetString.Contains("/"))
			{
				string[] array = rawEmoteSetString.Split('/');
				foreach (string emoteData in array)
				{
					string emoteId = emoteData.Split(':')[0];
					if (emoteData.Contains(","))
					{
						string[] array2 = emoteData.Replace(emoteId + ":", "").Split(',');
						foreach (string emote in array2)
						{
							yield return GetEmote(emote, emoteId, message);
						}
					}
					else
					{
						yield return GetEmote(emoteData, emoteId, message, single: true);
					}
				}
				yield break;
			}
			string emoteId2 = rawEmoteSetString.Split(':')[0];
			if (rawEmoteSetString.Contains(","))
			{
				string[] array3 = rawEmoteSetString.Replace(emoteId2 + ":", "").Split(',');
				foreach (string emote2 in array3)
				{
					yield return GetEmote(emote2, emoteId2, message);
				}
			}
			else
			{
				yield return GetEmote(rawEmoteSetString, emoteId2, message, single: true);
			}
		}

		private Emote GetEmote(string emoteData, string emoteId, string message, bool single = false)
		{
			int num = -1;
			int num2 = -1;
			if (single)
			{
				num = int.Parse(emoteData.Split(':')[1].Split('-')[0]);
				num2 = int.Parse(emoteData.Split(':')[1].Split('-')[1]);
			}
			else
			{
				num = int.Parse(emoteData.Split('-')[0]);
				num2 = int.Parse(emoteData.Split('-')[1]);
			}
			string name = message.Substring(num, num2 - num + 1);
			EmoteBuilder emoteBuilder = EmoteBuilder.Create().WithId(emoteId).WithName(name)
				.WithStartIndex(num)
				.WithEndIndex(num2);
			return emoteBuilder.Build();
		}
	}
}
