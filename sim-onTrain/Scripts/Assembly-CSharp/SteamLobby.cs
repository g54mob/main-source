using System.Collections.Generic;
using Mirror;
using Steamworks;
using UnityEngine;
using UnityEngine.UI;

public class SteamLobby : Singleton<SteamLobby>
{
	protected Callback<LobbyCreated_t> LobbyCreated;

	protected Callback<GameLobbyJoinRequested_t> JoinRequest;

	protected Callback<LobbyEnter_t> LobbyEntered;

	protected Callback<LobbyDataUpdate_t> lobbyDataUpdated;

	public List<CSteamID> lobbyIDs = new List<CSteamID>();

	public ulong CurrentLobbyID;

	public const string HostAddressKey = "HostAddress";

	private CustomNetworkManager manager;

	public int lobbyMode;

	public Text LobbyNameText;

	private bool isConnecting;

	private void Start()
	{
		if (!SteamManager.Initialized)
		{
			Debug.Log("Steam Manager not initialized");
			return;
		}
		manager = GetComponent<CustomNetworkManager>();
		LobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
		JoinRequest = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequest);
		LobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
		lobbyDataUpdated = Callback<LobbyDataUpdate_t>.Create(OnGetLobbyData);
	}

	public void HostLobby()
	{
		ConnectToServer();
		SteamMatchmaking.CreateLobby((lobbyMode == 0) ? ELobbyType.k_ELobbyTypeFriendsOnly : ELobbyType.k_ELobbyTypePrivate, manager.maxConnections);
	}

	public void ConnectToServer()
	{
		isConnecting = true;
	}

	public void OpenNewGamePanel()
	{
	}

	private void OnLobbyCreated(LobbyCreated_t callback)
	{
		if (callback.m_eResult != EResult.k_EResultOK)
		{
			Debug.Log("Failed to create lobby");
			return;
		}
		Debug.Log("Lobby created successfully, sahne yüklenene kadar joinable=false");
		CurrentLobbyID = callback.m_ulSteamIDLobby;
		SteamMatchmaking.SetLobbyJoinable(new CSteamID(callback.m_ulSteamIDLobby), bLobbyJoinable: false);
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "HostAddress", SteamUser.GetSteamID().ToString());
		string loadedGameKey = CustomNetworkManager.loadedGameKey;
		string personaName = SteamFriends.GetPersonaName();
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name", loadedGameKey + " (" + personaName + ")");
		SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "game", "OnTheTrain");
		manager.StartHost();
		Debug.Log($"Lobby ID: {callback.m_ulSteamIDLobby}");
	}

	private void OnJoinRequest(GameLobbyJoinRequested_t callback)
	{
		Debug.Log("Request To Join Lobby");
		SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
	}

	private void OnLobbyEntered(LobbyEnter_t callback)
	{
		CurrentLobbyID = callback.m_ulSteamIDLobby;
		if (!NetworkServer.active)
		{
			manager.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "HostAddress");
			manager.StartClient();
		}
	}

	public void MakeLobbyPublic()
	{
		if (CurrentLobbyID != 0L && lobbyMode == 0)
		{
			SteamMatchmaking.SetLobbyJoinable(new CSteamID(CurrentLobbyID), bLobbyJoinable: true);
			Debug.Log("Lobby artık joinable - arkadaşlar katılabilir!");
		}
	}

	public void OpenInviteDialog()
	{
		if (CurrentLobbyID != 0L)
		{
			SteamFriends.ActivateGameOverlayInviteDialog(new CSteamID(CurrentLobbyID));
		}
		else
		{
			Debug.LogWarning("Davet gönderilemedi - aktif lobby yok!");
		}
	}

	public void LeaveLobby()
	{
		if (CurrentLobbyID != 0L)
		{
			Debug.Log($"Leaving lobby: {CurrentLobbyID}");
			SteamMatchmaking.LeaveLobby(new CSteamID(CurrentLobbyID));
			CurrentLobbyID = 0uL;
		}
	}

	public void JoinLobby(CSteamID lobbyID)
	{
		SteamMatchmaking.JoinLobby(lobbyID);
	}

	public void GetLobbiesList()
	{
		lobbyIDs.Clear();
		int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
		for (int i = 0; i < friendCount; i++)
		{
			CSteamID friendByIndex = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
			if (SteamFriends.GetFriendGamePlayed(friendByIndex, out var pFriendGameInfo) && pFriendGameInfo.m_gameID.AppID() == SteamUtils.GetAppID())
			{
				CSteamID steamIDLobby = pFriendGameInfo.m_steamIDLobby;
				if (steamIDLobby.IsValid() && !lobbyIDs.Contains(steamIDLobby))
				{
					lobbyIDs.Add(steamIDLobby);
					SteamMatchmaking.RequestLobbyData(steamIDLobby);
					string friendPersonaName = SteamFriends.GetFriendPersonaName(friendByIndex);
					Debug.Log($"Friend lobby found: {friendPersonaName} - LobbyID: {steamIDLobby.m_SteamID}");
				}
			}
		}
		Debug.Log($"Friend lobbies found: {lobbyIDs.Count}");
	}

	private void OnGetLobbyData(LobbyDataUpdate_t result)
	{
		Singleton<LobbiesListManager>.Instance.DisplayLobbies(lobbyIDs, result);
	}

	private void OnApplicationQuit()
	{
		LeaveLobby();
	}

	private void OnDestroy()
	{
		LeaveLobby();
	}
}
