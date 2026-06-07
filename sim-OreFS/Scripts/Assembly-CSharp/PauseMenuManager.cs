using System.Collections;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using Heathen.SteamworksIntegration;
using I2.Loc;
using Mirror;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
	[Header("Pause Menu UI")]
	public GameObject pauseMenuPanel;

	public GameObject resqueInfoObj;

	public Button returnToMenuButton;

	public Button quickSaveButton;

	[Tooltip("Save notice açıldığında kapatılacak ana menü objesi")]
	public GameObject menuObj;

	[Header("Save Notice Panel")]
	[Tooltip("Çıkışta kaydetmek isteyip istemediğini soran panel")]
	public GameObject saveNoticePanel;

	public Button saveAndExitButton;

	public Button exitWithoutSaveButton;

	[Header("Saving Panel")]
	[Tooltip("Save işlemi sırasında gösterilecek panel")]
	public GameObject savingPanel;

	[Header("Connection Details Panel")]
	[Tooltip("Online olduğunda aktif olacak panel")]
	public GameObject connectionDetailsPanel;

	[Header("Lobby Code Section")]
	public TextMeshProUGUI lobbyCodeText;

	public Button toggleCodeVisibilityButton;

	[Tooltip("Kod gizliyken gösterilecek sprite (göz kapalı)")]
	public Sprite codeHiddenSprite;

	[Tooltip("Kod görünürken gösterilecek sprite (göz açık)")]
	public Sprite codeVisibleSprite;

	private Image toggleButtonImage;

	private bool isCodeVisible;

	[Header("Lobby Privacy Section")]
	public Button lobbyPrivacyButton;

	public TextMeshProUGUI lobbyPrivacyText;

	private static bool isCurrentLobbyPrivate;

	[Header("Player List Section")]
	public Transform playerListContainer;

	public GameObject playerListItemPrefab;

	[Tooltip("Player list'in sonunda gösterilecek davet butonu")]
	public GameObject inviteButtonObj;

	[Header("Settings")]
	[Tooltip("Kick sonrası ana menüye dönmeden önce bekleme süresi")]
	public float kickedWaitTime = 2f;

	[Header("Main Menu Scene")]
	[Tooltip("Ana menü sahnesinin adı")]
	public string mainMenuSceneName = "MainMenuScene";

	private Dictionary<int, PlayerListItemUI> playerListItems = new Dictionary<int, PlayerListItemUI>();

	public static PauseMenuManager Instance { get; private set; }

	private NewNetworkManager NetManager => NetworkManager.singleton as NewNetworkManager;

	private CSteamID CurrentLobbyId
	{
		get
		{
			if (!(NetManager != null))
			{
				return CSteamID.Nil;
			}
			return NetManager.currentSteamLobbyID;
		}
	}

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		SetupButtonListeners();
		if (toggleCodeVisibilityButton != null)
		{
			toggleButtonImage = toggleCodeVisibilityButton.GetComponent<Image>();
		}
		if (NetManager != null)
		{
			NetManager.OnPlayerListChanged += OnPlayerListChanged;
		}
		StartCoroutine(DelayedUIUpdate());
	}

	public void TrySaveGame()
	{
		if (SaveLoadGameManager.Instance != null)
		{
			SaveLoadGameManager.Instance.SaveGame();
		}
	}

	public void RefreshSaveButtonState()
	{
		if (!(quickSaveButton == null))
		{
			bool interactable = SaveLoadGameManager.Instance != null && SaveLoadGameManager.Instance.CanSaveNow;
			quickSaveButton.interactable = interactable;
		}
	}

	private IEnumerator DelayedUIUpdate()
	{
		yield return new WaitForSecondsRealtime(0.5f);
		UpdateConnectionDetailsVisibility();
		RefreshSaveButtonState();
	}

	private void OnDestroy()
	{
		if (NetManager != null)
		{
			NetManager.OnPlayerListChanged -= OnPlayerListChanged;
		}
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void OnPlayerListChanged()
	{
		RefreshPlayerList();
	}

	private void SetupButtonListeners()
	{
		if (returnToMenuButton != null)
		{
			returnToMenuButton.onClick.AddListener(OnReturnToMenuClicked);
		}
		if (toggleCodeVisibilityButton != null)
		{
			toggleCodeVisibilityButton.onClick.AddListener(OnToggleCodeVisibilityClicked);
		}
		if (lobbyPrivacyButton != null)
		{
			lobbyPrivacyButton.onClick.AddListener(OnLobbyPrivacyButtonClicked);
		}
		if (saveAndExitButton != null)
		{
			saveAndExitButton.onClick.AddListener(OnSaveAndExitClicked);
		}
		if (exitWithoutSaveButton != null)
		{
			exitWithoutSaveButton.onClick.AddListener(OnExitWithoutSaveClicked);
		}
	}

	private bool IsMultiplayer()
	{
		if (NetManager != null)
		{
			return !string.IsNullOrEmpty(NetManager.currentLobbyCode);
		}
		return false;
	}

	private bool IsHost()
	{
		return NetworkServer.active;
	}

	private string GetLobbyCode()
	{
		return NetManager?.currentLobbyCode;
	}

	public static CSteamID GetCurrentLobbyId()
	{
		NewNetworkManager newNetworkManager = NetworkManager.singleton as NewNetworkManager;
		if (!(newNetworkManager != null))
		{
			return CSteamID.Nil;
		}
		return newNetworkManager.currentSteamLobbyID;
	}

	private void OnLobbyPrivacyButtonClicked()
	{
		if (IsHost() && !(CurrentLobbyId == CSteamID.Nil) && CurrentLobbyId.IsValid())
		{
			bool flag = !isCurrentLobbyPrivate;
			ELobbyType eLobbyType = ((!flag) ? ELobbyType.k_ELobbyTypePublic : ELobbyType.k_ELobbyTypePrivate);
			bool flag2 = SteamMatchmaking.SetLobbyType(CurrentLobbyId, eLobbyType);
			if (flag2)
			{
				isCurrentLobbyPrivate = flag;
				SteamMatchmaking.SetLobbyData(CurrentLobbyId, "IsPrivate", flag ? "1" : "0");
				CSteamID currentLobbyId = CurrentLobbyId;
				int num = (int)eLobbyType;
				SteamMatchmaking.SetLobbyData(currentLobbyId, "LobbyType", num.ToString());
				UpdateLobbyPrivacyText();
			}
			Debug.Log(string.Format("[PauseMenuManager] Lobby tipi değiştirildi: {0}, Success: {1}", flag ? "Private" : "Public", flag2));
		}
	}

	private void UpdateLobbyPrivacyButton()
	{
		bool active = IsHost();
		if (lobbyPrivacyButton != null)
		{
			lobbyPrivacyButton.gameObject.SetActive(active);
		}
		if (!(CurrentLobbyId == CSteamID.Nil) && CurrentLobbyId.IsValid())
		{
			isCurrentLobbyPrivate = SteamMatchmaking.GetLobbyData(CurrentLobbyId, "IsPrivate") == "1";
			UpdateLobbyPrivacyText();
			Debug.Log("[PauseMenuManager] Lobby privacy güncellendi: " + (isCurrentLobbyPrivate ? "Private" : "Public"));
		}
	}

	private void UpdateLobbyPrivacyText()
	{
		if (!(lobbyPrivacyText == null))
		{
			lobbyPrivacyText.text = (isCurrentLobbyPrivate ? LocalizationManager.GetTranslation("Invite Only") : LocalizationManager.GetTranslation("Public"));
		}
	}

	public void RefreshLobbyPrivacyText()
	{
		UpdateLobbyPrivacyButton();
	}

	public void UpdateConnectionDetailsVisibility()
	{
		bool flag = IsMultiplayer();
		Debug.Log($"[PauseMenuManager] UpdateConnectionDetailsVisibility - IsMultiplayer: {flag}, LobbyCode: {GetLobbyCode()}");
		if (connectionDetailsPanel != null)
		{
			connectionDetailsPanel.SetActive(flag);
		}
		if (flag)
		{
			isCodeVisible = false;
			UpdateLobbyCodeDisplay();
			UpdateLobbyPrivacyButton();
			RefreshPlayerList();
		}
		else
		{
			ClearPlayerList();
			if (lobbyPrivacyButton != null)
			{
				lobbyPrivacyButton.gameObject.SetActive(value: false);
			}
		}
	}

	private void OnToggleCodeVisibilityClicked()
	{
		isCodeVisible = !isCodeVisible;
		UpdateLobbyCodeDisplay();
	}

	private void UpdateLobbyCodeDisplay()
	{
		if (lobbyCodeText == null)
		{
			return;
		}
		string lobbyCode = GetLobbyCode();
		if (isCodeVisible)
		{
			lobbyCodeText.text = lobbyCode ?? "------";
			if (toggleButtonImage != null && codeVisibleSprite != null)
			{
				toggleButtonImage.sprite = codeVisibleSprite;
			}
		}
		else
		{
			lobbyCodeText.text = "******";
			if (toggleButtonImage != null && codeHiddenSprite != null)
			{
				toggleButtonImage.sprite = codeHiddenSprite;
			}
		}
	}

	public void RefreshPlayerList()
	{
		StartCoroutine(RefreshPlayerListActions());
	}

	private IEnumerator RefreshPlayerListActions()
	{
		yield return new WaitForSecondsRealtime(2f);
		if (NetManager == null)
		{
			Debug.Log("[PauseMenuManager] RefreshPlayerList - NetManager bulunamadı");
			ClearPlayerList();
			yield break;
		}
		if (playerListContainer == null || playerListItemPrefab == null)
		{
			Debug.LogWarning("[PauseMenuManager] RefreshPlayerList - Container veya Prefab atanmamış!");
			yield break;
		}
		List<GamePlayer> gamePlayers = NetManager.GamePlayers;
		Debug.Log($"[PauseMenuManager] RefreshPlayerList - {gamePlayers.Count} oyuncu bulundu");
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, PlayerListItemUI> playerListItem in playerListItems)
		{
			bool flag = false;
			foreach (GamePlayer item in gamePlayers)
			{
				if (item != null && item.ownerConnectionId == playerListItem.Key)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				list.Add(playerListItem.Key);
			}
		}
		foreach (int item2 in list)
		{
			if (playerListItems.TryGetValue(item2, out var value) && value != null)
			{
				Object.Destroy(value.gameObject);
			}
			playerListItems.Remove(item2);
		}
		foreach (GamePlayer item3 in gamePlayers)
		{
			if (item3 != null)
			{
				SpawnPlayerListItem(item3);
			}
		}
		UpdateInviteButton(gamePlayers.Count);
	}

	private void UpdateInviteButton(int playerCount)
	{
		if (!(inviteButtonObj == null))
		{
			bool flag = IsMultiplayer() && playerCount < 4;
			inviteButtonObj.SetActive(flag);
			if (flag)
			{
				inviteButtonObj.transform.SetAsLastSibling();
			}
		}
	}

	public void OpenSteamInviteOverlay()
	{
		CSteamID currentLobbyId = CurrentLobbyId;
		if (currentLobbyId == CSteamID.Nil || !currentLobbyId.IsValid())
		{
			Debug.LogWarning("[PauseMenuManager] Steam invite açılamadı - geçerli lobby yok.");
			return;
		}
		SteamFriends.ActivateGameOverlayInviteDialog(currentLobbyId);
		Debug.Log($"[PauseMenuManager] Steam invite overlay açıldı. LobbyId: {currentLobbyId}");
	}

	private void ClearPlayerList()
	{
		foreach (PlayerListItemUI value in playerListItems.Values)
		{
			if (value != null)
			{
				Object.Destroy(value.gameObject);
			}
		}
		playerListItems.Clear();
		if (inviteButtonObj != null)
		{
			inviteButtonObj.SetActive(value: false);
		}
	}

	private void SpawnPlayerListItem(GamePlayer gamePlayer)
	{
		if (!(playerListContainer == null) && !(playerListItemPrefab == null) && !playerListItems.ContainsKey(gamePlayer.ownerConnectionId))
		{
			GameObject gameObject = Object.Instantiate(playerListItemPrefab, playerListContainer);
			if (!gameObject.activeSelf)
			{
				gameObject.SetActive(value: true);
			}
			PlayerListItemUI component = gameObject.GetComponent<PlayerListItemUI>();
			if (component != null)
			{
				bool isLocalPlayer = gamePlayer.isLocalPlayer;
				bool flag = IsHost() && !isLocalPlayer;
				component.Initialize(gamePlayer, flag, OnKickPlayerClicked);
				playerListItems[gamePlayer.ownerConnectionId] = component;
				Debug.Log($"[PauseMenuManager] Player list item spawn edildi: {gamePlayer.playerName} (ConnectionId: {gamePlayer.ownerConnectionId}, CanKick: {flag}, Active: {gameObject.activeSelf})");
			}
			else
			{
				Debug.LogWarning("[PauseMenuManager] Prefab'da PlayerListItemUI component'i bulunamadı!");
				Object.Destroy(gameObject);
			}
		}
	}

	public void ShowSavingPanel()
	{
		if (savingPanel != null)
		{
			savingPanel.SetActive(value: true);
		}
	}

	public void HideSavingPanel()
	{
		if (savingPanel != null)
		{
			savingPanel.SetActive(value: false);
		}
	}

	public void TutorialChecker()
	{
		if (TutorialManager.Instance != null && !TutorialManager.Instance.IsTutorialRunning)
		{
			NetworkIdentity localPlayer = NetworkClient.localPlayer;
			if (localPlayer == null)
			{
				return;
			}
			GamePlayer component = localPlayer.GetComponent<GamePlayer>();
			if (!(component == null))
			{
				if (component.isInDigsite)
				{
					resqueInfoObj.SetActive(value: true);
				}
				else
				{
					resqueInfoObj.SetActive(value: false);
				}
			}
		}
		else
		{
			resqueInfoObj.SetActive(value: false);
		}
	}

	public void OnEmergencyRescueClicked()
	{
		NetworkIdentity localPlayer = NetworkClient.localPlayer;
		if (!(localPlayer == null))
		{
			GamePlayer component = localPlayer.GetComponent<GamePlayer>();
			if (!(component == null))
			{
				component.EmergencyRescue();
				Debug.Log("[PauseMenuManager] Emergency Rescue tetiklendi.");
			}
		}
	}

	public void OpenCustomization()
	{
		if (GameManager.Instance != null)
		{
			GameManager.Instance.OpenCustomization();
		}
	}

	private void OnReturnToMenuClicked()
	{
		if (SaveLoadGameManager.Instance != null && SaveLoadGameManager.Instance.CanSaveNow && saveNoticePanel != null)
		{
			if (menuObj != null)
			{
				menuObj.SetActive(value: false);
			}
			saveNoticePanel.SetActive(value: true);
		}
		else
		{
			StartCoroutine(ExitToMenuCoroutine(saveFirst: false));
		}
	}

	private void OnSaveAndExitClicked()
	{
		if (saveNoticePanel != null)
		{
			saveNoticePanel.SetActive(value: false);
		}
		StartCoroutine(ExitToMenuCoroutine(saveFirst: true));
	}

	private void OnExitWithoutSaveClicked()
	{
		if (saveNoticePanel != null)
		{
			saveNoticePanel.SetActive(value: false);
		}
		StartCoroutine(ExitToMenuCoroutine(saveFirst: false));
	}

	private IEnumerator ExitToMenuCoroutine(bool saveFirst)
	{
		bool saveCompleted;
		if (saveFirst)
		{
			saveCompleted = false;
			if (Singleton<SaveLoadManager>.Instance != null)
			{
				Singleton<SaveLoadManager>.Instance.EventAfterSave += OnSaveCompleted;
			}
			SaveLoadGameManager.Instance.SaveGame();
			float timeout = 15f;
			float elapsed = 0f;
			while (!saveCompleted && elapsed < timeout)
			{
				elapsed += Time.unscaledDeltaTime;
				yield return null;
			}
			if (Singleton<SaveLoadManager>.Instance != null)
			{
				Singleton<SaveLoadManager>.Instance.EventAfterSave -= OnSaveCompleted;
			}
			yield return new WaitForSecondsRealtime(2f);
			HideSavingPanel();
			Debug.Log($"[PauseMenuManager] Save tamamlandı (elapsed: {elapsed:F1}s), menüye dönülüyor...");
		}
		NewNetworkManager.SetDisconnectReason(DisconnectReason.Manual);
		LoadingManagerUI.Show(LoadingType.Menu);
		if (pauseMenuPanel != null)
		{
			pauseMenuPanel.SetActive(value: false);
		}
		yield return new WaitForSecondsRealtime(0.5f);
		if (NetManager != null)
		{
			NetManager.StopAllNetworking();
		}
		LeaveSteamLobby();
		yield return new WaitForSecondsRealtime(0.5f);
		SceneManager.LoadScene(mainMenuSceneName);
		void OnSaveCompleted(int slot)
		{
			saveCompleted = true;
		}
	}

	private void OnKickPlayerClicked(GamePlayer gamePlayer)
	{
		Debug.Log("[PauseMenuManager] Oyuncu onId: )");
		if (IsHost() && !(gamePlayer == null))
		{
			Debug.Log($"[PauseMenuManager] Oyuncu kickleniyor: {gamePlayer.playerName} (ConnectionId: {gamePlayer.ownerConnectionId})");
			if (gamePlayer.playerSteamId != 0L && CurrentLobbyId != CSteamID.Nil && CurrentLobbyId.IsValid())
			{
				LobbyData lobbyData = CurrentLobbyId.m_SteamID;
				UserData memberId = new CSteamID(gamePlayer.playerSteamId);
				lobbyData.KickMember(memberId);
			}
			gamePlayer.ServerKickPlayer();
		}
	}

	public static void LeaveSteamLobby()
	{
		CSteamID currentLobbyId = GetCurrentLobbyId();
		if (currentLobbyId != CSteamID.Nil && currentLobbyId.IsValid())
		{
			Debug.Log($"[PauseMenuManager] Steam lobby'den ayrılınıyor: {currentLobbyId}");
			SteamMatchmaking.LeaveLobby(currentLobbyId);
		}
	}

	public static void HandleKicked()
	{
		NewNetworkManager.SetDisconnectReason(DisconnectReason.Kicked);
		LeaveSteamLobby();
		LoadingManagerUI.Show(LoadingType.Menu);
		if (Instance != null)
		{
			Instance.StartCoroutine(Instance.HandleKickedCoroutine());
		}
		else
		{
			CoroutineHelper.Instance.StartCoroutine(HandleKickedStatic());
		}
	}

	private static IEnumerator HandleKickedStatic()
	{
		yield return new WaitForSecondsRealtime(2f);
		SceneManager.LoadScene("MainMenuScene");
	}

	private IEnumerator HandleKickedCoroutine()
	{
		yield return new WaitForSecondsRealtime(kickedWaitTime);
		SceneManager.LoadScene(mainMenuSceneName);
	}
}
