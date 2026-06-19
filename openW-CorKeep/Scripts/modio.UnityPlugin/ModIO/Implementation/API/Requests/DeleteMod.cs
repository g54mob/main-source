namespace ModIO.Implementation.API.Requests
{
	internal static class DeleteMod
	{
		public static WebRequestConfig Request(ModId modId)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", modId.id.ToString());
			webRequestConfig.RequestMethodType = "DELETE";
			return webRequestConfig;
		}
	}
}
