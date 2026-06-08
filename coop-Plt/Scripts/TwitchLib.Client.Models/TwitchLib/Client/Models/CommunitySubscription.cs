using System;
using System.Collections.Generic;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class CommunitySubscription
	{
		private const string AnonymousGifterUserId = "274598607";

		public List<KeyValuePair<string, string>> Badges;

		public List<KeyValuePair<string, string>> BadgeInfo;

		public string Color;

		public string DisplayName;

		public string Emotes;

		public string Id;

		public string Login;

		public bool IsModerator;

		public bool IsAnonymous;

		public string MsgId;

		public int MsgParamMassGiftCount;

		public int MsgParamSenderCount;

		public SubscriptionPlan MsgParamSubPlan;

		public string RoomId;

		public bool IsSubscriber;

		public string SystemMsg;

		public string SystemMsgParsed;

		public string TmiSentTs;

		public bool IsTurbo;

		public string UserId;

		public UserType UserType;

		public string MsgParamMultiMonthGiftDuration;

		public CommunitySubscription(IrcMessage ircMessage)
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
				case "msg-param-mass-gift-count":
					MsgParamMassGiftCount = int.Parse(text);
					break;
				case "msg-param-sender-count":
					MsgParamSenderCount = int.Parse(text);
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
	}
}
