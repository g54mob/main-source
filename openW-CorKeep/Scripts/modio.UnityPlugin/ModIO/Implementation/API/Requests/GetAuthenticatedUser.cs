namespace ModIO.Implementation.API.Requests
{
	internal static class GetAuthenticatedUser
	{
		public static WebRequestConfig Request()
		{
			return new WebRequestConfig
			{
				Url = Settings.server.serverURL + "/me?",
				RequestMethodType = "GET"
			};
		}
	}
}
