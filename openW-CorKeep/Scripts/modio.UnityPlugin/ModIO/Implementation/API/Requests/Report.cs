namespace ModIO.Implementation.API.Requests
{
	internal static class Report
	{
		public static WebRequestConfig Request(ModIO.Report report)
		{
			WebRequestConfig webRequestConfig = new WebRequestConfig();
			webRequestConfig.Url = Settings.server.serverURL + "/report?";
			webRequestConfig.RequestMethodType = "POST";
			webRequestConfig.AddField("id", report.id.ToString());
			webRequestConfig.AddField("resource", report.resourceType.ToString().ToLower());
			webRequestConfig.AddField("type", ((int)report.type.Value).ToString());
			webRequestConfig.AddField("name", report.user);
			webRequestConfig.AddField("contact", report.contactEmail);
			webRequestConfig.AddField("summary", report.summary);
			return webRequestConfig;
		}
	}
}
