using Factory;
using Motorways.Audio;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragRoundaboutAction : MotorwaysPlayerAction
	{
		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		private CameraView _cameraView;

		[Dependency]
		private GameCamera _gameCamera;

		private Vector2Int _lastCheckedCoordinates;

		private Vector2Int _lastPlacedCoordinates;

		private TileEditResult _result;

		private bool _isRebuildingMothballedRoundabout;

		public override void Reset()
		{
			base.Reset();
			_lastCheckedCoordinates = default(Vector2Int);
			_lastPlacedCoordinates = default(Vector2Int);
			_result = default(TileEditResult);
			_isRebuildingMothballedRoundabout = false;
		}

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.Roundabout) < 1)
			{
				OnActionCancel();
				return;
			}
			if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
			{
				_gameUI.ToggleDrawMode();
			}
			_result = TileEditResult.InvalidTileCoordinate(Vector2Int.zero);
			InitializeUpgradeCursor();
			_gameUI.UpgradeBar.RemoveFromUpgradeButtonStack(UpgradeType.Roundabout, fromAnimation: true);
			_lastCheckedCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			PlayerAction.Log.Info("Beginning DragRoundaboutAction from tile coordinates {0}.", _lastCheckedCoordinates);
			_gameUI.UpgradeBar.CreateAlertOnUpgradeButton(UpgradeType.Roundabout);
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragged, UpgradeType.Roundabout));
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: true);
				_tilemapView.viewMode = TilemapView.ViewMode.Edit;
			}
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			UpdateUpgradeCursorPosition();
			Vector2Int upgradeCursorTileCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			bool hasSchedulableClientEdits = base.HasSchedulableClientEdits;
			if ((upgradeCursorTileCoordinates != _lastCheckedCoordinates && (!hasSchedulableClientEdits || upgradeCursorTileCoordinates != _lastPlacedCoordinates)) || _isRebuildingMothballedRoundabout)
			{
				if (hasSchedulableClientEdits)
				{
					ClearDraftClientEdits();
					_isRebuildingMothballedRoundabout = false;
				}
				Vector2Int coordinates = upgradeCursorTileCoordinates + new Vector2Int(-1, -1);
				Vector2Int coordinates2 = upgradeCursorTileCoordinates + new Vector2Int(1, 1);
				if (_city.IsTileInPlayableArea(coordinates, _clockModel.ExpansionTime) && _city.IsTileInPlayableArea(coordinates2, _clockModel.ExpansionTime))
				{
					_result = SetDraftRoundaboutAt(upgradeCursorTileCoordinates);
					if (_result.IsSuccessful)
					{
						_isRebuildingMothballedRoundabout = IsTileMothballedRoundaboutCenter(upgradeCursorTileCoordinates);
						AddTileEdit(_result.edit, EditExecuteTiming.Draft);
						_gameUI.SetUpgradeCursorVisible(visible: false);
						_gameUI.SetUpgradeCursorPosition(_tilemapView.GetScreenPositionFromTileCoordinates(upgradeCursorTileCoordinates), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
						_lastPlacedCoordinates = upgradeCursorTileCoordinates;
						PlayerAction.Log.Info("Set draft roundabout at {0}.", _lastPlacedCoordinates);
						_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOver, UpgradeType.Roundabout));
						_feedbackGenerator.GenerateFeedback(HapticFeedbackType.LightImpact);
					}
					else
					{
						if (_result.edit != null)
						{
							base.Scope.Release(_result.edit);
							_result.edit = null;
						}
						if (hasSchedulableClientEdits)
						{
							_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOut, UpgradeType.Roundabout));
						}
						_gameUI.SetUpgradeCursorVisible(visible: true);
					}
				}
				else
				{
					if (_result.edit != null)
					{
						base.Scope.Release(_result.edit);
						_result.edit = null;
					}
					_gameUI.SetUpgradeCursorVisible(visible: true);
					_result = TileEditResult.InvalidTileCoordinate(upgradeCursorTileCoordinates);
				}
			}
			_lastCheckedCoordinates = upgradeCursorTileCoordinates;
		}

		protected virtual void InitializeUpgradeCursor()
		{
			_gameUI.InitializeUpgradeCursor(UpgradeType.Roundabout);
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

		private TileEditResult SetDraftRoundaboutAt(Vector2Int coordinates)
		{
			_result = _tileEditor.AddRoundabout(_tilemapView, coordinates);
			return _result;
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.Source == InputEventSource.Mouse)
			{
				if (inputEvent.InputAction == 19 && inputEvent.ButtonState == InputEventButtonState.JustUp)
				{
					OnActionComplete();
					return;
				}
				if (inputEvent.InputAction == 18 || inputEvent.InputAction == 20)
				{
					OnActionCancel();
					return;
				}
				PlayerAction.Log.Error($"Unexpected mouse button index {inputEvent.InputAction} with state {inputEvent.ButtonState} from input {inputEvent}!");
				OnActionCancel();
			}
			else
			{
				OnActionComplete();
			}
		}

		public override void OnActionCancel()
		{
			base.OnActionCancel();
			if (_gameUI.HasUpgradeCursor)
			{
				_gameUI.CancelUpgradeCursor();
			}
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.Roundabout, fromAnimation: true);
			CancelDrafts();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.Roundabout, success: false));
		}

		private void CancelDrafts()
		{
			ClearDraftClientEdits();
		}

		public override void OnActionComplete()
		{
			PlayerAction.Log.Info("Completing Roundabout Add action. Success? {0} {1}", _result.IsSuccessful, _result.resultCode);
			if (!_result.IsSuccessful || !_result.edit.CanApplyToSimulation)
			{
				CancelDrafts();
				if (_gameUI.HasUpgradeCursor)
				{
					_gameUI.CancelUpgradeCursor();
				}
				OnActionCancel();
				return;
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradePlaced, _gameCamera.GetPanFromWorld(TilemapView.GetWorldPositionForCoordinates(_lastPlacedCoordinates)).x));
			if (_gameUI.HasUpgradeCursor)
			{
				_gameUI.PlaceUpgradeCursorAssetAtPosition(_lastPlacedCoordinates);
				_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.Roundabout, fromAnimation: true);
			}
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			ApplyDraftClientEdits();
			base.OnActionComplete();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.Roundabout));
		}

		public static DragRoundaboutAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragRoundaboutAction dragRoundaboutAction = scope.Get<DragRoundaboutAction>();
			dragRoundaboutAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				dragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragRoundaboutAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragRoundaboutAction.BlockNewTouchUpgradeActions();
			}
			dragRoundaboutAction.OnActionBegin(timestamp);
			return dragRoundaboutAction;
		}

		private bool IsTileMothballedRoundaboutCenter(Vector2Int tileCoordinates)
		{
			Vector2Int vector2Int = Roundabout.GetCoordinatesOffsets()[0];
			Vector2Int coordinates = tileCoordinates + vector2Int;
			Tile tile = _tilemapView.GetTile(coordinates);
			if (tile == null)
			{
				return false;
			}
			return tile.GetRoundaboutState(Roundabout.GetConnectionForCoordinatesOffset(vector2Int)) == RoadState.Mothballed;
		}
	}
}
