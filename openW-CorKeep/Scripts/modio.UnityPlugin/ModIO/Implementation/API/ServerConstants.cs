namespace ModIO.Implementation.API
{
	internal static class ServerConstants
	{
		public static class HeaderKeys
		{
			public const string LANGUAGE = "accept-language";

			public const string PLATFORM = "x-modio-platform";

			public const string PORTAL = "x-modio-portal";
		}

		public static string ConvertUserPortalToHeaderValue(UserPortal portal)
		{
			string text = null;
			return portal switch
			{
				UserPortal.Apple => "apple", 
				UserPortal.Discord => "discord", 
				UserPortal.EpicGamesStore => "egs", 
				UserPortal.GOG => "gog", 
				UserPortal.Google => "google", 
				UserPortal.itchio => "itchio", 
				UserPortal.Nintendo => "nintendo", 
				UserPortal.Oculus => "oculus", 
				UserPortal.PlayStationNetwork => "psn", 
				UserPortal.Steam => "steam", 
				UserPortal.XboxLive => "xboxlive", 
				_ => "none", 
			};
		}
	}
}
