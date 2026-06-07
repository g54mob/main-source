using Client;
using Factory;
using Motorways.Audio;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragMotorwayAction : AddMotorwayAction
	{
		[Dependency]
		protected ViewClient _viewClient;

		[Dependency]
		protected CameraView _cameraView;

		[Dependency]
		protected GameCamera _gameCamera;

		[Dependency]
		protected MotorwaysThemeDatabase _theme;

		[Dependency]
		protected VisualConstantsData _constants;

		private Vector2Int _currentCoordinates;

		private bool _hasScheduledOverEvent;

		protected TileEditResult _editResult;

		public override void Reset()
		{
			_currentCoordinates = default(Vector2Int);
			_hasScheduledOverEvent = false;
			_editResult = default(TileEditResult);
			base.Reset();
		}

		public override void OnActionBegin(float timestamp)
		{
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.Motorway) < 1)
			{
				OnActionCancel();
				return;
			}
			if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
			{
				_gameUI.ToggleDrawMode();
			}
			base.OnActionBegin(timestamp);
			_hasScheduledOverEvent = false;
			_editResult = TileEditResult.InvalidTileCoordinate(_currentCoordinates);
			InitializeUpgradeCursor();
			_gameUI.UpgradeBar.RemoveFromUpgradeButtonStack(UpgradeType.Motorway, fromAnimation: true);
			_newMotorwayId = -1;
			_currentCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			PlayerAction.Log.Info("Beginning DragMotorwayAction from tile coordinates {0}.", _currentCoordinates);
			_gameUI.UpgradeBar.CreateAlertOnUpgradeButton(UpgradeType.Motorway);
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: true);
				_tilemapView.viewMode = TilemapView.ViewMode.Edit;
			}
			_gameUI.SetMotorwayGridActive(active: true);
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragged, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
		}

		public override void Tick(float frameTime)
		{
			base.Tick(frameTime);
			UpdateUpgradeCursorPosition();
			Vector2Int upgradeCursorTileCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			if (upgradeCursorTileCoordinates != _currentCoordinates)
			{
				if (DoesTileSupportMotorway(upgradeCursorTileCoordinates) && !HasMotorwayOnTile(upgradeCursorTileCoordinates))
				{
					_editResult = SetDraftMotorwayAt(upgradeCursorTileCoordinates);
					if (_editResult.IsSuccessful)
					{
						ClearDraftClientEdits();
						AddTileEdit(_editResult.edit, EditExecuteTiming.Draft);
						_gameUI.SetUpgradeCursorVisible(visible: false);
						_gameUI.SetUpgradeCursorPosition(_tilemapView.GetScreenPositionFromTileCoordinates(upgradeCursorTileCoordinates), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
						PlayerAction.Log.Info("Set draft motorway at {0}.", upgradeCursorTileCoordinates);
						_hasScheduledOverEvent = true;
						_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOver, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
						_feedbackGenerator.GenerateFeedback(HapticFeedbackType.LightImpact);
					}
					else
					{
						if (_hasScheduledOverEvent)
						{
							_hasScheduledOverEvent = false;
							_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOut, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
						}
						if (_editResult.edit != null)
						{
							base.Scope.Release(_editResult.edit);
						}
					}
				}
				else
				{
					ClearDraftClientEdits();
					if (_editResult.edit != null)
					{
						base.Scope.Release(_editResult.edit);
					}
					_gameUI.SetUpgradeCursorVisible(visible: true);
					_editResult = TileEditResult.InvalidTileCoordinate(_currentCoordinates);
				}
			}
			_currentCoordinates = upgradeCursorTileCoordinates;
		}

		protected virtual void InitializeUpgradeCursor()
		{
			_gameUI.InitializeUpgradeCursor(UpgradeType.Motorway);
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

		private TileEditResult SetDraftMotorwayAt(Vector2Int coordinates)
		{
			if (_newMotorwayId == -1)
			{
				_newMotorwayId = _city.GetNextMotorwayIdAndIncrement();
			}
			if (_newMotorwayNumber == 0)
			{
				_newMotorwayNumber = _tilemapView.GetLowestAvailableMotorwayNumber();
			}
			_editResult = _tileEditor.AddUnbuiltMotorway(_tilemapView, _newMotorwayId, _newMotorwayNumber, coordinates);
			SetAnchorTile(coordinates, TileDirection.None);
			return _editResult;
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.InputAction == 18 || inputEvent.InputAction == 20)
			{
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
				_gameUI.SetUpgradeCursorVisible(visible: false);
				_gameUI.CancelUpgradeCursor();
			}
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			_gameUI.SetMotorwayGridActive(active: false);
			_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.Motorway, fromAnimation: true);
			CancelDrafts();
		}

		protected void CancelDrafts()
		{
			ClearDraftClientEdits();
		}

		public override void OnActionComplete()
		{
			_gameUI.SetMotorwayGridActive(active: false);
			PlayerAction.Log.Info("Completing MotorwayAdd action. Success? {0} {1}", _editResult.IsSuccessful, _editResult.resultCode);
			if (!_editResult.IsSuccessful || !_editResult.edit.CanApplyToSimulation)
			{
				CancelDrafts();
				if (_gameUI.HasUpgradeCursor)
				{
					_gameUI.SetUpgradeCursorVisible(visible: false);
					_gameUI.CancelUpgradeCursor();
				}
				OnActionCancel();
				return;
			}
			_audioSystem.ScheduleEvent(AudioEvent.CreateEvent(-1.0, AudioEventType.UpgradePlaced, _gameCamera.GetPanFromWorld(TilemapView.GetWorldPositionForCoordinates(_currentCoordinates)).x));
			if (_gameUI.HasUpgradeCursor)
			{
				_gameUI.PlaceUpgradeCursorAssetAtPosition(_currentCoordinates);
			}
			AlertView.Create(_viewClient, TilemapView.GetWorldPositionForCoordinates(_currentCoordinates), _theme.GetGlobalColor(_constants.UpgradeAlertColor), 1f, 0.8f);
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			ApplyDraftClientEdits();
			base.OnActionComplete();
		}

		protected override TileEditResult CreateTileEdit(int newMotorwayId, int motorwayNumber, Vector2Int anchorCoordinates, TileDirection anchorDirection, Vector2Int danglingCoordinates, TileDirection danglingDirection)
		{
			return new TileEditResult
			{
				resultCode = TileEditResultCode.Success
			};
		}

		public static DragMotorwayAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragMotorwayAction dragMotorwayAction = scope.Get<DragMotorwayAction>();
			dragMotorwayAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				dragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragMotorwayAction.BlockNewTouchUpgradeActions();
			}
			dragMotorwayAction.OnActionBegin(timestamp);
			return dragMotorwayAction;
		}
	}
}
