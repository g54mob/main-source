using System;
using System.Collections;
using System.Collections.Generic;
using Heathen.SteamworksIntegration;
using Heathen.SteamworksIntegration.API;
using I2.Loc;
using Steamworks;
using UnityEngine;
using UnityEngine.Events;

public class SteamLobbyManager : MonoBehaviour
{
	[Header("Lobby Settings")]
	[Tooltip("Maksimum oyuncu sayısı (gerçek limit)")]
	public int maxPlayers = 4;

	[Tooltip("Steam Lobby slot sayısı (1 fazla, kick için buffer)")]
	public int lobbySlots = 5;

	[Header("References")]
	public NewNetworkManager networkManager;

	[Header("Current Lobby Info")]
	[SerializeField]
	private LobbyData currentLobby;

	[SerializeField]
	private string currentLobbyCode;

	[SerializeField]
	private bool isHost;

	public const string META_LOBBY_NAME = "LobbyName";

	public const string META_OWNER_NAME = "OwnerName";

	public const string META_LOBBY_CODE = "LobbyCode";

	public const string META_VERSION = "Version";

	public const string META_LOBBY_TYPE = "LobbyType";

	public const string META_PLAYER_COUNT = "PlayerCount";

	public const string META_IS_PRIVATE = "IsPrivate";

	public const string META_JOIN_ENABLED = "JoinEnabled";

	[Header("Events")]
	public UnityEvent<LobbyData> onLobbyCreated;

	public UnityEvent<LobbyData> onLobbyJoined;

	public UnityEvent onLobbyLeft;

	public UnityEvent<LobbyData[]> onLobbiesFound;

	public UnityEvent<UserData> onPlayerJoined;

	public UnityEvent<UserData> onPlayerLeft;

	public UnityEvent<string> onError;

	private UnityAction<LobbyEnter_t> onLobbyEnterSuccessDelegate;

	private UnityAction<LobbyEnter_t> onLobbyEnterFailedDelegate;

	private UnityAction<LobbyChatUpdate_t> onLobbyChatUpdateDelegate;

	private UnityAction<LobbyData> onLobbyLeaveDelegate;

	private UnityAction<LobbyData> onAskedToLeaveDelegate;

	private UnityAction<LobbyData, UserData> onGameLobbyJoinRequestedDelegate;

	private bool pendingIsPrivate;

	public static SteamLobbyManager Instance { get; private set; }

	public LobbyData CurrentLobby => currentLobby;

	public bool IsInLobby
	{
		get
		{
			if (currentLobby != CSteamID.Nil.m_SteamID)
			{
				return currentLobby.MemberCount > 0;
			}
			return false;
		}
	}

	public bool IsHost => isHost;

	public string LobbyCode => currentLobbyCode;

	public int MemberCount
	{
		get
		{
			if (!IsInLobby)
			{
				return 0;
			}
			return currentLobby.MemberCount;
		}
	}

	public event Action OnJoinBlockedByTutorial;

	public event Action<LobbyData, UserData> OnSteamInviteReceived;

	public event Action<LobbyData> OnLobbyCreatedEvent;

	public event Action<LobbyData> OnLobbyJoinedEvent;

	public event Action OnLobbyLeftEvent;

	public event Action<LobbyData[]> OnLobbiesFoundEvent;

	public event Action<UserData> OnPlayerJoinedEvent;

	public event Action<UserData> OnPlayerLeftEvent;

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		Matchmaking.Client.LeaveAllLobbies();
		CheckCommandLineJoin();
	}

	private void CheckCommandLineJoin()
	{
		string[] commandLineArgs = Environment.GetCommandLineArgs();
		for (int i = 0; i < commandLineArgs.Length; i++)
		{
			if (commandLineArgs[i] == "+connect_lobby" && i + 1 < commandLineArgs.Length)
			{
				if (ulong.TryParse(commandLineArgs[i + 1], out var result))
				{
					Debug.Log($"[SteamLobbyManager] +connect_lobby argümanı bulundu: {result}");
					LobbyData lobby = LobbyData.Get(result);
					StartCoroutine(DelayedInviteReceived(lobby));
				}
				else
				{
					Debug.LogWarning("[SteamLobbyManager] +connect_lobby argümanı geçersiz: " + commandLineArgs[i + 1]);
				}
				break;
			}
		}
	}

	private IEnumerator DelayedInviteReceived(LobbyData lobby)
	{
		yield return new WaitForSeconds(1f);
		this.OnSteamInviteReceived?.Invoke(lobby, default(UserData));
	}

	private void OnEnable()
	{
		onLobbyEnterSuccessDelegate = delegate(LobbyEnter_t result)
		{
			HandleLobbyEnterSuccess(result);
		};
		onLobbyEnterFailedDelegate = delegate(LobbyEnter_t result)
		{
			HandleLobbyEnterFailed(result);
		};
		onLobbyChatUpdateDelegate = delegate(LobbyChatUpdate_t callback)
		{
			HandleLobbyChatUpdate(callback);
		};
		onLobbyLeaveDelegate = delegate(LobbyData lobby)
		{
			HandleLobbyLeave(lobby);
		};
		onAskedToLeaveDelegate = delegate(LobbyData lobby)
		{
			HandleAskedToLeave(lobby);
		};
		onGameLobbyJoinRequestedDelegate = delegate(LobbyData lobby, UserData friend)
		{
			HandleGameLobbyJoinRequested(lobby, friend);
		};
		Matchmaking.Client.EventLobbyEnterSuccess.AddListener(onLobbyEnterSuccessDelegate);
		Matchmaking.Client.EventLobbyEnterFailed.AddListener(onLobbyEnterFailedDelegate);
		Matchmaking.Client.EventLobbyChatUpdate.AddListener(onLobbyChatUpdateDelegate);
		Matchmaking.Client.EventLobbyLeave.AddListener(onLobbyLeaveDelegate);
		Matchmaking.Client.EventLobbyAskedToLeave.AddListener(onAskedToLeaveDelegate);
		Overlay.Client.EventGameLobbyJoinRequested.AddListener(onGameLobbyJoinRequestedDelegate);
	}

	private void OnDisable()
	{
		Matchmaking.Client.EventLobbyEnterSuccess.RemoveListener(onLobbyEnterSuccessDelegate);
		Matchmaking.Client.EventLobbyEnterFailed.RemoveListener(onLobbyEnterFailedDelegate);
		Matchmaking.Client.EventLobbyChatUpdate.RemoveListener(onLobbyChatUpdateDelegate);
		Matchmaking.Client.EventLobbyLeave.RemoveListener(onLobbyLeaveDelegate);
		Matchmaking.Client.EventLobbyAskedToLeave.RemoveListener(onAskedToLeaveDelegate);
		Overlay.Client.EventGameLobbyJoinRequested.RemoveListener(onGameLobbyJoinRequestedDelegate);
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void CreateLobby(bool isPrivate)
	{
		if (IsInLobby)
		{
			LeaveLobby();
		}
		pendingIsPrivate = isPrivate;
		string text = (pendingIsPrivate ? LocalizationManager.GetTranslation("Invite Only") : LocalizationManager.GetTranslation("Public"));
		Debug.Log("[SteamLobbyManager] Lobby oluşturuluyor... Type: " + text);
		Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypePublic, lobbySlots, OnLobbyCreatedCallback);
	}

	[Obsolete("Use CreateLobby(bool isPrivate) instead")]
	public void CreateLobby(ELobbyType lobbyType)
	{
		bool isPrivate = lobbyType == ELobbyType.k_ELobbyTypePrivate;
		CreateLobby(isPrivate);
	}

	public void CreatePublicLobby()
	{
		CreateLobby(isPrivate: false);
	}

	public void CreateFriendsOnlyLobby()
	{
		CreateLobby(isPrivate: false);
	}

	public void CreatePrivateLobby()
	{
		CreateLobby(isPrivate: true);
	}

	private void OnLobbyCreatedCallback(EResult result, LobbyData lobby, bool ioError)
	{
		if (ioError || result != EResult.k_EResultOK)
		{
			string text = $"Lobby oluşturma başarısız: {result}";
			Debug.LogError("[SteamLobbyManager] " + text);
			onError?.Invoke(text);
			return;
		}
		currentLobby = lobby;
		isHost = true;
		currentLobbyCode = GenerateLobbyCode();
		string personaName = SteamFriends.GetPersonaName();
		string text2 = (lobby["LobbyName"] = personaName + "'s Factory");
		lobby["OwnerName"] = personaName;
		lobby["LobbyCode"] = currentLobbyCode;
		lobby["Version"] = Application.version;
		lobby["LobbyType"] = ((int)lobby.Type).ToString();
		lobby["PlayerCount"] = "1";
		lobby["IsPrivate"] = (pendingIsPrivate ? "1" : "0");
		lobby["JoinEnabled"] = "0";
		string text4 = (pendingIsPrivate ? LocalizationManager.GetTranslation("Invite Only") : LocalizationManager.GetTranslation("Public"));
		Debug.Log("[SteamLobbyManager] Lobby oluşturuldu: " + text2 + " | Code: " + currentLobbyCode + " | Type: " + text4);
		if (networkManager != null)
		{
			networkManager.SetLobbyCode(currentLobbyCode);
			networkManager.SetSteamLobbyID(lobby);
		}
		onLobbyCreated?.Invoke(lobby);
		this.OnLobbyCreatedEvent?.Invoke(lobby);
	}

	private string GenerateLobbyCode()
	{
		return UnityEngine.Random.Range(100000, 999999).ToString();
	}

	public void SearchLobbies(int maxResults = 50, ELobbyDistanceFilter distanceFilter = ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide)
	{
		Debug.Log($"[SteamLobbyManager] Lobby aranıyor... Distance: {distanceFilter}");
		Matchmaking.Client.AddRequestLobbyListDistanceFilter(distanceFilter);
		Matchmaking.Client.AddRequestLobbyListFilterSlotsAvailable(1);
		Matchmaking.Client.AddRequestLobbyListResultCountFilter(maxResults);
		Matchmaking.Client.RequestLobbyList(OnLobbyListReceived);
	}

	private void OnLobbyListReceived(LobbyData[] lobbies, bool ioError)
	{
		if (ioError)
		{
			Debug.LogError("[SteamLobbyManager] Lobby listesi alınamadı");
			onLobbiesFound?.Invoke(new LobbyData[0]);
			this.OnLobbiesFoundEvent?.Invoke(new LobbyData[0]);
			return;
		}
		Debug.Log($"[SteamLobbyManager] {lobbies.Length} lobby bulundu");
		List<LobbyData> list = new List<LobbyData>();
		for (int i = 0; i < lobbies.Length; i++)
		{
			LobbyData item = lobbies[i];
			if (item.MemberCount < maxPlayers)
			{
				list.Add(item);
			}
		}
		onLobbiesFound?.Invoke(list.ToArray());
		this.OnLobbiesFoundEvent?.Invoke(list.ToArray());
	}

	public void JoinLobby(LobbyData lobby)
	{
		if (IsInLobby)
		{
			LeaveLobby();
		}
		Debug.Log($"[SteamLobbyManager] Lobby'e katılınıyor: {lobby}");
		Matchmaking.Client.JoinLobby(lobby, OnLobbyJoinCallback);
	}

	public void JoinLobby(ulong lobbyId)
	{
		JoinLobby(LobbyData.Get(lobbyId));
	}

	public void JoinLobbyByCode(string code)
	{
		Debug.Log("[SteamLobbyManager] Kod ile lobby aranıyor: " + code);
		Matchmaking.Client.AddRequestLobbyListStringFilter("LobbyCode", code, ELobbyComparison.k_ELobbyComparisonEqual);
		Matchmaking.Client.AddRequestLobbyListStringFilter("Version", Application.version, ELobbyComparison.k_ELobbyComparisonEqual);
		Matchmaking.Client.AddRequestLobbyListResultCountFilter(1);
		Matchmaking.Client.RequestLobbyList(delegate(LobbyData[] lobbies, bool ioError)
		{
			if (ioError || lobbies.Length == 0)
			{
				string text = "Lobby bulunamadı veya kod geçersiz";
				Debug.LogWarning("[SteamLobbyManager] " + text);
				onError?.Invoke(text);
			}
			else
			{
				JoinLobby(lobbies[0]);
			}
		});
	}

	public void JoinLobbyByCodeAndStartClient(string code)
	{
		Debug.Log("[SteamLobbyManager] Kod ile lobby aranıyor ve client başlatılıyor: " + code);
		Matchmaking.Client.AddRequestLobbyListStringFilter("LobbyCode", code, ELobbyComparison.k_ELobbyComparisonEqual);
		Matchmaking.Client.AddRequestLobbyListStringFilter("Version", Application.version, ELobbyComparison.k_ELobbyComparisonEqual);
		Matchmaking.Client.AddRequestLobbyListResultCountFilter(1);
		Matchmaking.Client.RequestLobbyList(delegate(LobbyData[] lobbies, bool ioError)
		{
			if (ioError || lobbies.Length == 0)
			{
				string text = "Lobby bulunamadı veya kod geçersiz";
				Debug.LogWarning("[SteamLobbyManager] " + text);
				onError?.Invoke(text);
			}
			else
			{
				JoinLobbyAndStartClient(lobbies[0]);
			}
		});
	}

	private void OnLobbyJoinCallback(LobbyEnter result, bool ioError)
	{
		if (ioError)
		{
			string text = "Lobby'e katılma başarısız: IO Error";
			Debug.LogError("[SteamLobbyManager] " + text);
			onError?.Invoke(text);
		}
		else if (result.Response != EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
		{
			string text2 = $"Lobby'e katılma başarısız: {result.Response}";
			Debug.LogError("[SteamLobbyManager] " + text2);
			onError?.Invoke(text2);
		}
	}

	public void LeaveLobby()
	{
		if (IsInLobby)
		{
			Debug.Log("[SteamLobbyManager] Lobby'den ayrılınıyor...");
			if (networkManager != null)
			{
				networkManager.StopAllNetworking();
				networkManager.ClearLobbyCode();
			}
			currentLobby.Leave();
			currentLobby = default(LobbyData);
			currentLobbyCode = null;
			isHost = false;
			onLobbyLeft?.Invoke();
			this.OnLobbyLeftEvent?.Invoke();
		}
	}

	private void HandleLobbyEnterSuccess(LobbyEnter_t result)
	{
		LobbyData lobbyData = (currentLobby = LobbyData.Get(result.m_ulSteamIDLobby));
		currentLobbyCode = lobbyData["LobbyCode"];
		int memberCount = lobbyData.MemberCount;
		Debug.Log($"[SteamLobbyManager] Lobby'e girildi. Oyuncu sayısı: {memberCount}");
		if (networkManager != null)
		{
			networkManager.SetLobbyCode(currentLobbyCode);
			networkManager.SetSteamLobbyID(lobbyData);
		}
		onLobbyJoined?.Invoke(lobbyData);
		this.OnLobbyJoinedEvent?.Invoke(lobbyData);
	}

	private void HandleLobbyEnterFailed(LobbyEnter_t result)
	{
		EChatRoomEnterResponse eChatRoomEnterResponse = (EChatRoomEnterResponse)result.m_EChatRoomEnterResponse;
		string text = $"Lobby'e giriş başarısız: {eChatRoomEnterResponse}";
		Debug.LogError("[SteamLobbyManager] " + text);
		onError?.Invoke(text);
	}

	private void HandleLobbyChatUpdate(LobbyChatUpdate_t callback)
	{
		if (callback.m_ulSteamIDLobby != (ulong)currentLobby)
		{
			return;
		}
		uint rgfChatMemberStateChange = callback.m_rgfChatMemberStateChange;
		UserData userData = callback.m_ulSteamIDUserChanged;
		if (rgfChatMemberStateChange == 1)
		{
			Debug.Log("[SteamLobbyManager] Oyuncu katıldı: " + userData.Name);
			if (isHost && currentLobby.MemberCount > maxPlayers)
			{
				CSteamID steamID = SteamUser.GetSteamID();
				if (userData.id != steamID)
				{
					Debug.Log("[SteamLobbyManager] Lobby dolu! Oyuncu kickleniyor: " + userData.Name);
					currentLobby.KickMember(userData);
					return;
				}
			}
			UpdatePlayerCount();
			onPlayerJoined?.Invoke(userData);
			this.OnPlayerJoinedEvent?.Invoke(userData);
		}
		else
		{
			Debug.Log("[SteamLobbyManager] Oyuncu ayrıldı: " + userData.Name);
			UpdatePlayerCount();
			onPlayerLeft?.Invoke(userData);
			this.OnPlayerLeftEvent?.Invoke(userData);
		}
	}

	private void HandleLobbyLeave(LobbyData lobby)
	{
		if (lobby == currentLobby)
		{
			Debug.Log("[SteamLobbyManager] Lobby'den ayrıldık");
			currentLobby = default(LobbyData);
			currentLobbyCode = null;
			isHost = false;
			onLobbyLeft?.Invoke();
			this.OnLobbyLeftEvent?.Invoke();
		}
	}

	private void HandleAskedToLeave(LobbyData lobby)
	{
		if (lobby == currentLobby)
		{
			Debug.Log("[SteamLobbyManager] Lobby'den çıkarıldık (kicked)");
			LeaveLobby();
			onError?.Invoke("Oyundan atıldınız.");
		}
	}

	private void HandleGameLobbyJoinRequested(LobbyData lobby, UserData friend)
	{
		Debug.Log($"[SteamLobbyManager] Steam davet/join isteği geldi - Lobby: {(ulong)lobby}, Friend: {friend.Name}");
		if (IsInLobby)
		{
			Debug.LogWarning("[SteamLobbyManager] Zaten bir lobby'desin, davet reddedildi.");
		}
		else
		{
			this.OnSteamInviteReceived?.Invoke(lobby, friend);
		}
	}

	private void UpdatePlayerCount()
	{
		if (isHost && IsInLobby)
		{
			currentLobby["PlayerCount"] = currentLobby.MemberCount.ToString();
		}
	}

	public bool IsJoinEnabled()
	{
		if (!IsInLobby)
		{
			return false;
		}
		return SteamMatchmaking.GetLobbyData(currentLobby, "JoinEnabled") == "1";
	}

	public void StartMirrorHost()
	{
		if (!IsInLobby || !isHost)
		{
			Debug.LogWarning("[SteamLobbyManager] Mirror Host başlatılamaz - Önce lobby oluşturulmalı!");
			return;
		}
		if (networkManager == null)
		{
			networkManager = UnityEngine.Object.FindFirstObjectByType<NewNetworkManager>();
		}
		if (networkManager != null)
		{
			networkManager.StartHostSafe();
			Debug.Log("[SteamLobbyManager] Mirror Host başlatıldı");
		}
		else
		{
			Debug.LogError("[SteamLobbyManager] NetworkManager bulunamadı!");
		}
	}

	public void StartMirrorClient()
	{
		if (!IsInLobby || isHost)
		{
			Debug.LogWarning("[SteamLobbyManager] Mirror Client başlatılamaz - Önce lobby'e katılmalı!");
			return;
		}
		if (networkManager == null)
		{
			networkManager = UnityEngine.Object.FindFirstObjectByType<NewNetworkManager>();
		}
		if (networkManager != null)
		{
			UserData user = currentLobby.Owner.user;
			string text = user.id.m_SteamID.ToString();
			networkManager.networkAddress = text;
			networkManager.StartClientSafe(text);
			Debug.Log("[SteamLobbyManager] Mirror Client başlatıldı, bağlanılıyor: " + text);
		}
		else
		{
			Debug.LogError("[SteamLobbyManager] NetworkManager bulunamadı!");
		}
	}

	public void CreateLobbyAndStartHost(bool isPrivate)
	{
		if (IsInLobby)
		{
			LeaveLobby();
		}
		pendingIsPrivate = isPrivate;
		string text = (pendingIsPrivate ? LocalizationManager.GetTranslation("Invite Only") : LocalizationManager.GetTranslation("Public"));
		Debug.Log("[SteamLobbyManager] Lobby oluşturuluyor ve host başlatılıyor... Type: " + text);
		Matchmaking.Client.CreateLobby(ELobbyType.k_ELobbyTypePublic, lobbySlots, delegate(EResult result, LobbyData lobby, bool ioError)
		{
			OnLobbyCreatedCallback(result, lobby, ioError);
			if (!ioError && result == EResult.k_EResultOK)
			{
				StartMirrorHost();
			}
		});
	}

	[Obsolete("Use CreateLobbyAndStartHost(bool isPrivate) instead")]
	public void CreateLobbyAndStartHost(ELobbyType lobbyType)
	{
		bool isPrivate = lobbyType == ELobbyType.k_ELobbyTypePrivate;
		CreateLobbyAndStartHost(isPrivate);
	}

	public void JoinLobbyAndStartClient(LobbyData lobby)
	{
		if (IsInLobby)
		{
			LeaveLobby();
		}
		Debug.Log($"[SteamLobbyManager] Lobby'e katılınıyor ve client başlatılıyor: {lobby}");
		Matchmaking.Client.JoinLobby(lobby, delegate(LobbyEnter result, bool ioError)
		{
			if (ioError)
			{
				string text = "Lobby'e katılma başarısız: IO Error";
				Debug.LogError("[SteamLobbyManager] " + text);
				onError?.Invoke(text);
			}
			else if (result.Response != EChatRoomEnterResponse.k_EChatRoomEnterResponseSuccess)
			{
				string text2 = $"Lobby'e katılma başarısız: {result.Response}";
				Debug.LogError("[SteamLobbyManager] " + text2);
				onError?.Invoke(text2);
			}
			else
			{
				StartCoroutine(StartMirrorClientDelayed());
			}
		});
	}

	private IEnumerator StartMirrorClientDelayed()
	{
		yield return new WaitForSeconds(0.1f);
		LoadingManagerUI.Hide(LoadingType.JoiningRoom);
		LoadingManagerUI.Show(LoadingType.Scene);
		Debug.Log("[SteamLobbyManager] Host'un hazır olması bekleniyor (JoinEnabled)...");
		yield return new WaitUntil(() => IsJoinEnabled());
		Debug.Log("[SteamLobbyManager] Host hazır, Mirror Client başlatılıyor...");
		yield return new WaitForSeconds(0.5f);
		StartMirrorClient();
	}

	public LobbyInfo GetLobbyInfo(LobbyData lobby)
	{
		bool isPrivate = lobby["IsPrivate"] == "1";
		return new LobbyInfo
		{
			lobbyId = lobby,
			lobbyName = lobby["LobbyName"],
			ownerName = lobby["OwnerName"],
			lobbyCode = lobby["LobbyCode"],
			version = lobby["Version"],
			lobbyType = GetLobbyType(lobby),
			playerCount = lobby.MemberCount,
			maxPlayers = maxPlayers,
			isPrivate = isPrivate
		};
	}

	public ELobbyType GetLobbyType(LobbyData lobby)
	{
		if (int.TryParse(lobby["LobbyType"], out var result))
		{
			return (ELobbyType)result;
		}
		return ELobbyType.k_ELobbyTypePublic;
	}

	public static string GetLobbyTypeString(ELobbyType type)
	{
		return type switch
		{
			ELobbyType.k_ELobbyTypePublic => "Public", 
			ELobbyType.k_ELobbyTypeFriendsOnly => "Friends Only", 
			ELobbyType.k_ELobbyTypePrivate => "Private", 
			_ => "Unknown", 
		};
	}
}
