using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Gh.Tk.UI;
using Gh.Tk.UI.Dialogs;
using Gh.Tk.UI.Dialogs.Notification;
using Gh.Tk.UI.InfoPanels;
using I18n;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PostProcessing;
using UnityEngine.Serialization;
using Utils;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	public class UIController : SingletonMonoBehaviour<UIController>, IPersistable
	{
		public interface IUIUpdateable
		{
			void UpdateUI(float deltaTime);
		}

		public class PickableStock : IPersistable
		{
			[PersistenceObjectReference]
			public GameItemTemplate Template { get; set; }

			public string GroupCategory { get; set; }

			public int AvailableAmount { get; set; }

			public MarketTrend AvailableAmountTrend { get; set; }

			public int BoughtAmount { get; set; }

			public int Price { get; set; }

			public ShopItemPriceVariation PriceVariation { get; set; }

			public MarketTrend PriceTrend { get; set; }

			public ShopItemDemand ItemDemand { get; set; }

			public MarketTrend ItemDemandTrend { get; set; }
		}

		public class UINotificationVisualData : IPersistable
		{
			public string id;

			public bool isOpened;

			public bool isChecklistOpen;

			public string groupId;

			public bool notificationBellPlayed;

			public string activeGroupMemberId;

			public int groupPriority;

			protected UINotificationVisualData()
			{
			}

			public UINotificationVisualData(string id)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetWeatherCheatMenuItems_003Ed__437 : IEnumerable<ContextMenuItem>, IEnumerable, IEnumerator<ContextMenuItem>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private ContextMenuItem _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private float[] _003Cintensities_003E5__2;

			private IEnumerator<WeatherEffectBase> _003C_003E7__wrap2;

			ContextMenuItem IEnumerator<ContextMenuItem>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CGetWeatherCheatMenuItems_003Ed__437(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<ContextMenuItem> IEnumerable<ContextMenuItem>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CLogStreamRoutine_003Ed__435 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CLogStreamRoutine_003Ed__435(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private static Camera _uiCamera;

		public GameObject tooltipPrefab;

		[SerializeField]
		private GameObject _demolishOverlay;

		[SerializeField]
		private GameObject _designOverlay;

		[SerializeField]
		private DesignModePurple _designModePurple;

		[SerializeField]
		private GameObject _multiSelectionOverlay;

		[FormerlySerializedAs("_buildPickerOverlay")]
		[SerializeField]
		private GameObject _cloneToolOverlay;

		[SerializeField]
		private SpecialScreenEffectVisual[] _screenEffects;

		public const float MINIMUM_ASPECT_RATIO = 1.76f;

		private BuildController _buildController;

		[PersistenceOptIn]
		private RollingList<string> _uiDebugLogs;

		public bool useFrameLockedTime;

		private int _prevHeight;

		private int _prevWidth;

		private LayerMask _exclusionMask;

		private Dictionary<Camera, int> _appliedMasks;

		public List<Camera> renderCameras;

		private List<IUIUpdateable> _uiUpdateables;

		private List<IUIUpdateable> _gameUIUpdateables;

		private float _deltaSum;

		private float _targetInterval;

		private int _targetUIFPS;

		private int _currentTockCount;

		private bool _isTick;

		public FrameCachedValue<IEnumerable<RaycastResult>> HoveredUGUI;

		private bool _isWallIndexVisible;

		private float _lastSparkTick;

		private float _sparkTickInterval;

		private string _currentOverlay;

		private string _playerSelectedOverlay;

		private List<Action> _preRenderActions;

		private bool _showPatronPoolInfo;

		[SerializeField]
		private GameObject _cantAffordVisualPrefab;

		private FeedbackButton3DUIView[] _feedbackButtons;

		private List<FilterButton3DUIView> _filterButtons;

		private Dictionary<string, Button3DUIView> _subCategoryButtonInstances;

		private TextMeshProI18n _currentCostText;

		private Dictionary<string, Button3DUIView> _zoneSelectionButtonsDict;

		private readonly List<PropBuildButton3DUIView> _propButtonInstances;

		private Dictionary<string, int> _categorySearchCounts;

		private Dictionary<string, int> _subCategorySearchCounts;

		private Dictionary<BuildableTemplate, BuildableTemplate> _variantGroupDefaultTemplates;

		private bool _autoSelectZoneUnderMouseCursor;

		private Vector3 _lastCheckedMouseCursorPosition;

		private TextSizeGroup _subCategoryTextSizeGroup;

		private TextSizeGroup _subCategorySearchCountTextSizeGroup;

		private bool _buildableSortingAscending;

		private int _currentSelectionPage;

		private bool _initiatedSelectionButtons;

		private bool _ignoreMoneyChange;

		private bool _autoSwitchedToZoning;

		public static EventHandler<ValueChangedEventArgs<BuildMenuState>> BuildMenuStateChangedEvent;

		private BuildMenuState _buildMenuState;

		private bool _decoModeEnabledFreeCam;

		public const string SocketModelName = "_SMP_";

		private Coroutine _logStreamTest;

		private bool _spawnSingleGameItems;

		private bool _spawnSingleIngredients;

		private Dictionary<string, TooltipData> _codexTooltips;

		[SerializeField]
		private SimpleDecisionWindow3DUIView _simpleDecisionWindow;

		private SimpleDecisionWindow3DUIView _customDecisionWindow;

		[SerializeField]
		private SimpleInputDialog3DUIView _simpleInputDialog;

		private Queue<Action> _popupQueue;

		private static Mesh _boundsBakingMesh;

		private static int[] _boundingBoxLayers;

		private static Vector3 _colliderOverlapPadding;

		private float _alignmentCornerMultiplier;

		public static FrameCachedValue<float> AspectedScreenWidth;

		public static FrameCachedValue<float> ScreenWidthAspectMultiplier;

		public bool IsInfoPanelOpen;

		private Transform _infoPanel;

		private InfoPanel _currentInfoPanel;

		private MouseHelper _mouseHelper;

		private string _currentNotificationDialogId;

		private List<UINotificationData> _notifications;

		private Dictionary<string, Action<int>> _notificationDecisionCallbacks;

		private Dictionary<string, Action> _notificationDialogOpenCallbacks;

		private Dictionary<string, Action> _notificationDismissCallbacks;

		private Queue<string> _notificationDialogQueue;

		private Transform _notificationsTransform;

		private Transform _currentNotification;

		public bool IsNotificationOpen;

		private Dictionary<string, bool> _uiVisibilityFlags;

		private List<string> _designModeUIVisibilityFlags;

		private List<string> _dialogWithStatusBar;

		[SerializeField]
		private GameObject _miscTavernUI;

		private bool _tavernUIVisible;

		public static Vector2Int CameraViewSize => default(Vector2Int);

		public static int CameraViewWidth => 0;

		public static int CameraViewHeight => 0;

		public static int ActualScreenWidth => 0;

		public static int ActualScreenHeight => 0;

		public static Camera UICamera { get; private set; }

		public static PostProcessingProfile FinalPostProcessingProfile { get; private set; }

		public static Camera TextCamera { get; private set; }

		public static Camera CardCamera { get; private set; }

		public static LayerMask UILayerMask { get; private set; }

		public AlertManager_3DUIView Alerts { get; private set; }

		public MainMenu3DUIView MainMenu { get; private set; }

		public PauseMenu3DUIView PauseMenu { get; private set; }

		public Dialogs3DUIView Dialogs { get; private set; }

		public SideInfoPanels3DUIView SideInfos { get; private set; }

		public StatusBar3DUIView StatusBar { get; private set; }

		public StatusBarLite3DUIView StatusBarLite { get; private set; }

		public DesignModeStatusBar3DUIView DesignModeStatusBar { get; private set; }

		public StarRevealDialog3DUIView StarRevealer { get; private set; }

		public UnlockScreenDialog3DUIView UnlockScreen { get; private set; }

		public TavernStars3DUIView TavernStarBoard { get; private set; }

		public Tooltip3DUIView Tooltip { get; private set; }

		public ContextMenu3DUIView ContextMenu { get; private set; }

		public ContextMenu3DUIView DevMenu { get; private set; }

		public FeedbackWindow3DUIView FeedbackWindow { get; private set; }

		public DirectorsToolbar3DUIView DirectorsToolbar { get; private set; }

		public ShareCodePopUp3DUIView ShareCodePopUp { get; private set; }

		public DecorationToolbar3DUIView DecorationToolbar { get; private set; }

		public StylePicker3DUIView StylePicker { get; private set; }

		public UserHandbook3DUIView UserHandbook { get; private set; }

		public AspectRatioMask AspectRatioMask { get; private set; }

		public ThanksForPlayingDialog3DUIView ThanksForPlayingDialog { get; private set; }

		public InteractiveFictionDialog3DUIView InteractiveFictionDialog { get; private set; }

		public LevelEditorToolbar3DUIView LevelEditorToolbar { get; private set; }

		public static bool IsReady { get; private set; }

		public static bool IsBusy => false;

		public Transform UISocket { get; private set; }

		public static float DeltaTime => 0f;

		public static float SmoothDeltaTime => 0f;

		public static Vector2 CameraViewCenter => default(Vector2);

		public BuildMenu3DUIView BuildMenu { get; private set; }

		public BuildMenuSearch3DUIView BuildMenuSearch { get; private set; }

		public Transform PaperBackerWithOutFilterArea { get; private set; }

		private Color _positiveTextColor => default(Color);

		private Color _negativeTextColor => default(Color);

		public bool IsBuildMenuStateDirty { get; private set; }

		public string CurrentQuickFilterId { get; private set; }

		public string CurrentBuildMenuSortingType { get; private set; }

		public string CurrentBuildMenuZoneFilter { get; private set; }

		public string CurrentBuildMenuCategoryFilter { get; private set; }

		public string CurrentSubCategoryFilter { get; private set; }

		[PersistenceOptIn]
		public List<string> FilterButtonsSeen { get; set; }

		[PersistenceOptIn]
		public List<string> SelectionButtonsSeen { get; set; }

		[PersistenceOptIn]
		public List<string> SubCategoryButtonsSeen { get; set; }

		public BuildMenuState BuildMenuState
		{
			get
			{
				return default(BuildMenuState);
			}
			private set
			{
			}
		}

		public bool IsDevMenuOpen => false;

		public DevCommentaryToolbar3DUIView DevCommentaryToolbar { get; private set; }

		public bool IsAnyDialogOpen => false;

		private static int[] BoundingBoxLayers => null;

		public bool IsInfoPanelBlockingNotifications => false;

		public InfoPanel CurrentInfoPanel => null;

		public ISelectable CurrentSelectable { get; private set; }

		public bool IsCurrentSelectableValid => false;

		public NotificationArea3DUIView NotificationArea { get; private set; }

		[PersistenceOptIn]
		public Dictionary<string, UINotificationVisualData> NotificationVisualData { get; set; }

		public bool IsUIMasked => false;

		public static event EventHandler UITick
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler UITock
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler ResetUI
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler AtmosphereOverlayChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler ScreenSizeChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler QuickSearchFilterChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler CurrentSelectableChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event EventHandler TavernUIVisibilityChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static bool IsUIOrCameraBusy()
		{
			return false;
		}

		public static void AddUIDebugLog(string log)
		{
		}

		public override void Awake()
		{
		}

		public void InitUI()
		{
		}

		private void OnLoadingScreenStateChanged(object sender, EventArgs e)
		{
		}

		private void OnLevelUnload(object sender, EventArgs e)
		{
		}

		private void InitControls()
		{
		}

		public void MaskUI()
		{
		}

		public void UnmaskUI()
		{
		}

		private void SetExclusionMask(bool isEnabled)
		{
		}

		public Camera[] GetRenderCameras()
		{
			return null;
		}

		public void ClearUI()
		{
		}

		public void ResetDefaultValues()
		{
		}

		public void ResetPostLoad()
		{
		}

		public void AddGameUIUpdateable(IUIUpdateable updateable)
		{
		}

		public void AddUIUpdateable(IUIUpdateable updateable)
		{
		}

		public void RemoveUIUpdateable(IUIUpdateable updateable)
		{
		}

		public void RemoveGameUIUpdateable(IUIUpdateable updateable)
		{
		}

		public void UpdateUISystems()
		{
		}

		private void UpdateUpdateables(List<IUIUpdateable> updateables)
		{
		}

		public void UpdateGameStateUI()
		{
		}

		public static Action<InputAction.CallbackContext> InputWrapperWithUI(Action<InputAction.CallbackContext> action, bool allowWhileTyping = false, bool allowWhileCameraFrozen = false, bool allowWhileLoading = false)
		{
			return null;
		}

		public static Action<InputAction.CallbackContext> InputWrapper(Action<InputAction.CallbackContext> action, bool allowWhileTyping = false, bool allowWhileCameraFrozen = false, bool allowWhileLoading = false)
		{
			return null;
		}

		private static Action<InputAction.CallbackContext> InputWrapper(Action<InputAction.CallbackContext> action, bool allowMouseOnUIInput, bool allowWhileTyping, bool allowWhileCameraFrozen, bool allowWhileLoading)
		{
			return null;
		}

		public bool IsMouseOnUI()
		{
			return false;
		}

		public bool IsMouseOnUnityUI()
		{
			return false;
		}

		public bool IsMouseOn3DUI()
		{
			return false;
		}

		public BaseInteractable3DUIView GetInteractableUnderMouse()
		{
			return null;
		}

		public void OnStarRatingChanged(object sender, EventArgs<float> e)
		{
		}

		public void OnResearchChanged(object sender, EventArgs e)
		{
		}

		public void ToggleFPSCounter()
		{
		}

		private void ToggleWallIndexVisuals()
		{
		}

		private void EnableDamageTint(bool enable)
		{
		}

		private void EnableFilthTint(bool enable)
		{
		}

		private void EnableFlammabilityTint(bool enable)
		{
		}

		private void UpdateFakeSparkTick(object sender, EventArgs eventArgs)
		{
		}

		public void SetAtmosphereOverlay(string id, bool playerSelected = true)
		{
		}

		private void RefreshTint(Buildable buildable)
		{
		}

		private void UpdateTint(string oldOverlay)
		{
		}

		public bool IsAtmosphereOverlayActiveFromSystem()
		{
			return false;
		}

		public bool IsAtmosphereOverlayActive()
		{
			return false;
		}

		public string GetCurrentAtmosphereOverlay()
		{
			return null;
		}

		public void ExecutePreRenderFrame(Action action)
		{
		}

		private void OnPreRender()
		{
		}

		private void OnGUI()
		{
		}

		private void UpdateDebugInfos()
		{
		}

		public void PlayScreenEffect(SpecialScreenEffectVisual.SpecialEffects effect)
		{
		}

		public void ShowCantAffordVisual()
		{
		}

		public void OpenFeedbackWindow()
		{
		}

		public void ToggleDirectorsToolbar()
		{
		}

		public void SetBugAlertState(bool isBugPresent)
		{
		}

		protected void OnDestroy()
		{
		}

		public void EnableUIGuide(string uiGuideId)
		{
		}

		public void DisableUIGuide(string uiGuideId)
		{
		}

		public void QueueErrorPopUp(NotEnoughStorageSpaceException nex)
		{
		}

		public void QueueErrorPopUp(string title, string message)
		{
		}

		internal void ShowBuildControls()
		{
		}

		internal bool HideBuildControls(bool withAnimations = true)
		{
			return false;
		}

		public void SetMultiSelectOverlay(bool show)
		{
		}

		public void SetCloneToolOverlay(bool show)
		{
		}

		public void StopBuilding()
		{
		}

		private void NudgeConfirmDialog()
		{
		}

		private void OnCurrentCostChanged(object sender, EventArgs e)
		{
		}

		private void ActivateZoningSelection()
		{
		}

		private Button3DUIView PositionZoningButton(string zoneName, int slot)
		{
			return null;
		}

		private void UpdateCostValues()
		{
		}

		private void CreatePropBuildButtonInstances(int maxSelectionButtons)
		{
		}

		public void InvalidateBuildMenuState()
		{
		}

		public void PopulateBuildPropButtons()
		{
		}

		public void OpenBuildMenuOnPage(string propKey)
		{
		}

		private IEnumerable<BuildableTemplate> OrderBySelectedSortingType(IEnumerable<BuildableTemplate> list)
		{
			return null;
		}

		private void ClearSearchCounts()
		{
		}

		private IEnumerable<BuildableTemplate> GetPropItemsForCurrentFilterSettings(bool ignoreSubCategories = false)
		{
			return null;
		}

		private void AddSearchCounts(string[] categories, string[] subCategories)
		{
		}

		public bool IsBuildMenuSearchFilterActive()
		{
			return false;
		}

		public void SetBuildMenuQuickSearchFilter(string filterId)
		{
		}

		private bool IsQuickSearchFilterActive()
		{
			return false;
		}

		private bool DoesTemplateMatchQuickSearchFilter(BuildableTemplate template)
		{
			return false;
		}

		private bool IsCustomSearchFilterActive()
		{
			return false;
		}

		private bool DoesMatchCustomSearchFilter(BuildableTemplate template)
		{
			return false;
		}

		internal void InvalidateBuildableButtons()
		{
		}

		private BuildableTemplate[] GetAvailableItemsForCurrentFilter()
		{
			return null;
		}

		private void UpdatePropBuildButtonContentForPage(int page)
		{
		}

		private void InitBuildMenu()
		{
		}

		private void CollectSeenUIUnlocks()
		{
		}

		private void BuildableTemplate_TemplatesChanged(object sender, EventArgs<BuildableTemplate> e)
		{
		}

		public bool IsBuildMenuOpen()
		{
			return false;
		}

		public void CloseBuildMenu()
		{
		}

		public void OpenBuildMenu()
		{
		}

		private void UpdateUIController_BuildControls()
		{
		}

		public bool DoCurrentBuildablesHaveSubCategories()
		{
			return false;
		}

		private void InvalidateZoneButtonState(int page)
		{
		}

		private bool ShouldDisplayZoneButtons()
		{
			return false;
		}

		private void SetParentSlot(Transform button, Transform transform, string slotName)
		{
		}

		private void InstantiateButtons()
		{
		}

		private void ActivateFilterButtons()
		{
		}

		private void UpdateSubCategoryButtonStates()
		{
		}

		private void AddSubCategoryButton(string subCategory)
		{
		}

		public void SelectBuildable(string uniqueType)
		{
		}

		public void UpdateSelectionButtonStates()
		{
		}

		public void NextSelectionPage()
		{
		}

		public void PreviousSelectionPage()
		{
		}

		private void ShowSelectionButtonsPage(int page)
		{
		}

		private void AddSelectZoneButton(RoomZone zone)
		{
		}

		private void ClearSelectionAndSortingButtons(bool withAnimation = true)
		{
		}

		private void ClearBuildUI()
		{
		}

		private void DisableButtons()
		{
		}

		public void SelectZone(string zoneName)
		{
		}

		public void SortBuildableSelectionButtonsBy(string type)
		{
		}

		public void FilterBuildableSelectionButtonsByZone(string zone)
		{
		}

		public void FilterBuildableSelectionButtonsByCategory(string category)
		{
		}

		public string GetBuildCategoryNameKey(string categoryId)
		{
			return null;
		}

		public bool IsBuildCategoryAvailable(string categoryId)
		{
			return false;
		}

		private void UpdateFilterButtonStates()
		{
		}

		private void UpdateStarCategoryPanelVisibility()
		{
		}

		public float GetStarForBuildCategory(string buildCategoryId)
		{
			return 0f;
		}

		public void FilterBuildableSelectionButtonsBySubCategory(string subCategory)
		{
		}

		private void UpdateTextCreatorButton()
		{
		}

		public void ConfirmZoningChanges()
		{
		}

		public void CancelZoningChanges()
		{
		}

		public void PressDemolishButton()
		{
		}

		private bool IsSwitchingBuildMenuAllowed()
		{
			return false;
		}

		public void PressBuildPropButton()
		{
		}

		public void ToggleDesignMode()
		{
		}

		public void PressZoneButton()
		{
		}

		public bool CanSwitchBuildMenu()
		{
			return false;
		}

		public void PressCloneToolButton()
		{
		}

		private void EnterDecorPlacementGameMode()
		{
		}

		private void ExitDecorPlacementGameMode()
		{
		}

		public bool IsFilterButtonSeen(string key)
		{
			return false;
		}

		public bool IsSelectionButtonSeen(string key)
		{
			return false;
		}

		public void MarkBuildableAsSeen(string key)
		{
		}

		public void ToggleMenuState(BuildMenuState targetState, bool withAnimation = true)
		{
		}

		private string ChooseZoningSFX(RoomZone zone)
		{
			return null;
		}

		private void GameHooks_PropDiscountChanged(object sender, EventArgs<string> e)
		{
		}

		private void OnBuildableDemolished(object sender, EventArgs<Buildable> e)
		{
		}

		private void OnBuildableBuilt(object sender, EventArgs<Buildable> e)
		{
		}

		private void OnFilterButtonHoveredChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnSubCategoryButtonHoveredChanged(object sender, EventArgs<bool> e)
		{
		}

		private void OnHasPendingChangesChanged(object sender, EventArgs e)
		{
		}

		private void ResearchChanged(object sender, EventArgs e)
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		private void Tavern_StarRatingChangedEvent(object sender, EventArgs<float> e)
		{
		}

		public static GameObject AddModelCopyToSocket(GameObjectX gox, Transform modelSocket, BuildableTemplate template)
		{
			return null;
		}

		public static void AddModelToSocket(GameItem item, Transform modelSocket)
		{
		}

		public static void AddModelToSocket(Transform modelTransform, Transform modelSocket, EntityObject entityObject = null, string swatchMaterialIdOverride = null, bool useVertexScaling = true)
		{
		}

		public static void ResizeViaVertices(Transform rootTransform, Transform modelTransform, Transform modelSocket, Renderer[] modelRenderers)
		{
		}

		public static void ResizeViaBounds(Transform rootTransform, Transform modelTransform, Transform modelSocket, Renderer[] modelRenderers)
		{
		}

		private static List<ContextMenuItem> CreatePaginatedMenuItems(string label, List<ContextMenuItem> menuItems, int maxPerPage = 15)
		{
			return null;
		}

		public void ToggleCheatMenu()
		{
		}

		private void CloseDevMenu()
		{
		}

		private void OpenDevMenu()
		{
		}

		private List<ContextMenuItem> CreatePlayerCheatsMenu()
		{
			return null;
		}

		private GroupContextMenuItem CreateGreenbackMenu()
		{
			return null;
		}

		private List<ContextMenuItem> CreateMainMenuDevCheats()
		{
			return null;
		}

		private List<ContextMenuItem> CreateDevCheatsMenu()
		{
			return null;
		}

		private ContextMenuItem CreateSteamTestCheatsMenu()
		{
			return null;
		}

		private ContextMenuItem CreateAchievementsMenu()
		{
			return null;
		}

		private ContextMenuItem CreateCollectibleCardCheats()
		{
			return null;
		}

		private void StartLogStream()
		{
		}

		[IteratorStateMachine(typeof(_003CLogStreamRoutine_003Ed__435))]
		private IEnumerator LogStreamRoutine()
		{
			return null;
		}

		private void StopLogStream()
		{
		}

		[IteratorStateMachine(typeof(_003CGetWeatherCheatMenuItems_003Ed__437))]
		private IEnumerable<ContextMenuItem> GetWeatherCheatMenuItems()
		{
			return null;
		}

		private List<ContextMenuItem> GetGameTimeoutMenuItems(int minutesAmount)
		{
			return null;
		}

		private ContextMenuItem CreateStarRevealCheatMenuItems()
		{
			return null;
		}

		private ContextMenuItem CreateLoanMenuItem()
		{
			return null;
		}

		private List<ContextMenuItem> CreateGoxContextMenuItems()
		{
			return null;
		}

		private GroupContextMenuItem CreateProfileCheats()
		{
			return null;
		}

		private List<ContextMenuItem> CreateProfileUnlockMenuItems()
		{
			return null;
		}

		private List<ContextMenuItem> CreateMapRegionMenuItems()
		{
			return null;
		}

		private ContextMenuItem CreateHireStaffContextMenuItem()
		{
			return null;
		}

		private ContextMenuItem CreateEventCameraTests()
		{
			return null;
		}

		private ContextMenuItem CreateDecorationSetTests()
		{
			return null;
		}

		private ContextMenuItem CreatePatronContextMenuItem()
		{
			return null;
		}

		private List<ContextMenuItem> CreateSpawnPatronWantingShopItemList(ShopItemTemplate template)
		{
			return null;
		}

		private ContextMenuItem CreateActorTraitMenuItem(Type traitType)
		{
			return null;
		}

		private List<ContextMenuItem> CreatePaginatedTraitMenu(string label, IEnumerable<Type> traits)
		{
			return null;
		}

		private List<ContextMenuItem> CreateActorTraitsList()
		{
			return null;
		}

		private ContextMenuItem CreateSpawnItemsContextMenuItem()
		{
			return null;
		}

		private ContextMenuItem CreateSpawnIngredientsContextMenuItem()
		{
			return null;
		}

		private ButtonContextMenuItem CreateIngredientMenuItem(IngredientTemplate template)
		{
			return null;
		}

		public void RefreshDevMenuItems()
		{
		}

		private PatronData GeneratePatronData(int tier, string race = null)
		{
			return null;
		}

		private ContextMenuItem CreateLevelUnlockMenu()
		{
			return null;
		}

		private ContextMenuItem CreateMarketingCheatMenu()
		{
			return null;
		}

		private ContextMenuItem CreateStoryTriggerCheatsMenu()
		{
			return null;
		}

		public StringBuilder ParseTooltipCodexLinks(StringBuilder sb)
		{
			return null;
		}

		public void RegisterCodexTooltip(string keyword, TooltipData tooltip)
		{
		}

		public TooltipData GetCodexTooltip(string templateId)
		{
			return null;
		}

		public void InitTooltipDirectory()
		{
		}

		private void RegisterDynamicCodexTooltips()
		{
		}

		public void ShowDevCommentaryPopUp()
		{
		}

		public void HideDevCommentaryPopUp()
		{
		}

		public T PrepareDialogToOpen<T>(string dialogId, bool closeBuildMenu = true, bool closeInfoPanel = true) where T : BaseDialog3DUIView
		{
			return null;
		}

		public BaseDialog3DUIView PrepareDialogToOpen(string dialogId, bool closeBuildMenu = true, bool closeInfoPanel = true)
		{
			return null;
		}

		public T OpenDialog<T>(string dialogId, bool closeBuildMenu = true, bool closeInfoPanel = true, bool noAnimation = false) where T : BaseDialog3DUIView
		{
			return null;
		}

		public BaseDialog3DUIView OpenDialog(string dialogId, bool closeBuildMenu = true, bool closeInfoPanel = true, bool noAnimation = false)
		{
			return null;
		}

		public bool IsDialogOpen(string dialogId)
		{
			return false;
		}

		public void CloseDialog(string dialogId)
		{
		}

		public void CloseDialog(bool forceClose = false)
		{
		}

		public void OpenMealDesigner(bool openedFromTavernMenu = true)
		{
		}

		public void OpenRenameTavernDialog()
		{
		}

		public void EditTemplateData(BuildableTemplate template, bool isInitialEdit = false, Action<BuildableTemplate> onSubmit = null, Action<BuildableTemplate> onClosedWithoutSave = null)
		{
		}

		public void OpenMerchantDialog(string merchantId, IEnumerable<PickableStock> stock, Action<IEnumerable<Tuple<PickableStock, int>>> finishedCallback)
		{
		}

		public void OpenWorldMapShopDialog(ShopMapMarker mapShop)
		{
		}

		private void OpenSimpleInput(string title, string currentText, string invalidInputText, Action<string> submitCallback, string submitButtonText, Action<string> inputChangedCallback = null, Action closedCallback = null)
		{
		}

		public void QueueSimpleInput(string title, string currentText, string invalidInputText, Action<string> submitCallback, string submitButtonText, Action<string> inputChangedCallback = null, Action closedCallback = null)
		{
		}

		public void QueueOnlineFeaturesPopUp(Action okAction = null, Action cancelAction = null)
		{
		}

		public void QueueOkCancelPopUp(string title, string message, Action okAction, Action cancelAction, string okText = null, string cancelText = null, string prefabOverride = null)
		{
		}

		public void QueueOkPopUp(string title, string message, Action okAction, string okText = null)
		{
		}

		public void QueueSaveDiscardCancelPopUp(string title, string message, Action saveAction, Action discardAction, Action cancelAction)
		{
		}

		private SimpleDecisionWindow3DUIView GetDecisionWindow(string id)
		{
			return null;
		}

		private void OnCustomDecisionWindowClosed(object sender, EventArgs e)
		{
		}

		public void UpdatePopUpQueue()
		{
		}

		public bool IsPopUpOpen()
		{
			return false;
		}

		public void ClosePopUp(bool callCancelAction = false)
		{
		}

		public void SetPopUpMessageText(string msgKey)
		{
		}

		public static void CopyToClipboard(string copyText)
		{
		}

		public void JumpToSelectedObject()
		{
		}

		public void JumpToGameObjectX(GameObjectX gox, bool andClickIt = true)
		{
		}

		public void JumpToPosition(Vector3 position)
		{
		}

		public static Bounds SumBounds(IEnumerable<Renderer> renderers)
		{
			return default(Bounds);
		}

		public static Bounds SumVertexBounds(Transform root, IEnumerable<Renderer> renderers)
		{
			return default(Bounds);
		}

		public static Bounds SumBounds(IEnumerable<Collider> colliders)
		{
			return default(Bounds);
		}

		public static Bounds SumBounds(IEnumerable<Bounds> bounds)
		{
			return default(Bounds);
		}

		public static Bounds? CalculateBounds(Transform source, IEnumerable<Renderer> ignoreRenderers = null, bool includeParticleSystems = false)
		{
			return null;
		}

		public static Bounds? CalculateBoundsFromColliders(Transform source, List<Collider> ignoreColliders = null)
		{
			return null;
		}

		public static void ResizeColliderToRendererBounds(BoxCollider boxCol, Transform rootTransform, IEnumerable<Renderer> ignoreRenderers, Vector3 padding = default(Vector3))
		{
		}

		public Vector3 GetTooltipPosition(Transform source, TooltipAlignment alignment)
		{
			return default(Vector3);
		}

		public Vector3 GetTooltipPosition(Transform source, Collider col, TooltipAlignment alignment)
		{
			return default(Vector3);
		}

		public Vector3 GetTooltipPosition(Transform source, TooltipData tooltipData)
		{
			return default(Vector3);
		}

		public TooltipAlignment GetCenteredOpposite(TooltipAlignment alignment)
		{
			return default(TooltipAlignment);
		}

		public Vector3 GetAlignmentEdge(Bounds bounds, TooltipAlignment alignment, float tolerancePadding = 0f)
		{
			return default(Vector3);
		}

		public void ClampObjectToScreenEdge(Transform source, IEnumerable<Renderer> ignoreRenderers = null)
		{
		}

		public void ClampObjectToScreenEdge(Transform source, Bounds bounds)
		{
		}

		private Vector3 ClampScreenPoint(Vector3 screenPoint)
		{
			return default(Vector3);
		}

		public static Dictionary<int, Tuple<int, int>> GetProfitLossStatements(IEnumerable<TavernLog.TransactionLogEntry> logs)
		{
			return null;
		}

		public static void InitInteractableCanvas(Transform parent)
		{
		}

		public static IEnumerable<Material> GetDissolveMaterials(TMP_Text x)
		{
			return null;
		}

		public static void ReplaceSpriteAssetWithDissolve(IEnumerable<TMP_Text> texts)
		{
		}

		public static bool IsTooltipActive()
		{
			return false;
		}

		public static (Vector3, Vector3) AddLocalColliders(BoxCollider collider1, BoxCollider collider2)
		{
			return default((Vector3, Vector3));
		}

		public static Vector4 GetEdgePanSize()
		{
			return default(Vector4);
		}

		public void ShowOldSavesCleanUpPopUp()
		{
		}

		public static void TrySaveTemplateWithUsername(Action onReadyToSave)
		{
		}

		protected void InitInfoPanel()
		{
		}

		public void CloseInfoPanel(bool noAnimation = true)
		{
		}

		public void HideAllInfoPanels(bool noAnimation)
		{
		}

		public void OpenInfoPanel(bool noAnimation = false)
		{
		}

		private bool ActivateInfoPanelFor(ISelectable selectable, bool noAnimation = false)
		{
			return false;
		}

		private void CloseCurrentInfoPanel(bool noAnimation)
		{
		}

		private bool ShowRoomInfoPanel(Type type, Room room, bool noAnimation = false)
		{
			return false;
		}

		private bool ShowInfoPanel(Type type, GameObjectX gox, bool noAnimation = false, bool ignorePrefab = false)
		{
			return false;
		}

		private Transform GetInfoPanelForPrefabTypeIdentifier(string identifier)
		{
			return null;
		}

		private bool ShowInfoPanel(Type type, MapMarker mapMarker, bool noAnimation = false)
		{
			return false;
		}

		private void ShowInfoPanelInternal(InfoPanel infoPanel, object dataObject, bool noAnimation)
		{
		}

		private void UpdateInfoPanel(ISelectable infoPanelProvider)
		{
		}

		public void SetCurrentSelectable(ISelectable infoPanelProvider, bool jumpToObject = false)
		{
		}

		public void ToggleInfoPanelObject(ISelectable infoPanelProvider)
		{
		}

		public void ClearInfoPanelObject(bool closeInfoPanel = true)
		{
		}

		public void SetMouseHelper(string id)
		{
		}

		public void ClearMouseHelper(string id = null)
		{
		}

		public bool IsNotificationRegistered(string id)
		{
			return false;
		}

		public UINotificationData GetNotificationDataById(string id)
		{
			return null;
		}

		public UINotificationData GetNotificationBySourceId(int sourceId)
		{
			return null;
		}

		public void NotificationDecisionCallbackTriggered(string id, int option)
		{
		}

		public void NotificationClicked(string id)
		{
		}

		public void OpenNotificationDialog(UINotificationData uiNotificationData)
		{
		}

		private void QueueNotificationDialog(string id)
		{
		}

		protected void InitNotifications()
		{
		}

		public void CloseNotifications()
		{
		}

		private bool IsUINotificationDataValid(UINotificationData data)
		{
			return false;
		}

		private bool IsUINotificationDataDialogSupported(UINotificationData data)
		{
			return false;
		}

		public void CloseNotificationDialog(string id, Action callback)
		{
		}

		private void UpdateNotificationQueue()
		{
		}

		public void AddNotification(UINotificationData uiNotificationData, Action<string, int> onDecisionCallback, Action<UINotificationData> onDialogOpenCallback = null, Action<UINotificationData> onDismissCallback = null, int groupPriority = 0, string groupId = null)
		{
		}

		public void UpdateNotification(UINotificationData uiData, bool updateActiveDialog = false)
		{
		}

		public void DismissNotification(string id)
		{
		}

		public void DestroyNotification(string id, ShowHideAnimationSpeed speed = ShowHideAnimationSpeed.Instant)
		{
		}

		public void DestroyAllNotifications()
		{
		}

		private void NotificationDialogClosed()
		{
		}

		public void OpenStaffScheduleDialog(List<SlotOption> slotOptions, Staff opener)
		{
		}

		public void OpenRoomScheduleDialog(Room opener)
		{
		}

		public void OpenMaintainableScheduleDialog(Prop opener)
		{
		}

		public bool IsSideInfoOpen(string id)
		{
			return false;
		}

		public void ToggleLarderInfo()
		{
		}

		public void CloseSideInfos()
		{
		}

		public void CloseAllSideInfoPanels(bool forceClose = false)
		{
		}

		public void OpenStaffHiringDialog()
		{
		}

		public void ToggleWorldMap()
		{
		}

		public static bool IsStarRatingIncreasable()
		{
			return false;
		}

		public void IncreaseStars(bool skipReveal = false)
		{
		}

		public void OpenPatronSatisfactionDialog()
		{
		}

		public void OpenPatronAttractionDialog(bool showEntertainerTimeline = false)
		{
		}

		public void ToggleDialog(string dialogId)
		{
		}

		public void OpenFinanceLog()
		{
		}

		public void SetUIVisibility(bool isVisible)
		{
		}

		public bool IsUIVisibilityFlagActive(string flag)
		{
			return false;
		}

		public bool IsTavernUIVisible()
		{
			return false;
		}

		public bool IsUIPartVisible(string flag)
		{
			return false;
		}

		private bool IsDesignModeActive()
		{
			return false;
		}

		public bool IsFullStatusBarVisible()
		{
			return false;
		}

		public void ShowTavernUI()
		{
		}

		public void UpdateTavernUIVisibility()
		{
		}

		private void UpdateTavernUIVisibility(object sender, EventArgs e)
		{
		}

		public void HideAndCloseTavernUI()
		{
		}

		public void HideTavernUI()
		{
		}

		public void SetUIVisibilityFlag(string id, bool isActive)
		{
		}
	}
}
