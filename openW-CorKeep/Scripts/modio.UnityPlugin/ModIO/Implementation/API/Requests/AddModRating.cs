namespace ModIO.Implementation.API.Requests
{
	internal static class AddModRating
	{
		public static WebRequestConfig Request(ModId modId, ModRating rating)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}{5}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", modId.id, "/ratings");
			webRequestConfig.RequestMethodType = "POST";
			int num = (int)rating;
			webRequestConfig.AddField("rating", num.ToString());
			return webRequestConfig;
		}
	}
}
