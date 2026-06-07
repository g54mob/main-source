using System;
using MessagePipe;
using R3;
using UnityEngine;

public class RichPresence : MonoBehaviour
{
	private SteamRichPresence _steam;

	private DiscordRichPresence _discord;

	private void Start()
	{
		_steam = new SteamRichPresence();
		_discord = new DiscordRichPresence();
		EventHub.Persistent.Subscribe(OnSceneLoaded, Array.Empty<MessageHandlerFilter<SceneLoaded>>()).AddTo(this);
	}

	private void OnSceneLoaded(SceneLoaded ctx)
	{
		if (ctx.IsGame)
		{
			LoadedGame();
		}
		else
		{
			LoadedMainMenu();
		}
	}

	private void LoadedMainMenu()
	{
		_steam.MainMenu();
		_discord.MainMenu();
	}

	private void LoadedGame()
	{
		_steam.Game();
		_discord.Game();
	}

	public static bool TryGetUsername(out string username)
	{
		if (!SteamRichPresence.TryGetUsername(out username))
		{
			return DiscordRichPresence.TryGetUsername(out username);
		}
		return true;
	}
}
