namespace ModIO.Implementation.API.Requests
{
	internal static class UpdateModComment
	{
		public static WebRequestConfig Request(ModId modId, string content, long commentId)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}/comments/{5}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", (long)modId, commentId);
			webRequestConfig.RequestMethodType = "PUT";
			webRequestConfig.AddField("content", content);
			return webRequestConfig;
		}
	}
}
