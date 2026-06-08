using System;
using System.Collections.Generic;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class UserState
	{
		public List<KeyValuePair<string, string>> Badges { get; } = new List<KeyValuePair<string, string>>();

		public List<KeyValuePair<string, string>> BadgeInfo { get; } = new List<KeyValuePair<string, string>>();

		public string Channel { get; }

		public string ColorHex { get; }

		public string DisplayName { get; }

		public string EmoteSet { get; }

		public bool IsModerator { get; }

		public bool IsSubscriber { get; }

		public UserType UserType { get; }

		public UserState(IrcMessage ircMessage)
		{
			Channel = ircMessage.Channel;
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				switch (key)
				{
				case "badges":
					Badges = Helpers.ParseBadges(text);
					break;
				case "badge-info":
					BadgeInfo = Helpers.ParseBadges(text);
					break;
				case "color":
					ColorHex = text;
					break;
				case "display-name":
					DisplayName = text;
					break;
				case "emote-sets":
					EmoteSet = text;
					break;
				case "mod":
					IsModerator = Helpers.ConvertToBool(text);
					break;
				case "subscriber":
					IsSubscriber = Helpers.ConvertToBool(text);
					break;
				case "user-type":
					switch (text)
					{
					case "mod":
						UserType = UserType.Moderator;
						break;
					case "global_mod":
						UserType = UserType.GlobalModerator;
						break;
					case "admin":
						UserType = UserType.Admin;
						break;
					case "staff":
						UserType = UserType.Staff;
						break;
					default:
						UserType = UserType.Viewer;
						break;
					}
					break;
				default:
					Console.WriteLine("Unaccounted for [UserState]: " + key);
					break;
				}
			}
			if (string.Equals(ircMessage.User, Channel, StringComparison.InvariantCultureIgnoreCase))
			{
				UserType = UserType.Broadcaster;
			}
		}

		public UserState(List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string colorHex, string displayName, string emoteSet, string channel, bool isSubscriber, bool isModerator, UserType userType)
		{
			Badges = badges;
			BadgeInfo = badgeInfo;
			ColorHex = colorHex;
			DisplayName = displayName;
			EmoteSet = emoteSet;
			Channel = channel;
			IsSubscriber = isSubscriber;
			IsModerator = isModerator;
			UserType = userType;
		}
	}
}
