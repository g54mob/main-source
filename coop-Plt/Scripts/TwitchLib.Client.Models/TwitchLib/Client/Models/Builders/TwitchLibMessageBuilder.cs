using System.Collections.Generic;
using System.Drawing;
using TwitchLib.Client.Enums;

namespace TwitchLib.Client.Models.Builders
{
	public sealed class TwitchLibMessageBuilder : TwitchLibMessage, IBuilder<TwitchLibMessage>
	{
		private TwitchLibMessageBuilder()
		{
		}

		public TwitchLibMessageBuilder WithBadges(List<KeyValuePair<string, string>> badges)
		{
			base.Badges = badges;
			return this;
		}

		public TwitchLibMessageBuilder WithColorHex(string colorHex)
		{
			base.ColorHex = colorHex;
			return this;
		}

		public TwitchLibMessageBuilder WithColorHex(Color color)
		{
			base.Color = color;
			return this;
		}

		public TwitchLibMessageBuilder WithUsername(string username)
		{
			base.Username = username;
			return this;
		}

		public TwitchLibMessageBuilder WithDisplayName(string displayName)
		{
			base.DisplayName = displayName;
			return this;
		}

		public TwitchLibMessageBuilder WithEmoteSet(EmoteSet emoteSet)
		{
			base.EmoteSet = emoteSet;
			return this;
		}

		public TwitchLibMessageBuilder WithUserId(string userId)
		{
			base.UserId = userId;
			return this;
		}

		public TwitchLibMessageBuilder WithIsTurbo(bool isTurbo)
		{
			base.IsTurbo = isTurbo;
			return this;
		}

		public TwitchLibMessageBuilder WithBotUserName(string botUserName)
		{
			base.BotUsername = botUserName;
			return this;
		}

		public TwitchLibMessageBuilder WithUserType(UserType userType)
		{
			base.UserType = userType;
			return this;
		}

		public static TwitchLibMessageBuilder Create()
		{
			return new TwitchLibMessageBuilder();
		}

		public TwitchLibMessage Build()
		{
			return this;
		}
	}
}
