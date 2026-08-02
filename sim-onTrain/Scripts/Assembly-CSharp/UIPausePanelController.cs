using System.Collections;
using Mirror;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(-200)]
public class UIPausePanelController : UIPanelBase
{
	public Button continueButton;

	public Button saveGameButton;

	public Button settingsButton;

	public Button giveFeedbackButton;

	public Button mainMenuButton;

	public ConfirmPanel confirmPanel;

	public GiveFeedbackPanel giveFeedbackPanel;

	private InventoryManagerUI inventoryManager;

	private ObjectBuilderUIManager builderUI;

	private MainUIManager mainUIManager;

	private readonly WaitForSecondsRealtime saveDelay = new WaitForSecondsRealtime(0.5f);

	private SettingsPanel settingsPanel;

	private void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		builderUI = Object.FindObjectOfType<ObjectBuilderUIManager>();
		confirmPanel = Object.FindObjectOfType<ConfirmPanel>();
		inventoryManager = Object.FindObjectOfType<InventoryManagerUI>(includeInactive: true);
		mainUIManager = Object.FindObjectOfType<MainUIManager>(includeInactive: true);
		settingsPanel = Object.FindObjectOfType<SettingsPanel>(includeInactive: true);
		continueButton.onClick.AddListener(ContinueGame);
		saveGameButton.onClick.AddListener(SaveGame);
		settingsButton.onClick.AddListener(OpenSettings);
		giveFeedbackButton.onClick.AddListener(OpenGiveFeedback);
		mainMenuButton.onClick.AddListener(MainMenuClick);
	}

	public void SaveGame()
	{
		Debug.Log("ES3 Saving Game Data");
		Singleton<UserMessagePanel>.Instance.SendMessageToPanel("Game Saved Successfully!");
		Singleton<ES3SaveManager>.Instance.Save();
	}

	public void OpenSettings()
	{
		if (!TrainGameManager.instance.isServer)
		{
			saveGameButton.transform.parent.gameObject.SetActive(value: false);
		}
		HidePanel();
		settingsPanel.OpenPanel();
	}

	public void OpenGiveFeedback()
	{
		HidePanel();
		giveFeedbackPanel.ShowPanel(fromPausePanel: true);
	}

	public void LoadScene(int index)
	{
		StartCoroutine(FadeAndDisconnect(index));
	}

	private IEnumerator FadeAndDisconnect(int sceneIndex)
	{
		ScreenFader.Instance.FadeOut(0.5f);
		yield return new WaitForSecondsRealtime(0.5f);
		DisconnectAndLoadScene(sceneIndex);
	}

	private void DisconnectAndLoadScene(int index)
	{
		Time.timeScale = 1f;
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		CustomNetworkManager customNetworkManager = Object.FindObjectOfType<CustomNetworkManager>();
		if (customNetworkManager != null && customNetworkManager.isNetworkActive)
		{
			CustomNetworkManager.isManualDisconnect = true;
			if (NetworkServer.active && NetworkClient.isConnected)
			{
				customNetworkManager.StopHost();
			}
			else if (NetworkClient.isConnected)
			{
				customNetworkManager.StopClient();
			}
			else if (NetworkServer.active)
			{
				customNetworkManager.StopServer();
			}
		}
		SceneManager.LoadScene(index);
	}

	public void ClearSave()
	{
		Debug.Log("ES3 Loading Game Data");
		InventorySaver.Instance.ClearAllSaveData();
	}

	public void MainMenuClick()
	{
		HidePanel();
		confirmPanel.ShowPanel("Do you want to Exit?", delegate
		{
			ShowSaveConfirmation();
		}, delegate
		{
			ShowPanelWithFade(0.2f);
		});
	}

	private void ShowSaveConfirmation()
	{
		if (TrainGameManager.instance.isServer)
		{
			confirmPanel.ShowPanelWithFade("Do you want to save the game before exiting?", delegate
			{
				SaveAndLoadScene(0);
			}, delegate
			{
				LoadScene(0);
			}, 0.2f);
		}
		else
		{
			LoadScene(0);
		}
	}

	public void QuitClick()
	{
		if (TrainGameManager.instance.isServer)
		{
			confirmPanel.ShowPanel("Do you want to save the game before quitting?", delegate
			{
				SaveAndQuit();
			}, delegate
			{
				Quit();
			});
		}
		else
		{
			confirmPanel.ShowPanel("Quit game?", delegate
			{
				Quit();
			});
		}
	}

	private void SaveAndLoadScene(int sceneIndex)
	{
		StartCoroutine(SaveAndLoadSceneCoroutine(sceneIndex));
	}

	private void SaveAndQuit()
	{
		StartCoroutine(SaveAndQuitCoroutine());
	}

	private IEnumerator SaveAndLoadSceneCoroutine(int sceneIndex)
	{
		ScreenFader.Instance.FadeOut(0.5f);
		SaveGame();
		yield return new WaitForSecondsRealtime(0.5f);
		DisconnectAndLoadScene(sceneIndex);
	}

	private IEnumerator SaveAndQuitCoroutine()
	{
		ScreenFader.Instance.FadeOut(0.5f);
		SaveGame();
		yield return new WaitForSecondsRealtime(0.5f);
		DoQuit();
	}

	public void Quit()
	{
		StartCoroutine(FadeAndQuitCoroutine());
	}

	private IEnumerator FadeAndQuitCoroutine()
	{
		ScreenFader.Instance.FadeOut(0.5f);
		yield return new WaitForSecondsRealtime(0.5f);
		DoQuit();
	}

	private void DoQuit()
	{
		Time.timeScale = 1f;
		CustomNetworkManager customNetworkManager = Object.FindObjectOfType<CustomNetworkManager>();
		if (customNetworkManager != null && customNetworkManager.isNetworkActive)
		{
			customNetworkManager.StopHost();
		}
		Application.Quit();
	}

	public void ContinueGame()
	{
		ChangePanelActive();
	}

	private void Update()
	{
		if (!builderUI.canBuild)
		{
			if (isPanelOpen)
			{
				Cursor.visible = true;
				Cursor.lockState = CursorLockMode.Confined;
			}
			if (Input.GetKeyDown(Singleton<UserPrefencesManager>.Instance.keyData.ExitKey) && !mainUIManager.isInGamePanelOpened && !giveFeedbackPanel.isPanelOpen && !PipePlacementController.IsPipeModeActive)
			{
				ChangePanelActive();
			}
		}
	}

	public void ChangePanelActive()
	{
		if (!isPanelOpen)
		{
			Singleton<MainUIManager>.Instance.OnPausePanelOpened.Invoke();
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			ShowPanel();
			if (!TrainGameManager.instance.isServer)
			{
				saveGameButton.transform.parent.gameObject.SetActive(value: false);
			}
			TrainGameManager.isInputActive = false;
			inventoryManager.isOpenedExternal = true;
			inventoryManager.OnInventoryPanelOpened?.Invoke();
			if (NetworkServer.active && NetworkServer.connections.Count <= 1)
			{
				Time.timeScale = 0f;
			}
		}
		else
		{
			Time.timeScale = 1f;
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
			Singleton<MainUIManager>.Instance.OnPausePanelClosed.Invoke();
			HidePanel();
			TrainGameManager.isInputActive = true;
			inventoryManager.isOpenedExternal = false;
			inventoryManager.OnInventoryPanelClosed?.Invoke();
		}
	}
}
