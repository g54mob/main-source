using System.Collections;
using Mirror;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

namespace SteamLobbyTutorial
{
	public class SteamLobby : NetworkBehaviour
	{
		public static SteamLobby Instance;

		public GameObject hostButton;

		public ulong lobbyID;

		public NetworkManager networkManager;

		public PanelSwapper panelSwapper;

		protected Callback<LobbyCreated_t> lobbyCreated;

		protected Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequested;

		protected Callback<LobbyEnter_t> lobbyEntered;

		protected Callback<LobbyChatUpdate_t> lobbyChatUpdate;

		public Transport transport;

		private const string HostAddressKey = "HostAddress";

		private Coroutine joinTimeoutCoroutine;

		private bool lobbyJoinSucceeded;

		public UnityEvent timedOutEvent;

		public UnityEvent exitEvent;

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			else if (Instance != this)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void Start()
		{
			if (!SteamManager.Initialized)
			{
				Debug.LogError("Steam is not initialized.");
				return;
			}
			networkManager = networkManager ?? GetComponent<NetworkManager>() ?? NetworkManager.singleton;
			if (networkManager == null)
			{
				Debug.LogError("NetworkManager not found!");
				return;
			}
			if (transport == null)
			{
				transport = GetComponent<Transport>() ?? Object.FindObjectOfType<Transport>();
			}
			panelSwapper.gameObject.SetActive(value: true);
			lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
			gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnGameLobbyJoinRequested);
			lobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
			lobbyChatUpdate = Callback<LobbyChatUpdate_t>.Create(OnLobbyChatUpdate);
			Reset();
		}

		public void HostLobby()
		{
			SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, networkManager.maxConnections);
		}

		private void OnLobbyCreated(LobbyCreated_t callback)
		{
			if (callback.m_eResult != EResult.k_EResultOK)
			{
				Debug.LogError("Failed to create lobby: " + callback.m_eResult);
				return;
			}
			Debug.Log("Lobby created. ID: " + callback.m_ulSteamIDLobby);
			lobbyID = callback.m_ulSteamIDLobby;
			StartCoroutine(ResetTransportAndHostAgain());
			StartCoroutine(SetLobbyDataWhenReady(callback.m_ulSteamIDLobby));
		}

		private IEnumerator ResetTransportAndHostAgain()
		{
			Debug.Log("Resetting transport...");
			if (NetworkServer.active || NetworkClient.isConnected || NetworkClient.active)
			{
				NetworkManager.singleton.StopHost();
				NetworkManager.singleton.StopClient();
			}
			yield return null;
			transport?.Shutdown();
			yield return new WaitForSeconds(0.5f);
			networkManager.StopClient();
			networkManager.StopHost();
			Debug.Log("Restarting host...");
			networkManager.StartHost();
		}

		private IEnumerator SetLobbyDataWhenReady(ulong steamID)
		{
			float timeout = 3f;
			float elapsed = 0f;
			while (!NetworkServer.active && elapsed < timeout)
			{
				elapsed += Time.deltaTime;
				yield return null;
			}
			if (!NetworkServer.active)
			{
				Debug.LogWarning("SetLobbyDataWhenReady: Server never became active.");
			}
			else
			{
				SteamMatchmaking.SetLobbyData(new CSteamID(steamID), "HostAddress", SteamUser.GetSteamID().ToString());
			}
		}

		private void OnGameLobbyJoinRequested(GameLobbyJoinRequested_t callback)
		{
			CSteamID steamIDLobby = callback.m_steamIDLobby;
			Debug.Log("Join request received for lobby: " + steamIDLobby.ToString());
			StartCoroutine(HandleRejoinLobby(callback.m_steamIDLobby));
		}

		private IEnumerator HandleRejoinLobby(CSteamID lobby)
		{
			lobbyJoinSucceeded = false;
			if (joinTimeoutCoroutine != null)
			{
				StopCoroutine(joinTimeoutCoroutine);
			}
			joinTimeoutCoroutine = StartCoroutine(JoinLobbyTimeout(10f));
			if (lobbyID != 0L)
			{
				SteamMatchmaking.LeaveLobby(new CSteamID(lobbyID));
				lobbyID = 0uL;
			}
			if (NetworkServer.active)
			{
				NetworkManager.singleton.StopHost();
			}
			if (NetworkClient.isConnected || NetworkClient.active)
			{
				NetworkManager.singleton.StopClient();
			}
			yield return null;
			transport?.Shutdown();
			yield return new WaitForSeconds(0.5f);
			Debug.Log("Joining new lobby...");
			SteamMatchmaking.JoinLobby(lobby);
		}

		private void OnLobbyEntered(LobbyEnter_t callback)
		{
			lobbyJoinSucceeded = true;
			if (joinTimeoutCoroutine != null)
			{
				StopCoroutine(joinTimeoutCoroutine);
				joinTimeoutCoroutine = null;
			}
			if (NetworkServer.active)
			{
				Debug.Log("Already hosting. Ignoring join request.");
				return;
			}
			lobbyID = callback.m_ulSteamIDLobby;
			string lobbyData = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "HostAddress");
			networkManager.networkAddress = lobbyData;
			Debug.Log("Entered lobby: " + callback.m_ulSteamIDLobby);
			networkManager.StartClient();
			panelSwapper.SwapPanel("LobbyPanel");
		}

		private IEnumerator JoinLobbyTimeout(float seconds)
		{
			yield return new WaitForSeconds(seconds);
			if (!lobbyJoinSucceeded)
			{
				TimedOut();
			}
		}

		private void TimedOut()
		{
			Debug.Log("we timed out");
			panelSwapper.SwapPanel("MainPanel");
			timedOutEvent.Invoke();
		}

		private void OnLobbyChatUpdate(LobbyChatUpdate_t callback)
		{
			if (callback.m_ulSteamIDLobby == lobbyID)
			{
				EChatMemberStateChange rgfChatMemberStateChange = (EChatMemberStateChange)callback.m_rgfChatMemberStateChange;
				Debug.Log($"LobbyChatUpdate: {rgfChatMemberStateChange}");
				if ((rgfChatMemberStateChange & (EChatMemberStateChange.k_EChatMemberStateChangeEntered | EChatMemberStateChange.k_EChatMemberStateChangeLeft | EChatMemberStateChange.k_EChatMemberStateChangeDisconnected | EChatMemberStateChange.k_EChatMemberStateChangeKicked | EChatMemberStateChange.k_EChatMemberStateChangeBanned)) != 0)
				{
					StartCoroutine(DelayedNameUpdate(0.5f));
					LobbyUIManager.Instance?.CheckAllPlayersReady();
				}
			}
		}

		private IEnumerator DelayedNameUpdate(float delay)
		{
			yield return new WaitForSeconds(delay);
			LobbyUIManager.Instance?.UpdatePlayerLobbyUI();
		}

		public void LeaveLobby()
		{
			StartCoroutine(CleanupAndLeaveLobby());
		}

		private IEnumerator CleanupAndLeaveLobby()
		{
			CSteamID lobbyOwner = SteamMatchmaking.GetLobbyOwner(new CSteamID(lobbyID));
			CSteamID steamID = SteamUser.GetSteamID();
			CSteamID lobby = new CSteamID(lobbyID);
			if (lobbyID != 0L)
			{
				SteamMatchmaking.LeaveLobby(lobby);
				lobbyID = 0uL;
			}
			if (NetworkServer.active && lobbyOwner == steamID)
			{
				NetworkManager.singleton.StopHost();
			}
			else if (NetworkClient.isConnected || NetworkClient.active)
			{
				NetworkManager.singleton.StopClient();
			}
			yield return null;
			transport?.Shutdown();
			yield return new WaitForSeconds(0.5f);
			float elapsed = 0f;
			while (SteamMatchmaking.GetNumLobbyMembers(lobby) > 0 && elapsed < 2f)
			{
				elapsed += Time.deltaTime;
				yield return null;
			}
			Debug.Log("Steam lobby fully cleared.");
			panelSwapper.gameObject.SetActive(value: true);
			base.gameObject.SetActive(value: true);
			panelSwapper.SwapPanel("MainPanel");
			exitEvent.Invoke();
			Debug.Log("Lobby left and network shutdown complete.");
		}

		public void Reset()
		{
			StartCoroutine(ResetCoroutine());
		}

		private IEnumerator ResetCoroutine()
		{
			CSteamID lobbyOwner = SteamMatchmaking.GetLobbyOwner(new CSteamID(lobbyID));
			CSteamID steamID = SteamUser.GetSteamID();
			CSteamID lobby = new CSteamID(lobbyID);
			if (lobbyID != 0L)
			{
				SteamMatchmaking.LeaveLobby(lobby);
				lobbyID = 0uL;
			}
			if (NetworkServer.active && lobbyOwner == steamID)
			{
				NetworkManager.singleton.StopHost();
			}
			else if (NetworkClient.isConnected || NetworkClient.active)
			{
				NetworkManager.singleton.StopClient();
			}
			yield return null;
			transport?.Shutdown();
			yield return new WaitForSeconds(0.5f);
			float elapsed = 0f;
			while (SteamMatchmaking.GetNumLobbyMembers(lobby) > 0 && elapsed < 2f)
			{
				elapsed += Time.deltaTime;
				yield return null;
			}
			Debug.Log("Steam lobby fully cleared.");
			base.gameObject.SetActive(value: true);
			Debug.Log("Lobby left and network shutdown complete.");
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
