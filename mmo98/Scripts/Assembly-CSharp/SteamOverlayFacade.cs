using Steamworks;

public class SteamOverlayFacade : SteamFacade
{
	private Callback<GameOverlayActivated_t> _gameOverlayActivatedCallback;

	public override void Initialize()
	{
		base.Initialize();
		_gameOverlayActivatedCallback = Callback<GameOverlayActivated_t>.Create(OnGameOverlayActivated);
	}

	public void Open(string dialog = "")
	{
		if (Initialized)
		{
			SteamFriends.ActivateGameOverlay(dialog);
		}
	}

	public void InviteFriends(CSteamID lobbyId)
	{
		if (Initialized)
		{
			SteamFriends.ActivateGameOverlayInviteDialog(lobbyId);
		}
	}

	public void RemotePlay(CSteamID lobbyId)
	{
		if (Initialized)
		{
			SteamFriends.ActivateGameOverlayRemotePlayTogetherInviteDialog(lobbyId);
		}
	}

	private void OnGameOverlayActivated(GameOverlayActivated_t overlay)
	{
		_ = Initialized;
	}

	public void OpenStore(uint appId)
	{
		if (Initialized)
		{
			SteamFriends.ActivateGameOverlayToStore(new AppId_t(appId), EOverlayToStoreFlag.k_EOverlayToStoreFlag_None);
		}
	}

	public void OpenWebpage(string url)
	{
		if (Initialized)
		{
			SteamFriends.ActivateGameOverlayToWebPage(url);
		}
	}
}
