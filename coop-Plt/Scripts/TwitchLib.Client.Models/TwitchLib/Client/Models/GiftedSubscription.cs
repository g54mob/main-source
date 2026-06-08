using System;
using System.Collections.Generic;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class GiftedSubscription
	{
		private const string AnonymousGifterUserId = "274598607";

		public List<KeyValuePair<string, string>> Badges { get; }

		public List<KeyValuePair<string, string>> BadgeInfo { get; }

		public string Color { get; }

		public string DisplayName { get; }

		public string Emotes { get; }

		public string Id { get; }

		public bool IsModerator { get; }

		public bool IsSubscriber { get; }

		public bool IsTurbo { get; }

		public bool IsAnonymous { get; }

		public string Login { get; }

		public string MsgId { get; }

		public string MsgParamMonths { get; }

		public string MsgParamRecipientDisplayName { get; }

		public string MsgParamRecipientId { get; }

		public string MsgParamRecipientUserName { get; }

		public string MsgParamSubPlanName { get; }

		public SubscriptionPlan MsgParamSubPlan { get; }

		public string RoomId { get; }

		public string SystemMsg { get; }

		public string SystemMsgParsed { get; }

		public string TmiSentTs { get; }

		public string UserId { get; }

		public UserType UserType { get; }

		public string MsgParamMultiMonthGiftDuration { get; }

		public GiftedSubscription(IrcMessage ircMessage)
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
				case "msg-param-months":
					MsgParamMonths = text;
					break;
				case "msg-param-recipient-display-name":
					MsgParamRecipientDisplayName = text;
					break;
				case "msg-param-recipient-id":
					MsgParamRecipientId = text;
					break;
				case "msg-param-recipient-user-name":
					MsgParamRecipientUserName = text;
					break;
				case "msg-param-sub-plan-name":
					MsgParamSubPlanName = text;
					break;
				case "msg-param-sub-plan":
					switch (text)
					{
					case "prime":
						MsgParamSubPlan = SubscriptionPlan.Prime;
						break;
					case "1000":
						MsgParamSubPlan = SubscriptionPlan.Tier1;
						break;
					case "2000":
						MsgParamSubPlan = SubscriptionPlan.Tier2;
						break;
					case "3000":
						MsgParamSubPlan = SubscriptionPlan.Tier3;
						break;
					default:
						throw new ArgumentOutOfRangeException("ToLower");
					}
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
					if (UserId == "274598607")
					{
						IsAnonymous = true;
					}
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
				case "msg-param-gift-months":
					MsgParamMultiMonthGiftDuration = text;
					break;
				}
			}
		}

		public GiftedSubscription(List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string color, string displayName, string emotes, string id, string login, bool isModerator, string msgId, string msgParamMonths, string msgParamRecipientDisplayName, string msgParamRecipientId, string msgParamRecipientUserName, string msgParamSubPlanName, string msgMultiMonthDuration, SubscriptionPlan msgParamSubPlan, string roomId, bool isSubscriber, string systemMsg, string systemMsgParsed, string tmiSentTs, bool isTurbo, UserType userType, string userId)
		{
			Badges = badges;
			BadgeInfo = badgeInfo;
			Color = color;
			DisplayName = displayName;
			Emotes = emotes;
			Id = id;
			Login = login;
			IsModerator = isModerator;
			MsgId = msgId;
			MsgParamMonths = msgParamMonths;
			MsgParamRecipientDisplayName = msgParamRecipientDisplayName;
			MsgParamRecipientId = msgParamRecipientId;
			MsgParamRecipientUserName = msgParamRecipientUserName;
			MsgParamSubPlanName = msgParamSubPlanName;
			MsgParamSubPlan = msgParamSubPlan;
			MsgParamMultiMonthGiftDuration = msgMultiMonthDuration;
			RoomId = roomId;
			IsSubscriber = isSubscriber;
			SystemMsg = systemMsg;
			SystemMsgParsed = systemMsgParsed;
			TmiSentTs = tmiSentTs;
			IsTurbo = isTurbo;
			UserType = userType;
			UserId = userId;
		}
	}
}
