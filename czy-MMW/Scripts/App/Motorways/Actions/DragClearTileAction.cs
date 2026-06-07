using Factory;
using FixMath;
using Motorways.Audio;
using Motorways.Models;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragClearTileAction : MotorwaysPlayerAction
	{
		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private NotificationView _notificationView;

		private Fix64 _minMouseDistance = TilemapModel.TileWidth * (Fix64)1.15f;

		private Vector2Int _currentCoordinates;

		private Vector2Int _lastCoordinates;

		private bool _hasDeletedOriginalCoordinate;

		private TileDirection _lastSuccessfulEditDirection;

		private bool _isShowingError;

		private bool _didShowCursor;

		private bool shouldSwitchBackToAddMode = true;

		private const float TwoFingerGracePeriod = 0.5f;

		private float _twoFingerPanGracePeriodTimeRemaining;

		public override bool PreventsCursorAcceleration => true;

		private bool TwoFingerGracePeriodActive => _twoFingerPanGracePeriodTimeRemaining > 0f;

		public override void OnActionBegin(float timestamp)
		{
			_didShowCursor = false;
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			_twoFingerPanGracePeriodTimeRemaining = 0.5f;
			_lastCoordinates = GetPointerTilePosition();
			StartAction();
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			if (base.ActionState != State.Begun)
			{
				return;
			}
			if (TwoFingerGracePeriodActive)
			{
				if (_inputState.TouchCount > 1)
				{
					OnActionCancel();
					return;
				}
				_twoFingerPanGracePeriodTimeRemaining -= frameTime;
				Diagnostics.Log.Info("DragClearTileAction", "Grace Period Active: {0}s left", _twoFingerPanGracePeriodTimeRemaining);
			}
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			Tile tile = _tilemapView.GetTile(pointerTilePosition);
			if (tile != null && (tile.GetTwoLaneRoadCount() > 0 || tile.IsCenterOfRoundabout) && tile.ContentType != TileContentType.Carpark && tile.ContentType != TileContentType.House)
			{
				MakeExclusive();
			}
			bool flag = false;
			UpdateCursorPosition();
			if (pointerTilePosition != _currentCoordinates)
			{
				Diagnostics.Log.Info("DragClearTileAction", "Coordinates Changed from {0} to {1}", _currentCoordinates, pointerTilePosition);
				ClearTile(pointerTilePosition);
				_currentCoordinates = pointerTilePosition;
				_twoFingerPanGracePeriodTimeRemaining = 0f;
				flag = true;
			}
			if (!TwoFingerGracePeriodActive && !_hasDeletedOriginalCoordinate)
			{
				Diagnostics.Log.Info("DragClearTileAction", flag ? "Clearing original tile as coordinates changed" : "Clearing original tile as grace period ended");
				ClearTile(_lastCoordinates);
				_hasDeletedOriginalCoordinate = true;
			}
		}

		private void ClearTile(Vector2Int tileToClear)
		{
			bool roadsBecomePermanentOverTime = _city.Rules.RoadsBecomePermanentOverTime;
			TileEditResult tileEditResult = _tileEditor.ClearTile(_tilemapView, tileToClear, roadsBecomePermanentOverTime ? Tile.TileChangePermissions.RespectPermanence : Tile.TileChangePermissions.Full);
			if (tileEditResult.IsSuccessful && tileEditResult.edit != null)
			{
				Tile tile = _tilemapView.GetTile(tileToClear);
				if (tile.HasTrafficLight || tile.GetTwoLaneRoads(RoadState.VisiblyActive, Tile.MotorwayInclusion.Include).Count > 0 || tile.HasRoundabout(RoadState.Planned | RoadState.Active))
				{
					_feedbackGenerator.GenerateFeedback(HapticFeedbackType.LightImpact);
				}
				AddTileEdit(tileEditResult.edit, EditExecuteTiming.Immediate);
				_lastSuccessfulEditDirection = TileUtilities.GetClosestDirection(tileToClear - _currentCoordinates);
				_currentCoordinates = tileToClear;
				MakeExclusive();
				_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.MothballRoad));
				_notificationView.HideAlertIcon();
				_notificationView.CancelNotification();
				_isShowingError = false;
			}
			else if ((tileEditResult.resultCode == TileEditResultCode.NoDeletableRoads || tileEditResult.resultCode == TileEditResultCode.NoDeletableUpgrade) && !_isShowingError)
			{
				_notificationView.AddNotification(tileEditResult.resultCode, tileEditResult.errorPosition);
				_isShowingError = true;
			}
		}

		private void StartAction()
		{
			shouldSwitchBackToAddMode = _gameUI.CurrentRoadDrawMode != RoadDrawMode.Remove;
			if (base.OwningGroup.InstigatingInputEvent.Source == InputEventSource.Touch && !_cameraView.IsFocussedIn)
			{
				OnActionCancel();
				return;
			}
			if (base.Scope.Get<EditMenuPanel>().IsOpen)
			{
				_gameUI.ConfirmEditMenuEdit();
				OnActionCancel();
				return;
			}
			_currentCoordinates = GetPointerTilePosition();
			_hasDeletedOriginalCoordinate = false;
			_lastSuccessfulEditDirection = TileDirection.None;
			_gameUI.CurrentRoadDrawMode = RoadDrawMode.Remove;
			SetCursorVisible(visible: true);
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.Source == InputEventSource.Generic && _player.IsTapDrawEnabled && inputEvent.ButtonState == InputEventButtonState.JustUp)
			{
				OnActionBegin(timestamp);
				return;
			}
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			ClearTile(pointerTilePosition);
			OnActionComplete();
		}

		public override void OnActionComplete()
		{
			base.OnActionComplete();
			_notificationView.HideAlertIcon();
			_notificationView.CancelNotification();
			SetCursorVisible(visible: false);
			if (shouldSwitchBackToAddMode)
			{
				_gameUI.CurrentRoadDrawMode = RoadDrawMode.Add;
			}
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			_notificationView.HideNotification();
			_notificationView.HideAlertIcon();
			SetCursorVisible(visible: false);
			if (shouldSwitchBackToAddMode)
			{
				_gameUI.CurrentRoadDrawMode = RoadDrawMode.Add;
			}
		}

		public override void Reset()
		{
			_currentCoordinates = default(Vector2Int);
			_hasDeletedOriginalCoordinate = false;
			_didShowCursor = false;
			shouldSwitchBackToAddMode = true;
			_lastSuccessfulEditDirection = TileDirection.North;
			_isShowingError = false;
			_twoFingerPanGracePeriodTimeRemaining = 0.5f;
			_lastCoordinates = default(Vector2Int);
			base.Reset();
		}

		protected override void SetCursorVisible(bool visible)
		{
			if (visible)
			{
				_didShowCursor = true;
			}
			else if (!_didShowCursor)
			{
				return;
			}
			_gameUI.SetRoadCursorActive(visible);
			if (!_cameraView.IsFocussedIn)
			{
				SetWorldGridVisible(visible);
				_tilemapView.viewMode = (visible ? TilemapView.ViewMode.Edit : TilemapView.ViewMode.Normal);
			}
		}

		public static DragClearTileAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragClearTileAction dragClearTileAction = scope.Get<DragClearTileAction>();
			dragClearTileAction.InitializeAction(owningGroup, timestamp);
			dragClearTileAction._playerPositionSource = (MotorwaysPlayerAction.DoesInputTypeUseFocusPoint(owningGroup.InstigatingInputEvent.Source) ? PlayerPositionSource.FocusPoint : PlayerPositionSource.InputEvent);
			int num;
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Generic)
			{
				num = (scope.Get<ActivePlayer>().IsTapDrawEnabled ? 1 : 0);
				if (num != 0)
				{
					dragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Generic, owningGroup.InstigatingInputEvent.InputAction, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				}
			}
			else
			{
				num = 0;
			}
			dragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, owningGroup.InstigatingInputEvent.InputAction, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			dragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 17, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			dragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragClearTileAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
			}
			if (num == 0)
			{
				dragClearTileAction.OnActionBegin(timestamp);
			}
			return dragClearTileAction;
		}
	}
}
