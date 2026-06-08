using System;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class ChannelState
	{
		public string BroadcasterLanguage { get; }

		public string Channel { get; }

		public bool? EmoteOnly { get; }

		public TimeSpan? FollowersOnly { get; } = null;

		public bool Mercury { get; }

		public bool? R9K { get; }

		public bool? Rituals { get; }

		public string RoomId { get; }

		public int? SlowMode { get; }

		public bool? SubOnly { get; }

		public ChannelState(IrcMessage ircMessage)
		{
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				switch (key)
				{
				case "broadcaster-lang":
					BroadcasterLanguage = text;
					break;
				case "emote-only":
					EmoteOnly = Helpers.ConvertToBool(text);
					break;
				case "r9k":
					R9K = Helpers.ConvertToBool(text);
					break;
				case "rituals":
					Rituals = Helpers.ConvertToBool(text);
					break;
				case "slow":
				{
					int result2;
					bool flag = int.TryParse(text, out result2);
					SlowMode = (flag ? new int?(result2) : ((int?)null));
					break;
				}
				case "subs-only":
					SubOnly = Helpers.ConvertToBool(text);
					break;
				case "followers-only":
				{
					if (int.TryParse(text, out var result) && result > -1)
					{
						FollowersOnly = TimeSpan.FromMinutes(result);
					}
					break;
				}
				case "room-id":
					RoomId = text;
					break;
				case "mercury":
					Mercury = Helpers.ConvertToBool(text);
					break;
				default:
					Console.WriteLine("[TwitchLib][ChannelState] Unaccounted for: " + key);
					break;
				}
			}
			Channel = ircMessage.Channel;
		}

		public ChannelState(bool r9k, bool rituals, bool subonly, int slowMode, bool emoteOnly, string broadcasterLanguage, string channel, TimeSpan followersOnly, bool mercury, string roomId)
		{
			R9K = r9k;
			Rituals = rituals;
			SubOnly = subonly;
			SlowMode = slowMode;
			EmoteOnly = emoteOnly;
			BroadcasterLanguage = broadcasterLanguage;
			Channel = channel;
			FollowersOnly = followersOnly;
			Mercury = mercury;
			RoomId = roomId;
		}
	}
}
