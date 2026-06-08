namespace TwitchLib.Client.Models.Builders
{
	public sealed class ConnectionCredentialsBuilder : IBuilder<ConnectionCredentials>
	{
		private string _twitchUsername;

		private string _twitchOAuth;

		private string _twitchWebsocketURI = "wss://irc-ws.chat.twitch.tv:443";

		private bool _disableUsernameCheck;

		private ConnectionCredentialsBuilder()
		{
		}

		public ConnectionCredentialsBuilder WithTwitchUsername(string twitchUsername)
		{
			_twitchUsername = twitchUsername;
			return this;
		}

		public ConnectionCredentialsBuilder WithTwitchOAuth(string twitchOAuth)
		{
			_twitchOAuth = twitchOAuth;
			return this;
		}

		public ConnectionCredentialsBuilder WithTwitchWebSocketUri(string twitchWebSocketUri)
		{
			_twitchWebsocketURI = twitchWebSocketUri;
			return this;
		}

		public ConnectionCredentialsBuilder WithDisableUsernameCheck(bool disableUsernameCheck)
		{
			_disableUsernameCheck = disableUsernameCheck;
			return this;
		}

		public static ConnectionCredentialsBuilder Create()
		{
			return new ConnectionCredentialsBuilder();
		}

		public ConnectionCredentials Build()
		{
			return new ConnectionCredentials(_twitchUsername, _twitchOAuth, _twitchWebsocketURI, _disableUsernameCheck);
		}
	}
}
