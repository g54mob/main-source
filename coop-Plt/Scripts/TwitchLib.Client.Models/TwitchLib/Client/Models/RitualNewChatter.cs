using System.Collections.Generic;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class RitualNewChatter
	{
		public List<KeyValuePair<string, string>> Badges { get; }

		public List<KeyValuePair<string, string>> BadgeInfo { get; }

		public string Color { get; }

		public string DisplayName { get; }

		public string Emotes { get; }

		public string Id { get; }

		public bool IsModerator { get; }

		public bool IsSubscriber { get; }

		public bool IsTurbo { get; }

		public string Login { get; }

		public string Message { get; }

		public string MsgId { get; }

		public string MsgParamRitualName { get; }

		public string RoomId { get; }

		public string SystemMsgParsed { get; }

		public string SystemMsg { get; }

		public string TmiSentTs { get; }

		public string UserId { get; }

		public UserType UserType { get; }

		public RitualNewChatter(IrcMessage ircMessage)
		{
			Message = ircMessage.Message;
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
					Color = text;
					break;
				case "display-name":
					DisplayName = text;
					break;
				case "emotes":
					Emotes = text;
					break;
				case "id":
					Id = text;
					break;
				case "login":
					Login = text;
					break;
				case "mod":
					IsModerator = Helpers.ConvertToBool(text);
					break;
				case "msg-id":
					MsgId = text;
					break;
				case "msg-param-ritual-name":
					MsgParamRitualName = text;
					break;
				case "room-id":
					RoomId = text;
					break;
				case "subscriber":
					IsSubscriber = Helpers.ConvertToBool(text);
					break;
				case "system-msg":
					SystemMsg = text;
					SystemMsgParsed = text.Replace("\\s", " ").Replace("\\n", "");
					break;
				case "tmi-sent-ts":
					TmiSentTs = text;
					break;
				case "turbo":
					IsTurbo = Helpers.ConvertToBool(text);
					break;
				case "user-id":
					UserId = text;
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
				}
			}
		}
	}
}
