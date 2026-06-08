using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Models.Common;
using TwitchLib.Client.Models.Extensions.NetCore;
using TwitchLib.Client.Models.Internal;

namespace TwitchLib.Client.Models
{
	public class WhisperMessage : TwitchLibMessage
	{
		public string MessageId { get; }

		public string ThreadId { get; }

		public string Message { get; }

		public WhisperMessage(List<KeyValuePair<string, string>> badges, string colorHex, Color color, string username, string displayName, EmoteSet emoteSet, string threadId, string messageId, string userId, bool isTurbo, string botUsername, string message, UserType userType)
		{
			base.Badges = badges;
			base.ColorHex = colorHex;
			base.Color = color;
			base.Username = username;
			base.DisplayName = displayName;
			base.EmoteSet = emoteSet;
			ThreadId = threadId;
			MessageId = messageId;
			base.UserId = userId;
			base.IsTurbo = isTurbo;
			base.BotUsername = botUsername;
			Message = message;
			base.UserType = userType;
		}

		public WhisperMessage(IrcMessage ircMessage, string botUsername)
		{
			base.Username = ircMessage.User;
			base.BotUsername = botUsername;
			base.RawIrcMessage = ircMessage.ToString();
			Message = ircMessage.Message;
			foreach (string key in ircMessage.Tags.Keys)
			{
				string text = ircMessage.Tags[key];
				switch (key)
				{
				case "badges":
				{
					base.Badges = new List<KeyValuePair<string, string>>();
					if (!text.Contains('/'))
					{
						break;
					}
					if (!text.Contains(","))
					{
						base.Badges.Add(new KeyValuePair<string, string>(text.Split('/')[0], text.Split('/')[1]));
						break;
					}
					string[] array = text.Split(',');
					foreach (string text2 in array)
					{
						base.Badges.Add(new KeyValuePair<string, string>(text2.Split('/')[0], text2.Split('/')[1]));
					}
					break;
				}
				case "color":
					base.ColorHex = text;
					if (!string.IsNullOrEmpty(base.ColorHex))
					{
						base.Color = TwitchLib.Client.Models.Extensions.NetCore.ColorTranslator.FromHtml(base.ColorHex);
					}
					break;
				case "display-name":
					base.DisplayName = text;
					break;
				case "emotes":
					base.EmoteSet = new EmoteSet(text, Message);
					break;
				case "message-id":
					MessageId = text;
					break;
				case "thread-id":
					ThreadId = text;
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
					case "global_mod":
						base.UserType = UserType.GlobalModerator;
						break;
					case "admin":
						base.UserType = UserType.Admin;
						break;
					case "staff":
						base.UserType = UserType.Staff;
						break;
					default:
						base.UserType = UserType.Viewer;
						break;
					}
					break;
				}
			}
			if (base.EmoteSet == null)
			{
				base.EmoteSet = new EmoteSet((string)null, Message);
			}
		}
	}
}
