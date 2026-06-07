namespace Motorways.UI
{
	public static class TenYearCelebrationMiniMetroStoreLinks
	{
		private const string SteamUtmSource = "game";

		private const string SteamUtmCampaign = "tenyearcelebration";

		private const string SteamUtmMedium = "button";

		private static readonly string SteamStoreBaseLink = "https://store.steampowered.com/app/287980/Mini_Metro";

		private static readonly string SteamStoreParameters = "?utm_source=game&utm_campaign=tenyearcelebration&utm_medium=button";

		public static readonly string SteamStoreLink = SteamStoreBaseLink + "/" + SteamStoreParameters;

		public const string ArcadeAppStoreLink = "https://apple.co/-MiniMetro";
	}
}
