using System;
using System.Collections;
using System.Text.RegularExpressions;
using Fullscreen.NanoSave.Runtime;
using GameCreator.Runtime.Common;
using GameCreator.Runtime.Variables;
using Heathen.SteamworksIntegration;
using Kamgam.UGUIComponentsForSettings;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	private enum DemoNextAction
	{
		None = 0,
		StartSinglePlayer = 1,
		OpenConnectionPopup = 2,
		ShowSaveSlotSinglePlayer = 3,
		ShowSaveSlotMultiplayer = 4
	}

	[Header("References")]
	public NewNetworkManager networkManager;

	public SteamLobbyManager lobbyManager;

	public InternetConnectionChecker internetChecker;

	public ServerBrowserUI serverBrowser;

	[Header("Main Menu UI")]
	public GameObject mainMenuPanel;

	public Button singlePlayerButton;

	[Header("Misc")]
	public GameObject settingsPanel;

	public GameObject inputInfoUI;

	public GameObject creditsPanel;

	[Header("Save Slot UI")]
	[Tooltip("Save slot seçim paneli - Continue/New Game butonları")]
	public GameObject saveSlotPanel;

	[Tooltip("Ana menü butonları - SaveSlot açılınca kapanır")]
	public GameObject menuButtons;

	[Header("Save Slot Variables")]
	[Tooltip("GameCreator GlobalNameVariables - Save slot değişkenini içeren asset")]
	[SerializeField]
	private GlobalNameVariables saveSlotVariables;

	[Tooltip("Save slot değişkeninin adı (int olarak okunacak)")]
	[SerializeField]
	private string saveSlotVariableName = "SaveSlot";

	[Header("Multiplayer Buttons")]
	public Button joinButton;

	public Button newGameButton;

	[Header("Host Settings - Lobby Type Selector")]
	[Tooltip("OptionsButtonUGUI - Lobby tipi seçici (0: Public, 1: Friends Only, 2: Private)")]
	public OptionsButtonUGUI lobbyTypeSelector;

	[Tooltip("Next butonu - odayı oluştur")]
	public Button createLobbyButton;

	[Header("Join Panel")]
	public TMP_InputField lobbyCodeInput;

	public Button joinByCodeButton;

	[Header("Demo UI")]
	[Tooltip("Demo bilgilendirme paneli - oyun demo ise gösterilir")]
	public GameObject demoInfoPanel;

	[Tooltip("Demo panelindeki Next butonu")]
	public Button demoNextButton;

	[Header("Connection Popup")]
	[Tooltip("Multiplayer bağlantı popup'ı - Host/Join seçenekleri")]
	public GameObject connectionPopup;

	[Header("Popup Panels")]
	[Tooltip("İnternet bağlantısı yok popup'ı")]
	public GameObject noInternetPopup;

	[Tooltip("Versiyon uyumsuzluğu popup'ı")]
	public GameObject versionMismatchPopup;

	[Tooltip("Bağlantı koptu popup'ı")]
	public GameObject connectionLostPopup;

	[Tooltip("Kicklendin popup'ı")]
	public GameObject kickedPopup;

	[Tooltip("Host tutorial tamamlamadı popup'ı")]
	public GameObject hostTutorialNotCompletedPopup;

	[Tooltip("Demo bitti popup'ı")]
	public GameObject demoFinishedPopup;

	[Header("Version Check")]
	[Tooltip("Beklenen minimum versiyon (boş bırakılırsa kontrol yapılmaz)")]
	public string requiredVersion = "";

	[Tooltip("Versiyon kontrol URL'i (opsiyonel - web'den versiyon çekmek için)")]
	public string versionCheckUrl = "";

	[Header("Events")]
	public UnityEvent onSinglePlayerSelected;

	public UnityEvent onMultiplayerSelected;

	public UnityEvent onGameStarted;

	public UnityEvent onInternetCheckFailed;

	public UnityEvent onVersionCheckFailed;

	private bool selectedIsPrivate;

	private bool isCheckingMultiplayer;

	private bool isConnecting;

	private DemoNextAction pendingDemoAction;

	public static MainMenuManager Instance { get; private set; }

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
		InitializeUI();
		SetupButtonListeners();
		SetupEventListeners();
		ShowMainMenu();
		StartCoroutine(HideLoadingAfterDelay(2f));
		MusicManager.Instance.ChangeMusic(MusicManager.MusicMode.MainMenu);
		CheckDisconnectReason();
	}

	private IEnumerator HideLoadingAfterDelay(float delay)
	{
		yield return new WaitForSeconds(delay);
		LoadingManagerUI.HideAll();
	}

	private void OnDestroy()
	{
		RemoveEventListeners();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	private void CheckDisconnectReason()
	{
		if (!NewNetworkManager.WasInMultiplayerSession)
		{
			Debug.Log("[MainMenuManager] Multiplayer oturumundan dönülmedi - popup yok");
			return;
		}
		switch (NewNetworkManager.LastDisconnectReason)
		{
		case DisconnectReason.ConnectionLost:
			if (connectionLostPopup != null)
			{
				connectionLostPopup.SetActive(value: true);
				mainMenuPanel.SetActive(value: false);
				Debug.Log("[MainMenuManager] Bağlantı koptu popup gösterildi");
			}
			break;
		case DisconnectReason.Kicked:
			if (kickedPopup != null)
			{
				kickedPopup.SetActive(value: true);
				mainMenuPanel.SetActive(value: false);
				Debug.Log("[MainMenuManager] Kicklendin popup gösterildi");
			}
			break;
		case DisconnectReason.Manual:
			Debug.Log("[MainMenuManager] Manuel çıkış - popup yok");
			break;
		case DisconnectReason.DemoFinished:
			if (demoFinishedPopup != null)
			{
				demoFinishedPopup.SetActive(value: true);
				mainMenuPanel.SetActive(value: false);
				Debug.Log("[MainMenuManager] Demo bitti popup gösterildi");
			}
			break;
		}
		NewNetworkManager.ResetDisconnectReason();
	}

	private void InitializeUI()
	{
		if (lobbyTypeSelector != null)
		{
			lobbyTypeSelector.SelectedIndex = 0;
			OptionsButtonUGUI optionsButtonUGUI = lobbyTypeSelector;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Combine(optionsButtonUGUI.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnLobbyTypeSelectorChanged));
		}
	}

	private void SetupButtonListeners()
	{
		if (singlePlayerButton != null)
		{
			singlePlayerButton.onClick.AddListener(OnSinglePlayerClicked);
		}
		if (joinButton != null)
		{
			joinButton.onClick.AddListener(OnJoinClicked);
		}
		if (newGameButton != null)
		{
			newGameButton.onClick.AddListener(OnNewGameClicked);
		}
		if (createLobbyButton != null)
		{
			createLobbyButton.onClick.AddListener(OnCreateLobbyClicked);
		}
		if (joinByCodeButton != null)
		{
			joinByCodeButton.onClick.AddListener(OnJoinByCodeClicked);
		}
		if (demoNextButton != null)
		{
			demoNextButton.onClick.AddListener(OnDemoNextClicked);
		}
	}

	private void SetupEventListeners()
	{
		if (internetChecker != null)
		{
			internetChecker.OnConnectionStatusChanged += OnInternetStatusChanged;
		}
		if (lobbyManager != null)
		{
			lobbyManager.OnLobbyCreatedEvent += OnLobbyCreated;
			lobbyManager.OnLobbyJoinedEvent += OnLobbyJoined;
			lobbyManager.OnLobbyLeftEvent += OnLobbyLeft;
			lobbyManager.OnPlayerJoinedEvent += OnPlayerJoined;
			lobbyManager.OnPlayerLeftEvent += OnPlayerLeft;
			lobbyManager.onError.AddListener(OnLobbyError);
			lobbyManager.OnJoinBlockedByTutorial += OnJoinBlockedByTutorial;
			lobbyManager.OnSteamInviteReceived += OnSteamInviteReceived;
		}
	}

	private void RemoveEventListeners()
	{
		if (internetChecker != null)
		{
			internetChecker.OnConnectionStatusChanged -= OnInternetStatusChanged;
		}
		if (lobbyManager != null)
		{
			lobbyManager.OnLobbyCreatedEvent -= OnLobbyCreated;
			lobbyManager.OnLobbyJoinedEvent -= OnLobbyJoined;
			lobbyManager.OnLobbyLeftEvent -= OnLobbyLeft;
			lobbyManager.OnPlayerJoinedEvent -= OnPlayerJoined;
			lobbyManager.OnPlayerLeftEvent -= OnPlayerLeft;
			lobbyManager.onError.RemoveListener(OnLobbyError);
			lobbyManager.OnJoinBlockedByTutorial -= OnJoinBlockedByTutorial;
			lobbyManager.OnSteamInviteReceived -= OnSteamInviteReceived;
		}
		if (lobbyTypeSelector != null)
		{
			OptionsButtonUGUI optionsButtonUGUI = lobbyTypeSelector;
			optionsButtonUGUI.OnValueChanged = (OptionsButtonUGUI.OnValueChangedDelegate)Delegate.Remove(optionsButtonUGUI.OnValueChanged, new OptionsButtonUGUI.OnValueChangedDelegate(OnLobbyTypeSelectorChanged));
		}
	}

	private void ShowNoInternetPopup()
	{
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: false);
		}
		if (noInternetPopup != null)
		{
			noInternetPopup.SetActive(value: true);
		}
		Debug.LogWarning("[MainMenuManager] İnternet bağlantısı yok popup gösterildi");
		onInternetCheckFailed?.Invoke();
	}

	private void ShowVersionMismatchPopup(string currentVersion, string requiredVer)
	{
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: false);
		}
		if (versionMismatchPopup != null)
		{
			versionMismatchPopup.SetActive(value: true);
		}
		Debug.LogWarning("[MainMenuManager] Versiyon uyumsuzluğu: " + currentVersion + " != " + requiredVer);
		onVersionCheckFailed?.Invoke();
	}

	public void ShowMainMenu()
	{
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
		UpdateInternetStatus();
	}

	public void ShowSettingsPanel()
	{
		if (settingsPanel != null)
		{
			if (mainMenuPanel != null)
			{
				mainMenuPanel.SetActive(value: false);
			}
			settingsPanel.SetActive(value: true);
		}
	}

	public void HideSettingsPanel()
	{
		if (settingsPanel != null)
		{
			if (mainMenuPanel != null)
			{
				mainMenuPanel.SetActive(value: true);
			}
			settingsPanel.SetActive(value: false);
		}
	}

	public void ShowCreditsPanel()
	{
		if (creditsPanel != null)
		{
			if (mainMenuPanel != null)
			{
				mainMenuPanel.SetActive(value: false);
			}
			creditsPanel.SetActive(value: true);
		}
	}

	public void HideCreditsPanel()
	{
		if (creditsPanel != null)
		{
			if (mainMenuPanel != null)
			{
				mainMenuPanel.SetActive(value: true);
			}
			creditsPanel.SetActive(value: false);
		}
	}

	public void ShowHostSettingsPanel()
	{
		if (lobbyTypeSelector != null)
		{
			lobbyTypeSelector.SelectedIndex = 0;
		}
		selectedIsPrivate = false;
	}

	public void ShowLoadingUI(LoadingType loadingType = LoadingType.JoiningRoom)
	{
		LoadingManagerUI.Show(loadingType);
		Debug.Log($"[MainMenuManager] Loading UI açıldı: {loadingType}");
	}

	public void HideLoadingUI()
	{
		LoadingManagerUI.HideAll();
		Debug.Log("[MainMenuManager] Loading UI kapatıldı");
		isConnecting = false;
	}

	private void ShowDemoPanel(DemoNextAction nextAction)
	{
		Debug.Log($"[MainMenuManager] ShowDemoPanel çağrıldı - Aksiyon: {nextAction}");
		pendingDemoAction = nextAction;
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: false);
			Debug.Log("[MainMenuManager] Ana menü paneli kapatıldı");
		}
		if (menuButtons != null)
		{
			menuButtons.SetActive(value: false);
		}
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: true);
			Debug.Log($"[MainMenuManager] Demo paneli açıldı - Next butonuna basıldığında: {nextAction}");
		}
		else
		{
			Debug.LogError("[MainMenuManager] Demo paneli referansı atanmamış! Direkt işleme geçiliyor...");
			OnDemoNextClicked();
		}
	}

	public void HideDemoPanel()
	{
		Debug.Log("[MainMenuManager] Demo paneli kapatılıyor");
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: false);
		}
		if (menuButtons != null)
		{
			menuButtons.SetActive(value: true);
		}
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
		pendingDemoAction = DemoNextAction.None;
	}

	public void ShowConnectionPopup()
	{
		Debug.Log("[MainMenuManager] Connection popup açılıyor...");
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: false);
		}
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: false);
		}
		if (connectionPopup != null)
		{
			connectionPopup.SetActive(value: true);
			Debug.Log("[MainMenuManager] Connection popup aktif edildi");
		}
		else
		{
			Debug.LogError("[MainMenuManager] Connection popup referansı atanmamış!");
		}
	}

	public void HideConnectionPopup()
	{
		Debug.Log("[MainMenuManager] Connection popup kapatılıyor");
		if (connectionPopup != null)
		{
			connectionPopup.SetActive(value: false);
		}
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
	}

	public void ShowSaveSlotUI()
	{
		Debug.Log("[MainMenuManager] SaveSlotUI açılıyor");
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: false);
		}
		if (connectionPopup != null)
		{
			connectionPopup.SetActive(value: false);
		}
		if (menuButtons != null)
		{
			menuButtons.SetActive(value: false);
		}
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
		if (saveSlotPanel != null)
		{
			saveSlotPanel.SetActive(value: true);
		}
		else
		{
			Debug.LogError("[MainMenuManager] SaveSlotPanel referansı atanmamış!");
		}
	}

	public void HideSaveSlotUI()
	{
		Debug.Log("[MainMenuManager] SaveSlotUI kapatılıyor");
		if (saveSlotPanel != null)
		{
			saveSlotPanel.SetActive(value: false);
		}
		if (menuButtons != null)
		{
			menuButtons.SetActive(value: true);
		}
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
	}

	private void OnSinglePlayerClicked()
	{
		if (!isConnecting)
		{
			Debug.Log("[MainMenuManager] Single Player seçildi");
			onSinglePlayerSelected?.Invoke();
			SaveLoadGameManager.SetSinglePlayerMode();
			bool flag = SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo;
			Debug.Log($"[MainMenuManager] Demo durumu: {flag}");
			if (flag)
			{
				Debug.Log("[MainMenuManager] Demo modu aktif - Demo paneli açılıyor (Singleplayer)");
				ShowDemoPanel(DemoNextAction.ShowSaveSlotSinglePlayer);
			}
			else
			{
				Debug.Log("[MainMenuManager] Full versiyon - SaveSlotUI açılıyor (Singleplayer)");
				ShowSaveSlotUI();
			}
		}
	}

	private void OnDemoNextClicked()
	{
		Debug.Log($"[MainMenuManager] Demo Next butonuna basıldı - Pending action: {pendingDemoAction}");
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: false);
		}
		switch (pendingDemoAction)
		{
		case DemoNextAction.StartSinglePlayer:
			Debug.Log("[MainMenuManager] Demo Next → Singleplayer başlatılıyor");
			StartCoroutine(StartSinglePlayerWithLoading());
			break;
		case DemoNextAction.OpenConnectionPopup:
			Debug.Log("[MainMenuManager] Demo Next → Connection popup açılıyor");
			ShowConnectionPopup();
			break;
		case DemoNextAction.ShowSaveSlotSinglePlayer:
			Debug.Log("[MainMenuManager] Demo Next → SaveSlotUI açılıyor (SinglePlayer)");
			SaveLoadGameManager.SetSinglePlayerMode();
			ShowSaveSlotUI();
			break;
		case DemoNextAction.ShowSaveSlotMultiplayer:
			Debug.Log("[MainMenuManager] Demo Next → SaveSlotUI açılıyor (Multiplayer)");
			SaveLoadGameManager.SetMultiplayerMode();
			ShowSaveSlotUI();
			break;
		default:
			Debug.LogWarning("[MainMenuManager] Demo Next → Bilinmeyen aksiyon, ana menüye dönülüyor");
			ShowMainMenu();
			break;
		}
		pendingDemoAction = DemoNextAction.None;
	}

	public void OnMultiplayerClicked()
	{
		Debug.Log("[MainMenuManager] Multiplayer butonuna basıldı");
		bool flag = SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo;
		Debug.Log($"[MainMenuManager] Demo durumu: {flag}");
		if (flag)
		{
			Debug.Log("[MainMenuManager] Demo modu aktif - Demo paneli açılıyor (Multiplayer)");
			ShowDemoPanel(DemoNextAction.OpenConnectionPopup);
		}
		else
		{
			Debug.Log("[MainMenuManager] Full versiyon - Connection popup açılıyor");
			ShowConnectionPopup();
		}
	}

	private IEnumerator StartSinglePlayerWithLoading()
	{
		isConnecting = true;
		ShowLoadingUI(LoadingType.Scene);
		yield return new WaitForSeconds(1.5f);
		if (networkManager != null)
		{
			networkManager.ClearLobbyCode();
			networkManager.StartHostSafe();
		}
	}

	private IEnumerator CheckMultiplayerRequirements(Action onSuccess)
	{
		if (isCheckingMultiplayer)
		{
			yield break;
		}
		isCheckingMultiplayer = true;
		Debug.Log("[MainMenuManager] İnternet kontrolü yapılıyor...");
		bool hasInternet = false;
		bool internetCheckComplete = false;
		if (internetChecker != null)
		{
			internetChecker.CheckNow(delegate(bool result)
			{
				hasInternet = result;
				internetCheckComplete = true;
			});
			float timeout = 5f;
			while (!internetCheckComplete && timeout > 0f)
			{
				timeout -= Time.deltaTime;
				yield return null;
			}
			if (!internetCheckComplete)
			{
				hasInternet = InternetConnectionChecker.IsConnected();
			}
		}
		else
		{
			hasInternet = Application.internetReachability != NetworkReachability.NotReachable;
		}
		if (!hasInternet)
		{
			isCheckingMultiplayer = false;
			ShowNoInternetPopup();
			yield break;
		}
		Debug.Log("[MainMenuManager] İnternet kontrolü başarılı");
		if (!string.IsNullOrEmpty(requiredVersion))
		{
			Debug.Log("[MainMenuManager] Versiyon kontrolü yapılıyor...");
			string currentVersion = Application.version;
			if (!string.IsNullOrEmpty(versionCheckUrl))
			{
				yield return FetchVersionFromWeb();
			}
			if (!IsVersionValid(currentVersion, requiredVersion))
			{
				isCheckingMultiplayer = false;
				ShowVersionMismatchPopup(currentVersion, requiredVersion);
				yield break;
			}
			Debug.Log("[MainMenuManager] Versiyon kontrolü başarılı");
		}
		isCheckingMultiplayer = false;
		Debug.Log("[MainMenuManager] Multiplayer kontrolleri başarılı");
		onMultiplayerSelected?.Invoke();
		onSuccess?.Invoke();
	}

	private IEnumerator FetchVersionFromWeb()
	{
		if (string.IsNullOrEmpty(versionCheckUrl))
		{
			yield break;
		}
		using UnityWebRequest request = UnityWebRequest.Get(versionCheckUrl);
		request.timeout = 5;
		yield return request.SendWebRequest();
		if (request.result == UnityWebRequest.Result.Success)
		{
			string value = request.downloadHandler.text.Trim();
			if (!string.IsNullOrEmpty(value))
			{
				requiredVersion = value;
				Debug.Log("[MainMenuManager] Web'den versiyon alındı: " + requiredVersion);
			}
		}
		else
		{
			Debug.LogWarning("[MainMenuManager] Web'den versiyon alınamadı: " + request.error);
		}
	}

	private bool IsVersionValid(string current, string required)
	{
		if (string.IsNullOrEmpty(required))
		{
			return true;
		}
		if (current == required)
		{
			return true;
		}
		try
		{
			string[] array = current.Split('.');
			string[] array2 = required.Split('.');
			for (int i = 0; i < Math.Max(array.Length, array2.Length); i++)
			{
				int result;
				int num = ((i < array.Length && int.TryParse(array[i], out result)) ? result : 0);
				int result2;
				int num2 = ((i < array2.Length && int.TryParse(array2[i], out result2)) ? result2 : 0);
				if (num < num2)
				{
					return false;
				}
				if (num > num2)
				{
					return true;
				}
			}
			return true;
		}
		catch
		{
			return string.Compare(current, required, StringComparison.OrdinalIgnoreCase) >= 0;
		}
	}

	private void OnJoinClicked()
	{
		Debug.Log("[MainMenuManager] Join butonuna basıldı");
		bool flag = SteamAppChecker.Instance != null && SteamAppChecker.Instance.IsDemo;
		Debug.Log($"[MainMenuManager] Demo durumu: {flag}");
		StartCoroutine(CheckMultiplayerRequirements(delegate
		{
			if (serverBrowser != null)
			{
				serverBrowser.Show();
				serverBrowser.RefreshLobbyList();
			}
		}));
	}

	private void OnNewGameClicked()
	{
		Debug.Log("[MainMenuManager] New Game (Multiplayer) butonuna basıldı");
		SaveLoadGameManager.SetMultiplayerMode();
		OnMultiplayerClicked();
	}

	private void OnLobbyTypeSelectorChanged(int index)
	{
		selectedIsPrivate = index == 1;
		string text = (selectedIsPrivate ? "Private" : "Public");
		Debug.Log("[MainMenuManager] Lobby tipi değişti: " + text);
	}

	private void OnCreateLobbyClicked()
	{
		if (!isConnecting)
		{
			Debug.Log("[MainMenuManager] Create Lobby butonuna basıldı - SaveSlotUI açılıyor");
			SaveLoadGameManager.SetMultiplayerMode();
			ShowSaveSlotUI();
		}
	}

	private IEnumerator CreateLobbyWithLoading()
	{
		isConnecting = true;
		ShowLoadingUI(LoadingType.CreatingRoom);
		yield return new WaitForSeconds(1.5f);
		LoadingManagerUI.Hide(LoadingType.CreatingRoom);
		LoadingManagerUI.Show(LoadingType.Scene);
		yield return new WaitForSeconds(0.5f);
		lobbyManager.CreateLobbyAndStartHost(selectedIsPrivate);
	}

	public void OnSaveSlotContinueClicked()
	{
		if (isConnecting)
		{
			return;
		}
		Debug.Log("[MainMenuManager] SaveSlot Continue - Mod: " + (SaveLoadGameManager.IsSinglePlayerMode ? "SinglePlayer" : "Multiplayer"));
		if (SteamAppChecker.Instance != null && (SteamAppChecker.Instance.IsDemo || SteamAppChecker.Instance.IsPrologue) && IsSaveAtDemoLimit())
		{
			Debug.Log("[MainMenuManager] Demo/Prologue limiti - Character Level 3, demoFinishedPopup açılıyor");
			if (saveSlotPanel != null)
			{
				saveSlotPanel.SetActive(value: false);
			}
			if (mainMenuPanel != null)
			{
				mainMenuPanel.SetActive(value: false);
			}
			if (demoFinishedPopup != null)
			{
				demoFinishedPopup.SetActive(value: true);
			}
		}
		else
		{
			SaveLoadGameManager.RequestLoadOnStart();
			SetGameVariableIsSinglePlayer(SaveLoadGameManager.IsSinglePlayerMode);
			if (SaveLoadGameManager.IsSinglePlayerMode)
			{
				StartCoroutine(ContinueSinglePlayerWithLoading());
			}
			else
			{
				StartCoroutine(ContinueMultiplayerWithLoading());
			}
		}
	}

	private bool IsSaveAtDemoLimit()
	{
		if (Singleton<SaveLoadManager>.Instance == null)
		{
			return false;
		}
		if (!(Singleton<SaveLoadManager>.Instance.DataStorage is NanoSave nanoSave))
		{
			return false;
		}
		int currentSaveSlot = GetCurrentSaveSlot();
		string slotNumber = currentSaveSlot.ToString("D4");
		string item = nanoSave.GetMetaDataForSlot(slotNumber).charLevel;
		if (string.IsNullOrEmpty(item))
		{
			return false;
		}
		if (int.TryParse(Regex.Match(item, "\\d+").Value, out var result))
		{
			Debug.Log($"[MainMenuManager] Save slot {currentSaveSlot} Character Level: {result}");
			return result >= 3;
		}
		return false;
	}

	public void OnSaveSlotNewGameClicked()
	{
		if (!isConnecting)
		{
			Debug.Log("[MainMenuManager] SaveSlot New Game - Mod: " + (SaveLoadGameManager.IsSinglePlayerMode ? "SinglePlayer" : "Multiplayer"));
			SaveLoadGameManager.ClearLoadRequest();
			SetGameVariableIsSinglePlayer(SaveLoadGameManager.IsSinglePlayerMode);
			int currentSaveSlot = GetCurrentSaveSlot();
			Debug.Log($"[DiggerClear] MainMenu - Slot {currentSaveSlot} temizleniyor (sahne yuklenmeden ONCE)");
			SaveLoadGameManager.RequestNewGameOnStart();
			if (SaveLoadGameManager.IsSinglePlayerMode)
			{
				StartCoroutine(StartSinglePlayerWithLoading());
			}
			else
			{
				StartCoroutine(CreateLobbyWithLoading());
			}
		}
	}

	private void SetGameVariableIsSinglePlayer(bool isSinglePlayer)
	{
		if (saveSlotVariables == null)
		{
			return;
		}
		try
		{
			Singleton<GlobalNameVariablesManager>.Instance.Set(saveSlotVariables, "isSingleplayer", isSinglePlayer);
			Debug.Log($"[MainMenuManager] GameVariables isSingleplayer = {isSinglePlayer}");
		}
		catch (Exception ex)
		{
			Debug.LogError("[MainMenuManager] isSingleplayer ayarlanamadı: " + ex.Message);
		}
	}

	private int GetCurrentSaveSlot()
	{
		if (saveSlotVariables == null || string.IsNullOrEmpty(saveSlotVariableName))
		{
			Debug.LogWarning("[MainMenuManager] saveSlotVariables veya saveSlotVariableName tanımlanmamış - varsayılan slot 1");
			return 1;
		}
		try
		{
			if (!Singleton<GlobalNameVariablesManager>.Instance.Exists(saveSlotVariables, saveSlotVariableName))
			{
				Debug.LogWarning("[MainMenuManager] '" + saveSlotVariableName + "' değişkeni bulunamadı - varsayılan slot 1");
				return 1;
			}
			int num = Convert.ToInt32(Singleton<GlobalNameVariablesManager>.Instance.Get(saveSlotVariables, saveSlotVariableName));
			Debug.Log($"[MainMenuManager] GlobalNameVariables'dan slot okundu: {num}");
			return (num <= 0) ? 1 : num;
		}
		catch (Exception ex)
		{
			Debug.LogError("[MainMenuManager] Slot değişkeni okunamadı: " + ex.Message);
			return 1;
		}
	}

	private IEnumerator ContinueSinglePlayerWithLoading()
	{
		isConnecting = true;
		ShowLoadingUI(LoadingType.Scene);
		yield return new WaitForSeconds(0.5f);
		if (networkManager != null)
		{
			networkManager.ClearLobbyCode();
			networkManager.StartHostSafe();
			Debug.Log("[MainMenuManager] Continue SinglePlayer: Host baslatildi");
		}
	}

	private IEnumerator ContinueMultiplayerWithLoading()
	{
		isConnecting = true;
		ShowLoadingUI(LoadingType.CreatingRoom);
		yield return new WaitForSeconds(0.5f);
		LoadingManagerUI.Hide(LoadingType.CreatingRoom);
		LoadingManagerUI.Show(LoadingType.Scene);
		if (lobbyManager != null)
		{
			lobbyManager.CreateLobbyAndStartHost(selectedIsPrivate);
			Debug.Log("[MainMenuManager] Continue Multiplayer: Lobby olusturuldu ve host baslatildi");
		}
		else if (networkManager != null)
		{
			networkManager.StartHostSafe();
		}
	}

	private void OnSteamInviteReceived(LobbyData lobby, UserData friend)
	{
		Debug.Log($"[MainMenuManager] Steam davet alındı - Lobby: {(ulong)lobby}, Friend: {friend.Name}");
		CloseAllPanels();
		StartCoroutine(CheckMultiplayerRequirements(delegate
		{
			SaveLoadGameManager.SetMultiplayerMode();
			SetGameVariableIsSinglePlayer(isSinglePlayer: false);
			JoinLobbyWithLoading(lobby);
		}));
	}

	private void CloseAllPanels()
	{
		if (saveSlotPanel != null)
		{
			saveSlotPanel.SetActive(value: false);
		}
		if (demoInfoPanel != null)
		{
			demoInfoPanel.SetActive(value: false);
		}
		if (connectionPopup != null)
		{
			connectionPopup.SetActive(value: false);
		}
		if (settingsPanel != null)
		{
			settingsPanel.SetActive(value: false);
		}
		if (creditsPanel != null)
		{
			creditsPanel.SetActive(value: false);
		}
		if (noInternetPopup != null)
		{
			noInternetPopup.SetActive(value: false);
		}
		if (versionMismatchPopup != null)
		{
			versionMismatchPopup.SetActive(value: false);
		}
		if (connectionLostPopup != null)
		{
			connectionLostPopup.SetActive(value: false);
		}
		if (kickedPopup != null)
		{
			kickedPopup.SetActive(value: false);
		}
		if (demoFinishedPopup != null)
		{
			demoFinishedPopup.SetActive(value: false);
		}
		if (hostTutorialNotCompletedPopup != null)
		{
			hostTutorialNotCompletedPopup.SetActive(value: false);
		}
		if (menuButtons != null)
		{
			menuButtons.SetActive(value: true);
		}
		if (mainMenuPanel != null)
		{
			mainMenuPanel.SetActive(value: true);
		}
		pendingDemoAction = DemoNextAction.None;
		isConnecting = false;
		isCheckingMultiplayer = false;
	}

	private void OnJoinByCodeClicked()
	{
		if (!(lobbyManager == null) && !(lobbyCodeInput == null))
		{
			string text = lobbyCodeInput.text.Trim();
			if (string.IsNullOrEmpty(text) || text.Length != 6)
			{
				Debug.LogWarning("[MainMenuManager] Geçersiz lobby kodu!");
			}
			else if (!isConnecting)
			{
				StartCoroutine(JoinLobbyByCodeWithLoading(text));
			}
		}
	}

	private IEnumerator JoinLobbyByCodeWithLoading(string code)
	{
		isConnecting = true;
		SetGameVariableIsSinglePlayer(isSinglePlayer: false);
		ShowLoadingUI();
		yield return new WaitForSeconds(1f);
		lobbyManager.JoinLobbyByCodeAndStartClient(code);
	}

	private void OnOpenServerBrowserClicked()
	{
		if (serverBrowser != null)
		{
			serverBrowser.Show();
			serverBrowser.RefreshLobbyList();
		}
	}

	public void JoinLobbyWithLoading(LobbyData lobby)
	{
		if (!(lobbyManager == null) && !isConnecting)
		{
			StartCoroutine(JoinLobbyWithLoadingCoroutine(lobby));
		}
	}

	private IEnumerator JoinLobbyWithLoadingCoroutine(LobbyData lobby)
	{
		isConnecting = true;
		SetGameVariableIsSinglePlayer(isSinglePlayer: false);
		ShowLoadingUI();
		yield return new WaitForSeconds(1f);
		lobbyManager.JoinLobbyAndStartClient(lobby);
	}

	private void OnInternetStatusChanged(bool hasInternet)
	{
		UpdateInternetStatus();
	}

	private void UpdateInternetStatus()
	{
	}

	private void OnLobbyCreated(LobbyData lobby)
	{
		Debug.Log("[MainMenuManager] Lobby oluşturuldu, oyuna giriliyor...");
		StartCoroutine(HideLoadingAfterSceneTransition());
		onGameStarted?.Invoke();
	}

	private IEnumerator HideLoadingAfterSceneTransition()
	{
		yield return new WaitForSeconds(1f);
		HideLoadingUI();
		Debug.Log("[MainMenuManager] Host: Sahne geçişi sonrası loading kapatıldı");
	}

	private void OnLobbyJoined(LobbyData lobby)
	{
		Debug.Log("[MainMenuManager] Lobby'e katıldık, oyuna giriliyor...");
		onGameStarted?.Invoke();
	}

	private void OnLobbyLeft()
	{
		Debug.Log("[MainMenuManager] Lobby'den ayrıldık");
		HideLoadingUI();
	}

	private void OnPlayerJoined(UserData user)
	{
		Debug.Log("[MainMenuManager] Oyuncu katıldı: " + user.Name);
	}

	private void OnPlayerLeft(UserData user)
	{
		Debug.Log("[MainMenuManager] Oyuncu ayrıldı: " + user.Name);
	}

	private void OnLobbyError(string error)
	{
		Debug.LogError("[MainMenuManager] Lobby hatası: " + error);
		HideLoadingUI();
	}

	private void OnJoinBlockedByTutorial()
	{
		Debug.LogWarning("[MainMenuManager] Host tutorial tamamlamadı, katılım engellendi.");
		HideLoadingUI();
		if (hostTutorialNotCompletedPopup != null)
		{
			hostTutorialNotCompletedPopup.SetActive(value: true);
		}
	}
}
