namespace ModIO.Implementation.API.Requests
{
	internal static class EditMod
	{
		public static WebRequestConfig RequestPOST(ModProfileDetails details)
		{
			return InternalRequest(details, "POST");
		}

		public static WebRequestConfig RequestPUT(ModProfileDetails details)
		{
			return InternalRequest(details, "PUT");
		}

		public static WebRequestConfig InternalRequest(ModProfileDetails details, string requestType)
		{
			long num = (details.modId.HasValue ? details.modId.Value.id : 0);
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = string.Format("{0}{1}{2}{3}{4}?", Settings.server.serverURL, "/games/", Settings.server.gameId, "/mods/", num);
			webRequestConfig.RequestMethodType = requestType;
			WebRequestConfig webRequestConfig2 = webRequestConfig;
			webRequestConfig2.AddField("visible", (details.visible == false) ? "0" : "1");
			webRequestConfig2.AddField("name", details.name);
			webRequestConfig2.AddField("summary", details.summary);
			webRequestConfig2.AddField("description", details.description);
			webRequestConfig2.AddField("name_id", details.name_id);
			webRequestConfig2.AddField("homepage_url", details.homepage_url);
			webRequestConfig2.AddField("stock", details.maxSubscribers.ToString());
			if (details.contentWarning.HasValue)
			{
				webRequestConfig2.AddField("maturity_option", ((int)details.contentWarning.Value).ToString());
			}
			if (details.communityOptions.HasValue)
			{
				webRequestConfig2.AddField("community_options", ((int)details.communityOptions.Value).ToString());
			}
			webRequestConfig2.AddField("metadata_blob", details.metadata);
			if (details.logo != null)
			{
				webRequestConfig2.AddField("logo", "logo.png", details.GetLogo());
			}
			return webRequestConfig2;
		}
	}
}
