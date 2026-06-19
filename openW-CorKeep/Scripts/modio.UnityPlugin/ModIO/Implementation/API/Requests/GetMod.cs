namespace ModIO.Implementation.API.Requests
{
	internal static class GetMod
	{
		public static WebRequestConfig Request(long modId)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", modId);
			webRequestConfig.RequestMethodType = "GET";
			return webRequestConfig;
		}
	}
}
