using System;
using System.Collections;
using System.Collections.Generic;
using M4.Session;
using PajamaLlama.Debugs;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
	[Header("Panels")]
	[SerializeField]
	private PanelID _gameMenuId;

	[SerializeField]
	private GameObject _gameInputsBlocker;

	[Tooltip("Reference to the dynamic portrait")]
	[SerializeField]
	private PortraitDynamic _dynamicPortrait;

	[Header("Content Parents")]
	[Tooltip("Handler for the notifications.")]
	public NotificationHandler NotificationHandler;

	[SerializeField]
	private RewiredActionInfoBar _rewiredActionInfoBar;

	[Header("World Map")]
	[SerializeField]
	private WorldMapCanvas _worldMapCanvas;

	[SerializeField]
	private UIElementsLayerID _gameDefaultActiveUILayers = (UIElementsLayerID)(-1);

	[SerializeField]
	private UIElementsLayerID _worldMapDefaultActiveUILayers;

	[SerializeField]
	[Tooltip("UI elements that appear on top of the loading screen despite their sorting order because of unity bug")]
	private List<GameObject> _elementsToHideDuringLoading = new List<GameObject>();

	private readonly List<PanelContainer> _panels = new List<PanelContainer>(16);

	private readonly List<UIElementsLayer> _uiLayers = new List<UIElementsLayer>(8);

	private Vector2 _canvasResolution = Vector2.zero;

	private RectTransform _rectTransform;

	private Vector2 _screenSize = Vector2.zero;

	private BuildableTooltip _buildableTooltip;

	private bool _displayBuildableTooltip;

	private float _buildableTooltipTimer;

	private IPlaceable _tooltippedPlaceable;

	private Vector3 _buildableTooltipPosition = Vector3.zero;

	private readonly Stack<UIState> _previousUIStates = new Stack<UIState>();

	private IEnumerator _buildableCoroutineNumerator;

	private CanvasGroup _canvasGroup;

	private readonly List<IUIFlagsProvider> _flagsProviders = new List<IUIFlagsProvider>();

	private bool _updateFlags;

	private bool _updateBlockers;

	private GraphicRaycaster[] _raycasters;

	public List<PanelContainer> OpenPanels { get; } = new List<PanelContainer>();

	public UIState UIState { get; private set; }

	public UIFlags Flags { get; set; }

	public PanelContainerFlags PanelContainerFlags { get; private set; }

	public Vector2 CanvasResolution => _canvasResolution;

	public Vector2 ScreenSize => _screenSize;

	public SelectionFrame SelectionFrame { get; private set; }

	public bool DisplayFreeMooringPointIcons { get; private set; }

	public BuildablePreviewTooltip BuildablePreviewTooltip { get; private set; }

	public Canvas Canvas { get; private set; }

	public WorldMapCanvas WorldMapCanvas => _worldMapCanvas;

	public static bool AllowCancel { get; private set; } = true;

	public static bool AllowArchitectMode { get; private set; } = true;

	public static bool HasInstance
	{
		get
		{
			UIManager instance;
			return TryReturnInstance(out instance);
		}
	}

	public static UIState State
	{
		get
		{
			if (TryReturnInstance(out var instance))
			{
				return instance.UIState;
			}
			return UIState.Normal;
		}
	}

	public static bool IsPaused
	{
		get
		{
			UIState state = State;
			return state == UIState.Paused || state == UIState.Typing || state == UIState.GameTimePaused;
		}
	}

	public static Vector2 CanvasMousePosition
	{
		get
		{
			Vector2 result = FlotsamInputManager.MousePosition;
			if (TryReturnInstance(out var instance))
			{
				Vector2 zero = Vector2.zero;
				float num = instance.CanvasResolution.x * 0.5f;
				float num2 = instance.CanvasResolution.y * 0.5f;
				zero.x = FlotsamGame.RemapRange(result.x, 0f, Screen.width, 0f - num, num);
				zero.y = FlotsamGame.RemapRange(result.y, 0f, Screen.height, 0f - num2, num2);
				return zero;
			}
			return result;
		}
	}

	public void Initialize()
	{
		Canvas = GetComponent<Canvas>();
		SelectionFrame = GetComponentInChildren<SelectionFrame>(includeInactive: true);
		_buildableTooltip = GetComponentInChildren<BuildableTooltip>(includeInactive: true);
		BuildablePreviewTooltip = GetComponentInChildren<BuildablePreviewTooltip>(includeInactive: true);
		_canvasGroup = GetComponentInChildren<CanvasGroup>(includeInactive: true);
		_raycasters = GetComponentsInChildren<GraphicRaycaster>(includeInactive: true);
		if (_buildableTooltip == null)
		{
			Debugger.Warning("No buildable tooltip found!", this);
		}
		if (SelectionFrame == null)
		{
			Debugger.Warning("No selection frame found!", this);
		}
		_rectTransform = GameManager.UIManager.GetComponent<RectTransform>();
		_canvasResolution = new Vector2(_rectTransform.rect.width, _rectTransform.rect.height);
		_screenSize = new Vector2(Screen.width, Screen.height);
		_buildableCoroutineNumerator = BuildableTooltipTimerCoroutine();
		_previousUIStates.Push(UIState.Normal);
		PopulatePanels();
		ActivateGameUILayers();
		GameEventDispatcher.AddListener(GameEventType.GameStart, ShowSavePopUps);
		GameEventDispatcher.AddListener(GameEventType.MapActivated, ActivateWorldMapUILayers);
		GameEventDispatcher.AddListener(GameEventType.MapDeactivated, ActivateGameUILayers);
	}

	private void Update()
	{
		if (_rectTransform == null)
		{
			return;
		}
		_canvasResolution.x = _rectTransform.rect.width;
		_canvasResolution.y = _rectTransform.rect.height;
		if (State != UIState.Normal || EventSystem.current.IsPointerOverGameObject() || !FlotsamInputManager.GetButtonDoublePressUp(30))
		{
			return;
		}
		int count = OpenPanels.Count;
		while (0 < count--)
		{
			if (OpenPanels[count].CloseOnCancel)
			{
				OpenPanels[count].Close();
			}
		}
	}

	private void LateUpdate()
	{
		if (_updateFlags)
		{
			UpdateFlags();
		}
		if (_updateBlockers)
		{
			UpdateBlockers();
		}
	}

	public void Clear()
	{
		_previousUIStates.Clear();
		_previousUIStates.Push(UIState.Normal);
		NotificationHandler.Clear();
		GameSpeedManager.Reset();
	}

	public void RestartGame()
	{
		ClosePanel(PanelID.GameMenu);
		UnpauseGame();
		GameSpeedManager.SetGameSpeed(GameSpeed.One);
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void PopupExitToMainMenuDialog(DialogProperties properties)
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(properties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleExitToMainMenuDialog);
		}
	}

	private void HandleExitToMainMenuDialog(bool quit)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleExitToMainMenuDialog);
		if (quit)
		{
			QuitToMainMenu();
		}
	}

	public void QuitToMainMenu()
	{
		if (!(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("_02_GameWorld")))
		{
			Session.Profile.EndRun();
		}
	}

	public void PopupExitToDesktopDialog(DialogProperties properties)
	{
		if (PopUpDialog.Instance.TryOpenPopUpDialog(properties))
		{
			PopUpDialog.Instance.DialogFeedbackEvent.AddListener(HandleExitToDesktopDialog);
		}
	}

	private void HandleExitToDesktopDialog(bool quit)
	{
		PopUpDialog.Instance.DialogFeedbackEvent.RemoveListener(HandleExitToDesktopDialog);
		if (quit)
		{
			QuitGame();
		}
	}

	public void QuitGame()
	{
		GameManager.QuitToDesktop();
	}

	public void PauseGame(UIState state = UIState.Paused)
	{
		_previousUIStates.Push(state);
		UIState = state;
		if (state != UIState.GameTimePaused)
		{
			GameSpeedManager.Pause();
		}
	}

	public void UnpauseGame()
	{
		_previousUIStates.Pop();
		if (_previousUIStates.Count == 0)
		{
			_previousUIStates.Push(UIState.Normal);
		}
		UIState = _previousUIStates.Peek();
		if (_previousUIStates.Count == 1)
		{
			GameSpeedManager.Unpause();
		}
	}

	public void ToggleUIEnabled()
	{
		if (Canvas.enabled)
		{
			DisableUI();
		}
		else
		{
			EnableUI();
		}
	}

	public void EnableUI()
	{
		Canvas.enabled = true;
		_canvasGroup.blocksRaycasts = true;
		_canvasGroup.interactable = true;
		_canvasGroup.alpha = 1f;
		GraphicRaycaster[] raycasters = _raycasters;
		for (int i = 0; i < raycasters.Length; i++)
		{
			raycasters[i].enabled = true;
		}
		CameraController.Instance.UICamera.gameObject.SetActive(value: true);
	}

	public void DisableUI()
	{
		Canvas.enabled = false;
		_canvasGroup.blocksRaycasts = false;
		_canvasGroup.interactable = false;
		_canvasGroup.alpha = 0f;
		GraphicRaycaster[] raycasters = _raycasters;
		foreach (GraphicRaycaster graphicRaycaster in raycasters)
		{
			if (graphicRaycaster.enabled)
			{
				graphicRaycaster.enabled = false;
				continue;
			}
			Debug.LogWarningFormat("GraphicRaycaster '{0}' is disabled... this could be a problem!", graphicRaycaster);
		}
		CameraController.Instance.UICamera.gameObject.SetActive(value: false);
	}

	public void SetGameInputsBlockerActive(bool active)
	{
		if (_gameInputsBlocker != null)
		{
			_gameInputsBlocker.SetActive(active);
		}
	}

	public void SetUILayersActive(UIElementsLayerID layerMask, bool active, UIElementsLayerID exceptMask = (UIElementsLayerID)0)
	{
		if (active)
		{
			layerMask &= ((State == UIState.Map) ? _worldMapDefaultActiveUILayers : _gameDefaultActiveUILayers);
		}
		layerMask &= layerMask ^ exceptMask;
		foreach (UIElementsLayer uiLayer in _uiLayers)
		{
			if (layerMask.HasFlag(uiLayer.LayerID))
			{
				uiLayer.gameObject.SetActive(active);
			}
		}
	}

	public void SetUILayersInteractable(UIElementsLayerID layerMask, bool interactable)
	{
		foreach (UIElementsLayer uiLayer in _uiLayers)
		{
			if (layerMask.HasFlag(uiLayer.LayerID))
			{
				uiLayer.SetInputsActive(interactable);
			}
		}
	}

	private void ShowSavePopUps(GameEvent gameEvent)
	{
		if (gameEvent.EventType != GameEventType.GameStart)
		{
			return;
		}
		if (GameManager.PersistenceManager.IsRestoredGame && PersistenceManager.DoesSaveInfoVersionComeBefore(0, 3, 2))
		{
			PopUpDialog.Instance.QueuePopUp(GameManager.Settings.UISettings.OldSeagullLandmarkProperties);
			if (Community.PlayerCommunity.Birds.Count > 0)
			{
				PopUpDialog.Instance.QueuePopUp(GameManager.Settings.UISettings.SeagullsUpdatedProperties);
			}
		}
		PopUpDialog.Instance.ShowQueuedPopUps();
	}

	private void ActivateGameUILayers(GameEvent gameEvent = null)
	{
		SetUILayersActive(_worldMapDefaultActiveUILayers, active: false, _gameDefaultActiveUILayers);
		SetUILayersActive(_gameDefaultActiveUILayers, active: true);
	}

	private void ActivateWorldMapUILayers(GameEvent gameEvent = null)
	{
		SetUILayersActive(_gameDefaultActiveUILayers, active: false, _worldMapDefaultActiveUILayers);
		SetUILayersActive(_worldMapDefaultActiveUILayers, active: true);
	}

	public void EnableDynamicPortrait(Agent agent, Activity activity = Activity.DynamicPortrait)
	{
		_dynamicPortrait.Enable(agent, activity);
	}

	public void EnableDynamicPortrait(AgentDescriptor descriptor, Activity activity = Activity.DynamicPortrait)
	{
		_dynamicPortrait.Enable(descriptor, activity);
	}

	public void DisableDynamicPortrait(Agent agent = null)
	{
		_dynamicPortrait.Disable(agent);
	}

	public void DisableDynamicPortrait(AgentDescriptor descriptor)
	{
		_dynamicPortrait.Disable(descriptor);
	}

	public void SetDynamicPortraitActivity(Activity activity)
	{
		_dynamicPortrait.SetActivity(activity);
	}

	public bool IsDynamicPortraitEnabled()
	{
		return _dynamicPortrait.IsEnabled();
	}

	public bool CanDisplayPanel(PanelID panelID, IPanelContext context = null)
	{
		foreach (PanelContainer panel in _panels)
		{
			if ((bool)panel && panel.CanOpen(panelID, context))
			{
				return true;
			}
		}
		return false;
	}

	public bool DisplayPanel(PanelID panelID)
	{
		return DisplayPanel(panelID, null);
	}

	public bool DisplayPanel(IPanelContext context)
	{
		return DisplayPanel(context.PanelID, context);
	}

	public bool DisplayPanel(PanelID panelID, IPanelContext context)
	{
		foreach (PanelContainer panel in _panels)
		{
			if (!panel || !panel.Open(panelID, context))
			{
				continue;
			}
			switch (panel.Exclusivity)
			{
			case PanelContainerExclusivity.Exclusive:
				CloseAllPanels(panel);
				break;
			case PanelContainerExclusivity.ExcludePanels:
				if (!panel.ExcludedPanels.IsNullOrEmpty())
				{
					PanelID[] excludedPanels = panel.ExcludedPanels;
					foreach (PanelID panelID2 in excludedPanels)
					{
						ClosePanel(panelID2);
					}
				}
				break;
			}
			return true;
		}
		Debug.LogWarningFormat("Unable to open UI Panel with ID '{0}'", panelID);
		return false;
	}

	public bool TryGetPanel(PanelID panelID, out Panel panel)
	{
		foreach (PanelContainer panel2 in _panels)
		{
			if (panel2.TryGetPanel(panelID, out panel))
			{
				return true;
			}
		}
		panel = null;
		return false;
	}

	public bool IsPanelOpen(PanelID panelID)
	{
		return OpenPanels.Find((PanelContainer openPanel) => openPanel.ID == panelID) != null;
	}

	public bool ClosePanel(PanelID panelID)
	{
		if (panelID == PanelID.DialoguePanel)
		{
			Debug.LogException(new Exception("Dialogue Panel is being closed, only the dialogue panel should only close itself"));
		}
		int count = OpenPanels.Count;
		while (0 < count--)
		{
			if (OpenPanels[count].ID == panelID)
			{
				OpenPanels[count].Close();
				return true;
			}
		}
		return false;
	}

	public void CloseDrifterPanel()
	{
		ClosePanel(PanelID.AgentPanel);
		ClosePanel(PanelID.AnimalPanel);
	}

	public void CloseAllPanels(PanelContainer panelToExclude = null)
	{
		int count = OpenPanels.Count;
		while (0 < count--)
		{
			PanelContainer panelContainer = OpenPanels[count];
			if (panelContainer != panelToExclude && panelContainer.ID != PanelID.DialoguePanel)
			{
				OpenPanels[count].Close();
			}
		}
	}

	public void AddOpenPanel(PanelContainer panelContainer)
	{
		if (OpenPanels.AddUnique(panelContainer))
		{
			UpdateFlags();
		}
	}

	public void RemoveOpenPanel(PanelContainer panelContainer)
	{
		if (OpenPanels.Remove(panelContainer))
		{
			MarkFlagsDirty();
		}
	}

	private void AddUIFlagsProvider(IUIFlagsProvider provider)
	{
		if (_flagsProviders.AddUnique(provider))
		{
			UpdateFlags();
			UpdateBlockers();
		}
	}

	private void RemoveUIFlagsProvider(IUIFlagsProvider provider)
	{
		if (_flagsProviders.Remove(provider))
		{
			MarkFlagsDirty();
			_updateBlockers = true;
		}
	}

	public void MarkFlagsDirty()
	{
		_updateFlags = true;
	}

	private void UpdateFlags()
	{
		PanelContainerFlags panelContainerFlags = PanelContainerFlags.None;
		if ((FlotsamInputManager.ActiveInput & InputFlags.Joystick) != InputFlags.None)
		{
			foreach (PanelContainer openPanel in OpenPanels)
			{
				panelContainerFlags |= openPanel.Flags;
			}
			foreach (IUIFlagsProvider flagsProvider in _flagsProviders)
			{
				panelContainerFlags |= flagsProvider.Flags;
			}
		}
		if (PanelContainerFlags != panelContainerFlags)
		{
			PanelContainerFlags = panelContainerFlags;
			GameEventDispatcher.Dispatch(GameEventType.UIFlagsUpdated);
		}
		_updateFlags = false;
	}

	private void UpdateBlockers()
	{
		AllowCancel = true;
		AllowArchitectMode = true;
		foreach (IUIFlagsProvider flagsProvider in _flagsProviders)
		{
			if (flagsProvider.BlockCancel)
			{
				AllowCancel = false;
			}
			if (flagsProvider.BlockArchitectMode)
			{
				AllowArchitectMode = false;
			}
		}
		GameEventDispatcher.Dispatch(GameEventType.UIBlockersUpdated);
		_updateBlockers = false;
	}

	public static void AddFlagsProvider(IUIFlagsProvider provider)
	{
		if (GameManager.UIManager != null)
		{
			GameManager.UIManager.AddUIFlagsProvider(provider);
		}
	}

	public static void RemoveFlagsProvider(IUIFlagsProvider provider)
	{
		if (GameManager.UIManager != null)
		{
			GameManager.UIManager.RemoveUIFlagsProvider(provider);
		}
	}

	public void OpenGameMenu()
	{
		if (!Input.GetMouseButton(0) && UIState != UIState.Map && !ClosePanel(_gameMenuId) && UIState != UIState.Paused)
		{
			DisplayPanel(_gameMenuId);
		}
	}

	public void SelectCurrentResearch()
	{
		DisplayPanel(PanelID.TechTreePanel);
		Debug.Log("[TODO] Select current research.");
	}

	public void SelectResearch(CommunityResearch.Research research)
	{
		DisplayPanel(PanelID.TechTreePanel);
		Debug.Log("[TODO] Select research.");
	}

	private void PopulatePanels()
	{
		Transform parent = base.transform;
		_panels.Clear();
		PopulatePanels(_panels, parent, 0, 1);
		_uiLayers.Clear();
		_uiLayers.AddRange(GetComponentsInChildren<UIElementsLayer>());
		foreach (UIElementsLayer uiLayer in _uiLayers)
		{
			_panels.AddRange(uiLayer.Panels);
		}
	}

	private void PopulatePanels(List<PanelContainer> panels, Transform parent, int depth, int maxDepth)
	{
		int childCount = parent.childCount;
		while (0 < childCount--)
		{
			Transform child = parent.GetChild(childCount);
			if (child.TryGetComponent<PanelContainer>(out var component))
			{
				component.Initialize();
				_panels.Add(component);
			}
			else if (depth < maxDepth)
			{
				PopulatePanels(panels, child, depth + 1, maxDepth);
			}
		}
	}

	public void StartBuildableTooltipTimer(IPlaceable buildableProperties, Vector3 position, bool delay = true, bool upgradeResources = false)
	{
		_tooltippedPlaceable = buildableProperties;
		_buildableTooltipPosition = FlotsamGame.SetY(position, position.y + _buildableTooltip.VerticalOffset);
		_displayBuildableTooltip = true;
		StopCoroutine(_buildableCoroutineNumerator);
		_buildableCoroutineNumerator = BuildableTooltipTimerCoroutine(delay, upgradeResources);
		StartCoroutine(_buildableCoroutineNumerator);
	}

	private IEnumerator BuildableTooltipTimerCoroutine(bool delay = true, bool upgradeResources = false)
	{
		_buildableTooltipTimer = 0f;
		while (delay && _buildableTooltipTimer < GameManager.Settings.UISettings.TooltipDelay)
		{
			_buildableTooltipTimer += GameSpeedManager.PausableUnscaledDeltaTime;
			if (!_displayBuildableTooltip)
			{
				break;
			}
			yield return null;
		}
		if (_displayBuildableTooltip)
		{
			_buildableTooltip.gameObject.SetActive(value: true);
			_buildableTooltip.transform.position = _buildableTooltipPosition;
			_buildableTooltip.DisplayTooltip(_tooltippedPlaceable, upgradeResources);
		}
	}

	public void ResetBuildableTooltipTimer(IPlaceable properties)
	{
		if (_tooltippedPlaceable == properties)
		{
			_buildableTooltipTimer = 0f;
			_buildableTooltip.HideTooltip();
			StopCoroutine(_buildableCoroutineNumerator);
		}
	}

	public void ShowFreeMooringPointIcon(bool show)
	{
		DisplayFreeMooringPointIcons = show;
		List<MooringPoint> list = Community.PlayerCommunity.ReturnAllMooringPoints();
		for (int i = 0; i < list.Count; i++)
		{
			list[i].MooringPointUpdated.Invoke();
		}
	}

	public static void SetState(UIState state)
	{
		UIManager uIManager = GameManager.UIManager;
		if ((bool)uIManager && uIManager.UIState != state)
		{
			uIManager.UIState = state;
			GameEventDispatcher.Dispatch(GameEventType.UIStateChanged);
		}
	}

	public static void AddRewiredActionInfo(params IRewiredAction[] actions)
	{
		if ((bool)GameManager.UIManager && (bool)GameManager.UIManager._rewiredActionInfoBar)
		{
			GameManager.UIManager._rewiredActionInfoBar.AddActions(actions);
		}
	}

	public static void RemoveRewiredActionInfo(params IRewiredAction[] actions)
	{
		if ((bool)GameManager.UIManager && (bool)GameManager.UIManager._rewiredActionInfoBar)
		{
			GameManager.UIManager._rewiredActionInfoBar.RemoveActions(actions);
		}
	}

	public static void AddRewiredActionInfoToContext(UnityEngine.Object context, params IRewiredAction[] actions)
	{
		if ((bool)GameManager.UIManager && (bool)GameManager.UIManager._rewiredActionInfoBar)
		{
			GameManager.UIManager._rewiredActionInfoBar.AddActionToContext(context, actions);
		}
	}

	public static void RemoveActionInfoFromContext(UnityEngine.Object context, params IRewiredAction[] actions)
	{
		if ((bool)GameManager.UIManager && (bool)GameManager.UIManager._rewiredActionInfoBar)
		{
			GameManager.UIManager._rewiredActionInfoBar.RemoveActionsFromContext(context, actions);
		}
	}

	public static void DisableRewiredActionInfoContext(UnityEngine.Object context)
	{
		if ((bool)GameManager.UIManager && (bool)GameManager.UIManager._rewiredActionInfoBar)
		{
			GameManager.UIManager._rewiredActionInfoBar.DisableContext(context);
		}
	}

	public static bool TryReturnInstance(out UIManager instance)
	{
		instance = GameManager.UIManager;
		return instance != null;
	}

	public static bool HasOpenPanels()
	{
		if (TryReturnInstance(out var instance))
		{
			return !instance.OpenPanels.IsNullOrEmpty();
		}
		return false;
	}

	public static bool HasFlagsSet(PanelContainerFlags flags)
	{
		if (TryReturnInstance(out var instance))
		{
			return (instance.PanelContainerFlags & flags) == flags;
		}
		return false;
	}

	public static bool HasFlagsNotSet(PanelContainerFlags flags)
	{
		if (TryReturnInstance(out var instance))
		{
			return (instance.PanelContainerFlags & flags) == 0;
		}
		return false;
	}
}
