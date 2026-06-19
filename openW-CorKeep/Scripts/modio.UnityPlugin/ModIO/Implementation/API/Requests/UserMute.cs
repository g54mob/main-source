namespace ModIO.Implementation.API.Requests
{
	internal static class UserMute
	{
		public static WebRequestConfig Request(long userId)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}?", Settings.server.serverURL, "/users/", userId, "/mute");
			webRequestConfig.RequestMethodType = "POST";
			return webRequestConfig;
		}
	}
}
