using Factory;
using Motorways.Audio;
using Motorways.Views;
using UnityEngine;

namespace Motorways.Actions
{
	public class ControllerDragMotorwayAction : DragMotorwayAction
	{
		private bool _confirmedStartTile;

		private bool _hasScheduledOverEvent;

		[Dependency]
		protected MotorwaysInGameStateToggleController _controllerState;

		[Dependency]
		private NotificationView _notificationView;

		[Dependency]
		private IScope _scope;

		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		public override void OnActionBegin(float timestamp)
		{
			base.OnActionBegin(timestamp);
			_confirmedStartTile = false;
			_hasScheduledOverEvent = false;
		}

		public override void Tick(float frameTime)
		{
			if (!_confirmedStartTile)
			{
				base.Tick(frameTime);
				return;
			}
			Vector2Int pointerTilePosition = GetPointerTilePosition();
			if (pointerTilePosition != _danglingCoordinates)
			{
				MotorwayActionResult motorwayActionResult = SetDanglingTile(pointerTilePosition);
				if (motorwayActionResult == MotorwayActionResult.Success)
				{
					UpdateTileEdit();
				}
				else
				{
					DisplayError(motorwayActionResult, errorPertainsToAnchor: false);
				}
			}
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (base.ActionState != State.Begun || _controllerState.ControllerState != MotorwaysInGameStateToggleController.InGameControllerState.EditingTiles)
			{
				return;
			}
			if (inputEvent.InputAction == 2)
			{
				if (!_confirmedStartTile)
				{
					if (_editResult.IsSuccessful)
					{
						ApplyDraftClientEdits();
						_confirmedStartTile = true;
					}
				}
				else
				{
					OnActionComplete();
				}
			}
			else if (!_confirmedStartTile)
			{
				OnActionCancel();
			}
		}

		protected override TileEditResult CreateTileEdit(int newMotorwayId, int motorwayNumber, Vector2Int anchorCoordinates, TileDirection anchorDirection, Vector2Int danglingCoordinates, TileDirection danglingDirection)
		{
			if (_confirmedStartTile)
			{
				TileEditResult tileEditResult = _tileEditor.AddMotorway(_tilemapView, newMotorwayId, motorwayNumber, anchorCoordinates, anchorDirection, danglingCoordinates, danglingDirection, -1);
				if (tileEditResult.IsSuccessful)
				{
					_editResult = tileEditResult;
					if (_editResult.edit != null)
					{
						_notificationView.HideNotification();
						_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOver, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
						_hasScheduledOverEvent = true;
						return _editResult;
					}
				}
				else
				{
					if (tileEditResult.edit != null)
					{
						_scope.Release(tileEditResult.edit);
					}
					_notificationView.AddNotification(tileEditResult.resultCode, tileEditResult.errorPosition);
				}
				if (_hasScheduledOverEvent)
				{
					_audioSystem.ScheduleEvent(AudioEvent.CreateUpgradeEvent(AudioEventType.UpgradeOut, UpgradeType.Motorway, success: true, base.MotorwayBeingEdited));
					_hasScheduledOverEvent = false;
				}
				return tileEditResult;
			}
			return new TileEditResult
			{
				resultCode = TileEditResultCode.NotInitialized
			};
		}

		public override void Reset()
		{
			base.Reset();
			_confirmedStartTile = false;
			_hasScheduledOverEvent = false;
		}

		public new static ControllerDragMotorwayAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			ControllerDragMotorwayAction controllerDragMotorwayAction = scope.Get<ControllerDragMotorwayAction>();
			controllerDragMotorwayAction.InitializeAction(owningGroup, timestamp);
			controllerDragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 2, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 7, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(InputEventSource.Any, 18, InputEventButtonState.JustDown), ObserverGreediness.BlocksNewActions);
			controllerDragMotorwayAction.OnActionBegin(timestamp);
			return controllerDragMotorwayAction;
		}
	}
}
