using System;
using Cysharp.Text;
using Lachee.Discord;

public class DiscordRichPresence : IRichPresence
{
	private const string MainMenuText = "Idling at the main menu";

	private const string InGameText = "Working for {0}";

	public void MainMenu()
	{
		if (DiscordManager.current.isInitialized)
		{
			Presence currentPresence = DiscordManager.current.CurrentPresence;
			currentPresence.state = "Idling at the main menu";
			currentPresence.startTime = new Timestamp(0L);
			DiscordManager.current.SetPresence(currentPresence);
		}
	}

	public void Game()
	{
		if (DiscordManager.current.isInitialized)
		{
			Presence currentPresence = DiscordManager.current.CurrentPresence;
			currentPresence.state = ZString.Format("Working for {0}", Database.State.Studio.Name);
			currentPresence.startTime = new Timestamp(DateTime.Now);
			DiscordManager.current.SetPresence(currentPresence);
		}
	}

	public static bool TryGetUsername(out string username)
	{
		username = null;
		if (!DiscordManager.current.isInitialized)
		{
			return false;
		}
		username = DiscordManager.current.CurrentUser.displayName;
		if (!string.IsNullOrEmpty(username))
		{
			return true;
		}
		username = DiscordManager.current.CurrentUser.username;
		return !string.IsNullOrEmpty(username);
	}
}
