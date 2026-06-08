using System;
using System.Collections.Generic;
using System.Drawing;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Extensions.NetCore;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class ChatMessage : TwitchLibMessage
	{
		protected readonly MessageEmoteCollection _emoteCollection;

		public List<KeyValuePair<string, string>> BadgeInfo { get; }

		public int Bits { get; }

		public double BitsInDollars { get; }

		public string Channel { get; }

		public CheerBadge CheerBadge { get; }

		public string CustomRewardId { get; }

		public string EmoteReplacedMessage { get; }

		public string Id { get; }

		public bool IsBroadcaster { get; }

		public bool IsHighlighted { get; internal set; }

		public bool IsMe { get; }

		public bool IsModerator { get; }

		public bool IsSkippingSubMode { get; internal set; }

		public bool IsSubscriber { get; }

		public bool IsVip { get; }

		public bool IsStaff { get; }

		public bool IsPartner { get; }

		public string Message { get; }

		public Noisy Noisy { get; }

		public string RoomId { get; }

		public int SubscribedMonthCount { get; }

		public string TmiSentTs { get; }

		public ChatReply ChatReply { get; }

		public ChatMessage(string botUsername, IrcMessage ircMessage, ref MessageEmoteCollection emoteCollection, bool replaceEmotes = false)
		{
			base.BotUsername = botUsername;
			base.RawIrcMessage = ircMessage.ToString();
			Message = ircMessage.Message;
			_emoteCollection = emoteCollection;
			base.Username = ircMessage.User;
			Channel = ircMessage.Channel;
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				switch (key)
				{
				case "badges":
					base.Badges = Helpers.ParseBadges(text);
					foreach (KeyValuePair<string, string> badge in base.Badges)
					{
						switch (badge.Key)
						{
						case "bits":
							CheerBadge = new CheerBadge(int.Parse(badge.Value));
							break;
						case "subscriber":
							if (SubscribedMonthCount == 0)
							{
								SubscribedMonthCount = int.Parse(badge.Value);
							}
							break;
						case "vip":
							IsVip = true;
							break;
						case "admin":
							IsStaff = true;
							break;
						case "staff":
							IsStaff = true;
							break;
						case "partner":
							IsPartner = true;
							break;
						}
					}
					break;
				case "badge-info":
				{
					BadgeInfo = Helpers.ParseBadges(text);
					KeyValuePair<string, string> keyValuePair = BadgeInfo.Find((KeyValuePair<string, string> b) => b.Key == "founder");
					if (!keyValuePair.Equals(default(KeyValuePair<string, string>)))
					{
						IsSubscriber = true;
						SubscribedMonthCount = int.Parse(keyValuePair.Value);
						break;
					}
					KeyValuePair<string, string> keyValuePair2 = BadgeInfo.Find((KeyValuePair<string, string> b) => b.Key == "subscriber");
					if (!keyValuePair2.Equals(default(KeyValuePair<string, string>)))
					{
						SubscribedMonthCount = int.Parse(keyValuePair2.Value);
					}
					break;
				}
				case "bits":
					Bits = int.Parse(text);
					BitsInDollars = ConvertBitsToUsd(Bits);
					break;
				case "color":
					base.ColorHex = text;
					if (!string.IsNullOrWhiteSpace(base.ColorHex))
					{
						base.Color = TwitchLib.Client.Models.Extensions.NetCore.ColorTranslator.FromHtml(base.ColorHex);
					}
					break;
				case "custom-reward-id":
					CustomRewardId = text;
					break;
				case "display-name":
					base.DisplayName = text;
					break;
				case "emotes":
					base.EmoteSet = new EmoteSet(text, Message);
					break;
				case "id":
					Id = text;
					break;
				case "msg-id":
					handleMsgId(text);
					break;
				case "mod":
					IsModerator = Helpers.ConvertToBool(text);
					break;
				case "noisy":
					Noisy = (Helpers.ConvertToBool(text) ? Noisy.True : Noisy.False);
					break;
				case "reply-parent-display-name":
					if (ChatReply == null)
					{
						ChatReply = new ChatReply();
					}
					ChatReply.ParentDisplayName = text;
					break;
				case "reply-parent-msg-body":
					if (ChatReply == null)
					{
						ChatReply = new ChatReply();
					}
					ChatReply.ParentMsgBody = text;
					break;
				case "reply-parent-msg-id":
					if (ChatReply == null)
					{
						ChatReply = new ChatReply();
					}
					ChatReply.ParentMsgId = text;
					break;
				case "reply-parent-user-id":
					if (ChatReply == null)
					{
						ChatReply = new ChatReply();
					}
					ChatReply.ParentUserId = text;
					break;
				case "reply-parent-user-login":
					if (ChatReply == null)
					{
						ChatReply = new ChatReply();
					}
					ChatReply.ParentUserLogin = text;
					break;
				case "room-id":
					RoomId = text;
					break;
				case "subscriber":
					IsSubscriber = IsSubscriber || Helpers.ConvertToBool(text);
					break;
				case "tmi-sent-ts":
					TmiSentTs = text;
					break;
				case "turbo":
					base.IsTurbo = Helpers.ConvertToBool(text);
					break;
				case "user-id":
					base.UserId = text;
					break;
				case "user-type":
					switch (text)
					{
					case "mod":
						base.UserType = UserType.Moderator;
						break;
					case "global_mod":
						base.UserType = UserType.GlobalModerator;
						break;
					case "admin":
						base.UserType = UserType.Admin;
						IsStaff = true;
						break;
					case "staff":
						base.UserType = UserType.Staff;
						IsStaff = true;
						break;
					default:
						base.UserType = UserType.Viewer;
						break;
					}
					break;
				}
			}
			if (Message.Length > 0 && (byte)Message[0] == 1 && (byte)Message[Message.Length - 1] == 1 && Message.StartsWith("\u0001ACTION ") && Message.EndsWith("\u0001"))
			{
				Message = Message.Trim('\u0001').Substring(7);
				IsMe = true;
			}
			if (base.EmoteSet != null && Message != null && base.EmoteSet.Emotes.Count > 0)
			{
				string[] array = base.EmoteSet.RawEmoteSetString.Split('/');
				string[] array2 = array;
				foreach (string text2 in array2)
				{
					int num2 = text2.IndexOf(':');
					int num3 = text2.IndexOf(',');
					if (num3 == -1)
					{
						num3 = text2.Length;
					}
					int num4 = text2.IndexOf('-');
					if (num2 > 0 && num4 > num2 && num3 > num4 && int.TryParse(text2.Substring(num2 + 1, num4 - num2 - 1), out var result) && int.TryParse(text2.Substring(num4 + 1, num3 - num4 - 1), out var result2) && result >= 0 && result < result2 && result2 < Message.Length)
					{
						string id = text2.Substring(0, num2);
						string text3 = Message.Substring(result, result2 - result + 1);
						_emoteCollection.Add(new MessageEmote(id, text3));
					}
				}
				if (replaceEmotes)
				{
					EmoteReplacedMessage = _emoteCollection.ReplaceEmotes(Message);
				}
			}
			if (base.EmoteSet == null)
			{
				base.EmoteSet = new EmoteSet((string)null, Message);
			}
			if (string.IsNullOrEmpty(base.DisplayName))
			{
				base.DisplayName = base.Username;
			}
			if (string.Equals(Channel, base.Username, StringComparison.InvariantCultureIgnoreCase))
			{
				base.UserType = UserType.Broadcaster;
				IsBroadcaster = true;
			}
			if (Channel.Split(':').Length == 3 && string.Equals(Channel.Split(':')[1], base.UserId, StringComparison.InvariantCultureIgnoreCase))
			{
				base.UserType = UserType.Broadcaster;
				IsBroadcaster = true;
			}
		}

		public ChatMessage(string botUsername, string userId, string userName, string displayName, string colorHex, Color color, EmoteSet emoteSet, string message, UserType userType, string channel, string id, bool isSubscriber, int subscribedMonthCount, string roomId, bool isTurbo, bool isModerator, bool isMe, bool isBroadcaster, bool isVip, bool isPartner, bool isStaff, Noisy noisy, string rawIrcMessage, string emoteReplacedMessage, List<KeyValuePair<string, string>> badges, CheerBadge cheerBadge, int bits, double bitsInDollars)
		{
			base.BotUsername = botUsername;
			base.UserId = userId;
			base.DisplayName = displayName;
			base.ColorHex = colorHex;
			base.Color = color;
			base.EmoteSet = emoteSet;
			Message = message;
			base.UserType = userType;
			Channel = channel;
			Id = id;
			IsSubscriber = isSubscriber;
			SubscribedMonthCount = subscribedMonthCount;
			RoomId = roomId;
			base.IsTurbo = isTurbo;
			IsModerator = isModerator;
			IsMe = isMe;
			IsBroadcaster = isBroadcaster;
			IsVip = isVip;
			IsPartner = isPartner;
			IsStaff = isStaff;
			Noisy = noisy;
			base.RawIrcMessage = rawIrcMessage;
			EmoteReplacedMessage = emoteReplacedMessage;
			base.Badges = badges;
			CheerBadge = cheerBadge;
			Bits = bits;
			BitsInDollars = bitsInDollars;
			base.Username = userName;
		}

		private void handleMsgId(string val)
		{
			if (!(val == "highlighted-message"))
			{
				if (val == "skip-subs-mode-message")
				{
					IsSkippingSubMode = true;
				}
			}
			else
			{
				IsHighlighted = true;
			}
		}

		private static double ConvertBitsToUsd(int bits)
		{
			if (bits < 1500)
			{
				return (double)bits / 100.0 * 1.4;
			}
			if (bits < 5000)
			{
				return (double)bits / 1500.0 * 19.95;
			}
			if (bits < 10000)
			{
				return (double)bits / 5000.0 * 64.4;
			}
			if (bits < 25000)
			{
				return (double)bits / 10000.0 * 126.0;
			}
			return (double)bits / 25000.0 * 308.0;
		}
	}
}
