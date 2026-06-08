using System.Collections.Generic;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class RaidNotification
	{
		public List<KeyValuePair<string, string>> Badges { get; }

		public List<KeyValuePair<string, string>> BadgeInfo { get; }

		public string Color { get; }

		public string DisplayName { get; }

		public string Emotes { get; }

		public string Id { get; }

		public string Login { get; }

		public bool Moderator { get; }

		public string MsgId { get; }

		public string MsgParamDisplayName { get; }

		public string MsgParamLogin { get; }

		public string MsgParamViewerCount { get; }

		public string RoomId { get; }

		public bool Subscriber { get; }

		public string SystemMsg { get; }

		public string SystemMsgParsed { get; }

		public string TmiSentTs { get; }

		public bool Turbo { get; }

		public string UserId { get; }

		public UserType UserType { get; }

		public RaidNotification(IrcMessage ircMessage)
		{
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
				case "login":
					Login = text;
					break;
				case "mod":
					Moderator = Helpers.ConvertToBool(text);
					break;
				case "msg-id":
					MsgId = text;
					break;
				case "msg-param-displayName":
					MsgParamDisplayName = text;
					break;
				case "msg-param-login":
					MsgParamLogin = text;
					break;
				case "msg-param-viewerCount":
					MsgParamViewerCount = text;
					break;
				case "room-id":
					RoomId = text;
					break;
				case "subscriber":
					Subscriber = Helpers.ConvertToBool(text);
					break;
				case "system-msg":
					SystemMsg = text;
					SystemMsgParsed = text.Replace("\\s", " ").Replace("\\n", "");
					break;
				case "tmi-sent-ts":
					TmiSentTs = text;
					break;
				case "turbo":
					Turbo = Helpers.ConvertToBool(text);
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

		public RaidNotification(List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string color, string displayName, string emotes, string id, string login, bool moderator, string msgId, string msgParamDisplayName, string msgParamLogin, string msgParamViewerCount, string roomId, bool subscriber, string systemMsg, string systemMsgParsed, string tmiSentTs, bool turbo, UserType userType, string userId)
		{
			Badges = badges;
			BadgeInfo = badgeInfo;
			Color = color;
			DisplayName = displayName;
			Emotes = emotes;
			Id = id;
			Login = login;
			Moderator = moderator;
			MsgId = msgId;
			MsgParamDisplayName = msgParamDisplayName;
			MsgParamLogin = msgParamLogin;
			MsgParamViewerCount = msgParamViewerCount;
			RoomId = roomId;
			Subscriber = subscriber;
			SystemMsg = systemMsg;
			SystemMsgParsed = systemMsgParsed;
			TmiSentTs = tmiSentTs;
			Turbo = turbo;
			UserType = userType;
			UserId = userId;
		}
	}
}
