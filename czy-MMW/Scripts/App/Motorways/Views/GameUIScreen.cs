using System.Collections.Generic;
using Client;
using Easing;
using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using Screens;
using Server;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Motorways.Views
{
	public class GameUIScreen : InGameScalingScreen, IView
	{
		public enum TimeScaleMode
		{
			Paused = 0,
			Play = 1,
			FastForward = 2,
			ExtraFastForward = 3
		}

		private enum ElectiveUpgradeState
		{
			WaitingForNextMilestone = 0,
			UpgradeAvailable = 1,
			RequestedUpgrade = 2
		}

		public static Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("View.GameUI");

		[Dependency]
		private City _city;

		[Dependency]
		private TilemapView _tilemapView;

		[Dependency]
		private ScoreModel _scoreModel;

		[Dependency]
		private UpgradeDatabaseModel _upgradeDatabaseModel;

		[Dependency]
		private MenuNavigation _menuNavigation;

		[Dependency]
		private CameraView _cameraView;

		[SerializeField]
		private RoadCursor _roadCursor;

		private UpgradeCursor _upgradeCursor;

		[SerializeField]
		private FocusPoint _focusPoint;

		private Vector2? _focusPointPosition;

		[SerializeField]
		protected Transform _worldGrid;

		[SerializeField]
		private Transform _clockViewParent;

		private GameObject _worldGridGameObject;

		private TweenFloat _worldGridThickness = new TweenFloat();

		private TweenFloat _motorwayDotDiagonalTransition = new TweenFloat();

		public SafeArea safeArea;

		[SerializeField]
		public RectTransform playableArea;

		private ClockView _clockView;

		private ScoreView _scoreView;

		[SerializeField]
		private GameObject _clockAnchorActive;

		[SerializeField]
		private Transform _clockAnchorInactive;

		[SerializeField]
		private GameObject _scoreTextAnchorActive;

		[SerializeField]
		private Transform _scoreTextAnchorInactive;

		[SerializeField]
		private GameObject _dayTextAnchorActive;

		[SerializeField]
		private Transform _dayTextAnchorInactive;

		public GameObject menuButtonAnchor;

		public GameObject drawButtonAnchors;

		public DrawModeToggle drawModeToggle;

		public TouchButton pauseButton;

		public TouchButton playButton;

		public TouchButton fastForwardButton;

		public TouchButton extraFastForwardButton;

		[SerializeField]
		private GameObject[] _timeButtonAnchors;

		private FloatingElement[] _timeButtonFloaters = new FloatingElement[3];

		[SerializeField]
		private GameObject _upgradeIcons;

		[Tooltip("The amount of time after a game starts until the upgrade bar transitions in")]
		public float upgradeBarAppearDelay = 1f;

		[Tooltip("The amount of time after a game starts until the clock transitions in")]
		public float clockAppearDelay = 5f;

		[SerializeField]
		private float WorldGridTransitionInTime = 0.2f;

		[SerializeField]
		private float WorldGridTransitionOutTime = 0.2f;

		private const float GRACE_INTERACTION_TIME = 3.2f;

		private float _currentGraceInteractionTime;

		public static readonly int ScoreChallengeModeAnimatorBool = Animator.StringToHash("ChallengeMode");

		public static readonly int ScorePulseAnimatorTrigger = Animator.StringToHash("Pulse");

		private float _uiAppearTimer;

		private bool _waitToShowClock;

		private bool _isTimeButtonVisibilityChangeScheduled;

		private bool _scheduledTimeButtonVisibility;

		private bool _clockEnabled;

		private bool _scoreEnabled;

		private bool _upgradeBarEnabled;

		private DrawModeToggle.VisibleState _drawModeVisibleState;

		private bool _showDrawButtonsNextTimeInGame;

		private TileView _currentSelectedTile;

		private bool _tileHighlightsAllowed = true;

		private bool _drawButtonsHiddenByTutorial;

		private GameObject _overlayCanvasObject;

		private Canvas _overlayCanvas;

		private RectTransform _overlayTransform;

		private bool _isUpgradeBarOnOverlay;

		private bool _uiVisible;

		private ISubmitHandler _focussedSelectable;

		private RoadDrawMode _currentDrawMode;

		private bool _isForceHidden;

		private bool _isWorldGridForceHidden;

		private bool _hasTransitionedIn;

		private ElectiveUpgradeState _electiveUpgradeState;

		private bool _debugToolsHideUI;

		public UpgradeBarClient UpgradeBar { get; private set; }

		public ScoreView ScoreView => _scoreView;

		public EditMenuPanel editMenuPanel { get; private set; }

		public ColourWidget ColourWidget { get; private set; }

		public TouchButton ScoreButton => _clockView.ScoreButton;

		public bool TimeButtonsVisible { get; private set; }

		public GameObject ScoreTextAnchor => _scoreTextAnchorActive;

		public GameObject ClockAnchor => _clockAnchorActive;

		public RectTransform OverlayTransform => _overlayTransform;

		public bool FocusPointIsBlocked { get; private set; }

		public ISubmitHandler FocussedSelectable => _focussedSelectable;

		public RoadDrawMode CurrentRoadDrawMode
		{
			get
			{
				return _currentDrawMode;
			}
			set
			{
				_currentDrawMode = value;
				drawModeToggle.SetDrawMode(_currentDrawMode);
				_themeDatabase.SetDrawMode(_currentDrawMode);
			}
		}

		public bool IsElectiveUpgradeRequested => _electiveUpgradeState == ElectiveUpgradeState.RequestedUpgrade;

		public Vector2 FocusPointPosition
		{
			get
			{
				if (!_focusPointPosition.HasValue)
				{
					_focusPointPosition = _gameCamera.Dimensions * 0.5f;
				}
				return _focusPointPosition.Value;
			}
		}

		public bool IsFocusPointActive
		{
			get
			{
				if (_focusPoint != null)
				{
					return _focusPoint.IsVisible;
				}
				return false;
			}
		}

		public bool HasUpgradeCursor => _upgradeCursor != null;

		public bool IsUpgradeBarOnOverlay
		{
			get
			{
				return _isUpgradeBarOnOverlay;
			}
			set
			{
				if (value != _isUpgradeBarOnOverlay)
				{
					if (value)
					{
						_gameCamera.AttachCameraToCanvas(_overlayCanvas, CameraLayer.Overlay);
						_overlayCanvas.sortingLayerID = _canvas.sortingLayerID;
						_overlayCanvasObject.layer = _gameCamera.OverlayLayerIndex;
						_overlayCanvasObject.SetActive(value: true);
						_upgradeIcons.transform.SetParent(_overlayTransform.transform, worldPositionStays: false);
					}
					else
					{
						_upgradeIcons.transform.SetParent(GetUpgradeBarTransform(), worldPositionStays: false);
					}
					_isUpgradeBarOnOverlay = value;
				}
			}
		}

		private bool AreTimeButtonsAnimating
		{
			get
			{
				FloatingElement[] timeButtonFloaters = _timeButtonFloaters;
				foreach (FloatingElement floatingElement in timeButtonFloaters)
				{
					if (Diagnostics.Verify(floatingElement != null) && floatingElement.IsAnimating)
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsClockVisible => _clockEnabled;

		public bool IsScoreVisible => _scoreEnabled;

		public bool DebugToolsHideUI
		{
			get
			{
				return _debugToolsHideUI;
			}
			set
			{
				_debugToolsHideUI = value;
				_canvasGroup.Alpha = (_debugToolsHideUI ? 0f : 1f);
			}
		}

		public bool DebugToolsHideWorldGrid { get; set; }

		public bool IsUiVisible => _uiVisible;

		public bool IsForceHidden => _isForceHidden;

		public void ToggleDrawMode()
		{
			CurrentRoadDrawMode = ((CurrentRoadDrawMode == RoadDrawMode.Add) ? RoadDrawMode.Remove : RoadDrawMode.Add);
		}

		public override void Awake()
		{
			base.Awake();
			Canvas component = GetComponent<Canvas>();
			_overlayCanvasObject = new GameObject(base.name + "-OverlayCanvas");
			_overlayCanvas = _overlayCanvasObject.AddComponent<Canvas>();
			_overlayCanvas.renderMode = RenderMode.ScreenSpaceCamera;
			_overlayCanvas.planeDistance = component.planeDistance;
			_overlayCanvas.sortingOrder = component.sortingOrder;
			CanvasScaler component2 = GetComponent<CanvasScaler>();
			CanvasScaler canvasScaler = _overlayCanvasObject.AddComponent<CanvasScaler>();
			canvasScaler.uiScaleMode = component2.uiScaleMode;
			canvasScaler.referenceResolution = component2.referenceResolution;
			canvasScaler.screenMatchMode = component2.screenMatchMode;
			canvasScaler.matchWidthOrHeight = component2.matchWidthOrHeight;
			_overlayCanvas.referencePixelsPerUnit = component2.referencePixelsPerUnit;
			GameObject gameObject = new GameObject("SafeArea");
			_overlayTransform = gameObject.AddComponent<RectTransform>();
			gameObject.AddComponent<SafeArea>();
			_overlayTransform.SetParent(_overlayCanvasObject.transform, worldPositionStays: false);
			_overlayTransform.localPosition = Vector2.zero;
			_overlayTransform.localScale = Vector2.one;
			_overlayTransform.sizeDelta = Vector2.zero;
			_overlayCanvasObject.SetActive(value: false);
			_timeButtonFloaters[0] = pauseButton.GetComponent<FloatingElement>();
			_timeButtonFloaters[1] = playButton.GetComponent<FloatingElement>();
			_timeButtonFloaters[2] = fastForwardButton.GetComponent<FloatingElement>();
			_worldGridGameObject = _worldGrid.gameObject;
		}

		public override void OnCreatedInScope(IScope scope)
		{
			UpgradeBar = scope.Get<UpgradeBarClient>();
			editMenuPanel = scope.Get<EditMenuPanel>();
			ColourWidget = scope.Get<ColourWidget>();
			_clockView = scope.Get<ClockView>();
			_clockView.transform.SetParent(_clockViewParent, worldPositionStays: false);
			_clockView.gameObject.SetActive(value: true);
			_clockView.OnClockToggled += OnClockToggled;
			_scoreView = _clockView.ScoreView;
			_scoreView.OnElectiveUpgradeButtonPressed += OnElectiveUpgradeButtonPressed;
			_scoreView.OnScoreButtonPressed += OnScorePressed;
			ViewClient viewClient = scope.Get<ViewClient>();
			viewClient.AddView(UpgradeBar);
			viewClient.AddView(editMenuPanel);
			viewClient.AddView(ColourWidget);
			base.OnCreatedInScope(scope);
			_canvasGroup.SetInteractable(isInteractable: false);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_canvasGroup.Alpha = 0f;
			_inputState.Subscribe(this);
			_scaleToCamera = false;
			_currentDrawMode = RoadDrawMode.Add;
			SetWorldGridActive(active: false, TransitionStyle.Snap);
			_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			SetRoadCursorActive(active: false);
			if (_focusPoint != null)
			{
				SetFocusPointActive(active: false, instantly: true);
			}
			if (_currentSelectedTile != null)
			{
				_currentSelectedTile.IsHighlighted = false;
				_currentSelectedTile = null;
			}
			backButton.ForceInitializeState();
			_gameCamera.AttachCameraToCanvas(_canvas, CameraLayer.UI);
			SetUIVisible(visible: false, instantly: true);
			fastForwardButton.gameObject.SetActive(value: true);
			extraFastForwardButton.gameObject.SetActive(value: false);
			SetVcrButtonState(paused: false, TimeScale.Single);
		}

		public override void OnReleasedFromScope(IScope scope)
		{
			base.OnReleasedFromScope(scope);
			SetUIVisible(visible: false);
			SetVcrButtonState(paused: false, TimeScale.Single);
			_inputState.Unsubscribe(this);
			UpgradeBar.OnReleasedFromScope(scope);
			if (_clockView != null)
			{
				_clockView.OnClockToggled -= OnClockToggled;
				_clockView.transform.SetParent(null, worldPositionStays: false);
			}
			if (_scoreView != null)
			{
				_scoreView.gameObject.SetActive(value: true);
				_scoreView.OnScoreButtonPressed -= OnScorePressed;
				_scoreView.OnElectiveUpgradeButtonPressed -= OnElectiveUpgradeButtonPressed;
				scope.Release(_scoreView);
				_scoreView = null;
			}
			if (editMenuPanel != null)
			{
				scope.Release(editMenuPanel);
			}
			if (ColourWidget != null)
			{
				scope.Release(ColourWidget);
			}
		}

		public override void Reset()
		{
			base.Reset();
			_currentGraceInteractionTime = 0f;
			_uiAppearTimer = 0f;
			_waitToShowClock = false;
			TimeButtonsVisible = false;
			_isTimeButtonVisibilityChangeScheduled = false;
			_scheduledTimeButtonVisibility = false;
			_currentGraceInteractionTime = 0f;
			_clockEnabled = false;
			_scoreEnabled = false;
			_upgradeBarEnabled = false;
			UpgradeBar.gameObject.SetActive(value: true);
			_drawModeVisibleState = DrawModeToggle.VisibleState.AlwaysShowing;
			_drawButtonsHiddenByTutorial = false;
			_showDrawButtonsNextTimeInGame = false;
			_currentSelectedTile = null;
			_tileHighlightsAllowed = true;
			FocusPointIsBlocked = false;
			_focusPointPosition = null;
			_focussedSelectable = null;
			_currentDrawMode = RoadDrawMode.Add;
			_isForceHidden = false;
			_isWorldGridForceHidden = false;
			_hasTransitionedIn = false;
			_electiveUpgradeState = ElectiveUpgradeState.WaitingForNextMilestone;
		}

		public override void ScaleToCamera()
		{
			ScaleToGameCamera();
		}

		public virtual RectTransform GetRectTransform()
		{
			return _rectTransform;
		}

		public Selectable GetFirstUpgradeIconSelectable()
		{
			return UpgradeBar.GetFirstUpgradeIconSelectable();
		}

		public void SetRoadCursorPosition(Vector2 newCursorPosition)
		{
			_roadCursor.Position = NormalizePositionToScaledScreenSize(newCursorPosition);
		}

		public void SetRoadCursorActive(bool active)
		{
			_roadCursor.IsVisible = active;
		}

		public void SetTileHighlightsAllowed(bool allowed)
		{
			if (!allowed && _currentSelectedTile != null)
			{
				_currentSelectedTile.IsHighlighted = false;
				_currentSelectedTile = null;
			}
			_tileHighlightsAllowed = allowed;
		}

		public void SetFocusPointPosition(Vector2 newFocusPointPosition)
		{
			_focusPointPosition = ClampPositionToScreenSize(newFocusPointPosition);
			_focusPoint.SetCursorPosition(NormalizePositionToScaledScreenSize(FocusPointPosition));
			if (FocusPointIsBlocked)
			{
				return;
			}
			UpdateFocussedSelectable(FocusPointPosition);
			if (!FeatureToggle.IsFeatureEnabled(Feature.TileHighlights) || (_inputState.CurrentDeviceInputType != DeviceInputType.Controller && _inputState.CurrentDeviceInputType != DeviceInputType.Remote) || !_tileHighlightsAllowed)
			{
				return;
			}
			if (_currentSelectedTile == null)
			{
				_currentSelectedTile = _tilemapView.GetOrCreateTileView(_tilemapView.GetTileCoordinatesFromScreenPosition(FocusPointPosition));
				if (_currentSelectedTile != null)
				{
					_currentSelectedTile.IsHighlighted = true;
				}
				return;
			}
			TileView orCreateTileView = _tilemapView.GetOrCreateTileView(_tilemapView.GetTileCoordinatesFromScreenPosition(FocusPointPosition));
			if (orCreateTileView == null)
			{
				_currentSelectedTile.IsHighlighted = false;
				_currentSelectedTile = null;
			}
			else if (orCreateTileView != _currentSelectedTile)
			{
				_currentSelectedTile.IsHighlighted = false;
				_currentSelectedTile = orCreateTileView;
				_currentSelectedTile.IsHighlighted = true;
			}
		}

		public void SetFocusPointActive(bool active, bool instantly = false)
		{
			if (!(FocusPointIsBlocked && active))
			{
				_focusPoint.SetFocusPointActive(active, instantly);
				if (!active && _currentSelectedTile != null)
				{
					_currentSelectedTile.IsHighlighted = false;
					_currentSelectedTile = null;
				}
			}
		}

		public void SetFocusPointBlocked(bool blocked)
		{
			FocusPointIsBlocked = blocked;
		}

		private void UpdateFocussedSelectable(Vector2 position)
		{
			if (EventSystem.current == null)
			{
				return;
			}
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = position;
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			ISubmitHandler submitHandler = null;
			foreach (RaycastResult item in list)
			{
				ISubmitHandler submitHandler2 = item.gameObject.GetComponent<ISubmitHandler>();
				if (submitHandler2 == null)
				{
					submitHandler2 = item.gameObject.GetComponentInParent<ISubmitHandler>();
				}
				if (submitHandler2 != null)
				{
					if (_focussedSelectable != null && submitHandler2 != _focussedSelectable && typeof(IPointerExitHandler).IsAssignableFrom(_focussedSelectable.GetType()))
					{
						((IPointerExitHandler)_focussedSelectable).OnPointerExit(pointerEventData);
					}
					submitHandler = submitHandler2;
					if (submitHandler != null && _focussedSelectable != submitHandler && typeof(IPointerEnterHandler).IsAssignableFrom(submitHandler.GetType()))
					{
						((IPointerEnterHandler)submitHandler).OnPointerEnter(pointerEventData);
					}
					break;
				}
			}
			if (submitHandler == null && _focussedSelectable != null && typeof(IPointerExitHandler).IsAssignableFrom(_focussedSelectable.GetType()))
			{
				((IPointerExitHandler)_focussedSelectable).OnPointerExit(pointerEventData);
				Log.Info("PointerExiting {0}", _focussedSelectable);
			}
			_focussedSelectable = submitHandler;
		}

		public void OpenEditMenu(ICreativeModeEditableObject editableObject, bool confirmOrCancelEdit = false)
		{
			if (editMenuPanel.EditableObject != null && confirmOrCancelEdit)
			{
				editMenuPanel.ConfirmEdit();
			}
			editMenuPanel.OpenEditMenu(editableObject);
		}

		public void ConfirmEditMenuEdit()
		{
			if (editMenuPanel != null && editMenuPanel.IsOpen)
			{
				editMenuPanel.ConfirmEdit();
			}
		}

		public void SetWorldGridActive(bool active, TransitionStyle transitionStyle = TransitionStyle.Tween)
		{
			if (!active || !_isWorldGridForceHidden)
			{
				Log.Info("Setting world grid active: {0}, with transition: {1}", active, transitionStyle);
				if (transitionStyle == TransitionStyle.Snap)
				{
					_worldGridThickness.Set(active ? 1f : 0f, 0.01f);
				}
				else if (active)
				{
					_worldGridThickness.Start(_worldGridThickness.Value, 1f, WorldGridTransitionInTime, Easings.Functions.SineEaseInOut);
				}
				else
				{
					_worldGridThickness.Start(_worldGridThickness.Value, 0f, WorldGridTransitionOutTime, Easings.Functions.SineEaseInOut);
				}
			}
		}

		public void SetMotorwayGridActive(bool active, TransitionStyle transitionStyle = TransitionStyle.Tween)
		{
			if (active && _isForceHidden)
			{
				return;
			}
			if (transitionStyle == TransitionStyle.Tween)
			{
				if (active)
				{
					_motorwayDotDiagonalTransition.Start(_motorwayDotDiagonalTransition.Value, 1f, WorldGridTransitionInTime, Easings.Functions.SineEaseInOut);
				}
				else
				{
					_motorwayDotDiagonalTransition.Start(_motorwayDotDiagonalTransition.Value, 0f, WorldGridTransitionInTime, Easings.Functions.SineEaseInOut);
				}
			}
			else
			{
				_motorwayDotDiagonalTransition.Set(active ? 1f : 0f, 0.01f);
			}
		}

		public void InitializeUpgradeCursor(UpgradeType upgradeButtonType)
		{
			UpgradeCursor upgradeCursor = _gameScope.Get<UpgradeCursor>();
			Sprite spriteForUpgradeType = UpgradeBar.GetSpriteForUpgradeType(upgradeButtonType);
			upgradeCursor.Initialize(spriteForUpgradeType, _rectTransform);
			_upgradeCursor = upgradeCursor;
		}

		public Vector2Int GetUpgradeCursorTileCoordinates()
		{
			if (Diagnostics.Verify(HasUpgradeCursor))
			{
				return _upgradeCursor.GetTileCoordinates();
			}
			return Vector2Int.zero;
		}

		public void SetUpgradeCursorPosition(Vector3 position, UpgradeCursor.UpgradeCursorOffsetType offsetType)
		{
			if (Diagnostics.Verify(HasUpgradeCursor))
			{
				_upgradeCursor.SetPosition(NormalizePositionToScaledScreenSize(position), offsetType);
			}
		}

		protected virtual Transform GetUpgradeBarTransform()
		{
			return UpgradeBar.transform;
		}

		public Vector2 NormalizePositionToScaledScreenSize(Vector2 position)
		{
			return position / _gameCamera.Dimensions * _rectTransform.sizeDelta;
		}

		private Vector3 ClampPositionToScreenSize(Vector3 position)
		{
			position.x = Mathf.Clamp(position.x, 0f, _gameCamera.Width);
			position.y = Mathf.Clamp(position.y, 0f, _gameCamera.Height);
			return position;
		}

		public void CancelUpgradeCursor()
		{
			if (Diagnostics.Verify(HasUpgradeCursor))
			{
				_upgradeCursor.CancelUpgradeCursor();
				_upgradeCursor = null;
			}
		}

		public void PlaceUpgradeCursorAssetAtPosition(Vector2Int tile)
		{
			if (Diagnostics.Verify(HasUpgradeCursor))
			{
				_upgradeCursor.PlaceAssetAtPosition(tile);
			}
		}

		public void SetUpgradeCursorVisible(bool visible)
		{
			if (Diagnostics.Verify(HasUpgradeCursor))
			{
				_upgradeCursor.gameObject.SetActive(visible);
			}
		}

		public virtual TickResult Tick(TimeInterval timeInterval, float stepAlpha)
		{
			base.Tick(timeInterval.Delta);
			_worldGrid.localScale = _rectTransform.sizeDelta;
			if (_showDrawButtonsNextTimeInGame && _screenStack.GetTopActiveScreenType() == ScreenStack.MotorwaysScreen.InGame)
			{
				SetDrawButtonsVisible(visible: true);
				_showDrawButtonsNextTimeInGame = false;
			}
			if (_city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones)
			{
				if (_playerActionController.BlockingPlayerActionCount > 0)
				{
					_currentGraceInteractionTime = 3.2f;
				}
				if (_currentGraceInteractionTime > 0f)
				{
					_currentGraceInteractionTime -= timeInterval.Delta;
				}
				switch (_electiveUpgradeState)
				{
				case ElectiveUpgradeState.WaitingForNextMilestone:
					if (_upgradeDatabaseModel.IsPendingUpgradeAvailable)
					{
						_electiveUpgradeState = ElectiveUpgradeState.UpgradeAvailable;
					}
					break;
				case ElectiveUpgradeState.UpgradeAvailable:
					SetElectiveUpgradeAvailable(_scoreView.IsEfficiencyTickerVisuallyComplete);
					break;
				case ElectiveUpgradeState.RequestedUpgrade:
					SetElectiveUpgradeAvailable(available: false);
					if (!_upgradeDatabaseModel.IsPendingUpgradeAvailable)
					{
						_electiveUpgradeState = ElectiveUpgradeState.WaitingForNextMilestone;
					}
					break;
				}
			}
			if (_uiAppearTimer > 0f && !_isForceHidden)
			{
				_uiAppearTimer -= timeInterval.Delta;
				while (_uiAppearTimer <= 0f)
				{
					if (!_upgradeBarEnabled)
					{
						SetUpgradeBarVisibility(visible: true);
						_uiAppearTimer = (_waitToShowClock ? clockAppearDelay : 0f);
						continue;
					}
					if (!_clockEnabled)
					{
						SetClockVisibility(visible: true);
						AudioSystem.Instance.ScheduleEvent(AudioEvent.CreateEvent(AudioSystem.Instance.DspTime, AudioEventType.ClockStart, 0.75f));
						continue;
					}
					_uiAppearTimer = -1f;
					break;
				}
			}
			if (_isTimeButtonVisibilityChangeScheduled && !_isForceHidden && !AreTimeButtonsAnimating)
			{
				SetTimeButtonsVisible(_scheduledTimeButtonVisibility);
			}
			if (!_scoreTextAnchorActive.activeSelf && _scoreModel.Score > 0 && _hasTransitionedIn)
			{
				SetScoreVisible(!_isForceHidden);
			}
			if (_worldGridThickness.IsActive)
			{
				float worldGridThickness = _worldGridThickness.Tick(timeInterval.Delta);
				_themeDatabase.materialCollection.SetWorldGridThickness(worldGridThickness);
			}
			if (DebugToolsHideWorldGrid)
			{
				_worldGridGameObject.SetActive(value: false);
			}
			else
			{
				_worldGridGameObject.SetActive((double)_worldGridThickness.Value > 0.0);
			}
			if (_motorwayDotDiagonalTransition.IsActive)
			{
				float mountainDotDiagonalRatio = _motorwayDotDiagonalTransition.Tick(timeInterval.Delta);
				_themeDatabase.materialCollection.SetMountainDotDiagonalRatio(mountainDotDiagonalRatio);
			}
			return TickResult.ContinueTicking;
		}

		public void SetGameobjectActive(bool isActive)
		{
			base.gameObject.SetActive(isActive);
		}

		protected virtual void SetElectiveUpgradeAvailable(bool available)
		{
			bool value = _currentGraceInteractionTime >= 0f;
			_scoreView.electiveUpgradeAnimator.SetBool(ScoreView.UpgradeAvailableId, available);
			_scoreView.electiveUpgradeAnimator.SetBool(ScoreView.PlayerInterruptedId, value);
		}

		public override void OnTransitionedIn()
		{
			_hasTransitionedIn = true;
			_alignToCamera = true;
			_canvasGroup.Alpha = 1f;
			_drawModeVisibleState = GetDrawModeVisibleStateFromInputType(_inputState.CurrentDeviceInputType);
			ScoreButton.animator.SetBool(ScoreChallengeModeAnimatorBool, _simulation.GetModel<ActiveChallengesModel>().HasChallenges);
			if (_city.Rules.UIStartVisible() && (!_upgradeBarEnabled || !_clockEnabled))
			{
				_upgradeBarEnabled = false;
				_clockEnabled = false;
			}
			if (_city.Rules.UIStartVisible() && (!_upgradeBarEnabled || !_clockEnabled))
			{
				_uiAppearTimer = upgradeBarAppearDelay;
				SetDrawButtonsVisible(_drawModeVisibleState == DrawModeToggle.VisibleState.AlwaysShowing);
			}
			if (!_isForceHidden)
			{
				SetClockVisibility(_clockEnabled);
				SetScoreVisible(_scoreEnabled);
				SetUpgradeBarVisibility(_upgradeBarEnabled);
				bool drawButtonsVisible = _drawModeVisibleState == DrawModeToggle.VisibleState.AlwaysShowing || (_drawModeVisibleState == DrawModeToggle.VisibleState.ShowWhenFocused && _cameraView.IsFocussedIn);
				SetDrawButtonsVisible(drawButtonsVisible);
			}
			SetMenuButtonVisible(visible: true);
			_canvasGroup.SetInteractable(isInteractable: true);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			backButton.ForceInitializeState();
			BuildingsIndicatorView buildingsIndicatorView = _gameScope.Get<BuildingsIndicatorView>();
			if ((bool)buildingsIndicatorView)
			{
				buildingsIndicatorView.StartPulsing();
			}
			_scoreView.SetEfficiencyTickerAnimationsPaused(isPaused: false);
			if (_city.Rules.ShowColourWidget)
			{
				ColourWidget.RefreshColours(resetCounter: true);
				ColourWidget.SetGameobjectActive(active: true);
			}
			else
			{
				ColourWidget.SetGameobjectActive(active: false);
			}
		}

		public override void OnTransitionedOut()
		{
			base.OnTransitionedOut();
			_menuNavigation.ClearFocus();
			backButton.ForceInitializeState();
		}

		public override void TransitionOut(ScreenStack.MotorwaysScreen inScreen)
		{
			_hasTransitionedIn = false;
			UpgradeBar.DeselectButtons();
			_canvasGroup.SetInteractable(isInteractable: false);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: false);
			_transitionDetails = _screenStack.GetTransitionDetailsFrom(base.ScreenType, inScreen);
			_focusPoint.SetFocusPointActive(active: false, instant: true);
			if (_city.Rules.UIStartVisible() && _uiAppearTimer > 0f && (!_upgradeBarEnabled || !_clockEnabled))
			{
				_uiAppearTimer = -1f;
			}
			BuildingsIndicatorView buildingsIndicatorView = _gameScope.Get<BuildingsIndicatorView>();
			if ((bool)buildingsIndicatorView)
			{
				buildingsIndicatorView.StopPulsing();
			}
			_scoreView.SetEfficiencyTickerAnimationsPaused(isPaused: true);
			if (_city.GameMode == GameMode.Creative)
			{
				ConfirmEditMenuEdit();
			}
			if (_city.Rules.ShowColourWidget)
			{
				ColourWidget.SetGameobjectActive(active: false);
				ColourWidget.Reset();
			}
		}

		public void OnBack()
		{
			_screenStack.PushScreen<PauseScreen>(ScreenStack.MotorwaysScreen.Pause, additive: false, _gameScope);
		}

		public void OnScorePressed()
		{
			ActiveChallengesModel challengeModel = _game.Scope.Get<ActiveChallengesModel>();
			if (challengeModel.HasChallenges)
			{
				_screenStack.PushScreen(ScreenStack.MotorwaysScreen.ChallengeInfo, delegate(ChallengeInfoScreen screen)
				{
					screen.PrepareScreen(challengeModel.challengeType, challengeModel.challenges, challengeModel.timeStart, challengeModel.timeEnd, StringId.Continue, changeBlurWhenTransitioning: true, showBackButton: true, _gameScope);
				});
			}
		}

		public void OnElectiveUpgradeButtonPressed()
		{
			if (_city.Rules.ScoringMode == ScoringMode.EfficiencyMilestones && _upgradeDatabaseModel.IsPendingUpgradeAvailable)
			{
				_electiveUpgradeState = ElectiveUpgradeState.RequestedUpgrade;
				_player.SetNewContentSeen("EndlessMilestoneFTUXMessage");
			}
		}

		public void OnClockToggled()
		{
			if (AreTimeButtonsAnimating)
			{
				_isTimeButtonVisibilityChangeScheduled = true;
				_scheduledTimeButtonVisibility = !TimeButtonsVisible;
			}
			else
			{
				SetTimeButtonsVisible(!TimeButtonsVisible);
			}
			_audioSystem?.ScheduleEvent(AudioEvent.CreateUIEvent(UIEventType.Click, UIAudioProfile.Clock, -1f, TimeButtonsVisible));
		}

		private void SetTimeButtonsVisible(bool visible)
		{
			GameObject[] timeButtonAnchors = _timeButtonAnchors;
			for (int i = 0; i < timeButtonAnchors.Length; i++)
			{
				timeButtonAnchors[i].SetActive(visible);
			}
			TimeButtonsVisible = visible;
			_isTimeButtonVisibilityChangeScheduled = false;
		}

		public void PulseClock()
		{
			_clockView.Pulse();
		}

		public virtual void OnPausePressed()
		{
			_game.SetPaused(isPaused: true);
			SetVcrButtonState(paused: true, TimeScale.Single);
		}

		public virtual void OnPlayPressed()
		{
			_game.SetPaused(isPaused: false);
			_game.SetTimeScale(TimeScale.Single);
			SetVcrButtonState(paused: false, TimeScale.Single);
		}

		public virtual void OnFastForwardPressed()
		{
			_game.SetPaused(isPaused: false);
			if (FeatureToggle.IsFeatureDisabled(Feature.ExtraFastForward))
			{
				_game.SetTimeScale(TimeScale.Double);
			}
			else
			{
				_game.SetTimeScale((_game.GetTimeScale() == TimeScale.Double) ? TimeScale.ExtraFast : TimeScale.Double);
			}
			SetVcrButtonState(paused: false, _game.GetTimeScale());
		}

		public virtual void OnExtraFastForwardPressed()
		{
			if (!FeatureToggle.IsFeatureDisabled(Feature.ExtraFastForward))
			{
				_game.SetPaused(isPaused: false);
				_game.SetTimeScale(TimeScale.ExtraFast);
				SetVcrButtonState(paused: false, TimeScale.ExtraFast);
			}
		}

		public virtual void SetVcrButtonState(bool paused, TimeScale timeScale)
		{
			pauseButton.interactable = !paused;
			playButton.interactable = paused || timeScale != TimeScale.Single;
			if (timeScale == TimeScale.ExtraFast || timeScale == TimeScale.Double)
			{
				fastForwardButton.gameObject.SetActive(timeScale == TimeScale.Double);
				extraFastForwardButton.gameObject.SetActive(timeScale == TimeScale.ExtraFast);
			}
			if (!FeatureToggle.IsFeatureEnabled(Feature.ExtraFastForward))
			{
				fastForwardButton.interactable = paused || timeScale != TimeScale.Double;
			}
			if (_clockView != null)
			{
				_clockView.IsVisuallyPaused = paused;
			}
		}

		public TimeScaleMode GetTimeScaleMode()
		{
			if (_simulation.IsPaused)
			{
				return TimeScaleMode.Paused;
			}
			return GetUnpausedTimeScaleMode();
		}

		public TimeScaleMode GetUnpausedTimeScaleMode()
		{
			if (_game.GetTimeScale() == TimeScale.Single)
			{
				return TimeScaleMode.Play;
			}
			if (_game.GetTimeScale() == TimeScale.Double)
			{
				return TimeScaleMode.FastForward;
			}
			if (FeatureToggle.IsFeatureEnabled(Feature.ExtraFastForward))
			{
				return TimeScaleMode.ExtraFastForward;
			}
			return TimeScaleMode.FastForward;
		}

		public virtual void SetClockVisibility(bool visible)
		{
			_clockEnabled |= visible;
			_clockAnchorActive.SetActive(visible);
			_dayTextAnchorActive.SetActive(visible);
		}

		public virtual void SetScoreVisible(bool visible)
		{
			_scoreEnabled |= visible;
			_scoreTextAnchorActive.SetActive(visible);
		}

		public virtual void SetMenuButtonVisible(bool visible)
		{
			menuButtonAnchor.SetActive(visible);
		}

		public virtual void SetUIVisible(bool visible, bool instantly = false, bool forceHide = false, bool forceHideWorldGrid = false)
		{
			_isForceHidden = forceHide && !visible;
			_isWorldGridForceHidden = forceHideWorldGrid;
			_uiVisible = visible;
			SetClockVisibility(visible);
			SetScoreVisible(visible);
			SetUpgradeBarVisibility(visible, instantly || !visible);
			UpgradeBar.SetCreativeModeColourWidgetVisible(visible);
			SetMenuButtonVisible(visible);
			if (!visible)
			{
				SetTimeButtonsVisible(visible: false);
				SetDrawButtonsVisible(visible: false);
				if (forceHideWorldGrid)
				{
					SetWorldGridActive(active: false, instantly ? TransitionStyle.Snap : TransitionStyle.Tween);
				}
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			if (!instantly)
			{
				return;
			}
			List<FloatingElement> list = new List<FloatingElement>(base.gameObject.GetComponentsInChildren<FloatingElement>());
			FloatingElement[] componentsInChildren = _clockView.GetComponentsInChildren<FloatingElement>();
			foreach (FloatingElement item in componentsInChildren)
			{
				list.Remove(item);
				list.Insert(0, item);
			}
			foreach (FloatingElement item2 in list)
			{
				item2.Snap();
			}
		}

		public void ResetForceHiddenState()
		{
			_isForceHidden = false;
			_isWorldGridForceHidden = false;
		}

		public void SetUpgradeBarVisibility(bool visible, bool instantly = false)
		{
			_upgradeBarEnabled |= visible;
			UpgradeBar.SetVisibility(visible, instantly);
		}

		public void SetDrawButtonsHiddenByTutorial(bool hidden)
		{
			_drawButtonsHiddenByTutorial = hidden;
		}

		public virtual void SetDrawButtonsVisible(bool visible)
		{
			drawButtonAnchors.SetActive(!_drawButtonsHiddenByTutorial && visible);
			drawModeToggle.touchButton.interactable = visible;
		}

		public override void InitScreen(IScope gameScope, bool blocksGameInput)
		{
			base.InitScreen(gameScope, blocksGameInput);
			ClockModel model = gameScope.Get<ISimulation>().GetModel<ClockModel>();
			_clockView.Initialize(model, _clockAnchorActive, _clockAnchorInactive, _dayTextAnchorActive, _dayTextAnchorInactive, _scoreTextAnchorActive, _scoreTextAnchorInactive);
			gameScope.Get<ViewClient>().AddView(_clockView);
			pauseButton.GetComponent<FloatingElement>().SetInactiveAnchor(_clockView.VcrInactiveAnchor);
			playButton.GetComponent<FloatingElement>().SetInactiveAnchor(_clockView.VcrInactiveAnchor);
			fastForwardButton.GetComponent<FloatingElement>().SetInactiveAnchor(_clockView.VcrInactiveAnchor);
			extraFastForwardButton.GetComponent<FloatingElement>().SetInactiveAnchor(_clockView.VcrInactiveAnchor);
			_canvasGroup.Alpha = 0f;
			_canvasGroup.SetInteractable(isInteractable: true);
			_canvasGroup.SetBlocksRaycasts(doesBlockRaycasts: true);
			_worldGrid.localScale = _rectTransform.sizeDelta;
			_waitToShowClock = _game.StartReason == GameStartReason.New;
		}

		public override void OnCurrentDeviceInputTypeChanged(DeviceInputType newInputType)
		{
			base.OnCurrentDeviceInputTypeChanged(newInputType);
			if (newInputType != DeviceInputType.Touch)
			{
				SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
				if (_cameraView.IsFocussedIn && CurrentRoadDrawMode == RoadDrawMode.Remove)
				{
					CurrentRoadDrawMode = RoadDrawMode.Add;
				}
			}
			_drawModeVisibleState = GetDrawModeVisibleStateFromInputType(newInputType);
			if (_drawModeVisibleState == DrawModeToggle.VisibleState.NeverShow)
			{
				SetDrawButtonsVisible(visible: false);
			}
			_showDrawButtonsNextTimeInGame = _drawModeVisibleState == DrawModeToggle.VisibleState.AlwaysShowing;
			if (newInputType != DeviceInputType.Controller && _currentSelectedTile != null)
			{
				_currentSelectedTile.IsHighlighted = false;
				_currentSelectedTile = null;
			}
		}

		private DrawModeToggle.VisibleState GetDrawModeVisibleStateFromInputType(DeviceInputType inputType)
		{
			if (inputType == DeviceInputType.Touch)
			{
				return DrawModeToggle.VisibleState.ShowWhenFocused;
			}
			if (_player.IsDrawModeToggleEnabled)
			{
				return DrawModeToggle.VisibleState.AlwaysShowing;
			}
			if (inputType == DeviceInputType.Remote)
			{
				return DrawModeToggle.VisibleState.AlwaysShowing;
			}
			return DrawModeToggle.VisibleState.NeverShow;
		}

		public void ExitEditModeUI()
		{
			_cameraView.ResetPlayerViewport();
			SetWorldGridActive(active: false);
			SetDrawButtonsVisible(visible: false);
			SetRoadCursorActive(active: false);
			if (CurrentRoadDrawMode == RoadDrawMode.Remove)
			{
				ToggleDrawMode();
			}
			if (IsFocusPointActive)
			{
				SetFocusPointActive(active: false);
			}
		}
	}
}
