namespace ModIO.Implementation.API.Requests
{
	internal static class UserUnmute
	{
		public static WebRequestConfig Request(long userId)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}?", Settings.server.serverURL, "/users/", userId, "/mute");
			webRequestConfig.RequestMethodType = "DELETE";
			return webRequestConfig;
		}
	}
}
