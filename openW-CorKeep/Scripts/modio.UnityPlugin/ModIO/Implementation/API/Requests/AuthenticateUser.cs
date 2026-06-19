namespace ModIO.Implementation.API.Requests
{
	internal static class AuthenticateUser
	{
		public static WebRequestConfig InternalRequest(string securityCode)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = Settings.server.serverURL + "/oauth/emailexchange?";
			webRequestConfig.RequestMethodType = "POST";
			webRequestConfig.DontUseAuthToken = true;
			webRequestConfig.AddField("api_key", Settings.server.gameKey);
			webRequestConfig.AddField("security_code", securityCode);
			return webRequestConfig;
		}

		public static WebRequestConfig ExternalRequest(AuthenticationServiceProvider serviceProvider, string data, TermsHash? hash, string emailAddress, string nonce, OculusDevice? device, string userId, PlayStationEnvironment environment)
		{
			string tokenFieldName = serviceProvider.GetTokenFieldName();
			string providerName = serviceProvider.GetProviderName();
			WebRequestConfig webRequestConfig = new WebRequestConfig
			{
				Url = Settings.server.serverURL + "/external/" + providerName + "?",
				RequestMethodType = "POST",
				DontUseAuthToken = true
			};
			bool flag = ResponseCache.termsHash.md5hash == hash?.md5hash;
			webRequestConfig.AddField(tokenFieldName, data);
			webRequestConfig.AddField("terms_agreed", flag.ToString());
			webRequestConfig.AddField("email", emailAddress);
			if (serviceProvider == AuthenticationServiceProvider.Oculus)
			{
				webRequestConfig.AddField("nonce", nonce);
				webRequestConfig.AddField("user_id", userId);
				webRequestConfig.AddField("device", (device == OculusDevice.Quest) ? "quest" : "rift");
			}
			if (serviceProvider == AuthenticationServiceProvider.PlayStation)
			{
				int num = (int)environment;
				webRequestConfig.AddField("env", num.ToString());
			}
			return webRequestConfig;
		}
	}
}
