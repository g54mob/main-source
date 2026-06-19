namespace ModIO.Implementation.API.Requests
{
	internal static class DeleteModTags
	{
		public static WebRequestConfig Request(ModId modId, string[] tags)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}/tags?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", (long)modId);
			webRequestConfig.RequestMethodType = "DELETE";
			WebRequestConfig webRequestConfig2 = webRequestConfig;
			foreach (string text in tags)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					webRequestConfig2.AddField("tags[]", text);
				}
			}
			return webRequestConfig2;
		}
	}
}
