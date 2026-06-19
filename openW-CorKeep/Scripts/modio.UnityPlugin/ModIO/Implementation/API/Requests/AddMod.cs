namespace ModIO.Implementation.API.Requests
{
	internal static class AddMod
	{
		public static WebRequestConfig Request(ModProfileDetails details)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods");
			webRequestConfig.RequestMethodType = "POST";
			webRequestConfig.ShouldRequestTimeout = false;
			WebRequestConfig webRequestConfig2 = webRequestConfig;
			webRequestConfig2.AddField("visible", (details.visible == false) ? "0" : "1");
			webRequestConfig2.AddField("name", details.name);
			webRequestConfig2.AddField("summary", details.summary);
			webRequestConfig2.AddField("description", details.description);
			webRequestConfig2.AddField("name_id", details.name_id);
			webRequestConfig2.AddField("homepage_url", details.homepage_url);
			webRequestConfig2.AddField("stock", details.maxSubscribers.ToString());
			webRequestConfig2.AddField("metadata_blob", details.metadata);
			if (details.contentWarning.HasValue)
			{
				webRequestConfig2.AddField("maturity_option", ((int)details.contentWarning.Value).ToString());
			}
			if (details.communityOptions.HasValue)
			{
				webRequestConfig2.AddField("community_options", ((int)details.communityOptions.Value).ToString());
			}
			if (details.tags != null)
			{
				for (int i = 0; i < details.tags.Length; i++)
				{
					webRequestConfig2.AddField($"tags[{i}]", details.tags[i]);
				}
			}
			if (details.logo != null)
			{
				webRequestConfig2.AddField("logo", "logo.png", details.GetLogo());
			}
			return webRequestConfig2;
		}
	}
}
