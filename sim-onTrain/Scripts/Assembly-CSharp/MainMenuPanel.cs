using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using DG.Tweening;
using Michsky.UI.Heat;
using Mirror;
using Mirror.Examples.CharacterSelection;
using Mirror.FizzySteam;
using Steamworks;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using kcp2k;

public class MainMenuPanel : MonoBehaviour
{
	private enum PendingAction
	{
		None = 0,
		NewGame = 1,
		JoinGame = 2
	}

	public bool isSteamMode = true;

	public Button newGameLeftPanelButton;

	public Button loadGameLeftPanelButton;

	public Button joinGameLeftPanelButton;

	public Button selectCharacterLeftPanelButton;

	public Button settingsLeftPanelButton;

	public Button giveFeedbackButton;

	public Button quitLeftPanelButton;

	public Button discordButton;

	public string discordInviteLink = "https://discord.gg/DAVET_KODUN";

	public Button wishlistButton;

	public string wishlistLink = "https://store.steampowered.com/app/3177710?utm_source=ingame&utm_medium=mainmenu&utm_campaign=wishlist";

	public TS_CharacterSelector characterSelector;

	public CanvasGroup mainUIItemsPanel;

	public CanvasGroup loadingPanel;

	public GameObject loadingCircle;

	public TextMeshProUGUI loadingPercentageText;

	public TMP_InputField joinGameTextInput;

	public CanvasGroup newGamePanel;

	public CanvasGroup loadGamePanel;

	public CanvasGroup joinGamePanel;

	public CanvasGroup lobbyListPanel;

	public GiveFeedbackPanel giveFeedbackPanel;

	private bool isConnecting;

	private bool isLoadingScene;

	private CharacterData characterData;

	private bool isLoadingCircleActive;

	private float loadingCircleRotationSpeed = 360f;

	private PendingAction pendingAction;

	private string pendingGameKey;

	[SerializeField]
	private CanvasReferencer canvasReferencer;

	[SerializeField]
	private TMP_InputField playerIndexInput;

	[SerializeField]
	private Button selectPlayerIndexButton;

	public TMP_InputField newGameNameInput;

	public TextMeshProUGUI newGameErrorText;

	public HorizontalSelector lobbyModeSelector;

	public Button closeNewGamePanelButton;

	public Button closeJoinGamePanelButton;

	public Button closeLoadGamePanelButton;

	public Button startNewGameButton;

	public Toggle localTestToogle;

	public TMP_InputField localTestNick;

	public List<MonoBehaviour> steamScripts = new List<MonoBehaviour>();

	public List<MonoBehaviour> localNetworkScripts = new List<MonoBehaviour>();

	private SettingsPanel settingsPanel;

	private static readonly Regex validGameNameRegex = new Regex("^[a-zA-Z0-9 _\\-]+$");

	private void PlayClickSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.clickSound);
		}
	}

	private void PlayHoverSound()
	{
		if (UIManagerAudio.instance != null && UIManagerAudio.instance.UIManagerAsset != null)
		{
			UIManagerAudio.instance.audioSource.PlayOneShot(UIManagerAudio.instance.UIManagerAsset.hoverSound);
		}
	}

	private void AddHoverSound(Button button)
	{
		EventTrigger eventTrigger = button.gameObject.GetComponent<EventTrigger>();
		if (eventTrigger == null)
		{
			eventTrigger = button.gameObject.AddComponent<EventTrigger>();
		}
		EventTrigger.Entry entry = new EventTrigger.Entry();
		entry.eventID = EventTriggerType.PointerEnter;
		entry.callback.AddListener(delegate
		{
			PlayHoverSound();
		});
		eventTrigger.triggers.Add(entry);
	}

	private void Start()
	{
		settingsPanel = UnityEngine.Object.FindObjectOfType<SettingsPanel>(includeInactive: true);
		int num = PlayerPrefs.GetInt("SelectedCharacter", 1);
		if (num > 0)
		{
			StaticVariables.characterNumber = num;
		}
		newGameLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenNewGamePanel();
		});
		loadGameLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenLoadGamePanel();
		});
		joinGameLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			JoinGame();
		});
		selectCharacterLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenCharacterSelection();
		});
		settingsLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenSettingsPanel();
		});
		giveFeedbackButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenGiveFeedbackPanel();
		});
		quitLeftPanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			OpenQuitPanel();
		});
		discordButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			Application.OpenURL(discordInviteLink);
		});
		wishlistButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			Application.OpenURL(wishlistLink);
		});
		startNewGameButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			TryStartNewGame(newGameNameInput.text);
		});
		closeJoinGamePanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			CloseJoinGamePanel();
		});
		closeLoadGamePanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			CloseLoadGamePanel();
		});
		closeNewGamePanelButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			CloseNewGamePanel();
		});
		selectPlayerIndexButton.onClick.AddListener(delegate
		{
			PlayClickSound();
			if (string.IsNullOrEmpty(playerIndexInput.text))
			{
				SelectCharacter(1);
			}
			else
			{
				SelectCharacter(int.Parse(playerIndexInput.text));
			}
		});
		AddHoverSound(newGameLeftPanelButton);
		AddHoverSound(loadGameLeftPanelButton);
		AddHoverSound(joinGameLeftPanelButton);
		AddHoverSound(selectCharacterLeftPanelButton);
		AddHoverSound(settingsLeftPanelButton);
		AddHoverSound(giveFeedbackButton);
		AddHoverSound(quitLeftPanelButton);
		AddHoverSound(discordButton);
		AddHoverSound(wishlistButton);
		AddHoverSound(startNewGameButton);
		AddHoverSound(closeJoinGamePanelButton);
		AddHoverSound(closeLoadGamePanelButton);
		AddHoverSound(closeNewGamePanelButton);
		AddHoverSound(selectPlayerIndexButton);
		newGameNameInput.onValueChanged.AddListener(ValidateNewGameInput);
		if (loadingPanel != null)
		{
			HideCanvasGroup(loadingPanel);
		}
		bool flag = UnityEngine.Object.FindObjectOfType<DemoInfoPanel>(includeInactive: true) != null && PlayerPrefs.GetInt("DemoInfoShown", 0) == 0;
		if (mainUIItemsPanel != null && !flag)
		{
			ShowCanvasGroup(mainUIItemsPanel);
		}
		NetworkClient.RegisterHandler<SceneMessage>(OnSceneChangeMessage);
		if (isSteamMode && SteamManager.Initialized)
		{
			try
			{
				string personaName = SteamFriends.GetPersonaName();
				if (!string.IsNullOrEmpty(personaName))
				{
					CustomNetworkManager.nick = personaName;
					Debug.Log("Steam nickname ayarlandı: " + personaName);
				}
			}
			catch (Exception ex)
			{
				Debug.LogWarning("Steam nickname alınamadı: " + ex.Message);
			}
		}
		if (isSteamMode)
		{
			EnableSteamHosting();
		}
		else
		{
			DisableSteamHosting();
		}
	}

	private void OnSceneChangeMessage(SceneMessage msg)
	{
		StartCoroutine(ShowLoadingForClient());
	}

	private void ValidateNewGameInput(string inputText)
	{
		bool interactable = true;
		string text = "";
		string text2 = inputText?.Trim();
		if (string.IsNullOrEmpty(text2) || string.IsNullOrWhiteSpace(text2))
		{
			interactable = false;
		}
		else if (text2.Length > 20)
		{
			interactable = false;
			text = "Name is too long. (max 20 characters)";
		}
		else if (!validGameNameRegex.IsMatch(text2))
		{
			interactable = false;
			text = "Only letters, numbers, spaces and hyphens allowed.";
		}
		else
		{
			string[] allSaves = Singleton<ES3SaveManager>.Instance.GetAllSaves();
			for (int i = 0; i < allSaves.Length; i++)
			{
				if (allSaves[i].Equals(text2, StringComparison.OrdinalIgnoreCase))
				{
					interactable = false;
					text = "Name already exist.";
					break;
				}
			}
		}
		startNewGameButton.interactable = interactable;
		if (newGameErrorText != null)
		{
			if (!string.IsNullOrEmpty(text))
			{
				newGameErrorText.text = text;
				newGameErrorText.gameObject.SetActive(value: true);
			}
			else
			{
				newGameErrorText.gameObject.SetActive(value: false);
			}
		}
	}

	public void ShowMainMenuCanvas()
	{
		ShowCanvasGroup(mainUIItemsPanel);
	}

	public void HideMainMenuCanvas()
	{
		HideCanvasGroup(mainUIItemsPanel);
	}

	public void JoinGame()
	{
		if (isSteamMode)
		{
			Debug.Log("Steam Lobby listesi açılıyor...");
			HideCanvasGroup(mainUIItemsPanel);
			ShowCanvasGroup(lobbyListPanel);
			Singleton<SteamLobby>.Instance.GetLobbiesList();
		}
		else
		{
			Debug.Log("Join Game paneli açılıyor (KCP Modu)...");
			HideCanvasGroup(mainUIItemsPanel);
			ShowCanvasGroup(joinGamePanel);
		}
	}

	public void OpenLoadGamePanel()
	{
		HideCanvasGroup(mainUIItemsPanel);
		loadGamePanel.GetComponent<GameSavesPanel>().ListSaveGames();
		ShowCanvasGroup(loadGamePanel);
	}

	public void OpenNewGamePanel()
	{
		HideCanvasGroup(mainUIItemsPanel);
		ShowCanvasGroup(newGamePanel);
		ValidateNewGameInput(newGameNameInput.text);
	}

	public void CloseJoinGamePanel()
	{
		HideCanvasGroup(joinGamePanel);
		ShowCanvasGroup(mainUIItemsPanel);
	}

	public void CloseNewGamePanel()
	{
		HideCanvasGroup(newGamePanel);
		ShowCanvasGroup(mainUIItemsPanel);
	}

	public void CloseLoadGamePanel()
	{
		HideCanvasGroup(loadGamePanel);
		ShowCanvasGroup(mainUIItemsPanel);
	}

	public void StartLoadingForJoin()
	{
		HideAllPanels();
		StartCoroutine(ShowLoadingForClient());
	}

	private void HideAllPanels()
	{
		HideCanvasGroupInstant(mainUIItemsPanel);
		HideCanvasGroupInstant(joinGamePanel);
		HideCanvasGroupInstant(newGamePanel);
		HideCanvasGroupInstant(loadGamePanel);
		if (lobbyListPanel != null)
		{
			HideCanvasGroupInstant(lobbyListPanel);
		}
	}

	private IEnumerator ShowLoadingForClient()
	{
		isLoadingScene = true;
		HideAllPanels();
		if (loadingPanel != null)
		{
			ShowCanvasGroupInstant(loadingPanel);
		}
		StartLoadingCircle();
		if (loadingPercentageText != null)
		{
			loadingPercentageText.text = "0%";
		}
		float progress = 0f;
		float displayedProgress = 0f;
		float loadSpeed = 0.5f;
		while (SceneManager.GetActiveScene().name == "MainMenu")
		{
			progress += Time.deltaTime * loadSpeed;
			if (progress > 0.9f && NetworkClient.isConnected)
			{
				progress = Mathf.Min(progress, 0.95f);
			}
			progress = Mathf.Clamp01(progress);
			displayedProgress = Mathf.Lerp(displayedProgress, progress, Time.deltaTime * 3f);
			if (loadingPercentageText != null)
			{
				loadingPercentageText.text = Mathf.RoundToInt(displayedProgress * 100f) + "%";
			}
			yield return null;
		}
		if (loadingPercentageText != null)
		{
			loadingPercentageText.text = "100%";
		}
		StopLoadingCircle();
		HideCanvasGroupInstant(loadingPanel);
		isLoadingScene = false;
	}

	public void ConnectToServer()
	{
		if (!isSteamMode)
		{
			if (string.IsNullOrEmpty(joinGameTextInput.text))
			{
				Debug.LogError("IP adresi boş olamaz!");
				return;
			}
			NetworkManager.singleton.networkAddress = joinGameTextInput.text;
			NetworkManager.singleton.StartClient();
			isConnecting = true;
			Debug.Log("Sunucuya bağlanmaya çalışılıyor (KCP): " + joinGameTextInput.text);
		}
		else
		{
			Debug.LogError("Steam modunda IP ile bağlantı yapılamaz! Lobby listesini kullanın.");
		}
	}

	private void Update()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		if (isConnecting && !isLoadingScene)
		{
			if (NetworkClient.isConnected)
			{
				Debug.Log("Sunucuya başarıyla bağlanıldı!");
				isConnecting = false;
				StartCoroutine(ShowLoadingAnimation());
			}
			else if (NetworkClient.isConnecting)
			{
				Debug.Log("Bağlantı sürüyor...");
			}
			else if (!NetworkClient.isConnected && !NetworkClient.isConnecting)
			{
				Debug.LogError("Bağlantı başarısız! Lütfen IP adresini kontrol edin.");
				isConnecting = false;
				NetworkManager.singleton.StopClient();
			}
		}
	}

	private IEnumerator ShowLoadingAnimation()
	{
		isLoadingScene = true;
		if (mainUIItemsPanel != null)
		{
			HideCanvasGroupInstant(mainUIItemsPanel);
		}
		if (loadingPanel != null)
		{
			ShowCanvasGroupInstant(loadingPanel);
		}
		StartLoadingCircle();
		if (loadingPercentageText != null)
		{
			loadingPercentageText.text = "0%";
		}
		float fakeProgress = 0f;
		float displayedProgress = 0f;
		while (fakeProgress < 1f && SceneManager.GetActiveScene().name == "MainMenu")
		{
			fakeProgress += Time.deltaTime * 1.5f;
			fakeProgress = Mathf.Clamp01(fakeProgress);
			displayedProgress = Mathf.Lerp(displayedProgress, fakeProgress, Time.deltaTime * 3f);
			if (loadingPercentageText != null)
			{
				loadingPercentageText.text = Mathf.RoundToInt(displayedProgress * 100f) + "%";
			}
			yield return null;
		}
		if (loadingPercentageText != null)
		{
			loadingPercentageText.text = "100%";
		}
		while (SceneManager.GetActiveScene().name == "MainMenu")
		{
			yield return null;
		}
		Debug.Log("Loading animasyonu tamamlandı!");
		StopLoadingCircle();
		isLoadingScene = false;
	}

	private void TryStartNewGame(string gameKey)
	{
		if (!HasSelectedCharacter())
		{
			pendingGameKey = gameKey;
			pendingAction = PendingAction.NewGame;
			HideCanvasGroup(newGamePanel);
			OpenCharacterSelectionWithPending();
		}
		else
		{
			StartGame(gameKey);
		}
	}

	public void StartGame(string gameKey)
	{
		HideCanvasGroup(joinGamePanel);
		HideCanvasGroup(newGamePanel);
		HideCanvasGroup(loadGamePanel);
		CustomNetworkManager.loadedGameKey = gameKey?.Trim();
		if (Singleton<ES3SaveManager>.Instance != null)
		{
			Singleton<ES3SaveManager>.Instance.SetSaveName(gameKey?.Trim());
		}
		Debug.Log("Yeni Oyun başlatılıyor... Mod: " + (isSteamMode ? "Steam" : "KCP"));
		NetworkManager.singleton.onlineScene = "TrainGame";
		if (isSteamMode && SteamManager.Initialized)
		{
			try
			{
				string personaName = SteamFriends.GetPersonaName();
				if (!string.IsNullOrEmpty(personaName))
				{
					CustomNetworkManager.nick = personaName;
				}
				else
				{
					CustomNetworkManager.nick = localTestNick.text;
				}
			}
			catch
			{
				CustomNetworkManager.nick = localTestNick.text;
			}
		}
		else
		{
			CustomNetworkManager.nick = localTestNick.text;
		}
		if (isSteamMode)
		{
			int lobbyMode = 0;
			string text = gameKey?.Trim();
			if (Singleton<ES3SaveManager>.Instance != null && !string.IsNullOrEmpty(text))
			{
				lobbyMode = Singleton<ES3SaveManager>.Instance.GetLobbyMode(text, out var exists);
				if (!exists && lobbyModeSelector != null)
				{
					lobbyMode = lobbyModeSelector.index;
				}
				Singleton<ES3SaveManager>.Instance.SaveLobbyMode(text, lobbyMode);
			}
			else if (lobbyModeSelector != null)
			{
				lobbyMode = lobbyModeSelector.index;
			}
			Singleton<SteamLobby>.Instance.lobbyMode = lobbyMode;
			Singleton<SteamLobby>.Instance.HostLobby();
		}
		else
		{
			NetworkManager.singleton.StartHost();
		}
		StartCoroutine(ShowLoadingAnimation());
	}

	public void OpenCharacterSelection()
	{
		Debug.Log("OpenCharacterSelection çağrıldı");
		if (characterSelector == null)
		{
			Debug.LogError("characterSelector NULL! Inspector'da ata.");
		}
		else
		{
			characterSelector.OpenCharacterSelection();
		}
	}

	public bool HasSelectedCharacter()
	{
		return PlayerPrefs.GetInt("CharacterSelectVisited", 0) == 1;
	}

	public void RequestCharacterSelectionForJoin(Action onConfirmed)
	{
		if (!(characterSelector == null))
		{
			HideCanvasGroup(lobbyListPanel);
			HideCanvasGroup(joinGamePanel);
			characterSelector.OpenCharacterSelection(delegate
			{
				PlayerPrefs.SetInt("CharacterSelectVisited", 1);
				PlayerPrefs.Save();
				onConfirmed();
			}, TS_CharacterSelector.OpenMode.PendingJoinGame);
		}
	}

	private void OpenCharacterSelectionWithPending()
	{
		if (!(characterSelector == null))
		{
			TS_CharacterSelector.OpenMode mode = ((pendingAction == PendingAction.NewGame) ? TS_CharacterSelector.OpenMode.PendingNewGame : TS_CharacterSelector.OpenMode.PendingJoinGame);
			characterSelector.OpenCharacterSelection(delegate
			{
				PlayerPrefs.SetInt("CharacterSelectVisited", 1);
				PlayerPrefs.Save();
				ExecutePendingAction();
			}, mode);
		}
	}

	private void ExecutePendingAction()
	{
		PendingAction pendingAction = this.pendingAction;
		this.pendingAction = PendingAction.None;
		switch (pendingAction)
		{
		case PendingAction.NewGame:
			StartGame(pendingGameKey);
			break;
		case PendingAction.JoinGame:
			if (isSteamMode)
			{
				HideCanvasGroup(mainUIItemsPanel);
				ShowCanvasGroup(lobbyListPanel);
				Singleton<SteamLobby>.Instance.GetLobbiesList();
			}
			else
			{
				HideCanvasGroup(mainUIItemsPanel);
				ShowCanvasGroup(joinGamePanel);
			}
			break;
		}
	}

	public void OpenSettingsPanel()
	{
		HideCanvasGroup(mainUIItemsPanel);
		settingsPanel.OpenPanel();
	}

	public void OpenGiveFeedbackPanel()
	{
		HideCanvasGroup(mainUIItemsPanel);
		giveFeedbackPanel.ShowPanel();
	}

	public void OpenQuitPanel()
	{
		Debug.Log("Oyundan çıkılıyor...");
		Application.Quit();
	}

	public void SelectCharacter(int characterIndex)
	{
		Debug.Log("Karakter seçildi: " + characterIndex);
		if (canvasReferencer != null)
		{
			canvasReferencer.SelectCharacter(characterIndex);
		}
		if (!NetworkServer.active && !NetworkClient.isConnected)
		{
			NetworkManager.singleton.StartHost();
		}
	}

	private void ShowCanvasGroup(CanvasGroup cg)
	{
		if (!(cg == null))
		{
			cg.DOKill();
			cg.gameObject.SetActive(value: true);
			cg.DOFade(1f, 0.5f);
			cg.interactable = true;
			cg.blocksRaycasts = true;
		}
	}

	private void HideCanvasGroup(CanvasGroup cg)
	{
		if (!(cg == null))
		{
			cg.DOKill();
			cg.DOFade(0f, 0.2f);
			cg.interactable = false;
			cg.blocksRaycasts = false;
		}
	}

	private void ShowCanvasGroupInstant(CanvasGroup cg)
	{
		if (!(cg == null))
		{
			cg.gameObject.SetActive(value: true);
			cg.alpha = 1f;
			cg.interactable = true;
			cg.blocksRaycasts = true;
		}
	}

	private void HideCanvasGroupInstant(CanvasGroup cg)
	{
		Debug.Log("hided");
		if (!(cg == null))
		{
			cg.alpha = 0f;
			cg.interactable = false;
			cg.blocksRaycasts = false;
			cg.gameObject.SetActive(value: false);
		}
	}

	private void StartLoadingCircle()
	{
		if (loadingCircle != null)
		{
			loadingCircle.SetActive(value: true);
			loadingCircle.transform.rotation = Quaternion.identity;
			isLoadingCircleActive = true;
		}
	}

	private void StopLoadingCircle()
	{
		if (loadingCircle != null)
		{
			isLoadingCircleActive = false;
			loadingCircle.SetActive(value: false);
		}
	}

	private void LateUpdate()
	{
		if (isLoadingCircleActive && loadingCircle != null)
		{
			float num = Time.unscaledDeltaTime * loadingCircleRotationSpeed;
			loadingCircle.transform.Rotate(0f, 0f, 0f - num);
		}
	}

	public void EnableSteamHosting()
	{
		isSteamMode = true;
		foreach (MonoBehaviour steamScript in steamScripts)
		{
			steamScript.enabled = true;
		}
		foreach (MonoBehaviour localNetworkScript in localNetworkScripts)
		{
			localNetworkScript.enabled = false;
		}
		CustomNetworkManager customNetworkManager = UnityEngine.Object.FindObjectOfType<CustomNetworkManager>();
		if (customNetworkManager.TryGetComponent<KcpTransport>(out var component))
		{
			UnityEngine.Object.DestroyImmediate(component);
		}
		if (!customNetworkManager.TryGetComponent<FizzySteamworks>(out var component2))
		{
			component2 = customNetworkManager.gameObject.AddComponent<FizzySteamworks>();
		}
		if (customNetworkManager.TryGetComponent<LatencySimulation>(out var component3))
		{
			component3.wrap = component2;
			customNetworkManager.transport = component3;
		}
		else
		{
			customNetworkManager.transport = component2;
		}
		Debug.Log("Steam Hosting aktif edildi");
	}

	public void DisableSteamHosting()
	{
		isSteamMode = false;
		foreach (MonoBehaviour steamScript in steamScripts)
		{
			steamScript.enabled = false;
		}
		foreach (MonoBehaviour localNetworkScript in localNetworkScripts)
		{
			localNetworkScript.enabled = true;
		}
		CustomNetworkManager customNetworkManager = UnityEngine.Object.FindObjectOfType<CustomNetworkManager>();
		if (customNetworkManager.TryGetComponent<FizzySteamworks>(out var component))
		{
			UnityEngine.Object.DestroyImmediate(component);
		}
		if (!customNetworkManager.TryGetComponent<KcpTransport>(out var component2))
		{
			component2 = customNetworkManager.gameObject.AddComponent<KcpTransport>();
		}
		component2.Timeout = 120000;
		if (customNetworkManager.TryGetComponent<LatencySimulation>(out var component3))
		{
			component3.wrap = component2;
			customNetworkManager.transport = component3;
		}
		else
		{
			customNetworkManager.transport = component2;
		}
		Debug.Log("KCP (Local) Hosting aktif edildi");
	}
}
