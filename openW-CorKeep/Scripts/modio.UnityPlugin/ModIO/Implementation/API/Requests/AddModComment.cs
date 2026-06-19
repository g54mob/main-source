namespace ModIO.Implementation.API.Requests
{
	internal static class AddModComment
	{
		public static WebRequestConfig Request(ModId modId, CommentDetails commentDetails)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}/comments?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", (long)modId);
			webRequestConfig.RequestMethodType = "POST";
			webRequestConfig.AddField("content", commentDetails.content);
			webRequestConfig.AddField("reply_id", commentDetails.replyId);
			return webRequestConfig;
		}
	}
}
