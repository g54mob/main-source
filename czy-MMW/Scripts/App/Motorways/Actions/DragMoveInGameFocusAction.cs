using Factory;
using UnityEngine;

namespace Motorways.Actions
{
	public class DragMoveInGameFocusAction : MoveInGameFocusAction
	{
		private Vector2 _prevJoystickValue = Vector2.zero;

		private bool _hasInitialized;

		protected override PlayerPositionSource _playerPositionSource => PlayerPositionSource.FocusPoint;

		private float ControllerMoveSpeedCoefficient => 2f;

		private float ControllerDragSpeedRamp => 2.5f;

		public override void Tick(float frameTime)
		{
			Vector2 moveFocusJoystickInputValue = GetMoveFocusJoystickInputValue();
			if (!_hasInitialized)
			{
				_prevJoystickValue = GetMoveFocusJoystickInputValue();
				_hasInitialized = true;
			}
			if (moveFocusJoystickInputValue == Vector2.zero)
			{
				OnActionComplete();
				return;
			}
			_focusMovementDelta = moveFocusJoystickInputValue - _prevJoystickValue;
			float sqrMagnitude = _focusMovementDelta.sqrMagnitude;
			_focusMovementDelta += _focusMovementDelta.normalized * (sqrMagnitude * ControllerDragSpeedRamp);
			Vector2 focusMovementDelta = _focusMovementDelta * (ControllerMoveSpeedCoefficient * _tilemapView.ScreenDistanceBetweenTiles);
			_focusMovementDelta = focusMovementDelta;
			if (_focusMovementDelta != Vector2.zero)
			{
				_gameUI.SetFocusPointPosition(_gameUI.FocusPointPosition + _focusMovementDelta);
			}
			_prevJoystickValue = moveFocusJoystickInputValue;
		}

		public override void ObserveInput(float timestamp, InputEvent inputEvent, bool overUI)
		{
			if (inputEvent.ButtonState == InputEventButtonState.Axis && inputEvent is AxisInputEvent)
			{
				if (_hasInitialized && Mathf.Approximately(_prevJoystickValue.sqrMagnitude, 0f))
				{
					OnActionComplete();
				}
			}
			else
			{
				OnActionComplete();
			}
		}

		public override void Reset()
		{
			base.Reset();
			_prevJoystickValue = default(Vector2);
			_hasInitialized = false;
		}

		public new static DragMoveInGameFocusAction Create(PlayerActionGroup owningGroup, IScope scope, float timestamp)
		{
			DragMoveInGameFocusAction dragMoveInGameFocusAction = scope.Get<DragMoveInGameFocusAction>();
			dragMoveInGameFocusAction.InitializeAction(owningGroup, timestamp);
			dragMoveInGameFocusAction.OnActionBegin(timestamp);
			dragMoveInGameFocusAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 0, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			dragMoveInGameFocusAction.RegisterObserveInputEvent(InputEventFilter.CreateEventFilter(owningGroup.InstigatingInputEvent.Source, 1, InputEventButtonState.Axis), ObserverGreediness.BlocksNewActions);
			return dragMoveInGameFocusAction;
		}
	}
}
