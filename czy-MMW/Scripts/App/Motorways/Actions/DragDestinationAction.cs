using Factory;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragDestinationAction : MotorwaysPlayerAction
	{
		private enum PivotCorner
		{
			TopLeft = 0,
			TopRight = 1,
			BottomLeft = 2,
			BottomRight = 3
		}

		private new static readonly Diagnostics.Log.Channel Log = Diagnostics.Log.OpenChannel("DragDestinationAction");

		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		[Dependency]
		private BuildingPlacer _placer;

		[Dependency]
		private TilemapModel _tilemapModel;

		[Dependency]
		private IScope _scope;

		private Vector2Int _lastCheckedCoordinates;

		private Vector2Int _lastPlacedCoordinates;

		protected DraftDestination draftDestination;

		protected bool fromUpgradeMenu;

		private Vector2Int _dragStartTileCoordinates;

		private Vector2Int _originalDestinationCoordinates;

		private Vector2Int _previousDragCoordinates;

		private Vector2Int _previousDestinationCoordinates;

		protected bool isDouble;

		private BuildingLayout _buildingLayout;

		private DrivewayDirection _singleDestinationAboveDrivewayDirections;

		private DrivewayDirection _singleDestinationToSideDrivewayDirections = DrivewayDirection.North;

		private TileDirection _carparkSide = TileDirection.West;

		private PivotCorner _pivotCorner = PivotCorner.TopRight;

		private UpgradeType UpgradeType
		{
			get
			{
				if (!isDouble)
				{
					return UpgradeType.Destination;
				}
				return UpgradeType.DoubleDestination;
			}
		}

		public override void Reset()
		{
			base.Reset();
			_lastCheckedCoordinates = default(Vector2Int);
			_lastPlacedCoordinates = default(Vector2Int);
			_dragStartTileCoordinates = default(Vector2Int);
			_originalDestinationCoordinates = default(Vector2Int);
			draftDestination = null;
			_singleDestinationAboveDrivewayDirections = DrivewayDirection.West;
			_singleDestinationToSideDrivewayDirections = DrivewayDirection.North;
			_carparkSide = TileDirection.West;
			_buildingLayout = BuildingLayout.BuildingAbove;
			isDouble = false;
			fromUpgradeMenu = false;
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			if (fromUpgradeMenu)
			{
				_gameUI.ConfirmEditMenuEdit();
			}
			_gameUI.SetWorldGridActive(active: true);
			_pivotCorner = PivotCorner.BottomLeft;
			if (fromUpgradeMenu && _upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType) < 1)
			{
				OnActionCancel();
				return;
			}
			_buildingLayout = BuildingLayout.BuildingToSide;
			if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
			{
				_gameUI.ToggleDrawMode();
			}
			if (fromUpgradeMenu)
			{
				InitializeUpgradeCursor();
				_gameUI.UpgradeBar.RemoveFromUpgradeButtonStack(UpgradeType, fromAnimation: true);
				_lastCheckedCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
				_gameUI.UpgradeBar.CreateAlertOnUpgradeButton(UpgradeType);
				_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragged, UpgradeType));
			}
			else
			{
				_lastCheckedCoordinates = GetNextTileCoordinates();
				EditMenuPanel editMenuPanel = _scope.Get<EditMenuPanel>();
				bool isOriginalDeleted = default(bool);
				if (editMenuPanel.EditableObject?.GetGhostPreview(out isOriginalDeleted) is DraftDestination draftDestination)
				{
					if (isOriginalDeleted)
					{
						editMenuPanel.CancelEdit();
					}
					this.draftDestination = draftDestination;
					_singleDestinationAboveDrivewayDirections = this.draftDestination.viewModel.singleDestinationAboveDrivewayDirections;
					_singleDestinationToSideDrivewayDirections = this.draftDestination.viewModel.singleDestinationToSideDrivewayDirections;
				}
			}
			if (this.draftDestination == null)
			{
				this.draftDestination = base.Scope.Get<DraftDestination>();
				this.draftDestination.Initialize(base.Scope, isDouble);
				PlayerAction.Log.Info("Spawned draft carpark at {0}", GetPointerTilePosition());
			}
			Log.Info("Beginning DragDestinationAction from tile coordinates {0}.", _lastCheckedCoordinates);
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			if (fromUpgradeMenu)
			{
				UpdateUpgradeCursorPosition();
			}
			Vector2Int nextTileCoordinates = GetNextTileCoordinates();
			bool flag = draftDestination != null;
			if (nextTileCoordinates != _lastCheckedCoordinates && (!flag || nextTileCoordinates != _lastPlacedCoordinates))
			{
				Vector2Int bottomLeftCoordinate = _originalDestinationCoordinates + nextTileCoordinates - _dragStartTileCoordinates + GetDragOffsetTileCoordinates();
				if (flag)
				{
					draftDestination.UpdatePosition(bottomLeftCoordinate, isReplacement: false);
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragSnap, UpgradeType.Destination, success: true, null, _tilemapView.GetScreenPositionFromTileCoordinates(nextTileCoordinates)));
				}
				_lastPlacedCoordinates = draftDestination.BottomLeftCoordinate;
			}
			_lastCheckedCoordinates = nextTileCoordinates;
		}

		private Vector2Int GetDragOffsetTileCoordinates()
		{
			if (isDouble)
			{
				switch (_buildingLayout)
				{
				case BuildingLayout.BuildingToSide:
					return new Vector2Int(0, -2);
				case BuildingLayout.BuildingAbove:
					return new Vector2Int(0, 0);
				}
			}
			else
			{
				switch (_buildingLayout)
				{
				case BuildingLayout.BuildingToSide:
					return new Vector2Int(-1, 1);
				case BuildingLayout.BuildingAbove:
					return new Vector2Int(0, 0);
				}
			}
			return new Vector2Int(0, 0);
		}

		private Vector2Int GetNextTileCoordinates()
		{
			return _pivotCorner switch
			{
				PivotCorner.BottomLeft => GetPointerTilePosition(), 
				PivotCorner.BottomRight => GetPointerTilePosition() + 2 * Vector2Int.left, 
				PivotCorner.TopLeft => GetPointerTilePosition() + ((!isDouble) ? 1 : 3) * Vector2Int.down, 
				PivotCorner.TopRight => GetPointerTilePosition() + 2 * Vector2Int.left + ((!isDouble) ? 1 : 3) * Vector2Int.down, 
				_ => GetPointerTilePosition(), 
			};
		}

		protected virtual void InitializeUpgradeCursor()
		{
			_gameUI.InitializeUpgradeCursor(UpgradeType);
			_gameUI.SetUpgradeCursorVisible(visible: false);
		}

		protected virtual void UpdateUpgradeCursorPosition()
		{
			if (base.OwningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.TopLeft);
			}
			else
			{
				_gameUI.SetUpgradeCursorPosition(GetPointerScreenPosition(), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if ((inputEvent.Source == InputEventSource.Mouse && inputEvent.InputAction == 19 && inputEvent.ButtonState == InputEventButtonState.JustUp) || (inputEvent.Source == InputEventSource.Touch && inputEvent.ButtonState == InputEventButtonState.JustUp) || (inputEvent.Source == InputEventSource.Remote && inputEvent.InputAction == 2 && inputEvent.ButtonState == InputEventButtonState.JustDown))
			{
				if (draftDestination == null || draftDestination.CompletelyOutOfPlayArea(_city))
				{
					OnActionCancel();
				}
				else
				{
					OnActionComplete();
				}
			}
			else if (inputEvent.InputAction == 18 || inputEvent.InputAction == 20)
			{
				OnActionCancel();
			}
			else
			{
				Log.Error($"Unexpected input: {inputEvent}!");
				OnActionCancel();
			}
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			if (_gameUI.HasUpgradeCursor && fromUpgradeMenu)
			{
				_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType, fromAnimation: true);
				_gameUI.CancelUpgradeCursor();
			}
			ClearOutAllDrafts();
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType, success: false));
		}

		private void ClearOutAllDrafts()
		{
			if (draftDestination != null)
			{
				if (fromUpgradeMenu)
				{
					base.Scope.Release(draftDestination);
				}
				else if (_gameUI.editMenuPanel.EditableObject != null)
				{
					_gameUI.editMenuPanel.CancelEdit();
				}
				else
				{
					draftDestination.Cancel();
				}
				draftDestination = null;
			}
		}

		public override void OnActionComplete()
		{
			Log.Info("Completing Drag Destination action.");
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradePlaced, _gameCamera.GetPanFromWorld(TilemapView.GetWorldPositionForCoordinates(_lastPlacedCoordinates)).x));
			if (_gameUI.HasUpgradeCursor && fromUpgradeMenu)
			{
				_gameUI.PlaceUpgradeCursorAssetAtPosition(_lastPlacedCoordinates);
				_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType, fromAnimation: true);
			}
			if (!_cameraView.playerZoomedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			base.Scope.Get<GameUIScreen>().OpenEditMenu(draftDestination, fromUpgradeMenu);
			base.OnActionComplete();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType));
		}

		public static DragDestinationAction CreateSingleFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: false, fromUpgradeMenu: false);
		}

		public static DragDestinationAction CreateDoubleFromEditMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: true, fromUpgradeMenu: false);
		}

		public static DragDestinationAction CreateSingleFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: false, fromUpgradeMenu: true);
		}

		public static DragDestinationAction CreateDoubleFromUpgradeMenu(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			return Create(owningGroup, scope, timestamp, isDouble: true, fromUpgradeMenu: true);
		}

		private static DragDestinationAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp, bool isDouble, bool fromUpgradeMenu)
		{
			DragDestinationAction dragDestinationAction = scope.Get<DragDestinationAction>();
			dragDestinationAction.isDouble = isDouble;
			dragDestinationAction.fromUpgradeMenu = fromUpgradeMenu;
			dragDestinationAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				dragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragDestinationAction.BlockNewTouchUpgradeActions();
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Remote)
			{
				dragDestinationAction.RegisterObserveInputEvent(InputEventFilter.CreateRemoteEventFilter(2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			dragDestinationAction.OnActionBegin(timestamp);
			dragDestinationAction.MakeExclusive();
			dragDestinationAction.SetWorldGridVisible(visible: true);
			return dragDestinationAction;
		}
	}
}
