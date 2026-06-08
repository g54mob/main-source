using System.Collections.Generic;
using System.Drawing;
using TwitchLib.Client.Enums;

namespace TwitchLib.Client.Models
{
	public abstract class TwitchLibMessage
	{
		public List<KeyValuePair<string, string>> Badges { get; protected set; }

		public string BotUsername { get; protected set; }

		public Color Color { get; protected set; }

		public string ColorHex { get; protected set; }

		public string DisplayName { get; protected set; }

		public EmoteSet EmoteSet { get; protected set; }

		public bool IsTurbo { get; protected set; }

		public string UserId { get; protected set; }

		public string Username { get; protected set; }

		public UserType UserType { get; protected set; }

		public string RawIrcMessage { get; protected set; }
	}
}
