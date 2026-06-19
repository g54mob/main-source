namespace ModIO.Implementation.API.Requests
{
	internal static class AuthenticateViaEmail
	{
		public static WebRequestConfig Request(string emailaddress)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = Settings.server.serverURL + "/oauth/emailrequest?";
			webRequestConfig.RequestMethodType = "POST";
			webRequestConfig.DontUseAuthToken = true;
			webRequestConfig.AddField("email", emailaddress);
			return webRequestConfig;
		}
	}
}
