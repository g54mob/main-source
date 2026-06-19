namespace ModIO
{
	public static class AuthenticationServiceProviderExtensions
	{
		public static string GetProviderName(this AuthenticationServiceProvider provider)
		{
			string result = "";
			switch (provider)
			{
			case AuthenticationServiceProvider.Steam:
				result = "steamauth";
				break;
			case AuthenticationServiceProvider.Epic:
				result = "epicgamesauth";
				break;
			case AuthenticationServiceProvider.GOG:
				result = "galaxyauth";
				break;
			case AuthenticationServiceProvider.Itchio:
				result = "itchioauth";
				break;
			case AuthenticationServiceProvider.Oculus:
				result = "oculusauth";
				break;
			case AuthenticationServiceProvider.Xbox:
				result = "xboxauth";
				break;
			case AuthenticationServiceProvider.Switch:
				result = "switchauth";
				break;
			case AuthenticationServiceProvider.Discord:
				result = "discordauth";
				break;
			case AuthenticationServiceProvider.Google:
				result = "googleauth";
				break;
			case AuthenticationServiceProvider.PlayStation:
				result = "psnauth";
				break;
			}
			return result;
		}

		public static string GetTokenFieldName(this AuthenticationServiceProvider provider)
		{
			string result = "";
			switch (provider)
			{
			case AuthenticationServiceProvider.Steam:
				result = "appdata";
				break;
			case AuthenticationServiceProvider.Epic:
				result = "access_token";
				break;
			case AuthenticationServiceProvider.GOG:
				result = "appdata";
				break;
			case AuthenticationServiceProvider.Itchio:
				result = "itchio_token";
				break;
			case AuthenticationServiceProvider.Oculus:
				result = "access_token";
				break;
			case AuthenticationServiceProvider.Xbox:
				result = "xbox_token";
				break;
			case AuthenticationServiceProvider.Switch:
				result = "id_token";
				break;
			case AuthenticationServiceProvider.Discord:
				result = "discord_token";
				break;
			case AuthenticationServiceProvider.Google:
				result = "id_token";
				break;
			case AuthenticationServiceProvider.PlayStation:
				result = "auth_code";
				break;
			}
			return result;
		}
	}
}
