public class SteamRichPresence : IRichPresence
{
	private const string DisplayKey = "steam_display";

	private const string MainMenuKey = "#Status_AtMainMenu";

	private const string GameKey = "#Status_InGame";

	private const string StudioKey = "STUDIO";

	public void MainMenu()
	{
		SteamManager.Friends.SetRichPresence("steam_display", "#Status_AtMainMenu");
	}

	public void Game()
	{
		SteamManager.Friends.SetRichPresence("STUDIO", Database.State.Studio.Name.Value);
		SteamManager.Friends.SetRichPresence("steam_display", "#Status_InGame");
	}

	public static bool TryGetUsername(out string username)
	{
		username = SteamManager.User.Name();
		return !string.IsNullOrEmpty(username);
	}
}
