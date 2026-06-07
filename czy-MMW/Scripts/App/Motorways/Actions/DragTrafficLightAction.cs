using Client;
using Factory;
using Motorways.Audio;
using Motorways.UI;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragTrafficLightAction : MotorwaysPlayerAction
	{
		[Dependency]
		private IAudioSystem _audioSystem;

		[Dependency]
		protected ViewClient _viewClient;

		[Dependency]
		protected CameraView _cameraView;

		[Dependency]
		protected MotorwaysThemeDatabase _theme;

		[Dependency]
		protected VisualConstantsData _constants;

		protected Vector2Int _currentCoordinates;

		protected Vector2Int _selectedCoordinates;

		protected TileEditResult result;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			SetColourWidgetRadialVisible(visible: false);
			if (_upgradeDatabase.GetAvailableOrDraftUpgradeCount(UpgradeType.TrafficLight) < 1)
			{
				OnActionCancel();
				return;
			}
			if (_gameUI.CurrentRoadDrawMode == RoadDrawMode.Remove)
			{
				_gameUI.ToggleDrawMode();
			}
			result = TileEditResult.InvalidTileCoordinate(Vector2Int.zero);
			InitializeUpgradeCursor();
			_gameUI.UpgradeBar.RemoveFromUpgradeButtonStack(UpgradeType.TrafficLight, fromAnimation: true);
			_currentCoordinates = _gameUI.GetUpgradeCursorTileCoordinates();
			PlayerAction.Log.Info("Beginning DragTrafficLightAction from tile coordinates {0}.", _currentCoordinates);
			_gameUI.UpgradeBar.CreateAlertOnUpgradeButton(UpgradeType.TrafficLight);
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeDragged, UpgradeType.TrafficLight));
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
			if (upgradeCursorTileCoordinates != _currentCoordinates || !result.IsSuccessful)
			{
				result = SetDraftTrafficLightsAt(upgradeCursorTileCoordinates);
				if (result.IsSuccessful)
				{
					ClearDraftClientEdits();
					AddTileEdit(result.edit, EditExecuteTiming.Draft);
					_gameUI.SetUpgradeCursorVisible(visible: false);
					_gameUI.SetUpgradeCursorPosition(_tilemapView.GetScreenPositionFromTileCoordinates(upgradeCursorTileCoordinates), UpgradeCursor.UpgradeCursorOffsetType.OnPointer);
					_selectedCoordinates = upgradeCursorTileCoordinates;
					PlayerAction.Log.Info("Set draft traffic light at {0}.", _selectedCoordinates);
					AlertView.Create(_viewClient, TilemapView.GetWorldPositionForCoordinates(upgradeCursorTileCoordinates), _theme.GetGlobalColor(_constants.UpgradeAlertColor), 1f, 0.8f);
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOver, UpgradeType.TrafficLight));
					_feedbackGenerator.GenerateFeedback(HapticFeedbackType.LightImpact);
				}
				else
				{
					if (result.edit != null)
					{
						base.Scope.Release(result.edit);
					}
					if (Vector2Int.Distance(_selectedCoordinates, upgradeCursorTileCoordinates) >= 1f)
					{
						if (base.HasSchedulableClientEdits)
						{
							_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOut, UpgradeType.TrafficLight));
						}
						ClearDraftClientEdits();
						_gameUI.SetUpgradeCursorVisible(visible: true);
						_selectedCoordinates = default(Vector2Int);
					}
				}
			}
			_currentCoordinates = upgradeCursorTileCoordinates;
		}

		protected virtual void InitializeUpgradeCursor()
		{
			_gameUI.InitializeUpgradeCursor(UpgradeType.TrafficLight);
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

		protected TileEditResult SetDraftTrafficLightsAt(Vector2Int coordinates)
		{
			result = _tileEditor.AddTrafficLight(_tilemapView, coordinates);
			return result;
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
			_gameUI.UpgradeBar.AddToUpgradeButtonStack(UpgradeType.TrafficLight, fromAnimation: true);
			CancelDrafts();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.TrafficLight, success: false));
		}

		protected void CancelDrafts()
		{
			ClearDraftClientEdits();
		}

		public override void OnActionComplete()
		{
			PlayerAction.Log.Info("Completing Traffic Light Add action. Success? {0} {1}", result.IsSuccessful, result.resultCode);
			if (!result.IsSuccessful || !result.edit.CanApplyToSimulation)
			{
				CancelDrafts();
				if (_gameUI.HasUpgradeCursor)
				{
					_gameUI.CancelUpgradeCursor();
				}
				OnActionCancel();
				return;
			}
			if (_gameUI.HasUpgradeCursor)
			{
				_gameUI.PlaceUpgradeCursorAssetAtPosition(_selectedCoordinates);
			}
			if (!_cameraView.IsFocussedIn)
			{
				_gameUI.SetWorldGridActive(active: false);
				_tilemapView.viewMode = TilemapView.ViewMode.Normal;
			}
			ApplyDraftClientEdits();
			base.OnActionComplete();
			_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeReleased, UpgradeType.TrafficLight));
		}

		public override void Reset()
		{
			base.Reset();
			_currentCoordinates = Vector2Int.zero;
			_selectedCoordinates = Vector2Int.zero;
			result = default(TileEditResult);
		}

		public static DragTrafficLightAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragTrafficLightAction dragTrafficLightAction = scope.Get<DragTrafficLightAction>();
			dragTrafficLightAction.InitializeAction(owningGroup, timestamp);
			if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Mouse)
			{
				dragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(19, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(20, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
				dragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateMouseEventFilter(18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			}
			else if (owningGroup.InstigatingInputEvent.Source == InputEventSource.Touch)
			{
				dragTrafficLightAction.RegisterObserveInputEvent(InputEventFilter.CreateTouchEventFilter(0, InputEventButtonState.JustUp), ObserverGreediness.BlocksNewActions);
				dragTrafficLightAction.BlockNewTouchUpgradeActions();
			}
			dragTrafficLightAction.OnActionBegin(timestamp);
			return dragTrafficLightAction;
		}
	}
}
