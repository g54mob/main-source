using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class NewNetworkManager : NetworkManager
{
	[Header("Runtime Controls")]
	public bool showRuntimeButtons;

	[Tooltip("Maksimum oyuncu sayısı")]
	public int maxPlayerCount = 4;

	[Header("Loading Timing")]
	[Tooltip("Oyuncu bağlandıktan sonra loading kapatma gecikmesi (async sahne yoksa)")]
	public float loadingHideDelayNoScene = 1f;

	[Tooltip("Async sahne yüklendikten sonra loading kapatma gecikmesi")]
	public float loadingHideDelayAfterScene = 2f;

	[Header("Events")]
	public UnityEvent onServerStarted;

	public UnityEvent onServerStopped;

	public UnityEvent onClientConnectedEvent;

	public UnityEvent onClientDisconnectedEvent;

	public UnityEvent<NetworkConnectionToClient> onPlayerJoined;

	public UnityEvent<NetworkConnectionToClient> onPlayerLeft;

	public UnityEvent<NetworkConnectionToClient> onPlayerKicked;

	[Header("Lobby Info")]
	[Tooltip("Mevcut lobby kodu (multiplayer için)")]
	public string currentLobbyCode;

	[Tooltip("Mevcut Steam Lobby ID")]
	public CSteamID currentSteamLobbyID;

	private List<GamePlayer> gamePlayers = new List<GamePlayer>();

	private Dictionary<int, Coroutine> pendingLoadingCoroutines = new Dictionary<int, Coroutine>();

	public const string META_JOIN_ENABLED = "JoinEnabled";

	public static NewNetworkManager Instance => NetworkManager.singleton as NewNetworkManager;

	public static DisconnectReason LastDisconnectReason { get; private set; } = DisconnectReason.Manual;

	public static bool WasInMultiplayerSession { get; private set; } = false;

	public bool IsHost
	{
		get
		{
			if (NetworkServer.active)
			{
				return NetworkClient.isConnected;
			}
			return false;
		}
	}

	public int ConnectedClientCount
	{
		get
		{
			if (!NetworkServer.active)
			{
				return 0;
			}
			return NetworkServer.connections.Count;
		}
	}

	public List<GamePlayer> GamePlayers => gamePlayers;

	public bool IsMultiplayer => !string.IsNullOrEmpty(currentLobbyCode);

	public event Action OnPlayerListChanged;

	public static void SetDisconnectReason(DisconnectReason reason)
	{
		LastDisconnectReason = reason;
		WasInMultiplayerSession = true;
		Debug.Log($"[NewNetworkManager] DisconnectReason set: {reason}");
	}

	public static void ResetDisconnectReason()
	{
		LastDisconnectReason = DisconnectReason.Manual;
		WasInMultiplayerSession = false;
		Debug.Log("[NewNetworkManager] DisconnectReason reset");
	}

	public override void Start()
	{
		base.Start();
		maxConnections = maxPlayerCount + 1;
	}

	public void StartHostSafe()
	{
		if (!NetworkClient.isConnected && !NetworkServer.active)
		{
			StartHost();
		}
	}

	public void StartServerOnlySafe()
	{
		if (!NetworkServer.active)
		{
			StartServer();
		}
	}

	public void StartClientSafe(string address = null)
	{
		if (!string.IsNullOrWhiteSpace(address))
		{
			networkAddress = address;
		}
		if (!NetworkClient.isConnected)
		{
			StartClient();
		}
	}

	public void StopAllNetworking()
	{
		if (IsHost)
		{
			StopHost();
		}
		else if (NetworkServer.active)
		{
			StopServer();
		}
		else if (NetworkClient.isConnected)
		{
			StopClient();
		}
	}

	public override void OnStartServer()
	{
		base.OnStartServer();
		onServerStarted?.Invoke();
		Debug.Log("[NewNetworkManager] Server started");
	}

	public override void OnStartClient()
	{
		base.OnStartClient();
		NetworkClient.RegisterHandler<SceneMessage>(OnSceneMessage);
		NetworkClient.RegisterHandler<DisconnectReasonMessage>(OnDisconnectReasonMessage);
	}

	public override void OnStopServer()
	{
		base.OnStopServer();
		onServerStopped?.Invoke();
		Debug.Log("[NewNetworkManager] Server stopped");
	}

	public override void OnServerConnect(NetworkConnectionToClient conn)
	{
		int count = NetworkServer.connections.Count;
		if (count > maxPlayerCount)
		{
			Debug.LogWarning($"[NewNetworkManager] Max player aşıldı! ({count}/{maxPlayerCount}) Connection reddediliyor: {conn.connectionId}");
			conn.Disconnect();
			onPlayerKicked?.Invoke(conn);
			return;
		}
		base.OnServerConnect(conn);
		if (conn.connectionId > 0)
		{
			conn.Send(new SceneMessage
			{
				sceneName = NetworkSceneLoader.Instance.CurrentLoadingScene
			});
		}
		if (count > 1 && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerShowLoadingExcept(conn, LoadingType.PlayerJoining);
			Debug.Log($"[NewNetworkManager] Yeni oyuncu bağlanıyor, diğerlerinde loading açıldı: {conn.connectionId}");
		}
		onPlayerJoined?.Invoke(conn);
		Debug.Log($"[NewNetworkManager] Server connect: {conn.connectionId} (Players: {count}/{maxPlayerCount})");
		StartCoroutine(OnClientConnectActions(conn));
	}

	private IEnumerator OnClientConnectActions(NetworkConnectionToClient conn)
	{
		yield return new WaitUntil(() => conn.isReady);
		SCC_Network.ServerRebroadcastSeatsForAll();
	}

	public override void OnServerDisconnect(NetworkConnectionToClient conn)
	{
		if (NetworkServer.active && conn != null && conn.identity != null)
		{
			SCC_Network.HandleClientDisconnected(conn.identity.netId);
			_ = NetworkSceneLoader.Instance != null;
		}
		if (conn != null && pendingLoadingCoroutines.TryGetValue(conn.connectionId, out var value))
		{
			if (value != null)
			{
				StopCoroutine(value);
			}
			pendingLoadingCoroutines.Remove(conn.connectionId);
		}
		if (conn != null && NetworkLoadingSync.Instance != null)
		{
			NetworkLoadingSync.Instance.ServerOnPlayerLeft(conn);
		}
		onPlayerLeft?.Invoke(conn);
		base.OnServerDisconnect(conn);
		Debug.Log("[NewNetworkManager] Server disconnect: " + conn.connectionId);
	}

	public override void OnClientConnect()
	{
		onClientConnectedEvent?.Invoke();
		Debug.Log(" sSceneLoader [NewNetworkManager] Client connected");
		if (NetworkServer.active)
		{
			if (!NetworkClient.ready)
			{
				NetworkClient.Ready();
			}
			if (autoCreatePlayer)
			{
				NetworkClient.AddPlayer();
			}
		}
	}

	private void OnSceneMessage(SceneMessage msg)
	{
		Debug.Log("[CLIENT] SceneMessage geldi: " + msg.sceneName);
		if (string.IsNullOrWhiteSpace(msg.sceneName))
		{
			if (!NetworkClient.ready)
			{
				NetworkClient.Ready();
			}
			if (autoCreatePlayer)
			{
				NetworkClient.AddPlayer();
			}
			NetworkClient.AddPlayer();
		}
		else
		{
			Scene sceneByName = SceneManager.GetSceneByName(msg.sceneName);
			if (sceneByName.IsValid() && sceneByName.isLoaded)
			{
				Debug.Log("[CLIENT] Scene zaten yüklü: " + msg.sceneName);
			}
			else
			{
				StartCoroutine(LoadAdditiveSceneFromMessage(msg.sceneName));
			}
		}
	}

	private IEnumerator LoadAdditiveSceneFromMessage(string sceneName)
	{
		Debug.Log("[CLIENT] Additive scene yükleniyor: " + sceneName);
		AsyncOperation op = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
		if (op == null)
		{
			Debug.LogError("[CLIENT] LoadSceneAsync null döndü. Build Settings'te var mı? Scene: " + sceneName);
			yield break;
		}
		while (!op.isDone)
		{
			yield return null;
		}
		Scene sceneByName = SceneManager.GetSceneByName(sceneName);
		if (sceneByName.IsValid() && sceneByName.isLoaded)
		{
			Debug.Log("[CLIENT] Additive scene yüklendi: " + sceneName);
			if (NetworkClient.active)
			{
				NetworkClient.PrepareToSpawnSceneObjects();
				Debug.Log("Rebuild Client spawnableObjects after additive scene load: " + sceneName);
			}
			if (!NetworkClient.ready)
			{
				NetworkClient.Ready();
			}
			if (autoCreatePlayer)
			{
				NetworkClient.AddPlayer();
			}
		}
		else
		{
			Debug.LogError("[CLIENT] Scene yüklendi sanıldı ama bulunamadı: " + sceneName);
		}
	}

	public override void OnClientDisconnect()
	{
		NetworkClient.UnregisterHandler<SceneMessage>();
		base.OnClientDisconnect();
		onClientDisconnectedEvent?.Invoke();
		Debug.Log("[NewNetworkManager] Client disconnected");
		if (!NetworkServer.active && IsMultiplayer)
		{
			if (!WasInMultiplayerSession)
			{
				SetDisconnectReason(DisconnectReason.ConnectionLost);
			}
			StartCoroutine(ReturnToMainMenuAfterDisconnect());
		}
	}

	private IEnumerator ReturnToMainMenuAfterDisconnect()
	{
		LoadingManagerUI.Show(LoadingType.Menu);
		PauseMenuManager.LeaveSteamLobby();
		ClearLobbyCode();
		yield return new WaitForSeconds(1f);
		SceneManager.LoadScene(offlineScene);
	}

	public override void OnServerAddPlayer(NetworkConnectionToClient conn)
	{
		base.OnServerAddPlayer(conn);
		if (!(NetworkLoadingSync.Instance != null))
		{
			return;
		}
		NetworkLoadingSync.Instance.ServerOnPlayerJoining(conn);
		if (pendingLoadingCoroutines.TryGetValue(conn.connectionId, out var value))
		{
			if (value != null)
			{
				StopCoroutine(value);
			}
			pendingLoadingCoroutines.Remove(conn.connectionId);
		}
		Coroutine value2 = StartCoroutine(HandlePlayerLoadingCompletion(conn));
		pendingLoadingCoroutines[conn.connectionId] = value2;
		Debug.Log($"[NewNetworkManager] Oyuncu eklendi, loading kapatma süreci başlatıldı: {conn.connectionId}");
	}

	private IEnumerator HandlePlayerLoadingCompletion(NetworkConnectionToClient conn)
	{
		yield return new WaitForSeconds(loadingHideDelayNoScene);
		DiggerReplayMessenger replayStreamer = DiggerReplayMessenger.Instance;
		if (replayStreamer != null && replayStreamer.IsConnectionPendingReady(conn.connectionId))
		{
			Debug.Log($"[NewNetworkManager] Digger replay kararı bekleniyor: {conn.connectionId}");
			float timeout = 15f;
			while (replayStreamer.IsConnectionPendingReady(conn.connectionId) && timeout > 0f)
			{
				yield return new WaitForSeconds(0.25f);
				timeout -= 0.25f;
			}
			if (timeout <= 0f)
			{
				Debug.LogWarning($"[NewNetworkManager] Digger replay kararı timeout: {conn.connectionId}");
			}
		}
		if (NetworkLoadingSync.Instance != null)
		{
			if (!SaveLoadGameManager.IsLoadPendingOrInProgress)
			{
				NetworkLoadingSync.Instance.ServerHideLoadingToTarget(conn, LoadingType.Scene);
				Debug.Log($"[NewNetworkManager] Scene loading kapatıldı (target): {conn.connectionId}");
			}
			else
			{
				Debug.Log($"[NewNetworkManager] Scene loading kapatma atlandı - load pending/in progress: {conn.connectionId}");
			}
			NetworkLoadingSync.Instance.ServerOnPlayerSceneLoaded(conn);
		}
		pendingLoadingCoroutines.Remove(conn.connectionId);
	}

	public void KickPlayer(NetworkConnectionToClient conn, string reason = "")
	{
		if (NetworkServer.active && conn != null)
		{
			Debug.Log($"[NewNetworkManager] Kicking player: {conn.connectionId}. Reason: {reason}");
			onPlayerKicked?.Invoke(conn);
			conn.Disconnect();
		}
	}

	public void KickPlayer(int connectionId, string reason = "")
	{
		if (NetworkServer.active && NetworkServer.connections.TryGetValue(connectionId, out var value))
		{
			KickPlayer(value, reason);
		}
	}

	public void BroadcastDisconnectAndKickAll(DisconnectReason reason)
	{
		if (NetworkServer.active)
		{
			Debug.Log($"[NewNetworkManager] Broadcasting disconnect reason to all clients: {reason}");
			NetworkServer.SendToAll(new DisconnectReasonMessage
			{
				reason = reason
			});
		}
	}

	private void OnDisconnectReasonMessage(DisconnectReasonMessage msg)
	{
		Debug.Log($"[NewNetworkManager] DisconnectReasonMessage received: {msg.reason}");
		SetDisconnectReason(msg.reason);
		if (!NetworkServer.active)
		{
			StartCoroutine(DisconnectAfterDelay(0.1f));
		}
	}

	private IEnumerator DisconnectAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		PauseMenuManager.LeaveSteamLobby();
		StopClient();
	}

	public int GetCurrentPlayerCount()
	{
		if (!NetworkServer.active)
		{
			return 0;
		}
		return NetworkServer.connections.Count;
	}

	public bool IsLobbyFull()
	{
		return GetCurrentPlayerCount() >= maxPlayerCount;
	}

	public void RegisterGamePlayer(GamePlayer player)
	{
		if (!(player == null) && !gamePlayers.Contains(player))
		{
			gamePlayers.Add(player);
			gamePlayers.Sort((GamePlayer a, GamePlayer b) => a.ownerConnectionId.CompareTo(b.ownerConnectionId));
			Debug.Log($"[NewNetworkManager] GamePlayer registered: {player.playerName} (ConnectionId: {player.ownerConnectionId}), Total: {gamePlayers.Count}");
			this.OnPlayerListChanged?.Invoke();
		}
	}

	public void UnregisterGamePlayer(GamePlayer player)
	{
		if (!(player == null) && gamePlayers.Contains(player))
		{
			if (IsMultiplayer && player.ownerConnectionId != 0 && PlayerActionNotificationManager.Instance != null)
			{
				PlayerActionNotificationManager.Instance.OnPlayerLeft(player.playerName);
			}
			gamePlayers.Remove(player);
			Debug.Log($"[NewNetworkManager] GamePlayer unregistered: {player.playerName}, Remaining: {gamePlayers.Count}");
			this.OnPlayerListChanged?.Invoke();
		}
	}

	public GamePlayer GetGamePlayerByConnectionId(int connectionId)
	{
		return gamePlayers.Find((GamePlayer p) => p.ownerConnectionId == connectionId);
	}

	public void SetLobbyCode(string code)
	{
		currentLobbyCode = code;
		Debug.Log("[NewNetworkManager] Lobby code set: " + code);
	}

	public void SetSteamLobbyID(CSteamID lobbyID)
	{
		currentSteamLobbyID = lobbyID;
		Debug.Log($"[NewNetworkManager] Steam Lobby ID set: {lobbyID}");
	}

	public void ClearLobbyCode()
	{
		currentLobbyCode = null;
		currentSteamLobbyID = CSteamID.Nil;
		Debug.Log("[NewNetworkManager] Lobby code cleared");
	}

	public void SetJoinEnabled(bool enabled)
	{
		if (!string.IsNullOrEmpty(currentLobbyCode))
		{
			string pchValue = (enabled ? "1" : "0");
			SteamMatchmaking.SetLobbyData(currentSteamLobbyID, "JoinEnabled", pchValue);
		}
	}
}
