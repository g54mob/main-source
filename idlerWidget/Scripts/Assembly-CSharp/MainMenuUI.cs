using System;
using System.Collections;
using Assets.Behaviour.Frame.Parts;
using Assets.Behaviour.UI;
using Assets.Behaviour.UI.MainMenu;
using Assets.Behaviour.Util;
using Assets.Source.Player;
using Assets.Source.Util;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
	[SerializeField]
	private RectTransform _mainMenuContent;

	[SerializeField]
	private LoadGameUI _loadGameContent;

	[SerializeField]
	private OptionsUI _optionsContent;

	[SerializeField]
	private RectTransform _creditsContent;

	[SerializeField]
	private Button _continueButton;

	[SerializeField]
	private Button _loadGameButton;

	[SerializeField]
	private TMP_Text _versionText;

	[SerializeField]
	private UIAlertWindow _alertWindow;

	[SerializeField]
	private Image _newGameOverlay;

	[SerializeField]
	private RectTransform _loadingScreen;

	public static MainMenuUI Instance { get; private set; }

	private void Awake()
	{
		PlayerControls.Init();
		PlayerControls.Disable();
	}

	private void Start()
	{
		Application.targetFrameRate = 120;
		if (SteamManager.Initialized)
		{
			SteamStatsManager.Init();
		}
		Instance = this;
		GamePlayer.Current = null;
		UIAlertWindow.Init(_alertWindow);
		_versionText.text = Application.version;
		ShowMainMenu();
		MusicManager.Play("GroundControl", forceImmediate: true);
	}

	private void OnEnable()
	{
		if (SaveGame.GetSaveGames().Count == 0)
		{
			_continueButton.interactable = false;
			_loadGameButton.interactable = false;
		}
	}

	private void Update()
	{
		if (PlayerControls.Escape && (_loadGameContent.gameObject.activeSelf || _optionsContent.gameObject.activeSelf))
		{
			ShowMainMenu();
		}
	}

	public void StartNewGame()
	{
		UISounds.CraftFinished();
		StartCoroutine(_initNewGame());
	}

	public void Continue()
	{
		UISounds.CraftFinished();
		DoLoadGame(SaveGame.GetLatestSave());
	}

	public void ShowMainMenu()
	{
		if (!_mainMenuContent.gameObject.activeSelf)
		{
			UISounds.WindowClose();
		}
		_optionsContent.gameObject.SetActive(value: false);
		_loadGameContent.gameObject.SetActive(value: false);
		_mainMenuContent.gameObject.SetActive(value: true);
	}

	public void ShowLoadGame()
	{
		UISounds.WindowOpen();
		_optionsContent.gameObject.SetActive(value: false);
		_mainMenuContent.gameObject.SetActive(value: false);
		_loadGameContent.gameObject.SetActive(value: true);
	}

	public void ShowOptions()
	{
		UISounds.WindowOpen();
		_loadGameContent.gameObject.SetActive(value: false);
		_mainMenuContent.gameObject.SetActive(value: false);
		_optionsContent.gameObject.SetActive(value: true);
	}

	public void ShowCredits()
	{
		if (_creditsContent.gameObject.activeSelf)
		{
			HideCredits();
			return;
		}
		UISounds.WindowOpen();
		_creditsContent.gameObject.SetActive(value: true);
	}

	public void HideCredits()
	{
		UISounds.WindowClose();
		_creditsContent.gameObject.SetActive(value: false);
	}

	public void DoExit()
	{
		Application.Quit();
	}

	public void DoLoadGame(SaveGameFile file)
	{
		StartCoroutine(_loadSaveGame(file));
	}

	private IEnumerator _loadSaveGame(SaveGameFile file)
	{
		_mainMenuContent.gameObject.SetActive(value: false);
		_loadGameContent.gameObject.SetActive(value: false);
		_loadingScreen.gameObject.SetActive(value: true);
		yield return null;
		try
		{
			file.LoadSaveGame();
			SceneManager.LoadScene("Game");
		}
		catch (Exception message)
		{
			_loadingScreen.gameObject.SetActive(value: false);
			_loadGameContent.gameObject.SetActive(value: true);
			UIAlertWindow.Show("Error loading game", "This save game file could not be loaded; most likely its data has been corrupted.");
			Debug.LogWarning(message);
		}
	}

	private IEnumerator _initNewGame()
	{
		_newGameOverlay.gameObject.SetActive(value: true);
		float progress = 0f;
		while (progress < 1f)
		{
			progress += Time.deltaTime / 2.5f;
			Color color = _newGameOverlay.color;
			color.a = Mathf.SmoothStep(0f, 1f, progress);
			_newGameOverlay.color = color;
			yield return null;
		}
		GamePlayer.StartNewGame();
		T1BasicWidgetIntro.NewGameStarted = true;
		SceneManager.LoadScene("Game");
	}
}
