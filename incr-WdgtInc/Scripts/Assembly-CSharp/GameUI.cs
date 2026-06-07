using System;
using System.Collections;
using Assets.Behaviour.UI;
using Assets.Behaviour.UI.Construction;
using Assets.Behaviour.UI.MainMenu;
using Assets.Behaviour.UI.Overview;
using Assets.Source.Ability;
using Assets.Source.Player;
using Assets.Source.Util;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
	[SerializeField]
	private InventoryUI _inventory;

	[SerializeField]
	private ConstructionUI _construction;

	[SerializeField]
	private Texture2D _interactableCursor;

	[SerializeField]
	private Texture2D _defaultCursor;

	[SerializeField]
	private RectTransform _topBar;

	[SerializeField]
	private RectTransform _bottomBar;

	[SerializeField]
	private RectTransform _buildTutorialArrow;

	[SerializeField]
	private RectTransform _techTutorialArrow;

	[SerializeField]
	private RectTransform _ingameMenu;

	[SerializeField]
	private RectTransform _mainMenuContent;

	[SerializeField]
	private SaveGameUI _saveContent;

	[SerializeField]
	private LoadGameUI _loadContent;

	[SerializeField]
	private OptionsUI _optionsContent;

	[SerializeField]
	private RectTransform _statusMessageParent;

	[SerializeField]
	private UIStatusMessage _statusMessagePrefab;

	[SerializeField]
	private UIAlertWindow _alertWindow;

	[SerializeField]
	private Button _loadGameButton;

	[SerializeField]
	private RectTransform _loadingScreen;

	[SerializeField]
	private Button _constructionButton;

	[SerializeField]
	private AbilityUI _abilityUI;

	private FullScreenUI _currentUI;

	private float _autosaveTimer;

	private int _interactableCount;

	private bool _interactableActive;

	private FullScreenUI _lastUI;

	private bool _ingameMenuOpened;

	private bool _hideUI;

	public static GameUI Instance { get; private set; }

	public static InventoryUI Inventory => Instance._inventory;

	public static ConstructionUI Construction => Instance._construction;

	public static bool MenuVisible => Instance._ingameMenu.gameObject.activeSelf;

	private void Awake()
	{
		Instance = this;
		UIStatusMessage.InitParent(_statusMessageParent, _statusMessagePrefab);
		UIAlertWindow.Init(_alertWindow);
		PlayerControls.Init();
		PlayerControls.Enable();
	}

	private void OnDisable()
	{
		Time.timeScale = 1f;
	}

	private void OnApplicationQuit()
	{
		SaveGame.StoreAutosaveState("autosave-exit");
		GamePlayer.Current = null;
		Translation.Clear();
	}

	public void ShowFrameUI()
	{
		ShowFullScreenUI(FrameUI.Instance);
	}

	public void ToggleFullScreenUI(FullScreenUI ui)
	{
		if (ui == _currentUI && Inventory.gameObject.activeSelf)
		{
			Inventory.Toggle();
		}
		else if (ui == _currentUI)
		{
			if ((bool)_lastUI && _lastUI != ui)
			{
				ShowFullScreenUI(_lastUI);
			}
			else if (ui == OverviewUI.Instance)
			{
				ShowFullScreenUI(FrameUI.Instance);
			}
			else
			{
				ShowFullScreenUI(OverviewUI.Instance);
			}
		}
		else
		{
			_lastUI = _currentUI;
			ShowFullScreenUI(ui);
		}
	}

	public void ShowFullScreenUI(FullScreenUI ui)
	{
		if (ui == _currentUI)
		{
			return;
		}
		_inventory.Hide();
		_construction.Hide();
		if ((bool)_currentUI)
		{
			_currentUI.SetFullScreenActive(active: false);
			_currentUI.OnFullScreenDeactivate();
			_currentUI.Canvas.enabled = false;
			_currentUI.WorldComponent.gameObject.SetActive(value: false);
			if (ui == FrameUI.Instance)
			{
				UISounds.WindowClose();
			}
			else
			{
				UISounds.WindowOpen();
			}
		}
		_currentUI = ui;
		_currentUI.SetFullScreenActive(active: true);
		_currentUI.OnFullScreenActivate();
		if (!_hideUI)
		{
			_currentUI.Canvas.enabled = true;
		}
		_currentUI.WorldComponent.gameObject.SetActive(value: true);
	}

	public void HideBottomBar()
	{
		_bottomBar.gameObject.SetActive(value: false);
	}

	public void ShowBottomBar()
	{
		_bottomBar.gameObject.SetActive(value: true);
	}

	public void HideTopBar()
	{
		_topBar.gameObject.SetActive(value: false);
	}

	public void ShowTopBar()
	{
		_topBar.gameObject.SetActive(value: true);
	}

	public void ShowBuildTutorial()
	{
		_buildTutorialArrow.gameObject.SetActive(value: true);
	}

	public void HideBuildTutorial()
	{
		_buildTutorialArrow.gameObject.SetActive(value: false);
	}

	public void ShowTechTutorial()
	{
		_techTutorialArrow.gameObject.SetActive(value: true);
	}

	public bool HideTechTutorial()
	{
		bool activeSelf = _techTutorialArrow.gameObject.activeSelf;
		_techTutorialArrow.gameObject.SetActive(value: false);
		return activeSelf;
	}

	public void UpdateConstructionButton()
	{
		_constructionButton.gameObject.SetActive(GamePlayer.Current.HasTech(ConstructionUI.ConstructionOverviewTech));
	}

	private void Update()
	{
		if ((!_bottomBar.gameObject.activeSelf && !_hideUI) || RocketLaunchUI.Instance.FullScreenActive)
		{
			return;
		}
		if (_ingameMenu.gameObject.activeSelf)
		{
			if (Keyboard.current.escapeKey.wasPressedThisFrame)
			{
				ProcessEscapeIngameMenu();
			}
			_ingameMenuOpened = false;
			return;
		}
		if (_interactableCount > 0)
		{
			_interactableCount = 0;
			if (!_interactableActive)
			{
				Cursor.SetCursor(_interactableCursor, Vector2.zero, CursorMode.Auto);
				_interactableActive = true;
			}
		}
		else if (_interactableActive)
		{
			Cursor.SetCursor(_defaultCursor, Vector2.zero, CursorMode.Auto);
			_interactableActive = false;
		}
		_autosaveTimer += Time.deltaTime;
		if (_autosaveTimer > 300f)
		{
			SaveGame.StoreAutosaveState();
			_autosaveTimer = 0f;
		}
	}

	public void ToggleInventory()
	{
		_inventory.Toggle();
	}

	public void ToggleConstructionWindow()
	{
		_construction.Toggle();
	}

	public void ToggleHideUI()
	{
		_hideUI = !_hideUI;
		_topBar.gameObject.SetActive(!_hideUI);
		_bottomBar.gameObject.SetActive(!_hideUI);
	}

	public void UpdateAbilityUI()
	{
		_abilityUI.UpdateUI(GamePlayer.Current.Abilities);
	}

	public void SelectAbility(int ability)
	{
		if ((bool)_abilityUI)
		{
			_abilityUI.SelectAbility(ability);
		}
	}

	public void SetSelectedAbility(ActivatedAbility ability)
	{
		if ((bool)_abilityUI)
		{
			_abilityUI.SetSelectedAbility(ability);
		}
	}

	public void IngameMenuShow()
	{
		if (!_ingameMenu.gameObject.activeSelf)
		{
			_ingameMenuOpened = true;
			PlayerControls.Disable();
			UISounds.WindowOpen();
			_mainMenuContent.gameObject.SetActive(value: true);
			_loadGameButton.interactable = SaveGame.GetSaveGames().Count > 0;
			_optionsContent.gameObject.SetActive(value: false);
			_loadContent.gameObject.SetActive(value: false);
			_saveContent.gameObject.SetActive(value: false);
			_ingameMenu.gameObject.SetActive(value: true);
			Time.timeScale = 0f;
		}
	}

	public void IngameMenuResume()
	{
		if (_ingameMenu.gameObject.activeSelf)
		{
			PlayerControls.Enable();
			UISounds.WindowClose();
			_ingameMenu.gameObject.SetActive(value: false);
			Time.timeScale = 1f;
		}
	}

	public void IngameMenuLoadGame()
	{
		UISounds.WindowOpen();
		_loadContent.gameObject.SetActive(value: true);
		_mainMenuContent.gameObject.SetActive(value: false);
	}

	public void IngameMenuSaveGame()
	{
		UISounds.WindowOpen();
		_saveContent.gameObject.SetActive(value: true);
		_mainMenuContent.gameObject.SetActive(value: false);
	}

	public void IngameMenuOptions()
	{
		UISounds.WindowOpen();
		_optionsContent.gameObject.SetActive(value: true);
		_mainMenuContent.gameObject.SetActive(value: false);
	}

	public void IngameMenuReturnToTitle()
	{
		UISounds.WindowClose();
		SaveGame.StoreAutosaveState("autosave-rtt");
		SceneManager.LoadScene("MainMenu");
	}

	public void IngameMenuExit()
	{
		Application.Quit();
	}

	public void ReturnToIngameMenu()
	{
		UISounds.WindowClose();
		_optionsContent.gameObject.SetActive(value: false);
		_saveContent.gameObject.SetActive(value: false);
		_loadContent.gameObject.SetActive(value: false);
		_mainMenuContent.gameObject.SetActive(value: true);
		_loadGameButton.interactable = SaveGame.GetSaveGames().Count > 0;
	}

	public void ProcessEscape()
	{
		if (_alertWindow.gameObject.activeSelf)
		{
			UIAlertWindow.Hide();
		}
		else if (!_inventory.Hide() && !_construction.Hide() && (!_currentUI || !_currentUI.ProcessEscape()))
		{
			if (!OverviewUI.Instance.FullScreenActive)
			{
				ShowFullScreenUI(OverviewUI.Instance);
			}
			else
			{
				IngameMenuShow();
			}
		}
	}

	public void ProcessEscapeIngameMenu()
	{
		if (!_ingameMenuOpened)
		{
			if (_alertWindow.gameObject.activeSelf)
			{
				UIAlertWindow.Hide();
			}
			else
			{
				IngameMenuResume();
			}
		}
	}

	public void ProcessCancel()
	{
		if (Inventory.Hide())
		{
			return;
		}
		OverviewUI instance = OverviewUI.Instance;
		if ((object)instance != null && instance.BuildMenuActive)
		{
			OverviewUI.Instance.ToggleBuildMenu();
			return;
		}
		ConstructionUI instance2 = ConstructionUI.Instance;
		if ((object)instance2 != null && instance2.Hide())
		{
			return;
		}
		TechTreeUI instance3 = TechTreeUI.Instance;
		if ((object)instance3 == null || !instance3.FullScreenActive)
		{
			FrameUI instance4 = FrameUI.Instance;
			if ((object)instance4 == null || !instance4.FullScreenActive)
			{
				return;
			}
		}
		ShowFullScreenUI(OverviewUI.Instance);
	}

	public void DoLoadGame(SaveGameFile file)
	{
		StartCoroutine(_loadSaveGame(file));
	}

	private IEnumerator _loadSaveGame(SaveGameFile file)
	{
		_loadContent.gameObject.SetActive(value: false);
		_loadingScreen.gameObject.SetActive(value: true);
		yield return null;
		try
		{
			file.LoadSaveGame();
			SceneManager.LoadScene("Game");
		}
		catch (Exception exception)
		{
			_loadingScreen.gameObject.SetActive(value: false);
			_loadContent.gameObject.SetActive(value: true);
			UIAlertWindow.Show("@LGError", "@LGErrorCorrupt");
			Debug.LogException(exception);
		}
	}

	public static void MouseOverInteractable(Interactable i)
	{
		Instance._interactableCount++;
	}
}
