using System;
using System.Text.RegularExpressions;

namespace TwitchLib.Client.Models
{
	public class ConnectionCredentials
	{
		public const string DefaultWebSocketUri = "wss://irc-ws.chat.twitch.tv:443";

		public string TwitchWebsocketURI { get; }

		public string TwitchOAuth { get; }

		public string TwitchUsername { get; }

		public Capabilities Capabilities { get; }

		public ConnectionCredentials(string twitchUsername, string twitchOAuth, string twitchWebsocketURI = "wss://irc-ws.chat.twitch.tv:443", bool disableUsernameCheck = false, Capabilities capabilities = null)
		{
			if (!disableUsernameCheck && !new Regex("^([a-zA-Z0-9][a-zA-Z0-9_]{3,25})$").Match(twitchUsername).Success)
			{
				throw new Exception("Twitch username does not appear to be valid. " + twitchUsername);
			}
			TwitchUsername = twitchUsername.ToLower();
			TwitchOAuth = twitchOAuth;
			if (!twitchOAuth.Contains(":"))
			{
				TwitchOAuth = "oauth:" + twitchOAuth.Replace("oauth", "");
			}
			TwitchWebsocketURI = twitchWebsocketURI;
			if (capabilities == null)
			{
				capabilities = new Capabilities();
			}
			Capabilities = capabilities;
		}
	}
}
