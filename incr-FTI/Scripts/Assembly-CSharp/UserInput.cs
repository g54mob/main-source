using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UserInput : MonoBehaviour
{
	private EventSystem currentEventSystem;

	private bool dragState;

	private bool hasInitModule;

	private static UserInput instance;

	public bool didBeginDragOnDragButton;

	private CustomInputModule customInputModule;

	public static bool isPrimaryPointerDown;

	private Stopwatch stopwatch;

	private List<ConsumableState> debugLargeList;

	public bool hasInitializedInput;

	public static bool isControlKeyDown;

	public static bool isShiftKeyDown;

	public static bool isAltKeyDown;

	public static bool IsInControllerMode;

	public static bool queueSnapshot;

	public static IncrementSetting incrementMultiple;

	public static int activeGlobalIncrement;

	public static int baselineGlobalIncrement;

	public static bool DidEnterTextInput;

	public static bool DidExitTextInput;

	public static bool isInTextInput;

	public MenuButton pointerDownButton;

	public float pointerRepeatTimer;

	public int pointerRepeatCount;

	public static string TimePauseHotkey = "F1";

	public static string TimeNormalHotkey = "F2";

	public static string TimeFastHotkey = "F3";

	public static string TimeUltraHotkey = "F4";

	public const KeyCode ControlTimeStop = KeyCode.F1;

	public const KeyCode ControlTimeNormal = KeyCode.F2;

	public const KeyCode ControlTimeTurbo = KeyCode.F3;

	public const KeyCode ControlTimeMax = KeyCode.F4;

	public const KeyCode ControlQuickSave = KeyCode.F5;

	public const KeyCode ControlQuests = KeyCode.Q;

	public const KeyCode ControlResearch = KeyCode.R;

	public const KeyCode ControlInventory = KeyCode.V;

	public const KeyCode ControlUpgrades = KeyCode.G;

	public const KeyCode ControlTownPerks = KeyCode.T;

	public const KeyCode ControlNotifications = KeyCode.F;

	public const KeyCode ControlWorldPerks = KeyCode.W;

	public const KeyCode ControlConstruction = KeyCode.C;

	public const KeyCode ControlTimeManagement = KeyCode.E;

	public const KeyCode ControlPanelHousing = KeyCode.Alpha1;

	public const KeyCode ControlPanelCultivation = KeyCode.Alpha2;

	public const KeyCode ControlPanelProspecting = KeyCode.Alpha3;

	public const KeyCode ControlPanelHarvesting = KeyCode.Alpha4;

	public const KeyCode ControlPanelCrafting = KeyCode.Alpha5;

	public const KeyCode ControlPanelMarkets = KeyCode.Alpha6;

	public const KeyCode ControlPanelTrading = KeyCode.Alpha7;

	public const KeyCode ControlPanelResearch = KeyCode.Alpha8;

	public const KeyCode ControlPanelStorage = KeyCode.Alpha9;

	public const KeyCode ControlsPanelWorld = KeyCode.Tab;

	public const KeyCode ControlsTownPrev2 = KeyCode.LeftArrow;

	public const KeyCode ControlsTownNext2 = KeyCode.RightArrow;

	public const KeyCode ControlGameMenu = KeyCode.Escape;

	public const KeyCode ControlNextSong = KeyCode.RightBracket;

	public const KeyCode ControlPrevSong = KeyCode.LeftBracket;

	private static MenuManager m => MenuManager.Instance;

	public static UserInput Instance => instance;

	protected void Awake()
	{
		stopwatch = new Stopwatch();
		instance = this;
		baselineGlobalIncrement = 1;
		activeGlobalIncrement = 1;
		currentEventSystem = EventSystem.current;
	}

	private bool IsUsingExternalKeyboardInput()
	{
		return false;
	}

	private void Update()
	{
		isControlKeyDown = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
		isShiftKeyDown = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		isAltKeyDown = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);
		if (DidEnterTextInput)
		{
			isInTextInput = true;
			DidEnterTextInput = false;
			if (IsUsingExternalKeyboardInput())
			{
				GameObject currentSelectedGameObject = EventSystem.current.currentSelectedGameObject;
				if (null != currentSelectedGameObject)
				{
					TMP_InputField component = currentSelectedGameObject.GetComponent<TMP_InputField>();
					if (null != component)
					{
						string empty = string.Empty;
						Platform.Instance.TryShowGamepadTextInput(component.multiLine, empty, component.text);
					}
				}
			}
		}
		if (DidExitTextInput)
		{
			isInTextInput = false;
			DidExitTextInput = false;
		}
		if (!hasInitModule && currentEventSystem.currentInputModule is CustomInputModule customInputModule)
		{
			this.customInputModule = customInputModule;
			customInputModule.pressChangeDelegate = PressChangeDelegate;
			hasInitModule = true;
		}
		if (!hasInitializedInput && Input.anyKeyDown && MenuManager.Instance.welcomePanel.IsVisible())
		{
			hasInitializedInput = true;
			MenuManager.Instance.welcomePanel.OnAnyKeyDown();
		}
		GameObject currentSelectedGameObject2 = currentEventSystem.currentSelectedGameObject;
		if (null != currentSelectedGameObject2 && currentSelectedGameObject2.TryGetComponent<TMP_InputField>(out var _))
		{
			isInTextInput = true;
		}
		else
		{
			isInTextInput = false;
		}
		if (isInTextInput)
		{
			isControlKeyDown = false;
			isShiftKeyDown = false;
			CheckInputFieldSubmit();
			return;
		}
		if (GameManager.GameState == GameState.InGame)
		{
			CheckGameInputKeys();
		}
		CheckInputKeys();
		CheckPointerRepeat();
	}

	public static float InputRepeatCooldown(int numRepeats)
	{
		if (numRepeats == 1)
		{
			return 0.4f;
		}
		if (numRepeats > 1)
		{
			return 0.2f;
		}
		return 0.5f;
	}

	private void CheckPointerRepeat()
	{
		if (!(null != pointerDownButton))
		{
			return;
		}
		if (!pointerDownButton.gameObject.activeInHierarchy)
		{
			pointerDownButton = null;
			return;
		}
		pointerRepeatTimer += TimeManager.MenuDelta;
		float num = InputRepeatCooldown(pointerRepeatCount);
		if (pointerRepeatTimer >= num)
		{
			pointerRepeatCount++;
			pointerDownButton.pointerDownDelegate?.Invoke();
			pointerRepeatTimer -= num;
		}
	}

	private void CheckInputFieldSubmit()
	{
		if (!(null != EventSystem.current) || !(null != EventSystem.current.currentSelectedGameObject) || !isInTextInput)
		{
			return;
		}
		if (EventSystem.current.currentSelectedGameObject.TryGetComponent<TMP_InputField>(out var _) && Input.GetKeyDown(KeyCode.Return))
		{
			ExecuteEvents.Execute(EventSystem.current.currentSelectedGameObject, null, ExecuteEvents.submitHandler);
		}
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			bool num = EventSystem.current.currentSelectedGameObject == MenuManager.Instance.searchHeader.searchField.gameObject;
			currentEventSystem.SetSelectedGameObject(null);
			if (num)
			{
				MenuManager.Instance.SetSearchActive(nextState: false);
			}
		}
	}

	private void CheckGameInputKeys()
	{
		int num = activeGlobalIncrement;
		if (isControlKeyDown)
		{
			if (isShiftKeyDown)
			{
				incrementMultiple = IncrementSetting.Combo;
				activeGlobalIncrement = 50 * baselineGlobalIncrement;
			}
			else
			{
				incrementMultiple = IncrementSetting.Major;
				activeGlobalIncrement = 10 * baselineGlobalIncrement;
			}
		}
		else if (isShiftKeyDown)
		{
			incrementMultiple = IncrementSetting.Minor;
			activeGlobalIncrement = 5 * baselineGlobalIncrement;
		}
		else
		{
			incrementMultiple = IncrementSetting.Single;
			activeGlobalIncrement = baselineGlobalIncrement;
		}
		if (activeGlobalIncrement != num)
		{
			MenuManager.Instance.OnIncrementChanged();
		}
		if (Input.GetKeyDown(KeyCode.F7))
		{
			queueSnapshot = true;
		}
		if (Input.GetKeyDown(KeyCode.F5) || (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.LeftControl)))
		{
			FileManager.Save();
			MenuManager.Instance.ShowMessage("GameSaved".Localized());
		}
		else
		{
			Input.GetKeyDown(KeyCode.F6);
		}
		if (Input.GetKeyDown(KeyCode.F1))
		{
			TimeManager.timeMode = -1;
			TimeManager.ShowTimeModeMessage();
		}
		if (Input.GetKeyDown(KeyCode.F2))
		{
			TimeManager.timeMode = 0;
			TimeManager.ShowTimeModeMessage();
		}
		if (Input.GetKeyDown(KeyCode.F3))
		{
			if (TimeManager.TrySpeedUp(1))
			{
				TimeManager.ShowTimeModeMessage();
			}
			else
			{
				TimeManager.ShowNoTokensMessage();
			}
		}
		if (Input.GetKeyDown(KeyCode.F4))
		{
			if (GameManager.Instance.isExtraActive)
			{
				TimeManager.ShowNoTurboModeMessage();
			}
			else if (TimeManager.TrySpeedUp(2))
			{
				TimeManager.ShowTimeModeMessage();
			}
			else
			{
				TimeManager.ShowNoTokensMessage();
			}
		}
		if (Input.GetKeyDown(KeyCode.F11))
		{
			Platform.TakeScreenshot();
		}
		if (isControlKeyDown && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			GameManager.Instance.CycleTown(clockwise: false);
		}
		if (Input.GetKeyDown(KeyCode.Mouse3))
		{
			GameManager.Instance.CycleTown(clockwise: false);
		}
		if (Input.GetKeyDown(KeyCode.Mouse4))
		{
			GameManager.Instance.CycleTown(clockwise: true);
		}
		if (isControlKeyDown && Input.GetKeyDown(KeyCode.RightArrow))
		{
			GameManager.Instance.CycleTown(clockwise: true);
		}
		if (isAltKeyDown && Input.GetKeyDown(KeyCode.LeftArrow))
		{
			MenuManager.Instance.NavigateBack();
		}
		if (Input.GetMouseButtonDown(3))
		{
			MenuManager.Instance.NavigateBack();
		}
		if (isAltKeyDown && Input.GetKeyDown(KeyCode.RightArrow))
		{
			MenuManager.Instance.NavigateForward();
		}
		if (Input.GetMouseButtonDown(4))
		{
			MenuManager.Instance.NavigateForward();
		}
		if (Input.GetKeyDown(KeyCode.Q))
		{
			m.questsPanelPopup.ToggleDisplay();
		}
		if (Input.GetKeyDown(KeyCode.R) && !m.researchPanel.isLocked)
		{
			m.researchPanel.ToggleDisplayForTown(GameManager.Instance.activeTown);
		}
		if (Input.GetKeyDown(KeyCode.V) && !m.inventoryPanelPopup.isLocked)
		{
			m.inventoryPanelPopup.ToggleDisplayForTown(GameManager.Instance.activeTown);
		}
		if (Input.GetKeyDown(KeyCode.G) && !m.upgradesPanel.isLocked)
		{
			m.upgradesPanel.ToggleDisplayForTown(GameManager.Instance.activeTown);
		}
		if (Input.GetKeyDown(KeyCode.T) && !m.townPerksPanel.isLocked)
		{
			m.townPerksPanel.ToggleDisplayForTown(GameManager.Instance.activeTown);
		}
		if (Input.GetKeyDown(KeyCode.F))
		{
			if (isControlKeyDown)
			{
				if (MenuManager.Instance.searchHeaderRegion.activeInHierarchy)
				{
					MenuManager.Instance.SetSearchActive(nextState: true);
					MenuManager.SetFocusOnInputField(MenuManager.Instance.searchHeader.searchField);
				}
			}
			else if (!m.logPanel.isLocked)
			{
				m.logPanel.ToggleDisplayForTown(GameManager.Instance.activeTown);
			}
		}
		if (Input.GetKeyDown(KeyCode.W) && !m.worldPerksPanel.isLocked)
		{
			m.worldPerksPanel.ToggleDisplay();
		}
		if (Input.GetKeyDown(KeyCode.C) && !m.buildingsPanel.isLocked)
		{
			m.buildingsPanel.ToggleDisplayForTown(GameManager.Instance.activeTown);
		}
		if (Input.GetKeyDown(KeyCode.E) && !m.timeTokensPanel.isLocked)
		{
			m.timeTokensPanel.ToggleDisplay();
		}
		if (Input.GetKey(KeyCode.Alpha1))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Housing].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha4))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Harvesting].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha5))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Production].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha2))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Cultivation].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha3))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Prospecting].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha6))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Markets].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha7))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Trading].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha8))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Research].PerformSelection();
		}
		if (Input.GetKey(KeyCode.Alpha9))
		{
			MenuManager.Instance.navigationPanel.recipeNavigationButtons[BuildingCategory.Storage].PerformSelection();
		}
		if (Input.GetKeyDown(KeyCode.Equals) || Input.GetKeyDown(KeyCode.W))
		{
			MenuManager.Instance.TryModify(1);
		}
		else if (Input.GetKeyDown(KeyCode.Minus) || Input.GetKeyDown(KeyCode.S))
		{
			MenuManager.Instance.TryModify(-1);
		}
		if (Input.GetKeyDown(KeyCode.Tab) && !MenuManager.Instance.worldPanel.isLocked)
		{
			MenuManager.Instance.worldPanel.ToggleDisplay();
		}
	}

	private void CheckEscape()
	{
		bool keyDown = Input.GetKeyDown(KeyCode.Escape);
		bool keyDown2 = Input.GetKeyDown(KeyCode.Escape);
		bool flag = false;
		bool flag2 = false;
		if (keyDown && MenuManager.Instance.gameMenuPanel.IsVisible())
		{
			MenuManager.Instance.gameMenuPanel.Hide();
			flag = true;
			flag2 = true;
		}
		if (keyDown2 && !flag2)
		{
			if (MenuManager.Instance.HideTopDismissableModalMenu())
			{
				flag = true;
			}
			else if (MenuManager.isSearchApplied)
			{
				MenuManager.Instance.searchHeader.searchField.text = string.Empty;
				MenuManager.Instance.ClearSearch();
				flag = true;
			}
		}
		if (keyDown && !flag)
		{
			MenuManager.Instance.gameMenuPanel.Show();
		}
	}

	private void CheckInputKeys()
	{
		if (GameManager.Instance.gameState == GameState.InGame)
		{
			CheckEscape();
		}
		if (null != m.debugPanel && !MenuManager.Instance.textEntryPanel.IsVisible() && (Input.GetKeyDown(KeyCode.BackQuote) || (isShiftKeyDown && Input.GetKeyDown(KeyCode.A))))
		{
			bool activeInHierarchy = m.debugPanel.gameObject.activeInHierarchy;
			m.debugPanel.SetVisible(!activeInHierarchy);
		}
		if (Input.GetKey(KeyCode.PageDown) || Input.GetKey(KeyCode.Z))
		{
			MenuManager.Instance.TryScroll(-1);
		}
		else if (Input.GetKey(KeyCode.PageUp) || Input.GetKey(KeyCode.A))
		{
			MenuManager.Instance.TryScroll(1);
		}
		else
		{
			MenuManager.Instance.numScrollRepeats = 0;
		}
		if (Input.GetKeyDown(KeyCode.RightBracket))
		{
			MusicPlayer.Instance.PlayNext();
		}
		else if (Input.GetKeyDown(KeyCode.LeftBracket))
		{
			MusicPlayer.Instance.Back();
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			MenuManager.Instance.TrySelect();
		}
		Input.GetKeyUp(KeyCode.Space);
	}

	private void DebugDictionaryValues()
	{
		stopwatch.Start();
		GameManager gameManager = GameManager.Instance;
		int num = 0;
		for (int i = 0; i < 10000; i++)
		{
			foreach (ItemState value in gameManager.activeTown.inventory.Values)
			{
				_ = value;
				num++;
			}
		}
		stopwatch.Stop();
		stopwatch.Reset();
	}

	private void DebugIterateForEach()
	{
		if (debugLargeList == null)
		{
			CreateDebugList();
		}
		stopwatch.Start();
		int num = 0;
		for (int i = 0; i < 10000; i++)
		{
			foreach (ConsumableState debugLarge in debugLargeList)
			{
				_ = debugLarge;
				num++;
			}
		}
		stopwatch.Stop();
		stopwatch.Reset();
	}

	private void DebugIterateFor()
	{
		if (debugLargeList == null)
		{
			CreateDebugList();
		}
		stopwatch.Start();
		int num = 0;
		for (int i = 0; i < 10000; i++)
		{
			for (int j = 0; j < debugLargeList.Count; j++)
			{
				_ = debugLargeList[j];
				num++;
			}
		}
		stopwatch.Stop();
		stopwatch.Reset();
	}

	private void DebugDictionaryIterateValuesFor()
	{
		GameManager gameManager = GameManager.Instance;
		stopwatch.Start();
		int num = 0;
		for (int i = 0; i < 10000; i++)
		{
			for (int j = 0; j < gameManager.activeTown.inventoryCache.Length; j++)
			{
				_ = gameManager.activeTown.inventoryCache[j];
				num++;
			}
		}
		stopwatch.Stop();
		stopwatch.Reset();
	}

	private void DebugDictionaryPairs()
	{
		stopwatch.Start();
		GameManager gameManager = GameManager.Instance;
		int num = 0;
		for (int i = 0; i < 10000; i++)
		{
			foreach (KeyValuePair<ItemType, ItemState> item in gameManager.activeTown.inventory)
			{
				_ = item;
				num++;
			}
		}
		stopwatch.Stop();
		stopwatch.Reset();
	}

	private void CreateDebugList()
	{
	}

	private void PressChangeDelegate(bool nextState)
	{
		isPrimaryPointerDown = nextState;
		if (!nextState)
		{
			didBeginDragOnDragButton = false;
		}
	}

	public static Vector3 ScreenMousePos()
	{
		Vector3 mousePosition = Input.mousePosition;
		mousePosition.z = 10f;
		return Input.mousePosition;
	}

	public void OnApplicationFocus(bool hasFocus)
	{
		if (!hasFocus)
		{
			pointerDownButton = null;
		}
	}

	public void OnPointerDown(MenuButton button)
	{
		pointerDownButton = button;
		pointerRepeatCount = 0;
		pointerRepeatTimer = 0f;
	}

	public void OnPointerUp(MenuButton b)
	{
		pointerDownButton = null;
	}
}
