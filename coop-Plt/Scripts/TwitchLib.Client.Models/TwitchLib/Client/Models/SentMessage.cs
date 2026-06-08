using System.Collections.Generic;
using TwitchLib.Client.Enums;

namespace TwitchLib.Client.Models
{
	public class SentMessage
	{
		public List<KeyValuePair<string, string>> Badges { get; }

		public string Channel { get; }

		public string ColorHex { get; }

		public string DisplayName { get; }

		public string EmoteSet { get; }

		public bool IsModerator { get; }

		public bool IsSubscriber { get; }

		public string Message { get; }

		public UserType UserType { get; }

		public SentMessage(UserState state, string message)
		{
			Badges = state.Badges;
			Channel = state.Channel;
			ColorHex = state.ColorHex;
			DisplayName = state.DisplayName;
			EmoteSet = state.EmoteSet;
			IsModerator = state.IsModerator;
			IsSubscriber = state.IsSubscriber;
			UserType = state.UserType;
			Message = message;
		}

		public SentMessage(List<KeyValuePair<string, string>> badges, string channel, string colorHex, string displayName, string emoteSet, bool isModerator, bool isSubscriber, UserType userType, string message)
		{
			Badges = badges;
			Channel = channel;
			ColorHex = colorHex;
			DisplayName = displayName;
			EmoteSet = emoteSet;
			IsModerator = isModerator;
			IsSubscriber = isSubscriber;
			UserType = userType;
			Message = message;
		}
	}
}
