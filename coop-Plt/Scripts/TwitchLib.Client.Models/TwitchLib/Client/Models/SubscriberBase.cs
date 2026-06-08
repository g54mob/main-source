using System;
using System.Collections.Generic;
using System.Drawing;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Extensions.NetCore;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class SubscriberBase
	{
		protected readonly int monthsInternal;

		public List<KeyValuePair<string, string>> Badges { get; }

		public List<KeyValuePair<string, string>> BadgeInfo { get; }

		public string ColorHex { get; }

		public Color Color { get; }

		public string DisplayName { get; }

		public string EmoteSet { get; }

		public string Id { get; }

		public bool IsModerator { get; }

		public bool IsPartner { get; }

		public bool IsSubscriber { get; }

		public bool IsTurbo { get; }

		public string Login { get; }

		public string MsgId { get; }

		public string MsgParamCumulativeMonths { get; }

		public bool MsgParamShouldShareStreak { get; }

		public string MsgParamStreakMonths { get; }

		public string RawIrc { get; }

		public string ResubMessage { get; }

		public string RoomId { get; }

		public SubscriptionPlan SubscriptionPlan { get; } = SubscriptionPlan.NotSet;

		public string SubscriptionPlanName { get; }

		public string SystemMessage { get; }

		public string SystemMessageParsed { get; }

		public string TmiSentTs { get; }

		public string UserId { get; }

		public UserType UserType { get; }

		public string Channel { get; }

		protected SubscriberBase(IrcMessage ircMessage)
		{
			RawIrc = ircMessage.ToString();
			ResubMessage = ircMessage.Message;
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				switch (key)
				{
				case "badges":
					Badges = Helpers.ParseBadges(text);
					foreach (KeyValuePair<string, string> badge in Badges)
					{
						if (badge.Key == "partner")
						{
							IsPartner = true;
						}
					}
					break;
				case "badge-info":
					BadgeInfo = Helpers.ParseBadges(text);
					break;
				case "color":
					ColorHex = text;
					if (!string.IsNullOrEmpty(ColorHex))
					{
						Color = TwitchLib.Client.Models.Extensions.NetCore.ColorTranslator.FromHtml(ColorHex);
					}
					break;
				case "display-name":
					DisplayName = text;
					break;
				case "emotes":
					EmoteSet = text;
					break;
				case "id":
					Id = text;
					break;
				case "login":
					Login = text;
					break;
				case "mod":
					IsModerator = ConvertToBool(text);
					break;
				case "msg-id":
					MsgId = text;
					break;
				case "msg-param-cumulative-months":
					MsgParamCumulativeMonths = text;
					break;
				case "msg-param-streak-months":
					MsgParamStreakMonths = text;
					break;
				case "msg-param-should-share-streak":
					MsgParamShouldShareStreak = Helpers.ConvertToBool(text);
					break;
				case "msg-param-sub-plan":
					switch (text.ToLower())
					{
					case "prime":
						SubscriptionPlan = SubscriptionPlan.Prime;
						break;
					case "1000":
						SubscriptionPlan = SubscriptionPlan.Tier1;
						break;
					case "2000":
						SubscriptionPlan = SubscriptionPlan.Tier2;
						break;
					case "3000":
						SubscriptionPlan = SubscriptionPlan.Tier3;
						break;
					default:
						throw new ArgumentOutOfRangeException("ToLower");
					}
					break;
				case "msg-param-sub-plan-name":
					SubscriptionPlanName = text.Replace("\\s", " ");
					break;
				case "room-id":
					RoomId = text;
					break;
				case "subscriber":
					IsSubscriber = ConvertToBool(text);
					break;
				case "system-msg":
					SystemMessage = text;
					SystemMessageParsed = text.Replace("\\s", " ");
					break;
				case "tmi-sent-ts":
					TmiSentTs = text;
					break;
				case "turbo":
					IsTurbo = ConvertToBool(text);
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

		internal SubscriberBase(List<KeyValuePair<string, string>> badges, List<KeyValuePair<string, string>> badgeInfo, string colorHex, Color color, string displayName, string emoteSet, string id, string login, string systemMessage, string msgId, string msgParamCumulativeMonths, string msgParamStreakMonths, bool msgParamShouldShareStreak, string systemMessageParsed, string resubMessage, SubscriptionPlan subscriptionPlan, string subscriptionPlanName, string roomId, string userId, bool isModerator, bool isTurbo, bool isSubscriber, bool isPartner, string tmiSentTs, UserType userType, string rawIrc, string channel, int months)
		{
			Badges = badges;
			BadgeInfo = badgeInfo;
			ColorHex = colorHex;
			Color = color;
			DisplayName = displayName;
			EmoteSet = emoteSet;
			Id = id;
			Login = login;
			MsgId = msgId;
			MsgParamCumulativeMonths = msgParamCumulativeMonths;
			MsgParamStreakMonths = msgParamStreakMonths;
			MsgParamShouldShareStreak = msgParamShouldShareStreak;
			SystemMessage = systemMessage;
			SystemMessageParsed = systemMessageParsed;
			ResubMessage = resubMessage;
			SubscriptionPlan = subscriptionPlan;
			SubscriptionPlanName = subscriptionPlanName;
			RoomId = roomId;
			UserId = UserId;
			IsModerator = isModerator;
			IsTurbo = isTurbo;
			IsSubscriber = isSubscriber;
			IsPartner = isPartner;
			TmiSentTs = tmiSentTs;
			UserType = userType;
			RawIrc = rawIrc;
			monthsInternal = months;
			UserId = userId;
			Channel = channel;
		}

		private static bool ConvertToBool(string data)
		{
			return data == "1";
		}

		public override string ToString()
		{
			return $"Badges: {Badges.Count}, color hex: {ColorHex}, display name: {DisplayName}, emote set: {EmoteSet}, login: {Login}, system message: {SystemMessage}, msgId: {MsgId}, msgParamCumulativeMonths: {MsgParamCumulativeMonths}" + $"msgParamStreakMonths: {MsgParamStreakMonths}, msgParamShouldShareStreak: {MsgParamShouldShareStreak}, resub message: {ResubMessage}, months: {monthsInternal}, room id: {RoomId}, user id: {UserId}, mod: {IsModerator}, turbo: {IsTurbo}, sub: {IsSubscriber}, user type: {UserType}, raw irc: {RawIrc}";
		}
	}
}
