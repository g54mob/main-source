namespace ModIO.Implementation.API.Requests
{
	internal static class GetTerms
	{
		public static WebRequestConfig Request()
		{
			return new WebRequestConfig
			{
				Url = Settings.server.serverURL + "/authenticate/terms?",
				RequestMethodType = "GET"
			};
		}
	}
}
